using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace AdidasNew.Models.DomainModels
{


    public  class RelationShip
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [DisplayName("نام و نام خانوادگی")]
        [Display(Name = "نام و نام خانوادگی")]
        public string Name { get; set; }
        [DisplayName("نسبت ")]
        [Display(Name = "نسبت ")]
        public string Relational { get; set; }
        [DisplayName("تلفن ")]
        [Display(Name = "تلفن ")]
        public string Tell { get; set; }
        [DisplayName("آدرس ")]
        [Display(Name = "آدرس ")]
        public string Address { get; set; }

        [DisplayName("معرف ")]
        [Display(Name = "معرف ")]
        public bool Moaref { get; set; }

        public  int Person_FK { get; set; }
        [ForeignKey(" Person_FK")]
        public virtual Person Person { get; set; }

    }
}
