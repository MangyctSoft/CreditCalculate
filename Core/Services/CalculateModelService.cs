﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditApplication.Core.Services
{
    public class CalculateModelService : ICalculateModelService
    {
        public IEnumerable<SelectListItem> GetStacksType() => new List<SelectListItem>
        {
            new SelectListItem
            {
                Value = "1",
                Text = "Ставка в год"
            },
            new SelectListItem
            {
                Value = "2",
                Text = "Ставка в день"
            }
        };        

        public IEnumerable<SelectListItem> GetTermType() => new List<SelectListItem>
        {
            new SelectListItem
            {
                Value = "1",
                Text = "Месяцы"
            },
            new SelectListItem
            {
                Value = "2",
                Text = "Дни"
            }
        };

        public IEnumerable<SelectListItem> GetStepPaymentType() => new List<SelectListItem>
        {
            new SelectListItem
            {
                Value = "10",
                Text = "Каждые 10 дней"
            },
            new SelectListItem
            {
                Value = "15",
                Text = "Каждые 15 дней"
            }
        };
    }
}
