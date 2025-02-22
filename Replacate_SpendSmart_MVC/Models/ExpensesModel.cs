using System.ComponentModel.DataAnnotations;

namespace Replacate_SpendSmart_MVC.Models
{
    public class ExpensesModel
    {
        public int Id { get; set; }
        public decimal Value { get; set; }
        [Required]
        public string Desription { get; set; }

    }
}
