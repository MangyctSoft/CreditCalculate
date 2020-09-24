using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditApplication.Core.Domain
{
    /// <summary>
    /// Модель калькулятора.
    /// </summary>
    public class Credit
    {
        /// <summary>
        /// Сумма кредита.
        /// </summary>
        public decimal Sum { get; set; }
        /// <summary>
        /// Срок кредита.
        /// </summary>
        public int Term{ get; set; }
        /// <summary>
        /// Тип срока кредита.
        /// </summary>
        public TermCredit TermCredit { get; set; }
        /// <summary>
        /// Ставка кредита.
        /// </summary>
        public decimal Stacks { get; set; }
        /// <summary>
        /// Тип ставки кредита.
        /// </summary>
        public StacksCredit StacksCredit { get; set; }
    }
}
