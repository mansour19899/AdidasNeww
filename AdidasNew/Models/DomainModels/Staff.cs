using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AdidasNew.Models.DomainModels
{
    public class Staff
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [DisplayName("تاریخ شروع همکاری ")]
        [Display(Name = "تاریخ شروع همکاری ")]
        [Required(ErrorMessage = "لطفا  {0}   را وارد کنید")]
        public Nullable<System.DateTime> StartWork { get; set; }

        [DisplayName("تاریخ خاتمه همکاری ")]
        [Display(Name = "تاریخ خاتمه همکاری ")]
        [Required(ErrorMessage = "لطفا  {0}   را وارد کنید")]
        public Nullable<System.DateTime> EndWork { get; set; }

        public int Person_FK { get; set; }
        public int? Person_PFK { get; set; }

        [ForeignKey(" Person_FK")]
        public virtual Person Person { get; set; }

        [ForeignKey(" Person_PFK")]
        public virtual Person PPerson { get; set; }




    }
}