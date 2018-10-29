using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceSegregation
{
    interface IShippingCost
    {
        void CalculateShippingCost();
    }
    interface IOrder
    {
        void ProcessPayment();
        void PlaceOrder();
    }

    class StorePickupOrder : IOrder
    {
        public void PlaceOrder()
        {
            Console.WriteLine("PlaceOrder Method is Called");
        }

        public void ProcessPayment()
        {
            Console.WriteLine("ProcessPayment Method is Called");
        }
    }

    class HomeDeliveryOrder : IShippingCost,IOrder
    {
        public void CalculateShippingCost()
        {
            Console.WriteLine("CalculateShippingCost Method is Called");
        }
        public void PlaceOrder()
        {
            Console.WriteLine("PlaceOrder Method is Called");
        }

        public void ProcessPayment()
        {
            Console.WriteLine("ProcessPayment Method is Called");
        }
    }

}
