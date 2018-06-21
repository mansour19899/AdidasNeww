using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
namespace AdidasNew.Models.DomainModels
{
    public class HistoryOfPerson
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [DisplayName("شخص مد نظر")]
        [Display(Name = "شخص مد نظر")]
        public int Person_Id_fk { get; set; }

        [DisplayName("وضعیت")]
        [Display(Name = "وضعیت")]
        public byte Status { get; set; }

        [DisplayName("توضیحات")]
        [Display(Name = " توضیحات ")]
        [MaxLength(200, ErrorMessage = "لطفا مقدار  {0} را بیشتر از {1} حرف وارد نکنید")]
        public string Description { get; set; }

        [DisplayName("تغییر توسط")]
        [Display(Name = " تغییر توسط ")]
        [Required(ErrorMessage = "لطفا  {0} را وارد کنید")]
        [MaxLength(130, ErrorMessage = "لطفا مقدار  {0} را بیشتر از {1} حرف وارد نکنید")]
        public string User_Id_fk { get; set; }

        [DisplayName(" زمان اعمال")]
        [Display(Name = " زمان اعمال ")]
        [Required(ErrorMessage = "لطفا  {0} را وارد کنید")]
       
        public DateTime RegDate { get; set; }
    }
}