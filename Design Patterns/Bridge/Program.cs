using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge
{
    class Program
    {
        /*
         Reference - YouTube/Derek Banas
         Progressively adding functionality while separating out major differences using abstract classes
         Refer attached diagram - use this pattern when you want to change both the abstractions and concrete classes independently.
             
             */
        static void Main(string[] args)
        {
            //instantiate a TV and couple it with a TV Remote
            //both are instantiate from abstract classes
            //Source could be a TV or a DVD player, and same for the remote
            var tvRemote = new TVRemote(new TV());
            tvRemote.Key7Pressed(); //Raise the Channel
            tvRemote.Key5Pressed(); //Raise Volume
            tvRemote.Key5Pressed(); //Raise Volume
            tvRemote.Key5Pressed(); //Raise Volume
            tvRemote.Key6Pressed(); //Reduce Volume
            tvRemote.Key9Pressed(); //Get the State of the device

            Console.ReadLine();
        }
    }

    //this could be a TV or a DVD player
    public abstract class EntertainmentDecive
    {
        public int VolumeLevel { get; set; }
        

        //we're using Keys 5 and 6 for Volume Level
        public void Key5Pressed()
        {
            VolumeLevel++;
        }
        public void Key6Pressed()
        {
            VolumeLevel--;
        }

        public abstract void State();   //we're keeping this abstract


        //keys 7 and 8 are abstract, derived class can choose other funcs
        public abstract void Key7Pressed();
        public abstract void Key8Pressed();
    }

    //Concrete implementation
    public class TV : EntertainmentDecive
    {
        public int Channel { get; set; }
        public override void Key7Pressed()
        {
            Channel++;
        }

        public override void Key8Pressed()
        {
            Channel--;
        }

        public override void State()
        {
            Console.WriteLine($"Channel is {Channel} and Volume is {VolumeLevel}");
        }
    }

    public abstract class RemoteDevice
    {
        private EntertainmentDecive _entertainmentDevice;

        public RemoteDevice(EntertainmentDecive entertainmentDecive)
        {
            _entertainmentDevice = entertainmentDecive;
        }

        public void Key5Pressed()
        {
            _entertainmentDevice.Key5Pressed();
        }
        public void Key6Pressed()
        {
            _entertainmentDevice.Key6Pressed();
        }

        
        public abstract void Key7Pressed();
        public abstract void Key8Pressed();
        public abstract void Key9Pressed();
    }

    public class TVRemote : RemoteDevice
    {
        private EntertainmentDecive _entertainmentDevice;
        public TVRemote(EntertainmentDecive entertainmentDecive) : base(entertainmentDecive)
        {
            _entertainmentDevice = entertainmentDecive;
        }

        public override void Key7Pressed()
        {
            _entertainmentDevice.Key7Pressed();
            
        }

        public override void Key8Pressed()
        {
            _entertainmentDevice.Key8Pressed();
        }

        public override void Key9Pressed()
        {
            _entertainmentDevice.State();
        }
    }
}
