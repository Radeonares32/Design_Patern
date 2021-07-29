using System;
using System.Collections;
using System.Collections.Generic;

namespace Composite
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee employee1 = new Employee{Name = "Buğra Köseoğlug"};
            Employee employee2 = new Employee{Name = "Emre Köseoğlu"};
            employee1.AddSubordinate(employee2);
            foreach (Employee data in employee1)
            {
                Console.WriteLine(data.Name);
                foreach (var person in data)
                {
                    Console.WriteLine(person.Name);
                }
            }
            Console.ReadLine();
        }
    }

    interface IPerson
    {
        string Name { get; set; }
    }

    class Employee : IPerson,IEnumerable<IPerson>
    {
        private List<IPerson> _subordinates = new List<IPerson>();

        public void AddSubordinate(IPerson person)
        {
            _subordinates.Add(person);
        }
        public void RemoveSubordinate(IPerson person)
        {
            _subordinates.Remove(person);
        }

        public IPerson GetSubordinate(int index)
        {
            return _subordinates[index];
        }
        public string Name { get; set; }
        public IEnumerator<IPerson> GetEnumerator()
        {
            foreach (var subordinate in _subordinates)
            {
                yield return subordinate;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

