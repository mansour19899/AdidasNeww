using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdidasNew.Controllers
{
    public enum PersonStatus
    {
        UnCheck=0,
        NotConfirmed = 1,//رد صلاحیت
        Confirmed = 2,//تایید شده
        Staff = 3,//کارمند
        Deporte=4,//اخراج شده
        Resignation=5 //اتمام همکاری
    }
}