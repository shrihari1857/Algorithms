using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectSquares
{
    class Program
    {
        // dp[i][j] is going to store true if sum j is 
        // possible with array elements from 0 to i. 
        static int[,] dp;
        static void Main(string[] args)
        {
            var f = NumSquares(43);
            int sum = 12;

            //generate the array first
            int maxArrValue = Convert.ToInt32(Math.Floor(Math.Sqrt(sum)));

            //int[] arr = new int[] { 1, 2, 5, 7 };
            int[] arr = Enumerable.Range(0, maxArrValue + 1).ToArray();
            int n = arr.Length;
            
            printAllSubsets(arr, n, sum);
        }

        public static int NumSquares(int n)
        {

            int[] arr = Enumerable.Range(0, Convert.ToInt32(Math.Floor(Math.Sqrt(n))) + 1).ToArray();
            int k = arr.Length;
            int[,] dp = new int[k, n + 1];
            int minNo = 0;


            for (int i = 1; i < k; ++i)
            {
                for (int j = 0; j < n + 1; ++j)
                {
                    int sqrVal = Convert.ToInt32(Math.Pow(arr[i], 2));
                    if (j < sqrVal)
                        dp[i, j] = dp[i - 1, j];
                    else if (j % sqrVal == 0)
                        dp[i, j] = j / sqrVal;
                    else if (j > 0 && dp[i - 1, j - sqrVal] > 0)
                        dp[i, j] = j / sqrVal + dp[i - 1, j - sqrVal * (int)(j / sqrVal)];
                }
                if (minNo == 0 || dp[i, n] < minNo)
                    minNo = dp[i, n];

            }

            return minNo;

        }
        // Prints all subsets of arr[0..n-1] with sum 0. 
        private static void printAllSubsets(int[] arr, int n, int sum)
        {
            if (n == 0 || sum < 0)
                return;

            // Sum 0 can always be achieved with 0 elements 
            //You can form Sum 0 with Value 0 
            dp = new int[n, sum + 1];

            //For Cell values starting 1st row  
            //Truth Value(TV) = TV by EXCLUDING NEW VALUE + (OR Gate) TV by INCLUDING NEW VALUE 

            int minNo = 0;
            // Fill rest of the entries in dp[][] 
            for (int i = 1; i < n; ++i)
            {
                for (int j = 0; j < sum + 1; ++j)
                {
                    int sqrVal = Convert.ToInt32(Math.Pow(arr[i], 2));
                    if (j < sqrVal)
                        dp[i, j] = dp[i - 1, j];
                    else if (j % sqrVal == 0)
                        dp[i, j] = j / sqrVal;
                    else if(j > 0 && dp[i - 1, j - sqrVal] > 0)
                        dp[i, j] = j / sqrVal + dp[i - 1, j - sqrVal * (int)(j / sqrVal)];
                }
                if (minNo == 0 || dp[i, sum] < minNo)
                    minNo = dp[i, sum];
               
            }
           
        }

        
    }
}
