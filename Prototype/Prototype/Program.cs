using System;

namespace Prototype
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer customer = new Customer {id = 1, name = "Buğra", job = "Developer"};
            Customer customer1 = (Customer)customer.Clone();
            customer1.name = "Emre";
            
            Console.WriteLine(customer.name);
            Console.WriteLine(customer1.name);

        }
    }

    public abstract class Person
    {
        public abstract Person Clone();
        public int id { get; set; }
        public string name { get; set; }
    }

    public class Customer : Person
    {
        public string job { get; set; }
        public override Person Clone()
        {
            return (Person) MemberwiseClone();
        }
    }
}