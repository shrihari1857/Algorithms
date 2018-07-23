using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    class Program
    {
        /*
         Defines one-to-many dependencies between objects so that the state one changes, all dependent objects are notified.
         Contains two main actors, Subject which notifies change and Observer that receives and acts on updates
         Loose coupling is a benefit. However, Subject may send updates that don't matter to Observer.
        */
        static void Main(string[] args)
        {
            var stockGrabber = new StockGrabber();
            var observer1 = new Observer1();
            var observer2 = new Observer2();

            stockGrabber.Register(observer1);
            stockGrabber.Register(observer2);
            stockGrabber.SetPrice(100.00);

            Console.ReadLine();

        }
    }

    public interface IObserver
    {
        void update(double price);
    }
    public interface ISubject
    {
        void Register(IObserver observer);
        void UnRegister(IObserver observer);
        void Notify();
    }

    public class StockGrabber : ISubject
    {
        public List<IObserver> Observers = new List<IObserver>();
        double price;
        public void Notify()
        {
            foreach (var Observer in Observers)
                Observer.update(price);
        }

        public void Register(IObserver observer)
        {
            Observers.Add(observer);
        }

        public void UnRegister(IObserver observer)
        {
            Observers.Remove(observer);
        }

        public void SetPrice(double newPrice)
        {
            price = newPrice;
            Notify();
        }
    }

    public class Observer1 : IObserver
    {
        public void update(double price)
        {
            Console.WriteLine($"Update received by Observer1, new price: {price}");
        }
    }

    public class Observer2 : IObserver
    {
        public void update(double price)
        {
            Console.WriteLine($"Update received by Observer2, new price: {price}");
        }
    }

}
