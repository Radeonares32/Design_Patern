using System;

namespace Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            var PersonalCar = new PersonelCar{Marka = "BMW",Model = "Bmw3",Price = 2500};
            var decorator = new SpecialOffer(PersonalCar);
            decorator.Discount = 10;
            
            Console.WriteLine("SpecialOffer {0}",decorator.Price);
            Console.WriteLine("PersonalCar {0}",PersonalCar.Price);
            
        }
    }

    abstract class CarBase
    {
        public abstract string Marka { get; set; }
        public abstract string Model { get; set; }
        public abstract decimal Price { get; set; }
    }

    class PersonelCar : CarBase
    {
        public override string Marka { get; set; }
        public override string Model { get; set; }
        public override decimal Price { get; set; }
    }
    class CommercialCar : CarBase
    {
        public override string Marka { get; set; }
        public override string Model { get; set; }
        public override decimal Price { get; set; }
    }

    abstract class CarDecorator : CarBase
    {
        private CarBase _carBase;

        protected CarDecorator(CarBase carBase)
        {
            _carBase = carBase;
        }
    }

    class SpecialOffer : CarDecorator
    {
        public  decimal Discount { get; set; }
        private CarBase _carBase;
        public SpecialOffer(CarBase carBase) : base(carBase)
        {
            _carBase = carBase;
        }

        public override string Marka { get; set; }
        public override string Model { get; set; }

        public override decimal Price
        {
            get
            {
                return _carBase.Price - (_carBase.Price * Discount)/100;
            }
            set
            {
                
            }
        }
    }
}