using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharingExpenses.Models.DTO.Expenses
{
    public class ExpensesDTO_Edit
    {
        
        public int? Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]        
        public decimal Cost { get; set; }

        [Required]
        public int User { get; set; }

        [Required]
        public int Group { get; set; }
    }
}
