using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogiData.Web.Models
{
    public class OwnerViewModel
    {
        public Owner EditedOwner { get; set; }
        public List<Owner> OwnersList { get; set; }
    }
}