using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State
{
    class Program
    {
        /*
         Reference: YouTube/Derek Banas
         Allows an object to alter it's behavior when it's internal state changes
         Here, we're trying to achieve a situation where an action could be called in any state of the object and it should be well equiped to handle it.
         For e.g. States like HasCard, NoCard, HasCash, NoCash etc. the ATM Machine could be either of the states, say HasCard - the next logical step would be add PIN which should be handled appropriately. However, if the requests cash directly, then this too should be handled properly.
         Hence, we define an interface IState, all identified States are defined it and equal implementation class are instantiated.
         In the ATM Machine class, we hold instances of these stated and vice versa.
         We'll getter setter methos on ATM Machine for all properties and states.
         This is a fool proof plan if all the states are identified and defined well.
             */
        static void Main(string[] args)
        {
            var atmMachine = new ATMMachine();
            atmMachine.insertCard();
            atmMachine.ejectCard();
            atmMachine.insertCard();
            atmMachine.insertPin(1234);
            atmMachine.requestCash(1500);
            atmMachine.insertCard();
            atmMachine.insertPin(1234);
            
        }
    }

    public interface IState
    {
        void insertCard();
        void ejectCard();
        void insertPin(int pinEntered);
        void requestCash(int cashToWithdraw);
    }

    public class ATMMachine
    {
        IState hasCard;
        IState noCard;
        IState hasCorrentPin;
        IState atmOutOfMoney;

        IState atmState;

        public int cashInMachine = 2000;
        public bool correctPinEntered = false;

        public ATMMachine()
        {
            hasCard = new hasCard(this);
            noCard = new NoCard(this);
            hasCorrentPin = new HasPin(this);
            atmOutOfMoney = new HasNoCash(this);

            atmState = noCard;

            if (cashInMachine < 0)
                atmState = atmOutOfMoney;
        }

        public void setAtmState(IState newATMState)
        {
            atmState = newATMState;
        }

        public void SetCashInMachine(int newCashInMachine)
        {
            cashInMachine = newCashInMachine;
        }

        public void insertCard()
        {
            atmState.insertCard();
        }

        public void ejectCard()
        {
            atmState.ejectCard();
        }

        public void requestCash(int cashToWithdraw)
        {
            atmState.requestCash(cashToWithdraw);
        }
        public void insertPin(int pinEntered)
        {
            atmState.insertPin( pinEntered);
        }

        public IState getYesCardState()
        {
            return hasCard;
        }
        public IState getNoCardState()
        {
            return noCard;
        }
        public IState gethasPin()
        {
            return hasCorrentPin;
        }
        public IState getNoCashState()
        {
            return atmOutOfMoney;
        }
    }

    public class hasCard : IState
    {
        ATMMachine atmMachine;

        public hasCard(ATMMachine _atmMachine)
        {
            atmMachine = _atmMachine;
        }
        public void ejectCard()
        {
            Console.WriteLine("Card ejected");
            atmMachine.setAtmState(atmMachine.getNoCardState());
        }

        public void insertCard()
        {
            Console.WriteLine("Can't insert more than one card");
        }

        public void insertPin(int pinEntered)
        {
            if (pinEntered == 1234)
            {
                Console.WriteLine("Correct Pin");
                atmMachine.correctPinEntered = true;
                atmMachine.setAtmState(atmMachine.gethasPin());
            }
            else
            {
                Console.WriteLine("incorrect Pin");
                atmMachine.correctPinEntered = false;
                Console.WriteLine("Card ejected");
                atmMachine.setAtmState(atmMachine.getNoCardState());
            }
            
        }

        public void requestCash(int cashToWithdraw)
        {
            Console.WriteLine("Enter pin first");
        }
    }

    public class NoCard : IState
    {
        private readonly ATMMachine aTMMachine;

        public NoCard(ATMMachine _aTMMachine)
        {
            aTMMachine = _aTMMachine;
        }

        public void ejectCard()
        {
            Console.WriteLine("Please enter a card first.");
            aTMMachine.setAtmState(aTMMachine.getYesCardState());
        }

        public void insertCard()
        {
            Console.WriteLine("Please enter PIN.");
            aTMMachine.setAtmState(aTMMachine.getYesCardState());
        }

        public void insertPin(int pinEntered)
        {
            Console.WriteLine("Please enter a card first.");
        }

        public void requestCash(int cashToWithdraw)
        {
            Console.WriteLine("Please enter a card first.");
        }
    }

    public class HasPin : IState
    {
        private readonly ATMMachine atmMachine;

        public HasPin(ATMMachine _aTMMachine)
        {
            atmMachine = _aTMMachine;
        }
        public void ejectCard()
        {
            Console.WriteLine("Card ejected");
            atmMachine.setAtmState(atmMachine.getNoCardState());
        }

        public void insertCard()
        {
            Console.WriteLine("You can't enter more than one card.");
        }

        public void insertPin(int pinEntered)
        {
            Console.WriteLine("Already entered PIN.");
        }

        public void requestCash(int cashToWithdraw)
        {
            if (cashToWithdraw > atmMachine.cashInMachine)
            {
                Console.WriteLine("Not enough cash.");
                Console.WriteLine("Card ejected.");
                atmMachine.setAtmState(atmMachine.getNoCardState());

            }
            else
            {
                Console.WriteLine($"{cashToWithdraw} provided by the machine.");
                atmMachine.SetCashInMachine(atmMachine.cashInMachine - cashToWithdraw);
                Console.WriteLine("Card ejected.");
                atmMachine.setAtmState(atmMachine.getNoCardState());

                if (atmMachine.cashInMachine <= 0)
                    atmMachine.setAtmState(atmMachine.getNoCashState());
            }
        }
    }

    public class HasNoCash : IState
    {
        private readonly ATMMachine aTMMachine;

        public HasNoCash(ATMMachine _aTMMachine)
        {
            aTMMachine = _aTMMachine;
        }
        public void ejectCard()
        {
            Console.WriteLine("No money. You didn't enter a card.");
        }

        public void insertCard()
        {
            Console.WriteLine("No money.");
        }

        public void insertPin(int pinEntered)
        {
            Console.WriteLine("No money.");
        }

        public void requestCash(int cashToWithdraw)
        {
            Console.WriteLine("No money.");
        }
    }
}
