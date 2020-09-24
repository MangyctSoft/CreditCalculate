using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace CreditApplication.Core.Domain
{
    /// <summary>
    /// Модель калькулятора.
    /// </summary>
    public class Credit
    {
        private const int DAY_OF_MOUNTH = 30;

        /// <summary>
        /// Сумма кредита.
        /// </summary>
        [Required]
        public decimal Sum { get; set; }
       
        private decimal term;
        /// <summary>
        /// Срок кредита.
        /// </summary>
        [Required]
        public decimal Term 
        { 
            get 
            {
                return TermCredit == TermCredit.Day ? term / DAY_OF_MOUNTH : term;
            } 
            set
            {
                term = value;
            }
        }
        /// <summary>
        /// Срока кредита, для вывода во вью.
        /// </summary>
        public string TermText
        {
            get
            {
                return term.ToString();
            }            
        }
        /// <summary>
        /// Тип срока кредита.
        /// </summary>
        [Required]
        public TermCredit TermCredit { get; set; } = TermCredit.Month;
        /// <summary>
        /// Ставка кредита.
        /// </summary>
        [Required]
        public decimal Stacks { get; set; }
        /// <summary>
        /// Тип ставки кредита.
        /// </summary>
        [Required]
        public StacksCredit StacksCredit { get; set; }
        /// <summary>
        /// Шаг платежа в днях.
        /// </summary>
        public int StepPayment {get;set;}

    }
}
