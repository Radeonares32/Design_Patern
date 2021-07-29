using System;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            var customerManager = CustomerManager.CustomerManagerAsSingleton();
            customerManager.Save();

        }
    }
    class CustomerManager{
        private static CustomerManager _customerManager;
        private static object _lock = new object();
        private CustomerManager() {
        }
        public static CustomerManager CustomerManagerAsSingleton() {
            lock (_lock)
            {
                if (_customerManager == null)
                {
                    _customerManager = new CustomerManager();
                }   
            };
            return _customerManager;
        }
        public void Save() {
            Console.WriteLine("Save");
        }
    }
}
