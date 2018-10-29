using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInversionProblem
{
    class Order
    {
        Mail mail = new Mail();
        public Order()
        { }

        public void PlaceOrder()
        {
            try
            {
                // Place order code goes here
                mail.SendMail();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
