using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AdidasNew.Helpers;

namespace AdidasNew.Models.ApiModel
{
    public class InformationPerson
    {
        public InformationPerson(bool marriage,DateTime birth,bool gender,int militaryService)
        {
            if (!gender)
                Gender = "خانم";
            else
                Gender = "آقا";
            if (marriage)
                Marriage = "مجرد";
            else
                Marriage = "'متاهل";
            TimeSpan r = DateTime.Now.Subtract(birth);
            int x = (int)(r.Days / 365.25);
            Birth =birth.ToPersianDateString()+" --"+ x + " ساله";

            switch (militaryService)
            {
                case (1):
                {
                        MilitaryService = DropDown.GetMilitaryList().ElementAt(1).Text;
                        break;
                    }
                case (2):
                    {
                        MilitaryService = DropDown.GetMilitaryList().ElementAt(2).Text;
                        break;
                    }
                case (3):
                    {
                        MilitaryService = DropDown.GetMilitaryList().ElementAt(3).Text;
                        break;
                    }
                case (4):
                    {
                        MilitaryService = DropDown.GetMilitaryList().ElementAt(4).Text;
                        break;
                    }
                default:
                    MilitaryService = DropDown.GetMilitaryList().ElementAt(0).Text;
                    break;
            }

        }
        
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Father { get; set; }
        public string Gender { get; set; }
        public string MilitaryService { get; set; }
        public string Tell { get; set; }
        public string Marriage { get; set; }
        public string Mobil { get; set; }
        public string Birth { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        public byte[] Image { get; set; }


    }
}