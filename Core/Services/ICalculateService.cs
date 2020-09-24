using CreditApplication.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditApplication.Core.Services
{
    public interface ICalculateService
    {
        IEnumerable<CreditResult> GetCreditResult(Credit credit);
    }
}
