using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInversion
{
    class Order
    {
        IMail mail;
        public Order(IMail mail)
        {
            this.mail = mail;
        }

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
