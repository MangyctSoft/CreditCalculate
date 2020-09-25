using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditApplication.Core.Services
{
    public interface ICalculateModelService
    {
        IEnumerable<SelectListItem> GetTermType();
        IEnumerable<SelectListItem> GetStacksType();
        IEnumerable<SelectListItem> GetStepPaymentType();
    }
}
