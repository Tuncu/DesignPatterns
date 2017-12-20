using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            var customerManager=CustomerManager.CreateAsSingleton();
            customerManager.Save();
        }
    }
    class CustomerManager
    {
        private static CustomerManager _customerManager;
        private CustomerManager()
        {

        }

        public static CustomerManager CreateAsSingleton()
        {         
            return _customerManager ?? (_customerManager = new CustomerManager());
        }

        //test
        public void Save()
        {
            Console.WriteLine("Kaydedildi");
        }
    }

    //multi-thread de kimi zaman aynı anda üretilebiliyor
    class CustomerManager1
    {
        private static CustomerManager1 _customerManager1;
        static object _lockObject = new object();
        private CustomerManager1()
        {

        }

        public static CustomerManager1 CreateAsSingleton()
        {
            lock (_lockObject)
            {
                if (_customerManager1==null)
                    _customerManager1 = new CustomerManager1();      
            }
            return _customerManager1;
        }

        //test
        public void Save()
        {
            Console.WriteLine("Kaydedildi");
        }
    }
}
