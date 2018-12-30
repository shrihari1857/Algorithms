using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingArrayOfText
{
    class Program
    {
        static void Main(string[] args)
        {
            //String[] arr = { "apple", "apple f ", "australia", "algorithm", "sell", "olympic", "jack", "sleep" };
            //var array = new string[] { "al 9 2 3 1", "g1 Act car", "zo4 4 7", "abl off KEY dog", "a8 act zoo" };
            var array = new string[] {"al 9 2 3 1", "g1 Act car" ,"zo4 4 7", "abl off KEY dog", "a8 act zoo"};
            var logFileSize = 5;
            var arr = new string[logFileSize];
            var intArray = new string[logFileSize];

            for (int i = 0; i < logFileSize; i++)
            {
                var splits = array[i].Split(new char[] { ' ' }, 2);
                char c = splits[1][0];
                if (Char.IsNumber(splits[1][0]))
                    intArray[i] = array[i];
                else
                    arr[i] = array[i];
                
            }

            arr =
                (from item in arr
                 where item != null
                 select item).ToArray();

            intArray =
                (from item in intArray
                 where item != null
                 select item).ToArray();

            radixSort(arr, ' ', 'z', true);

            int array1OriginalLength = arr.Length;
            Array.Resize(ref arr, array1OriginalLength + intArray.Length);
            Array.Copy(intArray, 0, arr, array1OriginalLength, intArray.Length);


            //   radixSort(arr, ' ', 'z', false);
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
            Console.ReadLine();
        }

            public static void countingSort(String[] arr, int index, char lower, char upper, bool SortbySecCol)
            {
                int[] countArray = new int[(upper - lower) + 2];
                String[] tempArray = new String[arr.Length];

                var tempStr = string.Empty;

                //increase count for char at index
                for (int i = 0; i < arr.Length; i++)
                {
                ////int charIndex = (arr[i].Length - 1 < index) ? 0 : ((arr[i][index] - lower) + 1);
                if (SortbySecCol)
                    tempStr = arr[i].Substring(arr[i].IndexOf(" ") + 1);
                else
                    tempStr = arr[i].Substring(0, arr[i].IndexOf(" "));

                int charIndex = (tempStr.Length - 1 < index) ? 0 : ((tempStr[index] - lower) + 1);
                countArray[charIndex]++;
                }

                //sum up countArray;countArray will hold last index for the char at each strings index
                for (int i = 1; i < countArray.Length; i++)
                {
                    countArray[i] += countArray[i - 1];
                }

                for (int i = arr.Length - 1; i >= 0; i--)
                {
                if (SortbySecCol)
                    tempStr = arr[i].Substring(arr[i].IndexOf(" ") + 1);
                else
                    tempStr = arr[i].Substring(0, arr[i].IndexOf(" "));

                int charIndex = (tempStr.Length - 1 < index) ? 0 : ((tempStr[index] - lower)) + 1;
                    tempArray[countArray[charIndex] - 1] = arr[i];
                    countArray[charIndex]--;
                }

                for (int i = 0; i < tempArray.Length; i++)
                {
                    arr[i] = tempArray[i];
                }
            }

            public static void radixSort(String[] arr, char lower, char upper, bool SortbySecCol)
            {
                var arrLength = 0;
                
                int maxIndex = 0;
                for (int i = 0; i < arr.Length; i++)
                {

                    if (SortbySecCol)
                        arrLength = arr[i].Substring(arr[i].IndexOf(" ") + 1).Length;
                    else
                        arrLength = arr[i].Substring(0, arr[i].IndexOf(" ")).Length;

                    ////if (arr[i].Length - 1 > maxIndex)
                    if ( arrLength- 1 > maxIndex)
                    {
                        ////////maxIndex = arr[i].Length - 1;
                        maxIndex = arrLength - 1;
                    }
                }

                for (int i = maxIndex; i >= 0; i--)
                {
                    countingSort(arr, i, lower, upper, SortbySecCol);
                }
            }
        }
}
