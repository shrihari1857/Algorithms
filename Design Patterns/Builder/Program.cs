using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    /*
     Reference - YouTube/d80
     Used to overcome short comings of Factory and Abstract Factory DPs.
     If the class instantiation is heavy and complex, Client needs to send null to Factory for the respective fields that are optional
     Intent is to separate complex object construction from it's representation
    */
    class Program
    {
        static void Main(string[] args)
        {
            var car = new FordFiestaBuilder()
                            .SunRoof(true)  //Setting properties in a chain
                            .SatNav(true)
                            .Color("Black");

            var offroad = new JeepWrangler()
                            .SunRoof(false)
                            .SatNav(false)
                            .Color("Red");
        }
    }

    public class JeepWrangler : CarBuilder
    {
        public JeepWrangler()
        {
            Make("Jeep");   //set a fields in the construction making the distinction
            Model("Wrangle");
        }
    }

    public class FordFiestaBuilder : CarBuilder
    {
        public FordFiestaBuilder()
        {
            Make("Ford");   
            Model("Fiesta");
        }
    }

    //entire representation of the car has been abstracted
    public abstract class CarBuilder
    {
        protected string _Make;
        protected string _Model;
        protected bool _SunRoof;
        protected bool _SatNav;
        protected string _Color;

        public CarBuilder Make(string Make)
        {
            _Make = Make;
            return this;        //helps chaining
        }
        public CarBuilder Model(string Model)
        {
            _Model = Model;
            return this;
        }
        public CarBuilder SunRoof(bool SunRoof)
        {
            _SunRoof = SunRoof;
            return this;
        }
        public CarBuilder SatNav(bool SatNav)
        {
            _SatNav = SatNav;
            return this;
        }
        public CarBuilder Color(string Color)
        {
            _Color = Color;
            return this;
        }
    }
}
