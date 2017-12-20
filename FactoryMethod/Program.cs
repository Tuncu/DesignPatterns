using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager(new LoogerFactory());
            customerManager.Save();
            Console.ReadLine();
        }
    }
    public class LoogerFactory:ILoggerFactory
    {
        public ILogger CreateLogger()
        {
            //İş geliştirme
            return new LogNetLogger();
        }
    }

    public interface ILoggerFactory
    {
        ILogger CreateLogger();
    }

    public interface ILogger
    {
        void Log();
    }
    public class TuLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged with TuLooger");
        }
    }

    public class LogNetLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged with LogNetLogger");
        }
    }

    public class CustomerManager
    {
        ILoggerFactory _loggerFactory;
        public CustomerManager(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
        }
        public void Save()
        {
            Console.WriteLine("Saved");
            ILogger logger = _loggerFactory.CreateLogger();
            logger.Log();
        }
    }
}
