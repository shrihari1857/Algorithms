using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kEmptySlots
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = kSlots(new int[] { 1, 3, 2 }, 1);
        }

        private static int kSlots(int[] flowers, int k)
        {
            //create the positions array
            var positions = new int[flowers.Length];

            for (int i = 0; i < flowers.Length; i++)
                positions[flowers[i] - 1] = i + 1;

            int left = 0, right = k + 1, result = int.MaxValue;

            for (int i = 0; right < positions.Length; i++)
            {
                if (positions[i] > positions[right] && positions[i] > positions[left])
                    continue;

                if (i == right)
                    result = Math.Min(result, Math.Max(positions[left], positions[right]));

                left = i;
                right = i + k + 1;
            }

            return result == int.MaxValue ? -1 : result;
        }
    }
}
