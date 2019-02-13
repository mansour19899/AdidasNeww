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
        public static string creator = "";
        public static int tempPage =1;
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
            string distnace = "home";
            if(user.Username.ToLower()=="kosar"&user.Password=="137705")
            {
                isvalid = true;
                creator = "کوثر";
                return RedirectToAction(distnace);
                
            }
            else if (user.Username.ToLower() == "ali" & user.Password == "136911")
            {
                isvalid = true;
                creator = "علی";
                return RedirectToAction(distnace);
            }
            else if (user.Username.ToLower() == "javad" & user.Password == "13733")
            {
                isvalid = true;
                creator = "جواد";
                return RedirectToAction(distnace);
            }
            else if (user.Username.ToLower() == "zohreh" & user.Password == "13623")
            {
                isvalid = true;
                creator = "دیانا";
                return RedirectToAction(distnace);
            }
            else if (user.Username.ToLower() == "mansour" & user.Password == "136815")
            {
                isvalid = true;
                creator = "منصور";
                return RedirectToAction(distnace);
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
        public ActionResult NewQuestion(int id=0)
        {
            if (isvalid)
                if(id==0)
                {
                    ViewBag.back = "home";
                    return View(new Question() { Id=0});

                }

            else
                {
                    ViewBag.back = "../../MobileApp/Questions/" + tempPage;
                    var q = db.Find(id);
                    return View(q);
                }
            else
                return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult NewQuestion(Question q )
        {
            if(q.Id==0)
            {
                ViewBag.back = "../../MobileApp/home";
                q.Creator = creator;
                if (db.Add(q))
                    ViewBag.Success = "سوال با موفقیت ثبت شد";
                return View(new Question() { Id = 0 });
            }
            else
            {
                q.Creator = creator;
                ViewBag.back = "../../MobileApp/Questions/" + tempPage;
                if (db.Update(q))
                    ViewBag.Success = "سوال با موفقیت ویرایش شد";
                return View(q);
            }

        }

        public ActionResult Questions(int id=1)
        {
            tempPage = id;
            if (isvalid)
            {
                int take = 10;
                int skip = (id-1)*take;
                int count = db.Count();

                ViewBag.pageId = id;
                if(count%3==0)
                    ViewBag.pageCount = count / take;
                else
                    ViewBag.pageCount = count / take+1;


                var list = db.Select().OrderByDescending(p=>p.Id).Skip(skip).Take(take).ToList();
                return View(list);
            }

            else
                return RedirectToAction("Index");
        }

    }
}