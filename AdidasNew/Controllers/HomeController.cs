using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdidasNew.Models.EntityModels;
using AdidasNew.Models.Repositores;
using AdidasNew.ViewModels;

namespace AdidasNew.Controllers
{
    public class HomeController : Controller
    {
        private AdidasNew.Models.DomainModels.DatabaseContext db = null;
        public static int personId;
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            DateOfBirth date = new DateOfBirth();
            ViewBag.Day = date.DayList;
            ViewBag.Month = date.MonthList;
            ViewBag.Year = date.YearList;



            return View();
        }

        [HttpPost]
        public ActionResult Register(PersonInfo per, HttpPostedFileBase UploadImage)
        {
            personId = 0;
            per.Person.BirthDay = (per.Date.Year + "/" + per.Date.Month + "/" + per.Date.Day).ToGeorgianDateTime();
            per.Person.RegPerson = DateTime.Now;



            //------------------------------------------------Image----------------------------------------------------------
            string AllowFormat = "image/jpeg,image/png,image/jpg,image/jpeg";
            if (UploadImage != null && UploadImage.ContentLength > 0)
            {
                if (!AllowFormat.Split(',').Contains(UploadImage.ContentType))
                {
                    return MessageBox.Show(" فرمت عکس صحیح نیست", MessageType.Warning);
                }
                else
                {
                    var yy = UploadImage.InputStream.ResizeImageByHeight(700, utilty.ImageComperssion.Normal);
                    // UploadImage.InputStream.ResizeImageByHeight(500, @"E:\1\" + UploadImage.FileName);
                    per.Person.image = yy;
                }

            }
            else
            {
                return MessageBox.Show(" عکس انتخاب نشده است", MessageType.Warning);
            }

            //--------------------------------------------------------------------------------------------------------------------------


            per.Person.NationalCode = per.Person.NationalCode.ConvertNumbersToEnglish();
            per.Person.Mobile = per.Person.Mobile.ConvertNumbersToEnglish();
            per.Person.Tell = per.Person.Tell.ConvertNumbersToEnglish();
            //per.Person.SalaryExpection = per.Person.SalaryExpection.Replace(",", string.Empty).ConvertNumbersToEnglish();
            per.Person.SalaryExpection = per.Person.SalaryExpection.ConvertNumbersToEnglish();
            per.Person.Status = 0;

            PersonRepository blPerson = new PersonRepository();
            JobRecordRepository blJob = new JobRecordRepository();
            RelationShipRepository blRelation = new RelationShipRepository();

            if (blPerson.Add(per.Person))
            {
                per.JobRecord1.Person_FK = personId;
                per.JobRecord2.Person_FK = personId;
                per.JobRecord3.Person_FK = personId;

                per.RelationShip1.Person_FK = personId;
                per.RelationShip2.Person_FK = personId;
                per.RelationShip3.Person_FK = personId;

                if (per.JobRecord1.Company != null)
                    blJob.Add(per.JobRecord1);
                if (per.JobRecord2.Company != null)
                    blJob.Add(per.JobRecord2);
                if (per.JobRecord3.Company != null)
                    blJob.Add(per.JobRecord3);

                if (per.RelationShip1.Name != null)
                    blRelation.Add(per.RelationShip1);
                if (per.RelationShip2.Name != null)
                    blRelation.Add(per.RelationShip2);
                if (per.RelationShip3.Name != null)
                    blRelation.Add(per.RelationShip3);

                return MessageBox.Show("با موفقیت ثبت شد", MessageType.Success);
            }

            else
                return MessageBox.Show(" ثبت نشد", MessageType.Error);
            //return View();
        }

    }
}
