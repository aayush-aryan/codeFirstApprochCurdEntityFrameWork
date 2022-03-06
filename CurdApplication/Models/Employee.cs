using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CurdApplication.Models
{
    public class Employee
    {
        
        public int Id { get; set; }
        [Required(ErrorMessage ="Enter valid Name")]
        public string Name { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public decimal Salary { get; set; }


    }
}
