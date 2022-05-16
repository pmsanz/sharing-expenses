using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharingExpenses.Models.DTO.Expenses
{
    public class ExpensesDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public decimal Cost { get; set; }

        public string User { get; set; }

        public string Group { get; set; }

    }
}
