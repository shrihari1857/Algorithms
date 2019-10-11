using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindKPairsWithSmallestSums
{
    class Program
    {
        static void Main(string[] args)
        {

            #region Description
            /*
                 You are given two integer arrays nums1 and nums2 sorted in ascending order and an integer k.

    Define a pair (u,v) which consists of one element from the first array and one element from the second array.

    Find the k pairs (u1,v1),(u2,v2) ...(uk,vk) with the smallest sums.
    Input: nums1 = [1,7,11], nums2 = [2,4,6], k = 3
    Output: [[1,2],[1,4],[1,6]] 
    Explanation: The first 3 pairs are returned from the sequence: 
                 [1,2],[1,4],[1,6],[7,2],[7,4],[11,2],[7,6],[11,4],[11,6]

                Input: nums1 = [1,1,2], nums2 = [1,2,3], k = 2
    Output: [1,1],[1,1]
    Explanation: The first 2 pairs are returned from the sequence: 
                 [1,1],[1,1],[1,2],[2,1],[1,2],[2,2],[1,3],[1,3],[2,3]

    Input: nums1 = [1,2], nums2 = [3], k = 3
    Output: [1,3],[2,3]
    Explanation: All possible pairs are returned from the sequence: [1,3],[2,3]

                 */
            #endregion

            //            var nums1 =
            //                new int[] { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };

            //            var x = RemoveDups(nums1);
            //            var result = KSmallestPairs(nums1
            ////new int[] { 11, 7, 1 },
            ////new int[] { 2, 4, 6 },
            //,
            //                new int[] { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            //                1000
            //                );

            var result = kSmallestPairs1(
                 new int[] { 11, 7, 1 },
                 new int[] { 6, 4, 6 }, 2);
        }

        public static int[][] kSmallestPairs1(int[] nums1, int[] nums2, int k)
        {
            int total = nums1.Length * nums2.Length;
            if (total < k)
            {
                k = total;
            }

            var f = 0;
            int[][] result = new int[k][];
            int[] idx = new int[nums1.Length];//track each element's cursor in nums2
            while (k > 0)
            {
                int min = int.MaxValue;
                int minIdx = -1;
                for (int i = 0; i < nums1.Length; i++)
                {
                    if (idx[i] < nums2.Length && nums1[i] + nums2[idx[i]] < min)
                    {
                        minIdx = i;
                        min = nums1[i] + nums2[idx[i]];
                    }
                }
                result[f] = new int[] { nums1[minIdx], nums2[idx[minIdx]] };
                f++;
                idx[minIdx]++;
                k--;
            }

            return result;
        }

        private static int[] RemoveDups(int[] arr)
        {
            var i = 0;
            var j = 1;
            var temp = 0;

            while (j < arr.Length)
            {
                if(arr[i] != arr[j])
                {
                    i++;
                    arr[i] = arr[j];
                }
                j++;
            }

            return arr.Take(i + 1).ToArray();
        }

        private static int[][] KSmallestPairs(int[] nums1, int[] nums2, int k)
        {
            int[] v1;
            int[] v2;
            int[][] result = new int[k][];

            if (nums1.Length > nums2.Length)
            {
                v1 = nums1;
                v2 = nums2;
            }
            else if (nums1.Length == nums2.Length)
            {
                v1 = nums1;
                v2 = nums2;
            }
            else
            {
                v1 = nums2;
                v2 = nums1;
            }
            
            //var size = Math.Max(nums1.Length, nums2.Length);
            var size = nums1.Length * nums2.Length;
            var heap = new Heap(size + 1);
            for (int i = 0; i < v1.Length; i++)
            {
                int temp = 0;
                for (int j = 0; j < v2.Length; j++)
                {
                    temp = v2[j];
                    heap.insert(
                        new HItem
                        {
                            Arr = new int[] { v1[i], temp},
                            Sum = v1[i] + temp
                        });
                }
            }

            heap.lastPointer--;

            k = Math.Min(k, size);
            for (int i = 0; i < k; i++)
                result[i] = heap.DelMin();

            return result;
        }
    }

    public class Heap
    {
        HItem[] arr;
        public int lastPointer { get; set; }
        public Heap(long size)
        {
            arr = new HItem[size];
            lastPointer = 1;
        }

        public void insert(HItem hItem)
        {
            arr[lastPointer] = hItem;
            
            var currentItem = lastPointer;
            int root = currentItem / 2;
            while (currentItem > 1 && root >= 1 && arr[currentItem].Sum < arr[root].Sum)
            {
                
                Swap(currentItem, root, arr);
                currentItem = root;
                root = currentItem / 2;
            }

            lastPointer++;
        }

        internal void Swap(int root, int leaf, HItem[] arr)
        {
            var temp = arr[root];
            arr[root] = arr[leaf];
            arr[leaf] = temp;
        }

        internal int[] DelMin()
        {
            var ret = arr[1].Arr;
            arr[1] = arr[lastPointer];
            lastPointer--;

            var root = 1;
            var left = 2;
            var right = 3;

            while (root < lastPointer)
            {
                if ((left <= lastPointer && arr[root].Sum > arr[left].Sum) || (right <= lastPointer && arr[root].Sum > arr[right].Sum))
                {
                    //if (arr[root].Sum > arr[left].Sum)
                    if (arr[left].Sum < arr[right].Sum)
                    {
                        Swap(root, left, arr);
                        root = left;
                    }
                    else
                    {
                        Swap(root, right, arr);
                        root = right;
                    }
                    left = root * 2;
                    right = left + 1;
                }
                else
                    break;


            }

            return ret;
        }
    }


    public class HItem
    {
        public int[] Arr { get; set; }

        public int Sum { get; set; }

        public HItem()
        {
            Arr = new int[2];
            Sum = 0;
        }
    }
}
