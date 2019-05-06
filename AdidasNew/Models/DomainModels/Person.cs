
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace AdidasNew.Models.DomainModels
{

    [Table("tblPerson")]
    public  class Person
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [DisplayName(" نام خانوادگی")]
        [Display(Name = " نام خانوادگی")]
        [Required(ErrorMessage ="لطفا  {0} را وارد کنید")]    
        [MaxLength(20,ErrorMessage ="لطفا مقدار  {0} را بیشتر از {1} حرف وارد نکنید")]
        public string LastName { get; set; }

        [DisplayName("نام ")]
        [Display(Name = "نام ")]
        [Required(ErrorMessage ="لطفا  {0} را وارد کنید", AllowEmptyStrings = false)]
        [Column("Firstname", TypeName = "NVARCHAR")]
        [MaxLength(20,ErrorMessage ="لطفا مقدار  {0} را بیشتر از {1} حرف وارد نکنید")]
        public string Name { get; set; }

        [DisplayName(" نام پدر ")]
        [Display(Name = "نام پدر ")]
        [Required(ErrorMessage ="لطفا  {0} را وارد کنید")]
       [MaxLength(20,ErrorMessage ="لطفا مقدار  {0} را بیشتر از {1} حرف وارد نکنید")]
        public string Father { get; set; }

        [DisplayName("تاریخ تولد ")]
        [Display(Name = "تاریخ تولد ")]
          [Required(ErrorMessage ="لطفا  {0}   را وارد کنید")]
        public Nullable<System.DateTime> BirthDay { get; set; }

        [DisplayName("وضعیت نظام وظیفه")]
        [Display(Name = "وضعیت نظام وظیفه")]
        public Nullable<byte> MilitaryService { get; set; }

        [DisplayName("وضعیت تاهل ")]
        [Display(Name = "وضعیت تاهل ")]
        public bool Marriage { get; set; }

        [DisplayName("تعداد فرزندان ")]
        [Display(Name = "تعداد فرزندان ")]
        public Nullable<byte> Children { get; set; }

        [DisplayName("کدملی ")]
        [Display(Name = "کدملی ")]
        [Required(ErrorMessage = "لطفا  {0} را وارد کنید")]
        [MaxLength(10, ErrorMessage = "لطفا مقدار  {0} را بیشتر از {1} رقم وارد نکنید")]
        [MinLength(10, ErrorMessage = "لطفا مقدار  {0} را کمتر از {1} رقم وارد نکنید")]
        [RegularExpression("^[0-9,۰۱۲۳۴۵۶۷۸۹]*$", ErrorMessage = "{0} نباید شامل حروف باشد")]
        ////[RegularExpression("^[0-9]{10}$", ErrorMessage = "کد ملی خود را به درستی وارد کنید")]
        //-------------------barasi shavad-----------------------------------
        //[Required(ErrorMessage = "وارد کردن {0} الزامی است !")]
        //[Display(Name = "کدملی")]
        //[NationalCode("کدملی وارد شده معتبر نمیباشد !")]
        public string NationalCode { get; set; }

        [DisplayName("آدرس ")]
        [Display(Name = "آدرس ")]
        [Required(ErrorMessage ="لطفا مقدار {0}  وارد کنید")]
        [MaxLength(200, ErrorMessage = "لطفا مقدار  {0} را بیشتر از {1} حرف وارد نکنید")]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }

        [DisplayName("تلفن ")]
        [Display(Name = "تلفن ")]
        [MaxLength(15, ErrorMessage = "لطفا مقدار  {0} را بیشتر از {1} رقم وارد نکنید")]
        [MinLength(5, ErrorMessage = "لطفا مقدار  {0} را کمتر از {1} رقم وارد نکنید")]
        [Required(ErrorMessage = "لطفا شماره  {0} را وارد کنید")]
        [RegularExpression("^[0-9,۰۱۲۳۴۵۶۷۸۹]*$", ErrorMessage = "{0} نباید شامل حروف باشد")]
       

        public string Tell { get; set; }

        [DisplayName("موبایل ")]
        [Display(Name = "موبایل ")]
        [Required(ErrorMessage ="لطفا شماره  {0} را وارد کنید")]
        [MaxLength(12, ErrorMessage = "لطفا مقدار  {0} را بیشتر از {1} حرف وارد نکنید")]
        //[MaxLength(11, ErrorMessage = "لطفا مقدار  {0} را بیشتر از {1} رقم وارد نکنید")]
        //[MinLength(10, ErrorMessage = "لطفا مقدار  {0} را کمتر از {1} رقم وارد نکنید")]
        [RegularExpression(@"^[0۰]?[9۹]([0-9,۰۱۲۳۴۵۶۷۸۹]{9})$", ErrorMessage = "شماره موبایل را بدرستی وارد کنید")]
         public string Mobile { get; set; }

        [DisplayName("ایمیل ")]
        [Display(Name = "ایمیل ")]
        [EmailAddress(ErrorMessage ="ایمیل وارد شده صحیح نمی باشد")]
     //   [RegularExpression(@"^[_A-Za-z0-9-\+]+(\.[_A-Za-z0-9-]+)*@[A-Za-z0-9-]+(\.[A-Za-z0-9-]+)*(\.[A-Za-z]{2,4})$", ErrorMessage = "ایمیل را بدرستی وارد کنید")]
        public string Email { get; set; }

        [DisplayName("آخرین مدرک تحصیلی ")]
        [Display(Name = "آخرین مدرک تحصیلی ")]
        public Nullable<byte> Degree { get; set; }

        [DisplayName("نام موسسه ")]
        [Display(Name = "نام موسسه ")]
        [Required(ErrorMessage = "لطفا  {0}  وارد کنید")]
        public string Institute { get; set; }

        [DisplayName("رشته تحصیلی ")]
        [Display(Name = "رشته تحصیلی ")]
        [Required(ErrorMessage = "لطفا نام {0}  وارد کنید")]
        public string Field { get; set; }

        [DisplayName("آشنایی با زبان خارجه ")]
        [Display(Name = "آشنایی با زبان خارجه ")]
        public Nullable<byte> EnglishKnowledge { get; set; }

        [DisplayName("Excel ")]
        [Display(Name = "Excel ")]
        public bool Excel { get; set; }

        [DisplayName("Word ")]
        [Display(Name = "Word ")]
        public bool Word { get; set; }

        [DisplayName("Outlook ")]
        [Display(Name = "Outlook ")]
        public bool Outlook { get; set; }

        [DisplayName("PowerPoint ")]
        [Display(Name = "PowerPoint ")]
        public bool PowerPoint { get; set; }

        [DisplayName("حسابداری ")]
        [Display(Name = "حسابداری ")]
        public bool Accounting { get; set; }

        [DisplayName("غیره . ذکر نرم افزار ")]
        [Display(Name = "غیره . ذکر نرم افزار ")]
        public string OtherSoftwer { get; set; }

        [DisplayName("دوره های کامپیوتری ")]
        [Display(Name = "دوره های کامپیوتری ")]
        public string Skills { get; set; }
        [DisplayName("میزان حقوق درخواستی ")]
        [Display(Name = "میزان حقوق درخواستی ")]
        [Required(ErrorMessage = "لطفا  {0}  وارد کنید")]
        [MaxLength(10, ErrorMessage = "مبلغ بیش از حد مجاز است")]
        [RegularExpression("^[0-9,۰۱۲۳۴۵۶۷۸۹]*$", ErrorMessage = " نباید شامل حروف باشد")]

        public string SalaryExpection { get; set; }
        [DisplayName("متقاضی کار ")]
        [Display(Name = "متقاضی کار ")]
        public bool JobStatus { get; set; }

        [DisplayName("چند روز در هفته ")]
        [Display(Name = "چند روز در هفته ")]
        public Nullable<byte> DaysNumber { get; set; }

        [DisplayName("آیا تعهد کاری 3 سال کار را می دهید؟ ")]
        [Display(Name = "آیا تعهد 3 سال کار را می دهید؟ ")]
        public bool WorkingGuranty { get; set; }

        [DisplayName("مدت تعهد کاری ")]
        [Display(Name = "مدت تعهد کاری ")]
        public Nullable<byte> Duration { get; set; }

        [DisplayName("آیا در صورت همکاری مشکلی برای پرداخت ضمانت دارید؟ ")]
        [Display(Name = "آیا در صورت همکاری مشکلی برای پرداخت ضمانت دارید؟ ")]
        public bool GurantyPayment { get; set; }

        [DisplayName("جنسیت ")]
        [Display(Name = "جنسیت ")]
        public bool Gender { get; set; }

        [DisplayName("تصویر ")]
        [Display(Name = "تصویر")]
         public byte[] image { get; set; }

        [DisplayName("تاریخ ثبت نام ")]
        [Display(Name = "تاریخ ثبت نام ")]
        public Nullable<System.DateTime> RegPerson { get; set; }

        [DisplayName("Checked ")]
        [Display(Name = "Checked ")]
        public bool Checked { get; set; }

        [DisplayName("وضعیت")]
        [Display(Name = "وضعیت")]
        public byte Status { get; set; }

        //[NotMapped]
        //public int test { get; set; }

        public virtual ICollection<JobRecord> JobRecord { get; set; }
        public virtual ICollection<RelationShip> RelationShip { get; set; }
       

    }
}
