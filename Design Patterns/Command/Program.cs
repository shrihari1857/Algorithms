using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    class Program
    {
        /*
         Reference: YouTube/Derek Banas
            Allows you to store lists of code that is executed later time or many times    
         Client says I want a specific  command to run when execute() is called on 1 of these encapsulated objects
         An object called invoker transfers this command to another object called a receiver to execute the right code
         
             */
        static void Main(string[] args)
        {
            //setup the devices/receivers
            var lights = new Light();
            var ac = new AirCondition();

            //setup the concrete commands
            var lightsOn = new LightOn(lights);
            var lightsOff = new LightOff(lights);
            var acOn = new AcOn(ac);
            var acOff = new AcOff(ac);

            //setup the invoker/remote control
            var remoteController = new RemoteController();
            remoteController.InsertNewOnCmd(lightsOn);
            remoteController.InsertNewOnCmd(acOn);
            remoteController.InsertNewOffCmd(lightsOff);
            remoteController.InsertNewOffCmd(acOff);

            //invoke the receiver
            remoteController.PressButtonOn(0);
            remoteController.PressButtonOn(1);
            remoteController.PressButtonOff(0);
            remoteController.PressButtonOff(1);

            Console.ReadLine();
        }
    }

    public interface ICommand
    {
        void Execute();
    }

    //Invoker
    public class RemoteController
    {
        public List<ICommand> TurnOnCmds = new List<ICommand>();
        public List<ICommand> TurnOffCmds = new List<ICommand>();

        public void InsertNewOnCmd(ICommand command)
        {
            TurnOnCmds.Add(command);
        }

        public void InsertNewOffCmd(ICommand command)
        {
            TurnOffCmds.Add(command);
        }

        public void PressButtonOn(int buttonNumber)
        {
            TurnOnCmds[buttonNumber].Execute();
        }

        public void PressButtonOff(int buttonNumber)
        {
            TurnOffCmds[buttonNumber].Execute();
        }

    }

    #region Concrete Commands
    public class LightOn : ICommand
    {
        private readonly Light light;

        public LightOn(Light _light)
        {
            light = _light;
        }
        public void Execute()
        {
            light.TurnOn();
        }
    }
    public class LightOff : ICommand
    {
        private readonly Light light;

        public LightOff(Light _light)
        {
            light = _light;
        }
        public void Execute()
        {
            light.TurnOff();
        }
    }
    public class AcOn : ICommand
    {
        private readonly AirCondition airCondition;

        public AcOn(AirCondition _airCondition)
        {
            airCondition = _airCondition;
        }
        public void Execute()
        {
            airCondition.TurnOn();
            airCondition.IncreaseTemperature();
        }
    }
    public class AcOff : ICommand
    {
        private readonly AirCondition airCondition;

        public AcOff(AirCondition _airCondition)
        {
            airCondition = _airCondition;
        }
        public void Execute()
        {
            airCondition.TurnOff();
            airCondition.DecreaseTemperature();
        }
    }
    #endregion
    #region Receivers
    public class Light
    {
        public void TurnOn()
        {
            Console.WriteLine("Lights turned ON.");
        }
        public void TurnOff()
        {
            Console.WriteLine("Lights turned ON.");
        }
    }
    public class AirCondition
    {
        public void TurnOn()
        {
            Console.WriteLine("AC turned ON.");
        }

        public void TurnOff()
        {
            Console.WriteLine("AC turned ON.");
        }
        public void IncreaseTemperature()
        {
            Console.WriteLine("Increasing Temperature.");
        }

        public void DecreaseTemperature()
        {
            Console.WriteLine("Decreasing Temperature.");
        }
    }
    #endregion
}
