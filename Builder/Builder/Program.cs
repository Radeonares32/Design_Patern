using System;

namespace Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            var customer = new NewCustomer();
            Builder builderData = new Builder();
            builderData.BuilderData(customer);
            var model = customer.Data();
            Console.WriteLine(model.Id);

        }
    }

    class ProductView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Discount { get; set; }
        public decimal DiscountNumber { get; set; }
    }

    abstract class Customer
    {
        public abstract void GetData();
        public abstract ProductView Data();
    }

    class NewCustomer : Customer
    {
        private ProductView model = new ProductView();
        public override void GetData()
        {
            model.Id = 1;
            model.Name = "Buğra";
            model.Discount = true;
            model.DiscountNumber = 1 * (decimal) 0.95;
        }

        public override ProductView Data()
        {
            return model;
        }
    }
    class OldCustomer : Customer
    {
        private ProductView model = new ProductView();
        public override void GetData()
        {
            model.Id = 2;
            model.Name = "Osman";
            model.Discount = false;
        }

        public override ProductView Data()
        {
            return model;
        }
    }

    class Builder
    {
        public void BuilderData(Customer customer)
        {
            customer.GetData();
        }
    }
}