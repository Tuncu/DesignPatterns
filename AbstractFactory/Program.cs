using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new Factory2());
            productManager.GetAll();
        }
    }

    public abstract class Logging
    {
        public abstract void Log(string message);
    }
    public class LogNet : Logging
    {
        public override void Log(string message)
        {
            Console.WriteLine("LogNet tarafından loglandı");
        }
    }
    public class NLogger : Logging
    {
        public override void Log(string message)
        {
            Console.WriteLine("Nlogger tarafından loglandı");
        }
    }

    public abstract class Caching
    {
        public abstract void Cache(string data);
    }

    public class MemCache : Caching
    {
        public override void Cache(string data)
        {
            Console.WriteLine("MemCache tarafından keşlendi");
        }
    }
    public class TuncCache : Caching
    {
        public override void Cache(string data)
        {
            Console.WriteLine("TuncCache tarafından cashlendi");
        }
    }

    public abstract class CrossConcernsFactory
    {
        public abstract Logging CreateLogger();
        public abstract Caching CreateCaching();
    }

    public class Factory1 : CrossConcernsFactory
    {



        public override Caching CreateCaching()
        {
            return new MemCache();
        }

        public override Logging CreateLogger()
        {
            return new LogNet();
        }
    }

    public class Factory2 : CrossConcernsFactory
    {



        public override Caching CreateCaching()
        {
            return new TuncCache();
        }

        public override Logging CreateLogger()
        {
            return new NLogger();
        }
    }

    public class ProductManager
    {
        private CrossConcernsFactory _crossConcernsFactory;
        private Logging _logging;
        private Caching _caching;

        public ProductManager(CrossConcernsFactory crossConcernsFactory)
        {
            _crossConcernsFactory = crossConcernsFactory;
            _logging = crossConcernsFactory.CreateLogger();
            _caching = crossConcernsFactory.CreateCaching();
            
        }

        public void GetAll()
        {
            _logging.Log("Logged");
            _caching.Cache("Data");
            Console.WriteLine("Ürün listesi");
        }
    }
}
