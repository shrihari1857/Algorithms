using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr = {"geeksforgeeks", "geeks",
                               "geek", "geezer"};
            int n = arr.Length;

            string ans = commonPrefix(arr, n);

            if (ans.Length > 0)
                Console.WriteLine("The longest common"
                                + " prefix is - " + ans);
            else
                Console.WriteLine("There is no common"
                                          + " prefix");
        }

        // A Function that returns the longest common prefix 
        // from the array of strings 
        static string commonPrefix(string[] arr, int n)
        {
            int index = findMinLength(arr, n);
            string prefix = ""; // Our resultant string 

            // We will do an in-place binary search on the 
            // first string of the array in the range 0 to 
            // index 
            int low = 0, high = index;
            while (low <= high)
            {

                // Same as (low + high)/2, but avoids  
                // overflow for large low and high 
                int mid = low + (high - low) / 2;

                if (allContainsPrefix(arr, n, arr[0], low,
                                                      mid))
                {
                    // If all the strings in the input array 
                    // contains this prefix then append this 
                    // substring to our answer 
                    prefix = prefix + arr[0].Substring(low,
                                              mid + 1);

                    // And then go for the right part 
                    low = mid + 1;
                }
                else // Go for the left part 
                {
                    high = mid - 1;
                }
            }

            return prefix;
        }

        // A Function to find the string having the  
        // minimum length and returns that length 
        static int findMinLength(string[] arr, int n)
        {
            int min = int.MaxValue;
            for (int i = 0; i <= (n - 1); i++)
            {
                if (arr[i].Length < min)
                {
                    min = arr[i].Length;
                }
            }
            return min;
        }

        static bool allContainsPrefix(string[] arr, int n,
                             string str, int start, int end)
        {
            for (int i = 0; i <= (n - 1); i++)
            {
                string arr_i = arr[i];

                for (int j = start; j <= end; j++)
                    if (arr_i[j] != str[j])
                        return false;
            }
            return true;
        }
    }
}
