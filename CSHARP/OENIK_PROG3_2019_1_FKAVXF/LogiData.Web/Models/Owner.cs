using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LogiData.Web.Models
{
    // Form Model
    public class Owner
    {
        [Display(Name = "Owner ID")]
        [Required]
        public int ID { get; set; }

        [Display(Name = "Owner Name")]
        public string Name { get; set; }

        [Display(Name = "Location")]
        public string City { get; set; }

        [Display(Name = "First Year")]
        public int StartYear { get; set; }

        [Display(Name = "Paid For This Year")]
        public bool HasPaidThisYear { get; set; }

        [Display(Name = "Owner Is Replaceable")]
        public bool IsReplaceable { get; set; }
    }
}