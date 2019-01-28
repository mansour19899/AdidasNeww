﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdidasNew.Models.DomainModels
{
    public class Question
    {
        [Key]
        public int Id { get; set; }

  
        [MaxLength(200)]
        public string question { get; set; }

        public int Level { get; set; }

        public int TypeQuestion { get; set; }




    }
}