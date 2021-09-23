# SOLID
SOLID Principles

*Single Responsibility Principle*

Problem:

```csharp
class Order
    {
        public Order()
        { }

        public void PlaceOrder()
        {
            try
            {
                // Place order code goes here
                SendMail();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void SendMail()
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
```

Solution:

```csharp
 class Mail
    {

        public static void SendMail()
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
```

*Open Closed Principle*

Problem:

```csharp
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
```

Solution:

```csharp
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
```

*Liskov Substitution Principle*

Problem:

```csharp
abstract class Payment
    {
        public abstract void CheckBalance();

        public abstract void DeductAmount();

        public abstract void ProcessTransaction();

    }

    class Paypal : Payment
    {
        public override void CheckBalance()
        {
            Console.WriteLine("CheckBalance Method Called");
        }

        public override void DeductAmount()
        {
            Console.WriteLine("DeductAmount Method Called");
        }

        public override void ProcessTransaction()
        {
            Console.WriteLine("ProcessTransaction Method Called");
        }
    }

    class COD : Payment
    {
        public override void CheckBalance()
        {
            throw new NotImplementedException();
        }

        public override void DeductAmount()
        {
            throw new NotImplementedException();
        }

        public override void ProcessTransaction()
        {
            Console.WriteLine("ProcessTransaction Method Called");
        }
    }
```

Solution:

```csharp
abstract class Payment
    {
        public abstract void ProcessTransaction();

    }

    interface IPayment
    {
        void CheckBalance();
        void DeductAmount();
    }

    class Paypal : Payment,IPayment
    {
        public void CheckBalance()
        {
            Console.WriteLine("CheckBalance Method Called");
        }

        public void DeductAmount()
        {
            Console.WriteLine("DeductAmount Method Called");
        }

        public override void ProcessTransaction()
        {
            Console.WriteLine("ProcessTransaction Method Called");
        }
    }

    class COD : Payment
    {
        public override void ProcessTransaction()
        {
            Console.WriteLine("ProcessTransaction Method Called");
        }
    }
```

*Interface Segregation Principle*

Problem:

```csharp
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
```

Solution:

```csharp
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
```

*Dependency Inversion Principle*

```csharp
 class Mail
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
```

Solution:

```csharp
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
```
