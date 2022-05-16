using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SharingExpenses.Models.DbModels
{
    
    public class Expenses
    {

        public int Id { get; set; }
        public int OwnerId { get; set; }
        public int GroupId { get; set; }

        [Column(TypeName = "decimal(5, 2)")]
        public decimal Cost { get; set; }
        public Users Owner { get; set; }
        public Groups Group { get; set; }
    }
}
