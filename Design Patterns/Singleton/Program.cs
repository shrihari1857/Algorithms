using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    //Singleton Cache-Aside Pattern
    class Program
    {
        static void Main(string[] args)
        {
            var instance1 = Singleton.GetInstance;
            instance1.GetData().ForEach(x => Console.WriteLine(x));

            var instance2 = Singleton.GetInstance;
            instance2.GetData().ForEach(x => Console.WriteLine(x));

            Console.ReadLine();
        }
    }

    //this class can be sealed to to prevent it from inheriting it to some derived class, this is necessary since it'll error due to private constructor
    public class Singleton
    {
        private static Singleton _instance = null;
        private const int mins = -2;
        private ConcurrentBag<Data> _data;
        private static object _lock = new object();

        private Singleton()
        {
            _data = new ConcurrentBag<Data>();
        }
        public static Singleton GetInstance
        {
            get
            {
                //thread safe
                lock (_lock)
                {
                    if (_instance == null)
                        _instance = new Singleton();

                    _instance.EnsureCacheIntegrity();   //ensure cache is maintened for 2 mins only

                    return _instance; 
                }
            }
        }

        private void EnsureCacheIntegrity()
        {
            try
            {
              _data = new ConcurrentBag<Data>(_data.TakeWhile(x => x.date > DateTime.Now.AddMinutes(mins)));
            }
            catch (Exception)
            {

                _data = new ConcurrentBag<Data>();
            }
        }

        public List<string> GetData()
        {
            if (!_data.Any())
                GetDataFromDataSource();    //if the cache has removed the data since the time has elapsed, get fresh data fron the store

            return _data.FirstOrDefault().list;
        }

        private void GetDataFromDataSource()
        {
            _data.Add(
                new Data
                {
                    list = 
                        new List<string>
                        {
                            "Test1",
                            "Test2"
                        },
                    date = DateTime.Now
                });
        }
    }

    public class Data
    {
        public List<string> list { get; set; }
        public DateTime date { get; set; }
    }


}
