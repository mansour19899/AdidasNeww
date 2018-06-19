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
using AdidasNew.Helpers.Attributes;


namespace AdidasNew.Controllers
{
    [Authorize(Roles = "Admin,Maneger")]
    public class AdminController : Controller
    {
        countLists count;
       // GET: Admin
       
        public ActionResult Index()
        {

            return View();
        }

        
        public ActionResult ControlPanel()
        {
            return View();
        }
        
        public ActionResult ListNewPerson()
        {
            PersonRepository blPerson = new PersonRepository();

            var list = blPerson.Where(p => p.Checked == false).ToList();

            return View(list);
        }
        
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

        
        public ActionResult ListCheckedPerson()
        {
            PersonRepository blPerson = new PersonRepository();

            var list = blPerson.Where(p => p.Checked == true).ToList();

            return View(list);
        }

        
         public ActionResult DashBorad()
        {
            var strCurrentUserId = User.Identity.GetUserId();
            var strCurrentUserIdd = User.Identity.GetUserName();

            count = new countLists();
            

            return View(count);
        }


        
        public ActionResult SetStatus(int id,int status)
        {
            PersonRepository blPerson = new PersonRepository();
            historyOfPersonRepository blHistory = new historyOfPersonRepository();

            var x = blPerson.Find(id);
            x.Checked = true;
            x.Status =(byte) status;
            blPerson.Update(x);

            HistoryOfPerson per = new HistoryOfPerson();
           

            return RedirectToAction("ListNewPerson");
        }
        
        public ActionResult ListConfirmedPerson()
        {
            PersonRepository blPerson = new PersonRepository();


            var list = blPerson.Where(p => p.Checked == true&p.Status==2).ToList();

            return View(list);
        }
        
        public ActionResult ListNotConfirmedPerson()
        {
            PersonRepository blPerson = new PersonRepository();

            var list = blPerson.Where(p => p.Checked == true & p.Status == 1).ToList();

            return View(list);
        }

        [HttpGet]
        public ActionResult test()
        {
           


            return View("");
        }


        [SendMessageHandler]
        [HttpPost]
        public ActionResult Send_sms(string Name, string status)
        {
            /// Do something ...
            return RedirectToAction("ListConfirmedPerson");
        }

        [SendMessageHandler]
        [HttpPost]
        public ActionResult Send_email(string Name, string status)
        {
            /// Do something ...
            /// 
            //https://www.dotnettips.info/post/1150/%DA%86%D9%86%D8%AF%DB%8C%D9%86-submit
            //-%D8%AF%D8%B1-%DB%8C%DA%A9-html-form-%D9%88-%D8%A7%D9%86%D8%AA%D8%B3%D8%A7%D8%
            //    A8-action-%D9%87%D8%A7%DB%8C-%D9%85%D8%AC%D8%B2%D8%A7-%D8%A8%D9%87-%D9%87%D8%B1
            //    -%DB%8C%DA%A9-%D8%A7%D8%B2-submit-%D9%87%D8%A7-%D8%AF%D8%B1-mvc
            return RedirectToAction("ListNotConfirmedPerson");
        }
    }
}