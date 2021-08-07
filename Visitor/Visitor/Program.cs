using System;
using System.Collections.Generic;
using System.Globalization;

namespace Visitor
{
    class Program
    {
        static void Main(string[] args)
        {
            Manager bugra = new Manager
            {
                Name = "Buğra",Salary = 1500
            };
            Manager emre = new Manager
            {
                Name = "Emre", Salary = 2000
            };
            Worker ahmet = new Worker
            {
                Name = "Ahmet", Salary = 800
            };
            Worker ali = new Worker
            {
                Name = "Ali",Salary = 800
            };
            bugra.Subordinates.Add(emre);
            emre.Subordinates.Add(ahmet);
            emre.Subordinates.Add(ali);

            OrganisationalStructure organisationalStructure = new OrganisationalStructure(bugra);
            PayrollVisitor payrollVisitor = new PayrollVisitor();
            Payrise payrise = new Payrise();
            organisationalStructure.Accept(payrollVisitor);
            organisationalStructure.Accept(payrise);
            Console.ReadLine();


        }
    }

    class OrganisationalStructure
    {
        public EmployeeBase Employee;

        public OrganisationalStructure(EmployeeBase firstEmployee)
        {
            Employee = firstEmployee;
        }

        public void Accept(VisitorBase visitor)
        {
            Employee.Accept(visitor);
        }
    }

  abstract  class EmployeeBase
  {
      public abstract void Accept(VisitorBase visitorBase);
      public string Name { get; set; }
      public decimal Salary { get; set; }
  }

  class Manager:EmployeeBase
  {
      public Manager()
      {
          Subordinates = new List<EmployeeBase>();
      }
      public List<EmployeeBase> Subordinates { get; set; }
      public override void Accept(VisitorBase visitorBase)
      {
          visitorBase.Visit(this);
          foreach (var employeeBase in Subordinates)
          {
              employeeBase.Accept((visitorBase));
          }
      }
  }

  class Worker:EmployeeBase
  {
      public override void Accept(VisitorBase visitorBase)
      {
          visitorBase.Visit(this);
      }
  }
    abstract class VisitorBase
    {
        public abstract void Visit(Worker worker);
        public abstract void Visit(Manager manager);
    }

    class PayrollVisitor : VisitorBase
    {
        public override void Visit(Worker worker)
        {
            Console.WriteLine("{0} paid {1}",worker.Name,worker.Salary);
        }

        public override void Visit(Manager manager)
        {
            Console.WriteLine("{0} paid {1}",manager.Name,manager.Salary);
        }
    }

    class Payrise : VisitorBase
    {
        public override void Visit(Worker worker)
        {
            Console.WriteLine("{0} salary increased to {1}",worker.Name,worker.Salary*(decimal)1.1);
        }

        public override void Visit(Manager manager)
        {
            Console.WriteLine("{0} salary increased to {1}",manager.Name,manager.Salary*(decimal)1.2);
        }
    }
}
