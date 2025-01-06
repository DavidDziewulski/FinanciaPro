using System.ComponentModel.DataAnnotations;

namespace RazorNet.Models
{
    public class Person
    {
        public int Id { get; set; }
        
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
        
        [Required]
        public string Position { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Amount { get; set; }
    }
}