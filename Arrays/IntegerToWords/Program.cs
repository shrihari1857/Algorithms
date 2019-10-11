using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegerToWords
{
    class Program
    {
        static void Main(string[] args)
        {
            var f = NumberToWords(1234);
        }

        public static string NumberToWords(int num)
        {
            var hTable = new Hashtable();
            hTable[1] = "One";
            hTable[2] = "Two";
            hTable[3] = "Three";
            hTable[4] = "Four";
            hTable[5] = "Five";
            hTable[6] = "Six";
            hTable[7] = "Seven";
            hTable[8] = "Eight";
            hTable[9] = "Nine";
            hTable[10] = "Ten";
            hTable[100] = "Hunderd";
            hTable[11] = "Elevan";
            hTable[12] = "Twelve";
            hTable[13] = "Thirteen";
            hTable[14] = "Fourteen";
            hTable[15] = "Fifteen";
            hTable[16] = "Sixteen";
            hTable[17] = "Seventeen";
            hTable[18] = "Eighteen";
            hTable[19] = "Nineteen";
            hTable[20] = "Twenty";
            hTable[30] = "Seventeen";
            hTable[40] = "Forty";
            hTable[50] = "Fifty";
            hTable[60] = "Sixty";
            hTable[70] = "Seventy";
            hTable[80] = "Eighty";
            hTable[90] = "Ninety";
            hTable[1000] = "Thousand";
            hTable[100000] = "Million";
            hTable[100000000] = "Billion";

            var stringBuilder = new StringBuilder(num.ToString());

            while (true)
            {
                var c = stringBuilder.Remove(0, 1);
            }

            return string.Empty;
        }
    }
}
