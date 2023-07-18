using Login_Register.Model.DBContext;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Login_Register.Controllers
{
    public class HobbyController : Controller
    {
        KajalPatel_01_07_2023Entities1 db = new KajalPatel_01_07_2023Entities1();
        // GET: Hobby
        public ActionResult create()
        {
            ViewBag.HobbyList = db.Hobbies.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult create( UserRecord12 userRecord, string[] hobbies)
        {
            ViewBag.HobbyList=db.Hobbies.ToList();
            //string[] checkedHobbies = 
            userRecord.Hobbies = "";
            foreach (var item in hobbies)
            {
                if (item!="false")
                {
                    userRecord.Hobbies += item+",";
                }
            }
            //userRecord.Hobbies = string.Join(",", hobbies);
            db.UserRecord12.Add(userRecord);
            db.SaveChanges();
            return View();
        }

        public JsonResult HobbyList()
        {
            List<Hobby> hobbies = db.Hobbies.ToList();
            var jsonQuesData = JsonConvert.SerializeObject(hobbies);
            return Json(jsonQuesData, JsonRequestBehavior.AllowGet);
        }
        
    }
}