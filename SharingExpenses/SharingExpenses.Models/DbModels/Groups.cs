using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharingExpenses.Models.DbModels
{
    
    public class Groups
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal TotalCost { get; set; }
        public ICollection<Users> Users { get; set; }
        public ICollection<Expenses> Expenses { get; set; }
        public ICollection<Payments> Payments { get; set; }


    }
}
