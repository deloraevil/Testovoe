using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Check
{
    internal class User
    {
        public int Id { get; set; }
        [Required]
        public string Fio { get; set; }
        [Required]
        public DateOnly dateOnly { get; set; }
        [Required]
        [MaxLength(1)]
        public string Sex { get; set; }

    }
}
