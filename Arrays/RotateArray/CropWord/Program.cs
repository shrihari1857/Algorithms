using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CropWord
{
    class Program
    {
        static void Main(string[] args)
        {
            var message = "Why not";
            var K = 100;
            var result = string.Empty;

           // var str = message.Substring(0, K);
            var left = K - 1;
            // (left + 1 <= message.Length && (!Char.IsWhiteSpace(message[left + 1]))
            //|| !Char.IsWhiteSpace(message[left - 1]))
            if (K < message.Length)
            {
                while (Char.IsWhiteSpace(message[left])
               || ((left + 1) < message.Length && !Char.IsWhiteSpace(message[left + 1])))
                {
                    left--;
                }
            }
            else
            {
                left = message.Length;
            }

            result = message.Substring(0, left + 1);
        }
    }
}
