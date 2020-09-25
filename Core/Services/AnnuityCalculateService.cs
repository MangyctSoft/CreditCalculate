using CreditApplication.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditApplication.Core.Services
{
    /// <summary>
    /// Сервис кредитный калькулятор.
    /// </summary>
    public class AnnuityCalculateService : ICalculateService
    {
        /// <summary>
        /// Расчет кредита с годовой ставкой ежемесячно.
        /// </summary>
        /// <param name="credit">Данные по кредиту.</param>
        public IEnumerable<CreditResult> GetCreditMounthResult(Credit credit)
        {
            var result = new List<CreditResult>();           
          
            var k = credit.Stacks / 100 / credit.Term;
           
            var payment = GetMonthlyPayments(credit.Sum, k, credit.Term);

            var debt = credit.Sum;

            var month = DateTime.Now.Month;
            var year = DateTime.Now.Year;
            int daysOfMounth = 0;

            var term = Math.Ceiling(credit.Term);

            for (int i = 1; i <= term; i++)
            {
                daysOfMounth += DateTime.DaysInMonth(year, month);

                var percent = GetPrecentPayments(debt, k);
                var body = GetBodyPayments(payment, percent);
                debt = GetDebt(debt, body);

                if (debt < 0)
                {
                    body += debt;
                    debt = 0;
                }

                result.Add(new CreditResult
                {
                    Number = i,
                    PaymentDate = DateTime.Now.AddDays(daysOfMounth),
                    PaymentBody = body,
                    PaymentPercent = percent,
                    Debt = debt
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
        /// Расчет кредита с ежедневной ставкой по указанному периоду платежа.
        /// </summary>
        /// <param name="credit">Данные по кредиту.</param>
        public IEnumerable<CreditResult> GetCreditDaysResult(Credit credit)
        {
            var temp = new List<CreditResult>();

            var k = credit.Stacks / 100;
            var term = credit.TermCredit == TermCredit.Month ? credit.Term * 30 : credit.Term;
            var payment = GetMonthlyPayments(credit.Sum, k, term);

            var debt = credit.Sum;           

            for (int i = 1; i <= term; i++)
            {
                var percent = GetPrecentPayments(debt, k);
                var body = GetBodyPayments(payment, percent);
                debt = GetDebt(debt, body);

                if (debt < 0)
                {
                    body += debt;
                    debt = 0;
                }

                temp.Add(new CreditResult
                {
                    Number = i,
                    PaymentDate = DateTime.Now.AddDays(i),
                    PaymentBody = body,
                    PaymentPercent = percent,
                    Debt = debt
                });
            }

            var results = new List<CreditResult>();
            temp.OrderBy(o => o.Number);
            int count = 1;
            int skip = 0;

            debt = credit.Sum;

            foreach (var item in temp)
            {
                if (item.Number % credit.StepPayment == 0 || item.Number == temp.Count)
                {
                    var percent = temp.Skip(skip).Take(credit.StepPayment).Sum(s => s.PaymentPercent);
                    var body = temp.Skip(skip).Take(credit.StepPayment).Sum(s => s.PaymentBody);
                    debt = GetDebt(debt, body);

                    results.Add(new CreditResult
                    {
                        Number = count,
                        PaymentDate = DateTime.Now.AddDays(skip),
                        PaymentBody = body,
                        PaymentPercent = percent,
                        Debt = debt
                    });
                    skip += credit.StepPayment;
                    count++;
                };

            }

            return results;
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
        private decimal GetDebt(decimal sP, decimal sA)
        { 
            sP = sP - sA;
            return sP;
        }
    }
}
