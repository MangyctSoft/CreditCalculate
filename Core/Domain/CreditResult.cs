using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditApplication.Core.Domain
{
    public class CreditResult
    {
        public int Number { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal PaymentBody { get; set; }
        public decimal PaymentPercent { get; set; }
        public decimal Debt { get; set; }
    }
}
