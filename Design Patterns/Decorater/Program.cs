using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorater
{
    class Program
    {
        /*
         Referenc: YouTube/Derek Banas
         Decorater allows to modify an object dynamically.
         Simplifies code because you add functionalities using many simple classes.
         Use it when you want the capabilities on inheritencies with Subclasses, but you need to add functionalities at run time
             */
        static void Main(string[] args)
        {
            var pizza = new Cheese(
                                new Marinara(
                                    new PlainPizza()));

            Console.WriteLine($"Description: {pizza.description()}" );
            Console.WriteLine($"Cost: {pizza.cost()}");

            Console.ReadLine();
        }
    }

    public interface IPizza
    {
        string description();
        double cost();
    }

    public class PlainPizza : IPizza
    {
        public double cost()
        {
            return 10.00;
        }

        public string description()
        {
            return "Added Dough";
        }
    }

    public class Cheese : IPizza
    {
        IPizza _pizza;
        public Cheese(IPizza pizza)
        {
            _pizza = pizza;
        }
        public double cost()
        {
            return _pizza.cost() + 2;
        }

        public string description()
        {
            return _pizza.description() + ", Cheese";
        }
    }

    public class Marinara : IPizza
    {
        IPizza _pizza;
        public Marinara(IPizza pizza)
        {
            _pizza = pizza;
        }
        public double cost()
        {
            return _pizza.cost() + 5;
        }

        public string description()
        {
            return _pizza.description() + ", Marinara";
        }
    }
}
