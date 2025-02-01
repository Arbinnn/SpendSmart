using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace SpendSmart.Models
{
    public class Expenses
    {
        public int Id { get; set; }
        public  double Value { get; set; }

        [Required]
        public string? description { get; set; }
    }
}

