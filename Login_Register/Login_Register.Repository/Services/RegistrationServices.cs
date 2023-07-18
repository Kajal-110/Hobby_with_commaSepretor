using Login_Register.Helper.Helpers;
using Login_Register.Model.DBContext;
using Login_Register.Model.Models;
using Login_Register.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login_Register.Repository.Services
{
    public class RegistrationServices : IRegistration
    {
        KajalPatel_01_07_2023Entities1 _context = new KajalPatel_01_07_2023Entities1();

        public List<City> GetAllCity(int StateId)
        {
            List<City> cities = _context.Cities.Where(x => x.StateId == StateId).ToList();
            return cities;
        }

        public List<Country> GetAllCountry()
        {
            List<Country> countries = _context.Countries.ToList();
            return (countries);
        }

        public List<State> GetAllState(int CountryId)
        {

            List<State> states = _context.States.Where(x => x.CountryId == CountryId).ToList();
            return states;
        }

      
        public string LoginUser(RegistrationModel registrationModel)
        {
            try
            {
                var email = _context.Registrations.Where(x => x.Email == registrationModel.Email).FirstOrDefault();
                var pass = _context.Registrations.Where(x => x.Password == registrationModel.Password).FirstOrDefault();
                if (email == null && pass == null)
                {
                    return "Invalid Email and Password ";

                }
                else if (email != null)
                {
                    if (email.Password != registrationModel.Password)
                    {
                        return "Invalid Password";
                    }
                    else
                    {
                        return email.Email;
                    }
                }
                else
                {
                    return "Invalid Email";
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public string UserRegister(RegistrationModel registrationModel)
        {
            try
            {
                Registration registration = new Registration();


                registration = RegistrationHelpers.ConvertToCustom(registrationModel);
                if (registration != null)
                {
                    _context.Registrations.Add(registration);
                    _context.SaveChanges();
                    return "Success";
                }
                else
                {
                    return "Fail";
                }

            }
            catch (Exception e)
            {
                throw e;
            }
        }
        //public string Register(RegistrationModel registrationModel)
        //{
        //    Registration regi = new Registration();
        //    regi = RegistrationHelpers.ConvertToCustom(registrationModel);
        //    if (regi != null)
        //    {
        //        _context.Registrations.Add(regi);
        //        _context.SaveChanges();
        //        return "Success";
        //    }
        //    else
        //    {
        //        return "Fail";
        //    }
        //}
        public List<RegistrationModel> GetAllUser()
        {
            try
            {

                List<Registration> registrations = new List<Registration>();
                List<RegistrationModel> registrationModels = new List<RegistrationModel>();

                registrations = _context.Registrations.ToList();
                if (registrations != null && registrations.Count > 0)
                {
                    registrationModels = RegistrationHelpers.convertUserToUserModel(registrations);

                }
                return registrationModels;
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

        public  RegistrationModel GetUserByUserId(int Id)
        {
            try
            {
               
                Registration registration = _context.Registrations.Where(x => x.UserId == Id).FirstOrDefault();
                if(registration != null)
                {
                    RegistrationModel registrationModel = RegistrationHelpers.ConvertToDB(registration);
                    return registrationModel;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}


        


       
  

       
 


