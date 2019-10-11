using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidParenthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = IsValid("(]");
        }

        public static bool IsValid(string s)
        {
            var stack = new Stack<char>();
            char d = char.MinValue;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(' || s[i] == '[' || s[i] == '{')
                    stack.Push(s[i]);
                else if(s[i] == ')' || s[i] == ']' || s[i] == '}')
                {
                    if (stack.Count != 0)
                        d = stack.Pop();
                    else
                        return false;

                    if ((s[i] == ')' && d != '(') || (s[i] == ']' && d != '[') || (s[i] == '}' && d != '{'))
                        return false;

                }
            }

            return stack.Count == 0;
        }
    }
}
