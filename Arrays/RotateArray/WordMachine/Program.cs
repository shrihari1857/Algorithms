using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            var S = "13 DUP 4 POP 5 DUP + DUP + -";
            var i = 0;
            var queue = new Queue<string>();

            while (i < S.Length)
            {
                var str = new StringBuilder();
                while (i < S.Length && (int)S[i] != 32)
                {
                    str.Append(S[i]);
                    i++;
                }
                queue.Enqueue(str.ToString());
                i++;
            }

            int result;
            var stack = new Stack<int>();
            

            while (queue.Count > 0)
            {
                int Num;
                var instr = queue.Dequeue();
                if (int.TryParse(instr, out Num))
                {
                    stack.Push(Num);
                }

                if (instr == "DUP")
                {
                    if (stack.Count == 0)
                    {
                        result = -1;
                    }

                    stack.Push(stack.Peek());
                }

                if (instr == "POP")
                {
                    if (stack.Count == 0)
                    {
                        result = -1;
                    }
                    stack.Pop();
                }
                    

                if (instr == "+")
                {
                    if (stack.Count < 2)
                    {
                        result = -1;
                    }

                    stack.Push(stack.Pop() + stack.Pop());
                }

                if (instr == "-")
                {
                    if (stack.Count < 2)
                    {
                        result = -1;
                    }

                    stack.Push(stack.Pop() - stack.Pop());
                }

            }

            result = stack.Pop();
            
        }
    }
}
