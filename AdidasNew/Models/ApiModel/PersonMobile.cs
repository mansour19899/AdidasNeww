using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdidasNew.Models.ApiModel
{
    public class PersonMobile
    {
        public PersonMobile()
        {

        }
        public PersonMobile(int id, string firstname, string lastname, bool marriage, DateTime birth, string mobil)
        {
            Id = id;
            FirstName = firstname;
            LastName = lastname;
            if (marriage)
                Marriage = "مجرد";
            else
                Marriage = "'متاهل";
            TimeSpan r = DateTime.Now.Subtract(birth);
            int x = (int)(r.Days / 365.25);
            Birth = x + " ساله";
            Mobil = mobil;

        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Marriage { get; set; }
        public string Mobil { get; set; }
        public string Birth { get; set; }
    }
}