using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Labb4.Models
{
    public class Interest
    {
        [Key]
        public int InterestId { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }

        public int PersonId { get; set; }
        public Person Person { get; set; }
    }
}
