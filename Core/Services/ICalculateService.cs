using CreditApplication.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditApplication.Core.Services
{
    public interface ICalculateService
    {
        IEnumerable<CreditResult> GetCreditMounthResult(Credit credit);
        IEnumerable<CreditResult> GetCreditDaysResult(Credit credit);
    }
}
