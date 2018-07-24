using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor
{
    class Program
    {
        /*
         Behavioral Design Pattern
         Here we have a Visitor and a Visitable.
         Visitor has a visit method for each visitable.
         Visitable has an accept method for the visitor.
         This is particularly useful, say you're traversing through a Tree, and you want to handle leaf and various nodes differently. In this case, visitable are the leaves and nodes while the visitor has visit methods for each. So, when we come across a leaf, we let the leaf accept the visitor and then call the visitor's visit method. Hence, leaf just let's the visitor know about it's presence and let it take action accordinly.
         
             */
        static void Main(string[] args)
        {
            var computer = new Computer();
            var computerVisitor = new ComputerPartVisitor();
            computer.accept(computerVisitor);

            Console.ReadLine();
        }
    }

    public interface IComputerPartVisitor
    {
        void visit(Mouse mouse);
        void visit(Monitor monitor);
        void visit(Keyboard keyboard);
    }

    public class ComputerPartVisitor : IComputerPartVisitor
    {
        public void visit(Mouse mouse)
        {
            Console.WriteLine("Displaying Mouse");
        }

        public void visit(Monitor monitor)
        {
            Console.WriteLine("Displaying Monitor");
        }

        public void visit(Keyboard keyboard)
        {
            Console.WriteLine("Displaying keyboard");
        }
    }
    public interface IComputerPart
    {
        void accept(IComputerPartVisitor computerPartVisitor);
    }

    public class Computer : IComputerPart
    {
        IComputerPart[] computerParts;
        public Computer()
        {
            computerParts = new IComputerPart[] { new Mouse(), new Keyboard(), new Monitor() };
        }
        public void accept(IComputerPartVisitor computerPartVisitor)
        {
            foreach (var part in computerParts)
            {
                part.accept(computerPartVisitor);
            }
        }
    }
    public class Mouse : IComputerPart
    {
        public void accept(IComputerPartVisitor computerPartVisitor)
        {
            computerPartVisitor.visit(this);
        }
    }
    public class Monitor : IComputerPart
    {
        public void accept(IComputerPartVisitor computerPartVisitor)
        {
            computerPartVisitor.visit(this);
        }
    }
    public class Keyboard : IComputerPart
    {
        public void accept(IComputerPartVisitor computerPartVisitor)
        {
            computerPartVisitor.visit(this);
        }
    }
}
