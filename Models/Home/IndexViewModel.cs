using CreditApplication.Core.Domain;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditApplication.Models.Home
{
    public class IndexViewModel
    {
        public IEnumerable<SelectListItem> TermTypes { get; set; }
        public IEnumerable<SelectListItem> StacksTypes { get; set; }
    }
}
