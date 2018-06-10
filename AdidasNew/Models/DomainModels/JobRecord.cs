using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using System.Linq;
using System.Web;


namespace AdidasNew.Models.DomainModels
{


    public  class JobRecord
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [DisplayName("نام موسسه")]
        [Display(Name = "نام موسسه")]
        public string Company { get; set; }
        [DisplayName(" سمت کاری/نوع همکاری")]
        [Display(Name = "سمت کاری/نوع همکاری")]
        public string Title { get; set; }
        [DisplayName(" مدت اشتغال")]
        [Display(Name = "مدت اشتغال")]
        public string Duration { get; set; }
        [DisplayName(" علت قطع همکاری")]
        [Display(Name = "علت قطع همکاری")]
        public string Disconnection { get; set; }
        [DisplayName("آدرس")]
        [Display(Name = "آدرس")]
        public string Address { get; set; }
        [DisplayName("تلفن")]
        [Display(Name = "تلفن")]
        public string Tell { get; set; }

        public int Person_FK { get; set; }
        [ForeignKey(" Person_FK")]
        public virtual Person Person { get; set; }
    }
}
