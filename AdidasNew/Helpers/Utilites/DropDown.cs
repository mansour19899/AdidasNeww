using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


public class DropDown
{
    public static IEnumerable<SelectListItem> GetMilitaryList()
    {
        List<SelectListItem> items = new List<SelectListItem>
            {
                new SelectListItem{Text = "---------------------------", Value = "0",Selected=true},
                new SelectListItem{Text = "دارای کارت پایان خدمت", Value = "1",Selected=false},
                new SelectListItem{Text = "معافیت تحصیلی", Value = "2",Selected=false},
                new SelectListItem{Text = "معافیت پزشکی", Value = "3",Selected=false},
                new SelectListItem{Text = "غایب", Value = "4",Selected=false},
            };
        return items;
    }

    public static IEnumerable<SelectListItem> GetCountOfChildernList()
    {
        List<SelectListItem> items = new List<SelectListItem>
            {
                new SelectListItem{Text = "ندارم", Value = "0",Selected=true},
                new SelectListItem{Text = "1", Value = "1",Selected=false},
                new SelectListItem{Text = "2", Value = "2",Selected=false},
                new SelectListItem{Text = "3", Value = "3",Selected=false},
                new SelectListItem{Text = "4", Value = "4",Selected=false},
            };
        return items;
    }

    public static IEnumerable<SelectListItem> GetDegreeList()
    {
        List<SelectListItem> items = new List<SelectListItem>
            {
               new SelectListItem{Text = "---------------------", Value = "0",Selected=true},
                new SelectListItem{Text = "دیپلم", Value = "1",Selected=false},
                new SelectListItem{Text = "کاردانی", Value = "2",Selected=false},
                new SelectListItem{Text = "کارشناسی", Value = "3",Selected=false},
                new SelectListItem{Text = "کارشناسی ارشد", Value = "4",Selected=false},
                new SelectListItem{Text = "در حین تحصیل", Value = "5",Selected=false}
              };
        return items;
    }

    public static IEnumerable<SelectListItem> GetKnowledgeList()
    {
        List<SelectListItem> items = new List<SelectListItem>
            {
             new SelectListItem{Text = "ندارم", Value = "0",Selected=true},
                new SelectListItem{Text = "ابتدایی", Value = "1",Selected=false},
                new SelectListItem{Text = "متوسط", Value = "2",Selected=false},
                new SelectListItem{Text = "خوب", Value = "3",Selected=false}

            };
        return items;
    }

    public static IEnumerable<SelectListItem> GetGenderList()
    {
        List<SelectListItem> items = new List<SelectListItem>
            {
                new SelectListItem{Text = "مرد", Value = "true",Selected=true},
                new SelectListItem{Text = "زن", Value = "false",Selected=false}
            };
        return items;
    }

    public static IEnumerable<SelectListItem> GetMarrigeList()
    {
        List<SelectListItem> items = new List<SelectListItem>
            {
                new SelectListItem{Text = "مجرد", Value = "true",Selected=true},
                new SelectListItem{Text = "متاهل", Value = "false",Selected=false }
            };
        return items;
    }

    public static IEnumerable<SelectListItem> GetJobStatusList()
    {
        List<SelectListItem> items = new List<SelectListItem>
            {
                new SelectListItem{Text = "تمام وقت", Value = "true",Selected=true},
                new SelectListItem{Text = "نیمه وقت", Value = "false",Selected=false}
            };
        return items;
    }

    public static IEnumerable<SelectListItem> GetYesOrNoList()
    {
        List<SelectListItem> items = new List<SelectListItem>
            {
                new SelectListItem{Text = "بله", Value = "true",Selected=false},
                new SelectListItem{Text = "خیر", Value = "false",Selected=true}
            };
        return items;
    }

    public static IEnumerable<SelectListItem> GetDaysList()
    {
        List<SelectListItem> items = new List<SelectListItem>
            {
              new SelectListItem{Text = "------------------------", Value = "0"},
                new SelectListItem{Text = " 1 روز", Value = "1"},
                new SelectListItem{Text = "2 روز", Value = "2"},
                new SelectListItem{Text = "3 روز", Value = "3"},
                new SelectListItem{Text = " 4 روز", Value = "4"},
                new SelectListItem{Text = "5 روز  ", Value = "5"},
                  new SelectListItem{Text = "6 روز  ", Value = "6"}
              };
        return items;
    }

    public static IEnumerable<SelectListItem> GetDay()
    {
        List<SelectListItem> items = new List<SelectListItem>
            {
                new SelectListItem{Text = "01", Value = "01"},
                new SelectListItem{Text = "02", Value = "02"},
                new SelectListItem{Text = "03", Value = "03"},
                new SelectListItem{Text = "04", Value = "04"},
                new SelectListItem{Text = "05", Value = "05"},
                 new SelectListItem{Text = "06", Value = "06"},
                new SelectListItem{Text = "07", Value = "07"},
                new SelectListItem{Text = "08", Value = "08"},
                new SelectListItem{Text = "09", Value = "09"},
                new SelectListItem{Text = "10", Value = "10"},
                 new SelectListItem{Text = "11", Value = "11"},
                new SelectListItem{Text = "12", Value = "12"},
                new SelectListItem{Text = "13", Value = "13"},
                new SelectListItem{Text = "14", Value = "14"},
                new SelectListItem{Text = "15", Value = "15"},
                 new SelectListItem{Text = "16", Value = "16"},
                new SelectListItem{Text = "17", Value = "17"},
                new SelectListItem{Text = "18", Value = "18"},
                new SelectListItem{Text = "19", Value = "19"},
                new SelectListItem{Text = "20", Value = "20"},
                 new SelectListItem{Text = "21", Value = "21"},
                new SelectListItem{Text = "22", Value = "22"},
                new SelectListItem{Text = "23", Value = "23"},
                new SelectListItem{Text = "24", Value = "24"},
                new SelectListItem{Text = "25", Value = "25"},
                 new SelectListItem{Text = "26", Value = "26"},
                new SelectListItem{Text = "27", Value = "27"},
                new SelectListItem{Text = "28", Value = "28"},
                new SelectListItem{Text = "29", Value = "29"},
                new SelectListItem{Text = "30", Value = "30"},
                 new SelectListItem{Text = "31", Value = "31"}
            };
        return items;
    }

    public static IEnumerable<SelectListItem> GetMounth()
    {
        List<SelectListItem> items = new List<SelectListItem>
            {
                new SelectListItem{Text = "01", Value = "01"},
                new SelectListItem{Text = "02", Value = "02"},
                new SelectListItem{Text = "03", Value = "03"},
                new SelectListItem{Text = "04", Value = "04"},
                new SelectListItem{Text = "05", Value = "05"},
                 new SelectListItem{Text = "06", Value = "06"},
                new SelectListItem{Text = "07", Value = "07"},
                new SelectListItem{Text = "08", Value = "08"},
                new SelectListItem{Text = "09", Value = "09"},
                new SelectListItem{Text = "10", Value = "10"},
                 new SelectListItem{Text = "11", Value = "11"},
                new SelectListItem{Text = "12", Value = "12"},

            };
        return items;
    }

    public static IEnumerable<SelectListItem> GetYear()
    {
        List<SelectListItem> items = new List<SelectListItem>
            {
                new SelectListItem{Text = "1362", Value = "1362"},
                new SelectListItem{Text = "1363", Value = "1363"},
                new SelectListItem{Text = "1364", Value = "1364"},
                new SelectListItem{Text = "1365", Value = "1365"},
                new SelectListItem{Text = "1366", Value = "1366"},
                 new SelectListItem{Text = "1367", Value = "1367"},
                new SelectListItem{Text = "1368", Value = "1368",Selected=true},
                new SelectListItem{Text = "1369", Value = "1369"},
                new SelectListItem{Text = "1370", Value = "1370"},
                new SelectListItem{Text = "1371", Value = "1371"},
                 new SelectListItem{Text = "1372", Value = "1372"},
               new SelectListItem{Text = "1373", Value = "1373"},
                new SelectListItem{Text = "1374", Value = "1374"},
                new SelectListItem{Text = "1375", Value = "1375"},
                new SelectListItem{Text = "1376", Value = "1376"},
                new SelectListItem{Text = "1377", Value = "1377"},
                 new SelectListItem{Text = "1378", Value = "1378"},
                new SelectListItem{Text = "1379", Value = "1379"}

            };
        return items;
    }

    public static IEnumerable<SelectListItem> GetDurationOfWorkList()
    {
        List<SelectListItem> items = new List<SelectListItem>
            {
               new SelectListItem{Text = "------------------------", Value = "0",Selected=true},
                new SelectListItem{Text = "شش ماه", Value = "1",Selected=false},
                new SelectListItem{Text = " یک سال", Value = "2",Selected=false},
                new SelectListItem{Text = "یک سال و شش ماه", Value = "3",Selected=false},
                new SelectListItem{Text = "دو سال", Value = "4",Selected=false},
                new SelectListItem{Text = "دو سال و شش ماه", Value = "5",Selected=false},
            };
        return items;
    }

    public static IEnumerable<SelectListItem> GetStatusList()
    {
        List<SelectListItem> items = new List<SelectListItem>
            {
                new SelectListItem{Text = "بررسی نشده", Value = "0",Selected=true},
                new SelectListItem{Text = "رد صلاحیت", Value = "1",Selected=true},
                new SelectListItem{Text = "تایید شد", Value = "2",Selected=false},
                new SelectListItem{Text = "کارمند", Value = "3",Selected=false},
                new SelectListItem{Text = "اخراج شد", Value = "4",Selected=false},
                new SelectListItem{Text = "اتمام همکاری", Value = "5",Selected=false},
            };
        return items;
    }


}
