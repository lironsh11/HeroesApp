using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Heroes.Models
{
    public class Trainer
    {
        public int ID { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        [RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$", ErrorMessage = "Password must contain atleast one digit, one capital and lower letter, and one special character. Password must be at least 8 characters.")]
        public string Password { get; set; }
    
    }
}
