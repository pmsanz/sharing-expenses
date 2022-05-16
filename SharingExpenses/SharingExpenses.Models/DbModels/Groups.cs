using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharingExpenses.Models.DbModels
{
    [Table("Groups", Schema = "SharingExpenses") ]
    public class Groups
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
                
        public virtual ICollection<Users> Users { get; set; }

        public virtual ICollection<Expenses> Expenses { get; set; }

        public virtual ICollection<Payments> Payments { get; set; }


    }
}
