using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SharingExpenses.Models.DbModels
{
    [Table("Expenses", Schema = "SharingExpenses")]
    public class Expenses
    {

        [Key]
        public int Id { get; set; }
        [Required]
        public int OwnerId { get; set; }

        [Column(TypeName = "decimal(5, 2)")]
        public decimal Cost { get; set; }
        
        [ForeignKey(nameof(OwnerId))]
        public Users Owner { get; set; }
    }
}
