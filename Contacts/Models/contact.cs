using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Contacts.Models 
{
    public class Contact   
    {

        public int id { get; set; }

        [Required]
        public string name { get; set; }
        [Required]
        public string phoneno { get; set; }

        public string email { get; set; }
        public string houseno { get; set; }
    }
}