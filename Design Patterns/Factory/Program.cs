using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Creational Design Pattern
/// </summary>
namespace Factory
{
    class Program
    {
        //We looked the factory design pattern, which is used to instantiate objects based on another data type such as integers.Factories can be used to reduce code bloat and also make it easier to modify which objects need to be created.
        //In Factory pattern, we create object without exposing the creation logic.In this pattern, an interface is used for creating an object, but let subclass decide which class to instantiate.The creation of object is done when it is required.The Factory method allows a class later instantiation to subclasses.
        static void Main(string[] args)
        {
            VendorManagement vendorManagement = new ConcreteVendorManagement();

            var abc = vendorManagement.GetVendor(Vendor.ABC);
            Console.WriteLine(
                        abc.PlaceOrder(
                                new Order
                                {
                                    ProductId = 123,
                                    Quantity = 10
                                }));

            var xyz = vendorManagement.GetVendor(Vendor.XYZ);
            Console.WriteLine(
                        xyz.PlaceOrder(
                                new Order
                                {
                                    ProductId = 456,
                                    Quantity = 20
                                }));

            Console.ReadLine();
        }
    }

    public enum Vendor
    {
        ABC,
        XYZ
    }
    public abstract class VendorManagement
    {
        public abstract IVendor GetVendor(Vendor vendor);
    }
    public class ConcreteVendorManagement : VendorManagement
    {
        IVendor _vendor = null;
        public override IVendor GetVendor(Vendor vendor)
        {
            switch (vendor)
            {
                case Vendor.ABC:
                    _vendor = new ABC();
                    break;
                case Vendor.XYZ:
                    _vendor = new XYZ();
                    break;
                default:
                    break;
            }
            return _vendor;
        }
    }
    public interface IVendor
    {
        string PlaceOrder(Order order);
    }

    public class Order
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }

    public class ABC : IVendor
    {
        public string PlaceOrder(Order order)
        {
            return $"Order placed with ABC, ProductId: {order.ProductId}, Quantity: {order.Quantity}";
        }
    }

    public class XYZ : IVendor
    {
        public string PlaceOrder(Order order)
        {
            return $"Order placed with XYZ, ProductId: {order.ProductId}, Quantity: {order.Quantity}";
        }
    }
}
