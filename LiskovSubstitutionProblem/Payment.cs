using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiskovSubstitutionProblem
{
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

}
