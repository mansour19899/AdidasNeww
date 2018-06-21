﻿using AdidasNew.Models.Repositores;
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


        
        public ActionResult SetStatus(int id,int status,string Description)
        {
            PersonRepository blPerson = new PersonRepository();
            historyOfPersonRepository blHistory = new historyOfPersonRepository();

            var x = blPerson.Find(id);
            x.Checked = true;
            x.Status =(byte) status;
            blPerson.Update(x);

            HistoryOfPerson per = new HistoryOfPerson()
            {
                Person_Id_fk = id,
                Status = (byte)status,
                Description = Description,
                User_Id_fk = User.Identity.GetUserId(),
                RegDate = DateTime.Now

        };
            blHistory.Add(per);
           

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



        [SendStatusHandler]
        [HttpPost]
        public ActionResult Confirmed(string Description, string PersonId)
        {
            SetStatus(int.Parse(PersonId), 2, Description);

            return RedirectToAction("ListConfirmedPerson");
        }

        [SendStatusHandler]
        [HttpPost]
        public ActionResult NotConfirmed(string Description, string PersonId)
        {
            SetStatus(int.Parse(PersonId), 1, Description);

            return RedirectToAction("ListNotConfirmedPerson");
        }
       
        public ActionResult History(int id)
        {
            
            historyOfPersonRepository per = new historyOfPersonRepository();
            AdidasNew.Models.ApplicationDbContext db = new Models.ApplicationDbContext();
            var t = db.Users.ToList();
           var history=  per.Where(p => p.Person_Id_fk == id).OrderByDescending(p=>p.RegDate).ToList();
            foreach (var item in history)
            {
                item.User_Id_fk = t.Find(p => p.Id == item.User_Id_fk).FullName;
                
            }
            return View(history);
        }
    }
}