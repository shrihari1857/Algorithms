using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintAllSubsetsWithGivenSum
{
    class Program
    {
        // dp[i][j] is going to store true if sum j is 
        // possible with array elements from 0 to i. 
        static bool[,] dp;
        static void Main(string[] args)
        {
            int[] arr = new int[]{ 1, 2, 5, 7 };
            int n = arr.Length;
            int sum = 8;
            printAllSubsets(arr, n, sum);
        }

        // Prints all subsets of arr[0..n-1] with sum 0. 
        private static void printAllSubsets(int[] arr, int n, int sum)
        {
            if (n == 0 || sum < 0)
                return;

            // Sum 0 can always be achieved with 0 elements 
            //You can form Sum 0 with Value 0 
            dp = new bool[n, sum + 1];
            for (int i = 0; i < n; ++i)
            {
                dp[i,0] = true;
            }

            // Sum arr[0] can be achieved with single element 
            //0 value and 0 sum is the base condition of this problem
            if (arr[0] <= sum)
                dp[0,arr[0]] = true;

            //For Cell values starting 1st row  
            //Truth Value(TV) = TV by EXCLUDING NEW VALUE + (OR Gate) TV by INCLUDING NEW VALUE 

            // Fill rest of the entries in dp[][] 
            for (int i = 1; i < n; ++i)
                for (int j = 0; j < sum + 1; ++j)
                    dp[i,j] = (arr[i] <= j) ? (dp[i - 1,j] ||
                                               dp[i - 1,j - arr[i]])
                                             : dp[i - 1,j];
            if (dp[n - 1,sum] == false)
            {
                Console.WriteLine("There are no subsets with" +
                                                      " sum " + sum);
                return;
            }

            // Now recursively traverse dp[][] to find all 
            // paths from dp[n-1][sum] 
            var p = new List<int>();
            printSubsetsRec(arr, n - 1, sum, p);
        }

        // A recursive function to print all subsets with the 
        // help of dp[][]. Vector p[] stores current subset. 
        private static void printSubsetsRec(int[] arr, int i, int sum, List<int> p)
        {
            // If we reached end and sum is non-zero. We print 
            // p[] only if arr[0] is equal to sun OR dp[0][sum] 
            // is true. 
            if (i == 0 && sum != 0 && dp[0,sum])
            {
                p.Add(arr[i]);
                display(p);
                p.Clear();
                return;
            }

            // If sum becomes 0 
            if (i == 0 && sum == 0)
            {
                display(p);
                p.Clear();
                return;
            }

            // If given sum can be achieved after ignoring 
            // current element. 
            if (dp[i - 1,sum])
            {
                // Create a new vector to store path 
                List<int> b = new List<int>();
                b.AddRange(p);
                printSubsetsRec(arr, i - 1, sum, b);
            }

            // If given sum can be achieved after considering 
            // current element. 
            if (sum >= arr[i] && dp[i - 1,sum - arr[i]])
            {
                p.Add(arr[i]);
                printSubsetsRec(arr, i - 1, sum - arr[i], p);
            }
        }

        private static void display(List<int> p)
        {
            Console.WriteLine("New Set");
            for (int i = 0; i < p.Count; i++)
            {
                Console.WriteLine(p[i]);
            }
        }
    }
}
