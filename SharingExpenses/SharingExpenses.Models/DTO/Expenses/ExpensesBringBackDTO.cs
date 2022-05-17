using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharingExpenses.Models.DTO.Expenses
{
    public class ExpensesBringBackDTO
    {

        public string User { get; set; }

        public decimal Must_Receive { get; set; }

        public decimal Must_Pay { get; set; }


    }
}
