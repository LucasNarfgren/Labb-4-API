using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Labb4.Models
{
    public class Person
    {
        [Key]
        public int PersonId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Adress { get; set; }
        public string Phone { get; set; }
        
        public ICollection<Interest> Interests { get; set; }
    }
}
