using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Heroes.Models
{
    public class Heroe
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Abilty { get; set; }
        [Required]
        public int GuideID { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public string SuiteColors { get; set; }
        [Required]
        public decimal StartingPower { get; set; }
        [Required]
        public decimal CurrentPower { get; set; }
    }
}
