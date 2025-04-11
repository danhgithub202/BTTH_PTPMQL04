using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoMVC.Models
{
    public class Student
    {
        [Key]
        public required string Id { get; set; }
        public required string FullName { get; set; }
        public string? Address { get; set; }
    }
}