using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdidasNew.Models.EntityModels
{
    public class DateOfBirth
    {
        public List<string> DayList { get; set; }
        public List<string> MonthList { get; set; }
        public List<string>YearList { get; set; }
        public string Day { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }
        private int StartYear;
        private int EndYear;

        public DateOfBirth()
        {
            StartYear = 1356;
            EndYear = 1379;

            DayList=new List<string>(){"01","02","03","04","05","06","07","08","09", "10", "11", "12", "13", "14", "15", "16", "17", "18" , "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31" };
            MonthList = new List<string>() {"01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12"};
            YearList = new List<string>() { "1356", "1357", "1358", "1359", "1360", "1361", "1362", "1363", "1364", "1365", "1366", "1367", "1368", "1369", "1370", "1371", "1372", "1373",
                "1374", "1375", "1376", "1377", "1378", "1379"};

        }
    }
}