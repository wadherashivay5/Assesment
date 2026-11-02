using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions
{
    internal class Q28
    {
        public class DeliveryService
        {
             
             public virtual Charge()
            {

            }

        }
        public class StandardDelivery : DeliveryService
        {
           base.Charge();
        }
        public class ExpressDelivery : DeliveryService
        {

        }
    }
}
