using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdidasNew.Models.EntityModels
{
    public class countLists
    {
        public int NewPerson { get; set; }
        public int ConfirmedPerson { get; set; }
        public int NotConfirmedPerson { get; set; }

        public int NewPersonUncheck { get; set; }
        public int ConfirmedPersonUncheck { get; set; }
        public int NotConfirmedPersonUncheck { get; set; }

        AdidasNew.Models.DomainModels.DatabaseContext db = null;
        public countLists()
        {
            db = new DomainModels.DatabaseContext();
            ConfirmedPerson = db.People.Where(p => p.Checked == true & p.Status == 2).ToList().Count();
            NotConfirmedPerson = db.People.Where(p => p.Checked == true & p.Status == 1).ToList().Count();
            NewPerson = db.People.Where(p => p.Checked == false ).ToList().Count();



        }

    }
}