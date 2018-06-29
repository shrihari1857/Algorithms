using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsertSort
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = new int[]{ 9, 4, 5, 8, 2, 0, 1, 7, 6, 3 };

            for (int i = 1; i < arr.Length; i++)
            {
                var flag = false;
                var temp1 = arr[i];
                var temp2 = 0;
                for (int j = 0; j<i; j++)
                {
                    if (!flag)
                    {
                        if (arr[i] < arr[j])
                        {
                            temp1 = arr[j];
                            arr[j] = arr[i];
                            flag = true;
                        }
                    }
                    else
                    {
                        temp2 = arr[j];
                        arr[j] = temp1;
                        temp1 = temp2;
                    }
                }
                arr[i] = temp1;
            }
        }
    }
}
