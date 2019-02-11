using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdidasNew.Models.Repositores;
using AdidasNew.ViewModels;
using AdidasNew.Models.DomainModels;

namespace AdidasNew.Controllers
{
    public class MobileAppController : Controller
    {
      public static  bool isvalid = false;
        QuestionRepository db = new QuestionRepository();
        // GET: MobileApp
        [HttpGet]
        public ActionResult Index()
        {
            isvalid = false;
            return View();
        }


        [HttpPost]
        public ActionResult Index(TempUser user)
        {
            if(user.Username.ToLower()=="kosar"&user.Password=="137705")
            {
                isvalid = true;
                return RedirectToAction("home");
                
            }
            else
            {
                ViewBag.massage = " نام کاربری یا رمز عبور اشتباه است";
                return View();
            }
 
        }

        [HttpGet]
        public ActionResult home()
        {
            if(isvalid)
            return View();
            else
                return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult NewQuestion()
        {
            if (isvalid)
                return View();
            else
                return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult NewQuestion(Question q )
        {
           if( db.Add(q))
            ViewBag.Success = "سوال با موفقیت ثبت شد";
            return View();
        }

    }
}