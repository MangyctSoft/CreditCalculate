using CreditApplication.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditApplication.Core.Services
{
    public class CalculateService : ICalculateService
    {
        public IEnumerable<CreditResult> GetCreditResult(Credit credit)
        {
            var result = new List<CreditResult>();

            var k = credit.Stacks / 100 / 12;

            var payment = GetMonthlyPayments(credit.Sum, k, credit.Term);

            var debt = credit.Sum;

            var month = DateTime.Now.Month;
            var year = DateTime.Now.Year;
            int daysOfMounth = 0;

            for (int i = 1; i <= credit.Term; i++)
            {
                daysOfMounth += DateTime.DaysInMonth(year, month);

                var percent = GetPrecentPayments(debt, k);
                var body = GetBodyPayments(payment, percent);

                result.Add(new CreditResult
                {
                    Number = i,
                    PaymentDate = DateTime.Now.AddDays(daysOfMounth),
                    PaymentBody = body,
                    PaymentPercent = percent,
                    Debt = GetDebt(ref debt, body)
                });

                month = month < 13 ? month++ : 1;
                if (month == 1)
                {
                    year++;
                }
            }

            return result;
        }

        /// <summary>
        /// Расчёт аннуитетного платежа по кредиту.
        /// </summary>
        /// <param name="sum">Сумма кредита.</param>
        /// <param name="i">Процентная ставка.</param>
        /// <param name="n">Количество периодов.</param>
        /// <returns></returns>
        private decimal GetMonthlyPayments(decimal sum, decimal i, decimal n)
        {
            decimal x = (decimal)Math.Pow(1 + (double)i, (double)n);
            decimal k = (i * x) / (x - 1);
            return k * sum;
        }

        /// <summary>
        /// Расчёт процентов по аннуитетным платежам.
        /// </summary>
        /// <param name="sP">Сумма текущей задолженности по кредиту.</param>
        /// <param name="i">Процентная ставка.</param>
        /// <returns></returns>
        private decimal GetPrecentPayments(decimal sP, decimal i) => sP * i;

        /// <summary>
        /// Расчёт доли тела кредита в аннуитетных платежах.
        /// </summary>
        /// <param name="pA">Aннуитетный платёж.</param>
        /// <param name="sA">Cумма в аннуитетном платеже.</param>
        /// <returns></returns>
        private decimal GetBodyPayments(decimal pA, decimal sA) => pA - sA;

        /// <summary>
        /// Долг аннуитетных платежей.
        /// </summary>
        /// <param name="sP">Сумма текущей задолженности по кредиту.</param>
        /// <param name="sA">Cумма в аннуитетном платеже.</param>
        /// <returns></returns>
        private decimal GetDebt(ref decimal sP, decimal sA)
        { 
            sP = sP - sA;
            return sP;
        }
    }
}
