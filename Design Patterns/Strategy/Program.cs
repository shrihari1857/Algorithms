using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    /// <summary>
    /// Behavioral
    /// </summary>
    class Program
    {
        /*
        Define a family of algorithms, encapsulate each one, and make them interchangeable. The Strategy Pattern lets the algorithm vary independently from clients that use it.
        Behavior can change without side effects, it isn't tied to Superclass or sub classes.
        */
        static void Main(string[] args)
        {
            var eagle = new Animal
            {
                FlyingType = new Flys()
            };
            eagle.FlyingType.fly();
            

            var dog = new Animal
            {
                FlyingType = new CantFly()
            };

            dog.FlyingType.fly();
            dog.ChangeFlyingType(new Flys());
            dog.FlyingType.fly();

        }

        //interface for the ability
        public interface IFly
        {
            void fly();
        }

        //one implemented class that has the ability
        public class Flys : IFly
        {
            public void fly()
            {
                Console.WriteLine("It flys");
            }
        }

        //another implemented class that doesn't have the ability
        public class CantFly : IFly
        {
            public void fly()
            {
                Console.WriteLine("Can't Fly");
            }
        }

        //main class
        public class Animal
        {
            public IFly FlyingType { get; set; }    // houses the flying type, should be set at object instantiation

            public void TryFlying()
            {
                FlyingType.fly();           //try to use that ability
            }

            public void ChangeFlyingType(IFly newType)
            {
                FlyingType = newType;   //switch the ability
            }
        }
        
    }
}
