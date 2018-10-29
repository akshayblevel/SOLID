using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenClosed
{
    public class Checkout
    {
        public virtual double CalculateShippingCost(double orderAmount)
        {
            return orderAmount;
        }
    }

    class Flipkart : Checkout
    {
        public override double CalculateShippingCost(double orderAmount)
        {
            return orderAmount + (orderAmount * 0.10);
        }
    }

    class Amazon : Checkout
    {
        public override double CalculateShippingCost(double orderAmount)
        {
            return orderAmount + (orderAmount * 0.05);
        }
    }
}
