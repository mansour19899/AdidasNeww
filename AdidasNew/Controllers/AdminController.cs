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
using Stimulsoft.Report.Mvc;
using Stimulsoft.Report;
using System.IO;

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

            var list = blPerson.Where(p => p.Status == 0).ToList().OrderByDescending(pp => pp.Id);

            return View(list);
        }

        public PersonInfo CreatePersonInfo(int id)
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

                t.Checked = true;
                blPerson.Update(t);

                return infoo;
            }
            else
            {

                return null;

            }


        }

        public ActionResult Info(int id = 1)
        {
            Session["id"] = null;

            var t = CreatePersonInfo(id);

            if (t != null)
            {
                Session["id"] = id;
                return View("info1", t);
            }
            else
            {
                Session["id"] = null;
                return View("ListNewPerson");

            }

        }


        public ActionResult ListCheckedPerson()
        {
            PersonRepository blPerson = new PersonRepository();

            var list = blPerson.Where(p => p.Checked == true).ToList().OrderByDescending(pp => pp.Id);

            return View(list);
        }


        public ActionResult DashBorad()
        {
            var strCurrentUserId = User.Identity.GetUserId();
            var strCurrentUserIdd = User.Identity.GetUserName();

            count = new countLists();


            return View(count);
        }



        public ActionResult SetStatus(int id, int status, string Description)
        {
            PersonRepository blPerson = new PersonRepository();
            historyOfPersonRepository blHistory = new historyOfPersonRepository();


            var x = blPerson.Find(id);
            int perviousStatus = x.Status;
            x.Checked = false;
            x.Status = (byte)status;
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

            switch (perviousStatus)
            {
                case 0:
                    return RedirectToAction("ListNewPerson");
                case 1:
                    return RedirectToAction("ListNotConfirmedPerson");
                case 2:
                    return RedirectToAction("ListConfirmedPerson");
                default:
                    return RedirectToAction("ListNewPerson");
            }

        }

        public ActionResult ListConfirmedPerson()
        {
            PersonRepository blPerson = new PersonRepository();


            var list = blPerson.Where(p => p.Status == 2).ToList().OrderByDescending(pp => pp.Id);

            return View(list);
        }

        public ActionResult ListNotConfirmedPerson()
        {
            PersonRepository blPerson = new PersonRepository();

            var list = blPerson.Where(p => p.Status == 1).ToList().OrderByDescending(pp => pp.Id);

            return View(list);
        }



        [SendStatusHandler]
        [HttpPost]
        public ActionResult Confirmed(string Description, string PersonId)
        {
            return SetStatus(int.Parse(PersonId), 2, Description);

            // return RedirectToAction("ListConfirmedPerson");

        }

        [SendStatusHandler]
        [HttpPost]
        public ActionResult NotConfirmed(string Description, string PersonId)
        {
            return SetStatus(int.Parse(PersonId), 1, Description);

            // return RedirectToAction("ListNotConfirmedPerson");

        }

        public ActionResult History(int id)
        {

            historyOfPersonRepository per = new historyOfPersonRepository();
            AdidasNew.Models.ApplicationDbContext db = new Models.ApplicationDbContext();
            var t = db.Users.ToList();
            var history = per.Where(p => p.Person_Id_fk == id).ToList().OrderByDescending(p => p.RegDate);
            foreach (var item in history)
            {
                item.User_Id_fk = t.Find(p => p.Id == item.User_Id_fk).FullName;

            }
            return View(history);
        }

        public ActionResult uncheck(int id,int s)
        {
            PersonRepository blPerson = new PersonRepository();
            var t = blPerson.Find(id);
            t.Checked = false;
            blPerson.Update(t);

            switch (s)
            {
                case 0:
                    return RedirectToAction("ListNewPerson");
                case 1:
                    return RedirectToAction("ListNotConfirmedPerson");
                case 2:
                    return RedirectToAction("ListConfirmedPerson");
                default:
                    return RedirectToAction("ListNewPerson");
            }
  
        }


        public ActionResult Print()
        {
            //------------------------------------------------



            // report.Print();


            //-----------------------------------------------------
            //return View("info1", t);
            return View();
        }


        //public ActionResult report()
        //{
        //    int yy = Convert.ToInt16(Session["id"]);

        //    var t = CreatePersonInfo(yy);


        //    var report = new StiReport();
        //    report.Load(Server.MapPath("/Reports/Report.mrt"));

        //    report.Dictionary.Variables["Name"].Value = t.Person.Name;
        //    report.Dictionary.Variables["Family"].Value = t.Person.LastName;
        //    report.Dictionary.Variables["Father"].Value = t.Person.Father;
        //    report.Dictionary.Variables["BirthDay"].Value = t.Person.BirthDay.Value.ToPersianDateString();

        //    report.Dictionary.Variables["Marriage"].Value = DropDown.GetMarrigeList().First(p => p.Value == t.Person.Marriage.ToString().ToLower()).Text;

        //    if (t.Person.Children != null)
        //        report.Dictionary.Variables["Children"].Value = DropDown.GetCountOfChildernList().FirstOrDefault(p => p.Value == t.Person.Children.ToString()).Text;
        //    else
        //        report.Dictionary.Variables["Children"].Value = "";

        //    if (t.Person.MilitaryService != null)
        //        report.Dictionary.Variables["MilitaryService"].Value = DropDown.GetMilitaryList().FirstOrDefault(p => p.Value == t.Person.MilitaryService.ToString()).Text;
        //    else
        //        report.Dictionary.Variables["MilitaryService"].Value = "";

        //    report.Dictionary.Variables["NationalCode"].Value = t.Person.NationalCode;
        //    report.Dictionary.Variables["Address"].Value = t.Person.Address;

        //    report.Dictionary.Variables["Tell"].Value = t.Person.Tell;
        //    report.Dictionary.Variables["Mobile"].Value = t.Person.Mobile;

        //    if (t.Person.Email != null)
        //        report.Dictionary.Variables["Email"].Value = t.Person.Email;
        //    else
        //        report.Dictionary.Variables["Email"].Value = "";

        //    report.Dictionary.Variables["Gender"].Value = DropDown.GetGenderList().First(p => p.Value == t.Person.Gender.ToString().ToLower()).Text;
        //    if (!t.Person.Gender)
        //        report.Dictionary.Variables["MilitaryService"].Value = "ــــــ";

        //    byte[] ImageByteArray = t.Person.image;
        //    MemoryStream ms = new MemoryStream(ImageByteArray);
        //    System.Drawing.Image image = System.Drawing.Image.FromStream(ms);
        //    report.Dictionary.Variables.Add("image", image);

        //    report.Dictionary.Variables["Degree"].Value = DropDown.GetDegreeList().FirstOrDefault(p => p.Value == t.Person.Degree.ToString()).Text;
        //    report.Dictionary.Variables["Institute"].Value = t.Person.Institute;
        //    report.Dictionary.Variables["Field"].Value = t.Person.Field;
        //    report.Dictionary.Variables["EnglishKnowledge"].Value = DropDown.GetKnowledgeList().FirstOrDefault(p => p.Value == t.Person.EnglishKnowledge.ToString()).Text;

        //    if (t.Person.Email != null)
        //        report.Dictionary.Variables["Skills"].Value = t.Person.Skills;
        //    else
        //        report.Dictionary.Variables["Skills"].Value = "";

        //    string softwer = "";
        //    if (t.Person.Word)
        //        softwer = softwer + "Word";
        //    if (t.Person.Excel)
        //        softwer = softwer + ",Exel";
        //    if (t.Person.PowerPoint)
        //        softwer = softwer + ",PowerPoint";
        //    if (t.Person.Outlook)
        //        softwer = softwer + ",Outlook";
        //    if (t.Person.Accounting)
        //        softwer = softwer + "حسابداری,";

        //    report.Dictionary.Variables["Softwer"].Value = softwer;

        //    if (t.Person.Email != null)
        //        report.Dictionary.Variables["OtherSoftwer"].Value = t.Person.OtherSoftwer;
        //    else
        //        report.Dictionary.Variables["OtherSoftwer"].Value = "";

        //    if (t.JobRecord1 != null)
        //    {
        //        if (t.JobRecord1.Company != null)
        //            report.Dictionary.Variables["Company1"].Value = t.JobRecord1.Company;
        //        else
        //            report.Dictionary.Variables["Company1"].Value = "";

        //        if (t.JobRecord1.Title != null)
        //            report.Dictionary.Variables["Title1"].Value = t.JobRecord1.Title;
        //        else
        //            report.Dictionary.Variables["Title1"].Value = "";

        //        if (t.JobRecord1.Duration != null)
        //            report.Dictionary.Variables["Duration1"].Value = t.JobRecord1.Duration;
        //        else
        //            report.Dictionary.Variables["Duration1"].Value = "";

        //        if (t.JobRecord1.Disconnection != null)
        //            report.Dictionary.Variables["Disconnection1"].Value = t.JobRecord1.Disconnection;
        //        else
        //            report.Dictionary.Variables["Disconnection1"].Value = "";

        //        if (t.JobRecord1.Address != null)
        //            report.Dictionary.Variables["Address1"].Value = t.JobRecord1.Address;
        //        else
        //            report.Dictionary.Variables["Address1"].Value = "";

        //    }

        //    if (t.JobRecord2 != null)
        //    {
        //        if (t.JobRecord2.Company != null)
        //            report.Dictionary.Variables["Company2"].Value = t.JobRecord2.Company;
        //        else
        //            report.Dictionary.Variables["Company2"].Value = "";

        //        if (t.JobRecord2.Title != null)
        //            report.Dictionary.Variables["Title2"].Value = t.JobRecord2.Title;
        //        else
        //            report.Dictionary.Variables["Title2"].Value = "";

        //        if (t.JobRecord2.Duration != null)
        //            report.Dictionary.Variables["Duration2"].Value = t.JobRecord2.Duration;
        //        else
        //            report.Dictionary.Variables["Duration2"].Value = "";

        //        if (t.JobRecord2.Disconnection != null)
        //            report.Dictionary.Variables["Disconnection2"].Value = t.JobRecord2.Disconnection;
        //        else
        //            report.Dictionary.Variables["Disconnection2"].Value = "";

        //        if (t.JobRecord2.Address != null)
        //            report.Dictionary.Variables["Address2"].Value = t.JobRecord2.Address;
        //        else
        //            report.Dictionary.Variables["Address2"].Value = "";

        //    }
        //    if (t.JobRecord3 != null)
        //    {
        //        if (t.JobRecord3.Company != null)
        //            report.Dictionary.Variables["Company3"].Value = t.JobRecord3.Company;
        //        else
        //            report.Dictionary.Variables["Company3"].Value = "";

        //        if (t.JobRecord3.Title != null)
        //            report.Dictionary.Variables["Title3"].Value = t.JobRecord3.Title;
        //        else
        //            report.Dictionary.Variables["Title3"].Value = "";

        //        if (t.JobRecord3.Duration != null)
        //            report.Dictionary.Variables["Duration3"].Value = t.JobRecord3.Duration;
        //        else
        //            report.Dictionary.Variables["Duration3"].Value = "";

        //        if (t.JobRecord3.Disconnection != null)
        //            report.Dictionary.Variables["Disconnection3"].Value = t.JobRecord3.Disconnection;
        //        else
        //            report.Dictionary.Variables["Disconnection3"].Value = "";

        //        if (t.JobRecord3.Address != null)
        //            report.Dictionary.Variables["Address3"].Value = t.JobRecord3.Address;
        //        else
        //            report.Dictionary.Variables["Address3"].Value = "";

        //    }

        //    report.Dictionary.Variables["JobStatus"].Value = DropDown.GetJobStatusList().First(p => p.Value == t.Person.JobStatus.ToString().ToLower()).Text;

        //    if (t.Person.DaysNumber != null)
        //        report.Dictionary.Variables["DaysNumber"].Value = string.Format("{0}", t.Person.DaysNumber.ToString());
        //    else
        //        report.Dictionary.Variables["DaysNumber"].Value = "";

        //    if (t.Person.Duration != null)
        //        report.Dictionary.Variables["Duration"].Value = DropDown.GetDurationOfWorkList().First(p => p.Value == t.Person.Duration.ToString()).Text;
        //    else
        //        report.Dictionary.Variables["Duration"].Value = "ــــ";


        //    report.Dictionary.Variables["WorkingGuranty"].Value = DropDown.GetYesOrNoList().First(p => p.Value == t.Person.WorkingGuranty.ToString().ToLower()).Text;
        //    report.Dictionary.Variables["GurantyPayment"].Value = DropDown.GetYesOrNoList().First(p => p.Value == t.Person.GurantyPayment.ToString().ToLower()).Text;
        //    report.Dictionary.Variables["SalaryExpection"].Value = t.Person.SalaryExpection;

        //    if (t.RelationShip1 != null)
        //    {
        //        if (t.RelationShip1.Name != null)
        //            report.Dictionary.Variables["Name1"].Value = t.RelationShip1.Name;
        //        else
        //            report.Dictionary.Variables["Name1"].Value = "";

        //        if (t.RelationShip1.Relational != null)
        //            report.Dictionary.Variables["Relational1"].Value = t.RelationShip1.Relational;
        //        else
        //            report.Dictionary.Variables["Relational1"].Value = "";

        //        if (t.RelationShip1.Tell != null)
        //            report.Dictionary.Variables["Tell1"].Value = t.RelationShip1.Tell;
        //        else
        //            report.Dictionary.Variables["Tell1"].Value = "";

        //        if (t.RelationShip1.Address != null)
        //            report.Dictionary.Variables["Address11"].Value = t.RelationShip1.Address;
        //        else
        //            report.Dictionary.Variables["Address11"].Value = "";
        //    }

        //    if (t.RelationShip2 != null)
        //    {
        //        if (t.RelationShip2.Name != null)
        //            report.Dictionary.Variables["Name2"].Value = t.RelationShip2.Name;
        //        else
        //            report.Dictionary.Variables["Name2"].Value = "";

        //        if (t.RelationShip2.Relational != null)
        //            report.Dictionary.Variables["Relational2"].Value = t.RelationShip2.Relational;
        //        else
        //            report.Dictionary.Variables["Relational2"].Value = "";

        //        if (t.RelationShip2.Tell != null)
        //            report.Dictionary.Variables["Tell2"].Value = t.RelationShip2.Tell;
        //        else
        //            report.Dictionary.Variables["Tell2"].Value = "";

        //        if (t.RelationShip2.Address != null)
        //            report.Dictionary.Variables["Address21"].Value = t.RelationShip2.Address;
        //        else
        //            report.Dictionary.Variables["Address21"].Value = "";
        //    }

        //    if (t.RelationShip3 != null)
        //    {
        //        if (t.RelationShip3.Name != null)
        //            report.Dictionary.Variables["Name3"].Value = t.RelationShip3.Name;
        //        else
        //            report.Dictionary.Variables["Name3"].Value = "";

        //        if (t.RelationShip3.Relational != null)
        //            report.Dictionary.Variables["Relational3"].Value = t.RelationShip3.Relational;
        //        else
        //            report.Dictionary.Variables["Relational3"].Value = "";

        //        if (t.RelationShip3.Tell != null)
        //            report.Dictionary.Variables["Tell3"].Value = t.RelationShip3.Tell;
        //        else
        //            report.Dictionary.Variables["Tell3"].Value = "";

        //        if (t.RelationShip3.Address != null)
        //            report.Dictionary.Variables["Address31"].Value = t.RelationShip3.Address;
        //        else
        //            report.Dictionary.Variables["Address31"].Value = "";
        //    }
        //    //report.Print();
        //    report.Compile();
        //    //report.RegBusinessObject("dt", db.People.ToList());
        //    return StiMvcViewer.GetReportSnapshotResult(report);
        //}

        //public ActionResult viewerEvent()
        //{
        //    return StiMvcViewer.ViewerEventResult(HttpContext);
        //}
    }

}
