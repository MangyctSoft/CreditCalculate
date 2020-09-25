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
        [Required(ErrorMessage = "Поле не может быть пустым.")]
        [Range(500, 5_000_000, ErrorMessage = "Недопустимая сумма кредита.")]
        public decimal Sum { get; set; }
       
        private decimal term;
        /// <summary>
        /// Срок кредита.
        /// </summary>
        [Required(ErrorMessage = "Поле не может быть пустым.")]
        [Range(3, 1_000, ErrorMessage = "Недопустимый срок кредита.")]
        public decimal Term 
        { 
            get => TermCredit == TermCredit.Day ? StacksCredit == StacksCredit.InYear ? term / DAY_OF_MOUNTH : term : term;
            set
            {
                term = value;
            }
        }
        /// <summary>
        /// Срока кредита, для вывода на view.
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
        [Required(ErrorMessage = "Поле не может быть пустым.")]
        [Range(0.05, 1_000, ErrorMessage = "Недопустимая ставка по кредиту.")]
        public decimal Stacks { get; set; }
        /// <summary>
        /// Тип ставки кредита.
        /// </summary>
        [Required]
        public StacksCredit StacksCredit { get; set; } = StacksCredit.InYear;
        /// <summary>
        /// Шаг платежа в днях.
        /// </summary>
        public int StepPayment {get;set;}

    }
}
