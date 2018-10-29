using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceSegregationProblem
{
    interface IOrder
    {
        void CalculateShippingCost();
        void ProcessPayment();
        void PlaceOrder();
    }
    class StorePickupOrder : IOrder
    {
        public void CalculateShippingCost()
        {
            throw new NotImplementedException();
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

    class HomeDeliveryOrder : IOrder
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
