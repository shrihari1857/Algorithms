using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterator
{
    /*
     Referece : https://www.tutorialspoint.com
        Typical pattern to iterate through lists
         
         */
    class Program
    {
        static void Main(string[] args)
        {

            var namesRepository = new NameRepository();
            for (IIterator iter = namesRepository.getIterator(); iter.hasNext();)
            {
                var name = iter.next().ToString();
                Console.WriteLine($"Name: {name}");
            }

            Console.ReadLine();
        }
    }

    //interface should have these 2 basic method definitions
    public interface IIterator
    {
        bool hasNext();
        object next();
    }


    public interface IContainer
    {
        IIterator getIterator();
    }

    public class NameRepository : IContainer
    {
        public string[] names = new string[]{ "Robert", "John", "Julie", "Lora" };
        public IIterator getIterator()
        {
            return new NameIterator(this);
        }

        private class NameIterator : IIterator
        {
            private readonly NameRepository nameRepository;
            int index;

            public NameIterator(NameRepository _nameRepository)
            {
                nameRepository = _nameRepository;
            }

            public bool hasNext()
            {
                if (index < nameRepository.names.Length)
                    return true;

                return false;
            }

            public object next()
            {
                if (this.hasNext())
                    return nameRepository.names[index++];

                return null;
            }
        }
    }
}
