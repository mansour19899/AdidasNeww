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
        static int personidd = 0;
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

            if(status==3)
            {
                x.Checked = true;
                blPerson.Update(x);

                StaffRepository BlStaff = new StaffRepository();
                RelationShipRepository BlRelationShip = new RelationShipRepository();
                JobRecordRepository BlJob = new JobRecordRepository();

                Staff staff = new Staff();
                staff.Person_PFK = id;
                x.IsStaff = true;
                x.Checked = false;
                blPerson.Add(x);
                int NewId= AdidasNew.Controllers.HomeController.personId;
                staff.Person_FK = NewId;

                var Job = BlJob.Where(p => p.Person_FK == id).ToList();
                foreach (var item in Job)
                {
                    item.Person_FK = NewId;
                    BlJob.Add(item);
                }

                var RelationShips = BlRelationShip.Where(p => p.Person_FK == id).ToList();
                foreach (var item in RelationShips)
                {
                    item.Person_FK = NewId;
                    BlRelationShip.Add(item);
                }

                staff.StartWork = DateTime.Now;
                BlStaff.Add(staff);
            }
  
            
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
                case (int)PersonStatus.NotConfirmed:
                    return RedirectToAction("ListNotConfirmedPerson");
                case (int)PersonStatus.Confirmed:
                    return RedirectToAction("ListConfirmedPerson");
                case (int)PersonStatus.Staff:
                    return RedirectToAction("ListStaffs");
                case (int)PersonStatus.Deporte:
                    return RedirectToAction("ListDeportePerson");
                case (int)PersonStatus.Resignation:
                    return RedirectToAction("ListResignationPerson");
                default:
                    return RedirectToAction("ListNewPerson");
            }

        }

        public ActionResult ListConfirmedPerson()
        {
            PersonRepository blPerson = new PersonRepository();


            var list = blPerson.Where(p => p.Status == (int)PersonStatus.Confirmed).ToList().OrderByDescending(pp => pp.Id);

            return View(list);
        }
        public ActionResult ListDeportePerson()
        {
            PersonRepository blPerson = new PersonRepository();


            var list = blPerson.Where(p => p.Status == (int)PersonStatus.Deporte).ToList().OrderByDescending(pp => pp.Id);

            return View(list);
        }
        public ActionResult ListResignationPerson()
        {
            PersonRepository blPerson = new PersonRepository();


            var list = blPerson.Where(p => p.Status == (int)PersonStatus.Resignation).ToList().OrderByDescending(pp => pp.Id);

            return View(list);
        }

        public ActionResult ListNotConfirmedPerson()
        {
            PersonRepository blPerson = new PersonRepository();

            var list = blPerson.Where(p => p.Status == (int)PersonStatus.NotConfirmed).ToList().OrderByDescending(pp => pp.Id);

            return View(list);
        }
        public ActionResult ListStaffs()
        {
            PersonRepository blPerson = new PersonRepository();

            var list = blPerson.Where(p => p.Status == (int)PersonStatus.Staff & p.IsStaff == true).ToList().OrderByDescending(pp => pp.Id);

            return View(list);
        }

        [HttpGet]
        public ActionResult updateInformation(int id)
        {
            ViewBag.isupdate = true ;
            PersonRepository blPerson = new PersonRepository();
            JobRecordRepository blJob = new JobRecordRepository();
            RelationShipRepository BlrelationShip = new RelationShipRepository();
            personidd = id;
            DateOfBirth date = new DateOfBirth();
            ViewBag.Day = date.DayList;
            ViewBag.Month = date.MonthList;
            ViewBag.Year = date.YearList;

            PersonInfo personInfo = new PersonInfo();

            Person person = blPerson.Find(id);
            personInfo.Person = person;

            var jobs = blJob.Where(p => p.Person_FK == id).ToList();
            if(jobs.Count==3)
            {
                personInfo.JobRecord1 = jobs.ElementAt(0);
                personInfo.JobRecord2 = jobs.ElementAt(1);
                personInfo.JobRecord3 = jobs.ElementAt(2);
            }
            else if(jobs.Count==2)
            {
                personInfo.JobRecord1 = jobs.ElementAt(0);
                personInfo.JobRecord2 = jobs.ElementAt(1);
            }
            else if (jobs.Count == 1)
            {
                personInfo.JobRecord1 = jobs.ElementAt(0);
             
            }
            else
            {

            }

            var rel = BlrelationShip.Where(p => p.Person_FK == id).ToList();
            if (rel.Count == 3)
            {
                personInfo.RelationShip1 = rel.ElementAt(0);
                personInfo.RelationShip2 = rel.ElementAt(1);
                personInfo.RelationShip3 = rel.ElementAt(2);
            }
            else if (rel.Count == 2)
            {
                personInfo.RelationShip1 = rel.ElementAt(0);
                personInfo.RelationShip2 = rel.ElementAt(1);
            }
            else if (rel.Count == 1)
            {
                personInfo.RelationShip1 = rel.ElementAt(0);

            }
            else
            {

            }


            return View("../Home/Register", personInfo);
        }
        [HttpPost]
        public ActionResult updateInformation(PersonInfo per, HttpPostedFileBase UploadImage)
        {
            var yt = ModelState.IsValid;
            PersonRepository blPerson = new PersonRepository();
            JobRecordRepository blJob = new JobRecordRepository();
            RelationShipRepository blRelation = new RelationShipRepository();

            per.Person.Id = personidd;

            var perr = blPerson.Find(per.Person.Id);
            var job = blJob.Where(p => p.Person_FK == per.Person.Id).ToList();
            var rel = blRelation.Where(p => p.Person_FK == per.Person.Id).ToList();
            perr.Name = per.Person.Name;
            perr.LastName = per.Person.LastName;
            perr.Father = per.Person.Father;
            perr.MilitaryService = per.Person.MilitaryService;
            perr.Marriage = per.Person.Marriage;
            perr.Children = per.Person.Children;
            perr.Address = per.Person.Address;
            perr.Email = per.Person.Email;
            perr.Degree = per.Person.Degree;
            perr.Institute = per.Person.Institute;
            perr.Field = per.Person.Field;
            perr.EnglishKnowledge = per.Person.EnglishKnowledge;
            perr.Excel = per.Person.Excel;
            perr.Outlook = per.Person.Outlook;
            perr.PowerPoint = per.Person.PowerPoint;
            perr.Accounting = per.Person.Accounting;
            perr.OtherSoftwer = per.Person.OtherSoftwer;
            perr.Skills = per.Person.Skills;
            perr.SalaryExpection = per.Person.SalaryExpection;
            perr.JobStatus = per.Person.JobStatus;
            perr.DaysNumber = per.Person.DaysNumber;
            perr.WorkingGuranty = per.Person.WorkingGuranty;
            perr.Duration = per.Person.Duration;
            perr.GurantyPayment = per.Person.GurantyPayment;
            perr.Gender = per.Person.Gender;
            perr.Name = per.Person.Name;




            perr.NationalCode = per.Person.NationalCode.ConvertNumbersToEnglish();
            perr.Mobile = per.Person.Mobile.ConvertNumbersToEnglish();
            perr.Tell = per.Person.Tell.ConvertNumbersToEnglish();

            perr.BirthDay = (per.Date.Year + "/" + per.Date.Month + "/" + per.Date.Day).ToGeorgianDateTime();

            int countjob = job.Count();

            if (countjob > 0 & per.JobRecord1.Company!=null)
            {
                job.ElementAt(0).Company = per.JobRecord1.Company;
                job.ElementAt(0).Title = per.JobRecord1.Title;
                job.ElementAt(0).Duration = per.JobRecord1.Duration;
                job.ElementAt(0).Disconnection = per.JobRecord1.Disconnection;
                job.ElementAt(0).Address = per.JobRecord1.Address;
                job.ElementAt(0).Tell = per.JobRecord1.Tell;
                blJob.Update(job.ElementAt(0));
            }
            if (countjob > 1 & per.JobRecord2.Company != null)
            {
                job.ElementAt(1).Company = per.JobRecord2.Company;
                job.ElementAt(1).Title = per.JobRecord2.Title;
                job.ElementAt(1).Duration = per.JobRecord2.Duration;
                job.ElementAt(1).Disconnection = per.JobRecord2.Disconnection;
                job.ElementAt(1).Address = per.JobRecord2.Address;
                job.ElementAt(1).Tell = per.JobRecord2.Tell;
                blJob.Update(job.ElementAt(1));
            }
            if (countjob > 2 & per.JobRecord3.Company != null)
            {
                job.ElementAt(2).Company = per.JobRecord3.Company;
                job.ElementAt(2).Title = per.JobRecord3.Title;
                job.ElementAt(2).Duration = per.JobRecord3.Duration;
                job.ElementAt(2).Disconnection = per.JobRecord3.Disconnection;
                job.ElementAt(2).Address = per.JobRecord3.Address;
                job.ElementAt(2).Tell = per.JobRecord3.Tell;
                blJob.Update(job.ElementAt(2));
            }

            if(per.JobRecord1.Company!=null&countjob<1)
            {
                per.JobRecord1.Person_FK = personidd;
                blJob.Add(per.JobRecord1);
            }
            if (per.JobRecord2.Company != null & countjob <2)
            {
                per.JobRecord2.Person_FK = personidd;
                blJob.Add(per.JobRecord2);
            }

            if (per.JobRecord3.Company != null & countjob<3)
            {
                per.JobRecord3.Person_FK = personidd;
                blJob.Add(per.JobRecord3);
            }

            int countrel = rel.Count();

            if (countrel > 0 & per.RelationShip1.Name != null)
            {
                rel.ElementAt(0).Name = per.RelationShip1.Name;
                rel.ElementAt(0).Relational = per.RelationShip1.Relational;
                rel.ElementAt(0).Tell = per.RelationShip1.Tell;
                rel.ElementAt(0).Address = per.RelationShip1.Address;
                rel.ElementAt(0).Moaref = per.RelationShip1.Moaref;                
                blRelation.Update(rel.ElementAt(0));
            }
            if (countrel > 1 & per.RelationShip2.Name != null)
            {
                rel.ElementAt(1).Name = per.RelationShip2.Name;
                rel.ElementAt(1).Relational = per.RelationShip2.Relational;
                rel.ElementAt(1).Tell = per.RelationShip2.Tell;
                rel.ElementAt(1).Address = per.RelationShip2.Address;
                rel.ElementAt(1).Moaref = per.RelationShip2.Moaref;
                blRelation.Update(rel.ElementAt(1));
            }
            if (countrel > 2 & per.RelationShip3.Name != null)
            {
                rel.ElementAt(2).Name = per.RelationShip3.Name;
                rel.ElementAt(2).Relational = per.RelationShip3.Relational;
                rel.ElementAt(2).Tell = per.RelationShip3.Tell;
                rel.ElementAt(2).Address = per.RelationShip3.Address;
                rel.ElementAt(2).Moaref = per.RelationShip3.Moaref;
                blRelation.Update(rel.ElementAt(2));
            }

            if (per.RelationShip1.Name != null & countrel < 1)
            {
                per.RelationShip1.Person_FK = personidd;
                blRelation.Add(per.RelationShip1);
            }
            if (per.RelationShip2.Name != null & countrel < 2)
            {
                per.RelationShip2.Person_FK = personidd;
                blRelation.Add(per.RelationShip2);
            }

            if (per.RelationShip3.Name != null & countrel < 3)
            {
                per.RelationShip3.Person_FK = personidd;
                blRelation.Add(per.RelationShip3);
            }

            //------------------------------------------------Image----------------------------------------------------------
            //string AllowFormat = "image/jpeg,image/png,image/jpg,image/jpeg";
            //if (UploadImage != null && UploadImage.ContentLength > 0)
            //{
            //    if (!AllowFormat.Split(',').Contains(UploadImage.ContentType))
            //    {
            //        return MessageBox.Show(" فرمت عکس صحیح نیست", MessageType.Warning);
            //    }
            //    else
            //    {
            //        var yy = UploadImage.InputStream.ResizeImageByHeight(700, utilty.ImageComperssion.Normal);
            //        // UploadImage.InputStream.ResizeImageByHeight(500, @"E:\1\" + UploadImage.FileName);
            //        per.Person.image = yy;
            //    }

            //}
            //else
            //{
            //    return MessageBox.Show(" عکس انتخاب نشده است", MessageType.Warning);
            //}

            //--------------------------------------------------------------------------------------------------------------------------



            //per.Person.SalaryExpection = per.Person.SalaryExpection.Replace(",", string.Empty).ConvertNumbersToEnglish();
            //perr.SalaryExpection = per.Person.SalaryExpection.ConvertNumbersToEnglish();

            if (blPerson.Update(perr))
            {
        
                
                return MessageBox.Show("با موفقیت ویراش شد", MessageType.Success);
                
            }
            else
            {
                return MessageBox.Show(" ویراش  شد", MessageType.Error);
            }

           
        }

  


        [SendStatusHandler]
        [HttpPost]
        public ActionResult Confirmed(string Description, string PersonId)
        {
            return SetStatus(int.Parse(PersonId), (int)PersonStatus.Confirmed, Description);

           

        }
        [SendStatusHandler]
        [HttpPost]
        public ActionResult MakeStaff(string Description, string PersonId)
        {
            return SetStatus(int.Parse(PersonId), (int)PersonStatus.Staff, Description);

           

        }
        [SendStatusHandler]
        [HttpPost]
        public ActionResult Resignation(string Description, string PersonId)
        {
            return SetStatus(int.Parse(PersonId),(int)PersonStatus.Resignation, Description);

            // return RedirectToAction("ListConfirmedPerson");

        }
        [SendStatusHandler]
        [HttpPost]
        public ActionResult Deporte(string Description, string PersonId)
        {
            return SetStatus(int.Parse(PersonId), (int)PersonStatus.Deporte, Description);

            // return RedirectToAction("ListConfirmedPerson");

        }
        [SendStatusHandler]
        [HttpPost]
        public ActionResult NotConfirmed(string Description, string PersonId)
        {
            return SetStatus(int.Parse(PersonId), (int)PersonStatus.NotConfirmed, Description);

            // return RedirectToAction("ListNotConfirmedPerson");

        }

        public ActionResult History(int id)
        {

            historyOfPersonRepository per = new historyOfPersonRepository();
            AdidasNew.Models.ApplicationDbContext db = new Models.ApplicationDbContext();
            StaffRepository staff = new StaffRepository();
            var pkk = staff.Where(p=>p.Person_FK==id).FirstOrDefault();
            int ttt = 0;
            if(pkk!=null)
            {
                ttt = pkk.Person_PFK.Value;
            }

            var t = db.Users.ToList();
            var history = per.Where(p => p.Person_Id_fk == id||p.Person_Id_fk==ttt).ToList().OrderByDescending(p => p.RegDate);
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
                case (int)PersonStatus.NotConfirmed:
                    return RedirectToAction("ListNotConfirmedPerson");
                case (int)PersonStatus.Confirmed:
                    return RedirectToAction("ListConfirmedPerson");
                case (int)PersonStatus.Staff:
                    return RedirectToAction("ListStaffs");
                case (int)PersonStatus.Deporte:
                    return RedirectToAction("ListDeportePerson");
                case (int)PersonStatus.Resignation:
                    return RedirectToAction("ListResignationPerson");
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
