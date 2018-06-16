using AdidasNew.Models.Repositores;
using AdidasNew.Models.EntityModels;
using AdidasNew.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdidasNew.Models.DomainModels;
using Microsoft.AspNet.Identity;


namespace AdidasNew.Controllers
{
   
    public class AdminController : Controller
    {
        countLists count;
       // GET: Admin
       [Authorize(Roles = "Admin,Maneger")]
        public ActionResult Index()
        {

            return View();
        }

        [Authorize(Roles = "Admin,Maneger")]
        public ActionResult ControlPanel()
        {
            return View();
        }
        [Authorize(Roles = "Admin,Maneger")]
        public ActionResult ListNewPerson()
        {
            PersonRepository blPerson = new PersonRepository();

            var list = blPerson.Where(p => p.Checked == false).ToList();

            return View(list);
        }
        [Authorize(Roles = "Admin,Maneger")]
        public ActionResult Info(int id =1)
        {

            PersonRepository blPerson = new PersonRepository();
            JobRecordRepository blJob = new JobRecordRepository();
            RelationShipRepository blRelation = new RelationShipRepository();

            PersonInfo infoo = new PersonInfo();

            var t = blPerson.Find(id);
            if (t != null)
            {
                var tt = blJob.Where(p => p.Person_FK == t.Id).ToList();
                var ttt = blRelation.Where(p => p.Person_FK == t.Id).ToList();
                infoo.Person = t;

                if (tt.Count() > 0)
                    infoo.JobRecord1 = tt.ElementAt(0);
                if (tt.Count() > 1)
                    infoo.JobRecord2 = tt.ElementAt(1);
                if (tt.Count() > 2)
                    infoo.JobRecord3 = tt.ElementAt(2);

                if (ttt.Count() > 0)
                    infoo.RelationShip1 = ttt.ElementAt(0);
                if (ttt.Count() > 1)
                    infoo.RelationShip2 = ttt.ElementAt(1);
                if (ttt.Count() > 2)
                    infoo.RelationShip3 = ttt.ElementAt(2);

                return View("info1",infoo);
            }
            else
            {

                return View("ListNewPerson");

            }

        }

        [Authorize(Roles = "Admin")]
        public ActionResult ListCheckedPerson()
        {
            PersonRepository blPerson = new PersonRepository();

            var list = blPerson.Where(p => p.Checked == true).ToList();

            return View(list);
        }

        [Authorize(Roles = "Admin,Maneger")]
         public ActionResult DashBorad()
        {
            var strCurrentUserId = User.Identity.GetUserId();
            var strCurrentUserIdd = User.Identity.GetUserName();

            count = new countLists();
            

            return View(count);
        }


        [Authorize(Roles = "Admin,Maneger")]
        public ActionResult SetStatus(int id,int status)
        {
            PersonRepository blPerson = new PersonRepository();
            historyOfPersonRepository blHistory = new historyOfPersonRepository();

            var x = blPerson.Find(id);
            x.Checked = true;
            x.Status =(byte) status;
            blPerson.Update(x);

            count = new countLists();

            return View("DashBorad",count);
        }
        [Authorize(Roles = "Admin")]
        public ActionResult ListConfirmedPerson()
        {
            PersonRepository blPerson = new PersonRepository();


            var list = blPerson.Where(p => p.Checked == true&p.Status==2).ToList();

            return View(list);
        }
        [Authorize(Roles = "Admin")]
        public ActionResult ListNotConfirmedPerson()
        {
            PersonRepository blPerson = new PersonRepository();

            var list = blPerson.Where(p => p.Checked == true & p.Status == 1).ToList();

            return View(list);
        }
    }
}