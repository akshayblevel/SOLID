using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInversion
{
    interface IMail
    {
        void SendMail();
    }
    class Mail : IMail
    {
        public void SendMail()
        {
            MailMessage mail = new MailMessage("akshay@dotnetbees.com", "akshayblevel@gmail.com");
            SmtpClient client = new SmtpClient();
            client.Port = 25;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Host = "smtp.gmail.com";
            mail.Subject = "Order Confirmation";
            mail.Body = "Order is placed successfully";
            client.Send(mail);
        }
    }
}
