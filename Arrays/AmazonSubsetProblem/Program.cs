using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonSubsetProblem
{
    class Program
    {
        static int[,] dp;
        static void Main(string[] args)
        {

            printAllSubsets(7, new List<List<int>> {
                new List<int>{ 1,2},
                new List<int>{ 2,4},
                new List<int>{ 3,6}
            },
             new List<List<int>> {
                new List<int>{ 1,2},
            });
        }

        //int[] arr, int n, int sum
        private static void optimalUtilization(int deviceCapacity,
                                             List<List<int>> foregroundAppList,
                                             List<List<int>> backgroundAppList)
        {
            var n = foregroundAppList.Count;
            //calculate n
            if (n == 0 || deviceCapacity < 0)
                return;

            // Sum 0 can always be achieved with 0 elements 
            //You can form Sum 0 with Value 0 
            dp = new int[foregroundAppList.Count + 1, backgroundAppList.Count + 1];
            //for (int i = 0; i < n; ++i)
            //{
            //    dp[i, 0] = true;
            //}

            for (int i = 0; i < foregroundAppList.Count; i++)
            {
                var x = foregroundAppList[i][1];
                dp[0, i] = x;
            }

            for (int i = 0; i < backgroundAppList.Count; i++)
            {
                dp[i, 0] = backgroundAppList[i][1];
            }

            // Sum arr[0] can be achieved with single element 
            //0 value and 0 sum is the base condition of this problem
            //if (arr[0] <= sum)
            //    dp[0, arr[0]] = true;

            //For Cell values starting 1st row  
            //Truth Value(TV) = TV by EXCLUDING NEW VALUE + (OR Gate) TV by INCLUDING NEW VALUE 

            // Fill rest of the entries in dp[][] 
            //for (int i = 0; i < n; ++i)
            //    for (int j = 0; j < backgroundAppList.Count; ++j)
            //        dp[i, j] = (arr[i] <= j) ? (dp[i - 1, j] ||
            //                                   dp[i - 1, j - arr[i]])
            //                                 : dp[i - 1, j];
            //if (dp[n - 1, sum] == false)
            //{
            //    Console.WriteLine("There are no subsets with" +
            //                                          " sum " + sum);
            //    return;
            //}

            //// Now recursively traverse dp[][] to find all 
            //// paths from dp[n-1][sum] 
            //var p = new List<int>();
            //printSubsetsRec(arr, n - 1, sum, p);
        }
    }
}
