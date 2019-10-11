using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RepeatedStringMatch
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = RepeatedStringMatch("abcd", "cdabcdabcd");
        }

        public static bool check(int index, string A, string B)
        {
            for (int i = 0; i < B.Length; i++)
            {
                if (A[(i + index) % A.Length] != B[i])
                {
                    return false;
                }
            }
            return true;
        }
        private static int RepeatedStringMatch(string A, string B)
        {
            int q = (B.Length - 1) / A.Length + 1;
            int p = 113, MOD = 1000000007;
            var pInv = System.Numerics.BigInteger.ModPow(p, 0, MOD);
            //int pInv = long.valueOf(p).modInverse(System.Numerics.BigInteger.valueOf(MOD)).intValue();

            BigInteger bHash = 0, power = 1;
            for (int i = 0; i < B.Length; i++)
            {
                bHash += power * char.ConvertToUtf32(B, i);
                bHash %= MOD;
                power = (power * p) % MOD;
            }

            BigInteger aHash = 0;
            power = 1;
            for (int i = 0; i < B.Length; i++)
            {
                aHash += power * char.ConvertToUtf32(A, i % A.Length);
                aHash %= MOD;
                power = (power * p) % MOD;
            }

            if (aHash == bHash && check(0, A, B))
            {
                return q;
            }
            power = (power * pInv) % MOD;

            for (int i = B.Length; i < (q + 1) * A.Length; i++)
            {
                aHash -= char.ConvertToUtf32(A, (i - B.Length) % A.Length);
                aHash *= pInv;
                aHash += power * char.ConvertToUtf32(A, i % A.Length);
                aHash %= MOD;
                if (aHash == bHash && check(i - B.Length + 1, A, B))
                {
                    return i < q * A.Length ? q : q + 1;
                }
            }
            return -1;

        }
    }
}
