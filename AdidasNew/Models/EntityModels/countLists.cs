using AdidasNew.Controllers;
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
        public int DeporteUncheck { get; set; }
        public int ResignationUncheck { get; set; }
        public int NotConfirmedPersonUncheck { get; set; }
        public int NotStaffUncheck { get; set; }

        public int CountRegister { get; set; }
        public int CountUnCheck { get; set; }
        public int CountStaff { get; set; }


        AdidasNew.Models.DomainModels.DatabaseContext db = null;
        public countLists()
        {
            db = new DomainModels.DatabaseContext();
            ConfirmedPerson = db.People.Where(p =>  p.Status == (int)PersonStatus.Confirmed).ToList().Count();
            NotConfirmedPerson = db.People.Where(p => p.Status == (int)PersonStatus.NotConfirmed).ToList().Count();
            NewPerson = db.People.Where(p => p.Status== (int)PersonStatus.UnCheck).ToList().Count();

            ConfirmedPersonUncheck = db.People.Where(p =>p.Checked==false& p.Status == (int)PersonStatus.Confirmed).ToList().Count();
            NotConfirmedPersonUncheck = db.People.Where(p => p.Checked == false & p.Status == (int)PersonStatus.NotConfirmed).ToList().Count();
            NotStaffUncheck = db.People.Where(p => p.Checked == false & p.Status == (int)PersonStatus.Staff & p.IsStaff==true).ToList().Count();
            NewPersonUncheck = db.People.Where(p => p.Checked == false & p.Status == (int)PersonStatus.UnCheck).ToList().Count();
            DeporteUncheck = db.People.Where(p => p.Checked == false & p.Status == (int)PersonStatus.Deporte).ToList().Count();
            ResignationUncheck = db.People.Where(p => p.Checked == false & p.Status == (int)PersonStatus.Resignation).ToList().Count();

            CountRegister = db.People.Where(p=>p.IsStaff==false).ToList().Count();
            CountUnCheck= db.People.Where(p => p.Checked == false ).ToList().Count();
            CountStaff = db.People.Where(p => p.Status == (int)PersonStatus.Staff & p.IsStaff==true).ToList().Count();
        }

    }
}