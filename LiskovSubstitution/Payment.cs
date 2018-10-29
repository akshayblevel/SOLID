using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiskovSubstitution
{
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
}
