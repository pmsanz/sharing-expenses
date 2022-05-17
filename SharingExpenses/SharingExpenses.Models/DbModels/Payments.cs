using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharingExpenses.Models.DbModels
{

    
    public class Payments
    {

       
        public int Id { get; set; }
        
        public int ToUserId { get; set; }
        
        public int GroupId { get; set; }

        [Column(TypeName = "decimal(5, 2)")]
        public decimal? Amount { get; set; }
                
        public Users ToUser { get; set; }
        
        public Groups Group { get; set; }

    }
}
