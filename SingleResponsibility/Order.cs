using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleResponsibility
{
    class Order
    {
        public Order()
        { }

        public void PlaceOrder()
        {
            try
            {
                // Place order code goes here
                Mail.SendMail();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
