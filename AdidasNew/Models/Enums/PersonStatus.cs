using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdidasNew.Controllers
{
    public enum PersonStatus
    {
        UnCheck=0,
        Confirmed = 2,//تایید شده
        NotConfirmed = 1,//رد صلاحیت
        Staff = 3,//کارمند
        Deporte=4,//اخراج شده
        Resignation=5 //اتمام همکاری
    }
}