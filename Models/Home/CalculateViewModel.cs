using CreditApplication.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditApplication.Models.Home
{
    public class CalculateViewModel
    {
        public Credit Credit { get; set; }
        public IEnumerable<CreditResult> CreditResults { get; set; }
    }
}
