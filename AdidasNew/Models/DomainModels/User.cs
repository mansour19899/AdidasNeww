using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdidasNew.Models.DomainModels
{
    public class User
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string Role { get; set; }

        public bool Enabled { get; set; }

        public DateTime Expired { get; set; }
    }
}