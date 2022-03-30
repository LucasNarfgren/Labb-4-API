using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Labb4.Models
{
    public class Link
    {
        [Key]
        public int LinkId { get; set; }
        public string URL { get; set; }

        public int InterestId { get; set; }
        public Interest Interest { get; set; }


    }
}
