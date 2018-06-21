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
         StandBy=3,//گزینش
        Staff = 4,//کارمند
        Deporte=5,//اخراج شده
        Resignation=6 //اتمام همکاری
    }
}