using System;
using System.Threading;

namespace Proxy
{
    class Program
    {
        static void Main(string[] args)
        {
            CreditBase manager = new CreditManagerProxy();
           var data = manager.Calculate();
            var data1 = manager.Calculate();
            Console.WriteLine(data);
            Console.WriteLine(data1);
            Console.ReadLine();

        }
    }

    abstract class CreditBase
    {
        public abstract int Calculate();
    }

    class CreditManager : CreditBase
    {
        public override int Calculate()
        {
            int result = 1;
            for (int i = 1; i < 5; i++)
            {
                result *= i;
                Thread.Sleep(1000);
            }

            return result;
        }
    }

    class CreditManagerProxy : CreditBase
    {
        private CreditManager _creditManager;
        private int _cachedvValue;
        public override int Calculate()
        {
            if (_creditManager == null)
            {
                _creditManager = new CreditManager();
                _cachedvValue = _creditManager.Calculate();
            }

            return _cachedvValue;
        }
    }
}