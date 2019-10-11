using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProducOfArrayItself
{
    class Program
    {
        static void Main(string[] args)
        {

            var product = productOfArrray(new int[] { 1, 2, 3, 4});
        }

        private static int[] productOfArrray(int[] nums)
        {
            var len = nums.Length;
            var pre = new int[len];
            var after = new int[len];
            var product = new int[len];

            for (int i = 0; i < len; i++)
            {
                pre[i] = 1;
                after[i] = 1;
            }
            for (int i = 1; i < len; i++)
            {
                pre[i] = pre[i - 1] * nums[i - 1];
            }

            for (int i = len-2; i >=0; i--)
            {
                after[i] = after[i + 1] * nums[i + 1];
            }

            for (int i = 0; i < len; i++)
            {
                product[i] = pre[i] * after[i];
            }

            return product;
        }

        
    }
}
