using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstactFactory
{
    class Program
    {
        /*
        Reference - Youtube/Derek Banas, Youtube/Pankaj Kumar
        It is like the factory pattern, but everything is encapsulated -
            The method that orders the object
            The method that builds the object
            The final objects
            The final objects contain objects use Strategy Pattern i.e. it uses compositions where it's class fields are actually objects
        Allows you to create families of related objects without specifying a concrete class
        Should be used when you have many objects that can be added/changed dynamically during runtime
        */
        static void Main(string[] args)
        {
            //Order 1
            Console.WriteLine(
                    VendorFactory.CreateVendor(
                                    new ABCFactory
                                    {
                                        _order = new Order
                                        {
                                            ProductId = 123,
                                            Quantity = 10
                                        }
                                    }).PlaceOrder());

            //Order 2
            Console.WriteLine(
                VendorFactory.CreateVendor(
                                new XYZFactory
                                {
                                    _order = new Order
                                    {
                                        ProductId = 456,
                                        Quantity = 20
                                    }
                                }).PlaceOrder());

            //just checking how easy is it to create a new vendor and place an order
            Console.WriteLine(
                VendorFactory.CreateVendor(
                                new PQRFactory
                                {
                                    _order = new Order
                                    {
                                        ProductId = 789,
                                        Quantity = 30
                                    }
                                }).PlaceOrder());

            Console.ReadLine();
        }
    }

    //Factory method that houses a static method that returns Vendor Factory
    public class VendorFactory
    {
        public Order order { get; set; }
        public static IVendor CreateVendor(IVendorFactory vendorFactory)
        {
            return vendorFactory.CreateVendor();
        }
    }

    //abstraction for factories
    public interface IVendorFactory
    {
        IVendor CreateVendor();
    }


    //Factory method for Vendor ABC
    public class ABCFactory : IVendorFactory
    {
        public Order _order { get; set; }
        public IVendor CreateVendor()
        {
            return new ABC { order = _order};
        }
    }

    //Factory method for Vendor XYZ
    public class XYZFactory : IVendorFactory
    {
        public Order _order { get; set; }
        public IVendor CreateVendor()
        {
            return new XYZ { order = _order };
        }
    }

    //Factory method for Vendor PQR
    public class PQRFactory : IVendorFactory
    {
        public Order _order { get; set; }
        public IVendor CreateVendor()
        {
            return new PQR { order = _order };
        }
    }

    //abstraction for vendor
    public interface IVendor
    {
        string PlaceOrder();
    }

    //Object for Order info
    public class Order
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }

    //concrete implementation for ABC
    public class ABC : IVendor
    {
        public Order order { get; set; }
        public string PlaceOrder()
        {
            return $"Order placed with ABC, ProductId: {order.ProductId}, Quantity: {order.Quantity}";
        }
    }

    //concrete implementation for XYZ
    public class XYZ : IVendor
    {
        public Order order { get; set; }
        public string PlaceOrder()
        {
            return $"Order placed with XYZ, ProductId: {order.ProductId}, Quantity: {order.Quantity}";
        }
    }

    //concrete implementation for PQR
    public class PQR : IVendor
    {
        public Order order { get; set; }
        public string PlaceOrder()
        {
            return $"Order placed with PQR, ProductId: {order.ProductId}, Quantity: {order.Quantity}";
        }
    }
}
