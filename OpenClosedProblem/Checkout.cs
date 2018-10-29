using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenClosedProblem
{
    class Checkout
    {
        private string merchant;

        public string Merchant
        {
            get { return merchant; }
            set { merchant = value; }
        }

        public double CalculateShippingCost(double orderAmount)
        {
            double shippingCost = 0;
            switch (merchant)
            {
                case "Flipkart":
                    shippingCost= orderAmount + (orderAmount * 0.10);
                    break;
                case "Amazon":
                    shippingCost = orderAmount + (orderAmount * 0.05);
                    break;
                default:
                    break;
            }
            return shippingCost;
        }

    }
}
