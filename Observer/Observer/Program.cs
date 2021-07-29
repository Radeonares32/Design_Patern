using System;
using System.Collections.Generic;

namespace Observer
{
    class Program
    {
        static void Main(string[] args)
        {
            var customer = new CustomerObserver();
            ProductManager productManager = new ProductManager();
            productManager.Attach(customer);
            productManager.Attach(new EmployeeObserver());
            productManager.Detach(customer);
            productManager.Update();
            Console.ReadLine();
        }
    }

    class ProductManager
    {
        private List<Observer> _observers = new List<Observer>();
        public void Update()
        {
            Console.WriteLine(" Product Manager Updated");
            Notify();
        }

        public void Attach(Observer observer)
        {
            _observers.Add(observer);
        }

        public void Detach(Observer observer)
        {
            _observers.Remove(observer);
        }

        private void Notify()
        {
            foreach (var observer in _observers)
            {
                observer.Update();
            }
        }
    }

    abstract class Observer
    {
        public abstract void Update();
    }

    class CustomerObserver:Observer
    {
        public override void Update()
        {
            Console.WriteLine("observer to customer : Updated");
        }
    }

    class EmployeeObserver : Observer
    {
        public override void Update()
        {
            Console.WriteLine("observer to employee : Updated");
        }
    }
}