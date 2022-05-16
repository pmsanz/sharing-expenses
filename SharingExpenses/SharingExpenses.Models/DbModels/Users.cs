using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharingExpenses.Models.DbModels
{
    [Table("User", Schema = "Config")]
    public class Users
    {
        
        [Key]
        public int Id { get; set; }

        
        [Required]
        public string Name { get; set; }

        
        [Required]
        public string Lastname { get; set; }


    }
}
