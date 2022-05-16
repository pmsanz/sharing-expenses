using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharingExpenses.Models.DbModels
{

    [Table("Payments", Schema = "SharingExpenses")]
    public class Payments
    {

        [Key]
        public int Id { get; set; }
        [Required]
        public int FromUserId { get; set; }
        [Required]
        public int ToUserId { get; set; }

        [Column(TypeName = "decimal(5, 2)")]
        public decimal? Amount { get; set; }

        [ForeignKey(nameof(FromUserId))]
        public Users FromUser { get; set; }

        [ForeignKey(nameof(ToUserId))]
        public Users ToUser { get; set; }

    }
}
