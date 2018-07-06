using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp11
{
    class Program
    {
        static void Main(string[] args)
        {
            //Exact String Matching: Knuth-Morris-Pratt (KMP)
            //Reference - http://www.mathcs.emory.edu/~cheung/Courses/323/Syllabus/Text/Matching-KMP1.html
            var text = "abadababaccabacabaabb";
            var pattern = "abacab";
            var failureFunction = FailureFunction(pattern);

            var i = KMP(text, pattern, failureFunction);
            Console.WriteLine("Pattern found at position: " + i);
        }

        private static int KMP(string text, string pattern, int[] failureFunction)
        {
            var iniTextPointer = 0;
            var movingTextPointer = 0;
            var movingPatternPointer = 0;
            var textLength = text.Length;
            var patternLength = pattern.Length;

            while (movingTextPointer < textLength)
            {
                if (text[movingTextPointer] == pattern[movingPatternPointer])
                {
                    movingPatternPointer++;
                    movingTextPointer++;

                    if (movingPatternPointer == patternLength)
                    {
                        return iniTextPointer;
                    }
                }
                else
                {
                    Console.WriteLine("Mismatch");
                    if (movingPatternPointer == 0)
                    {
                        Console.WriteLine("First Character");
                        Console.WriteLine("Slide the Text Pointers by 1 Position");
                        iniTextPointer++;
                        movingTextPointer = iniTextPointer;
                        movingPatternPointer = 0;
                    }
                    else
                    {
                        movingPatternPointer = failureFunction[movingPatternPointer - 1];
                        iniTextPointer = movingTextPointer - movingPatternPointer;
                    }
                }
            }
            return -1;
        }

        private static int[] FailureFunction(string pattern)
        {
            var patternLength = pattern.Length;
            var failureFunction = new int[patternLength];
            var iniPointer = 0;
            var movingPointer = 1;
            failureFunction[0] = 0;

            while (movingPointer < patternLength)
            {
                if (pattern[iniPointer] == pattern[movingPointer])
                {
                    failureFunction[movingPointer] = iniPointer + 1;
                    iniPointer++;
                    movingPointer++;
                }
                else
                {
                    if (iniPointer == 0)
                    {
                        failureFunction[movingPointer] = 0;
                        movingPointer++;
                    }
                    else
                    {
                        iniPointer = failureFunction[iniPointer - 1];
                    }
                }
            }

            return failureFunction;
        }
    }
}
