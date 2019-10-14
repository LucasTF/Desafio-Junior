using System;
using System.ComponentModel.DataAnnotations;

namespace OrbiumDesafioRH.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Job { get; set; }
        public double Salary { get; set; }
        [DataType(DataType.Date)]
        public DateTime HiringDate { get; set; }
    }
}
