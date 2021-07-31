using System;
using System.Collections.Generic;

namespace Command
{
    class Program
    {
        static void Main(string[] args)
        {
            StockManager stockManager = new StockManager();
            BuyStock buyStock = new BuyStock(stockManager);
            SellStock sellStock = new SellStock(stockManager);
            StockController stockController = new StockController();
            stockController.TakeOrder(buyStock);
            stockController.TakeOrder(sellStock);
            stockController.PlaceOrder();

        }
    }

    class StockManager
    {
        private string name = "PC";
        private int quantity = 20;

        public void Buy()
        {
            Console.WriteLine("Bought");
        }

        public void Sell()
        {
            Console.WriteLine("Sold");
        }
    }

    interface IOrder
    {
        void Execute();
    }

    class BuyStock : IOrder
    {
        private StockManager _stockManager;

        public BuyStock(StockManager stockManager)
        {
            _stockManager = stockManager;
        }

        public void Execute()
        {
            _stockManager.Buy();
        }
    }
    class SellStock : IOrder
    {
        private StockManager _stockManager;

        public SellStock(StockManager stockManager)
        {
            _stockManager = stockManager;
        }

        public void Execute()
        {
            _stockManager.Sell();
        }
    }

    class StockController
    {
        private List<IOrder> _orders = new List<IOrder>();

        public void TakeOrder(IOrder order)
        {
            _orders.Add(order);
        }

        public void PlaceOrder()
        {
            foreach (var order in _orders)
            {
                order.Execute();
            }
            _orders.Clear();
        }
    }
}