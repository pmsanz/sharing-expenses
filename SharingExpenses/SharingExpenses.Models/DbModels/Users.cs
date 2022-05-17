using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharingExpenses.Models.DbModels
{
    
    public class Users
    {
        
        public int Id { get; set; }

        public string Name { get; set; }

        public string Lastname { get; set; }

        public ICollection<Groups> Groups { get; set; }

        public ICollection<Expenses> Expenses { get; set; }

        public ICollection<Payments> PaymentsTo { get; set; }


    }
}
