using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IterativeInorderTraversal
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Tree construction
            var root =
                    new BinaryTree
                    {
                        Value = 'a',
                        Left =
                            new BinaryTree
                            {
                                Value = 'b',
                                Left =
                                    new BinaryTree
                                    {
                                        Value = 'd'
                                    },
                                Right =
                                    new BinaryTree
                                    {
                                        Value = 'e',
                                        Left =
                                            new BinaryTree
                                            {
                                                Value = 'h'
                                            }
                                    }
                            },
                        Right =
                            new BinaryTree
                            {
                                Value = 'c',
                                Left =
                                    new BinaryTree
                                    {
                                        Value = 'f',
                                        Left =
                                            new BinaryTree
                                            {
                                                Value = 'm'
                                            },
                                        Right =
                                            new BinaryTree
                                            {
                                                Value = 'k'
                                            }
                                    },
                                Right =
                                    new BinaryTree
                                    {
                                        Value = 'g'
                                    }
                            }
                    };
            #endregion

            var stack = new Stack<BinaryTree>();
            

            while (true)
            {
                while (root != null)
                {
                    stack.Push(root);
                    root = root.Left;
                }

                if (stack.Count == 0)
                    break;

                root = stack.Pop();
                Console.Write(root.Value + " "); // d b h e a m f c g

                root = root.Right;
            }

            Console.ReadLine();
        }
    }

    public class BinaryTree
    {
        public char Value { get; set; }
        public BinaryTree Left { get; set; }
        public BinaryTree Right { get; set; }
    }
}
