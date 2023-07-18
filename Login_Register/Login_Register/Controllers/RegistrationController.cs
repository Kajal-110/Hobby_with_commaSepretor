using Login_Register.Model.DBContext;
using Login_Register.Model.Models;
using Login_Register.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Login_Register.Controllers
{
    public class RegistrationController : Controller
    {
        KajalPatel_01_07_2023Entities1 _context = new KajalPatel_01_07_2023Entities1();

        IRegistration RInterface;
        public RegistrationController(IRegistration RInterface)
        {
            this.RInterface = RInterface;
        }

        public ActionResult Login()
        {
            return View();
        }



        [HttpPost]
        public ActionResult Login(RegistrationModel registrationModel)
        {
            string Login = RInterface.LoginUser(registrationModel);
            if (Login == "Invalid Email and Password " || Login == "Invalid Password" || Login == "Invalid Email")
            {
                TempData["Error"] = Login;
                return View();
            }
            else
            {
                Session["Email"] = Login;
                return RedirectToAction("Index", "Home");
            }

        }


        [HttpGet]
        public ActionResult Register()
        {
            ViewBag.CountryList = new SelectList(RInterface.GetAllCountry(), "CountryId", "CountryName");
            return View();
        }
        [HttpPost]
        public ActionResult Register(RegistrationModel registrationModel,FormCollection fc)
        {
            ViewBag.CountryList = new SelectList(RInterface.GetAllCountry(), "CountryId", "CountryName");

            var x =fc["hobby"];

            //string FileName = Path.GetFileNameWithoutExtension(registrationModel.ImageFile.FileName);
            //string FileExtension = Path.GetExtension(registrationModel.ImageFile.FileName);
            //FileName = DateTime.Now.ToString("yyyyMMdd") + "-" + FileName.Trim() + FileExtension;
            //string UploadPath = ConfigurationManager.AppSettings["UserImagePath"].ToString();
            //registrationModel.Profile_photo = UploadPath + FileName;
            //registrationModel.ImageFile.SaveAs(registrationModel.Profile_photo);

            string aa = RInterface.UserRegister(registrationModel);

            if (aa == "Success")
            {
                return RedirectToAction("GetData", "Registration");
            }

            else
            {
                return View();
            }

        }

        public ActionResult GetStateList(int CountryId)
        {
            KajalPatel_01_07_2023Entities1 _context = new KajalPatel_01_07_2023Entities1();
            List<State> SList = _context.States.Where(x => x.CountryId == CountryId).ToList();
            ViewBag.StateList = new SelectList(SList, "StateId", "StateName");
            return PartialView("DisplayState");
        }

        public ActionResult GetCityList(int StateId)
        {
            KajalPatel_01_07_2023Entities1 _context = new KajalPatel_01_07_2023Entities1
                ();
            List<City> CList = _context.Cities.Where(x => x.StateId == StateId).ToList();
            ViewBag.CityList = new SelectList(CList, "CityId", "CityName");
            return PartialView("DisplayCity");
        }

        public ActionResult GetData(int id)
        {


            RegistrationModel registration = RInterface.GetUserByUserId(id);
                return View(registration);
           
        }
        public ActionResult GetUserDataList(RegistrationModel registrationModel)
        {
            var aa = RInterface.GetAllUser();
            return View(aa);
        }
    }
}