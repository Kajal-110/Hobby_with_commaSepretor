using Login_Register.Model.DBContext;
using Login_Register.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login_Register.Helper.Helpers
{
    public static class RegistrationHelpers
    {
        public static RegistrationModel ConvertToDB(Registration registration)
        {
            RegistrationModel registrationModel = new RegistrationModel();
            registrationModel.UserId = registration.UserId;
            registrationModel.FirstName = registration.FirstName;
            registrationModel.LastName = registration.LastName;
            registrationModel.Email = registration.Email;
            registrationModel.Password = registration.Password;
            //registrationModel.Date_of_birth = registration.Date_of_birth;
            registrationModel.Address = registration.Address;
            //registrationModel.CountryId = registration.CountryId;
          
           // registrationModel.StateId = registration.StateId;
            //registrationModel.CityId = registration.CityId;
            registrationModel.Profile_photo = registration.Profile_photo;
            registrationModel.Attachment = registration.Attachment;
            registrationModel.Gender = registration.Gender;
            registrationModel.Hobbies = registration.Hobbies;
            return registrationModel;
        }


        public static Registration ConvertToCustom(RegistrationModel registration)
        {

            Registration registrationModel = new Registration();
            registrationModel.UserId = registration.UserId;
            registrationModel.FirstName = registration.FirstName;
            registrationModel.LastName = registration.LastName;
            registrationModel.Email = registration.Email;
            registrationModel.Password = registration.Password;
            registrationModel.Date_of_birth = registration.Date_of_birth;
            registrationModel.Address = registration.Address;
            registrationModel.CountryId = registration.CountryId;
           
            registrationModel.StateId = registration.StateId;
            registrationModel.CityId = registration.CityId;
            registrationModel.Profile_photo = registration.Profile_photo;
            registrationModel.Attachment = registration.Attachment;
            registrationModel.Gender = registration.Gender;
            registrationModel.Hobbies = registration.Hobbies;
            return registrationModel;
        }


        public static List<RegistrationModel> convertUserToUserModel(List<Registration> registration)
        {
            try
            {

                List<RegistrationModel> UserList = new List<RegistrationModel>();
                foreach (var item in registration)
                {
                    
                    RegistrationModel registrationModel = new RegistrationModel();
                    registrationModel.UserId = item.UserId;
                    registrationModel.FirstName = item.FirstName;
                    registrationModel.LastName = item.LastName;
                    registrationModel.Email =item.Email;
                    registrationModel.Password =item.Password;
                    //registrationModel.Date_of_birth =item.Date_of_birth;
                    registrationModel.Address =item.Address;                    
                    //registrationModel.CountryId =item.CountryId;
                    registrationModel.Country = item.Country.CountryName;
                    //registrationModel.StateId =item.StateId;
                    registrationModel.State = item.State.StateName;
                    //registrationModel.CityId =item.CityId;
                    registrationModel.City = item.City.CityName;
                    registrationModel.Profile_photo =item.Profile_photo;
                    registrationModel.Attachment =item.Attachment;
                    registrationModel.Gender =item.Gender;
                    registrationModel.Hobbies =item.Hobbies;
                    UserList.Add(registrationModel);
                }
                return UserList;
            }
            catch (System.Exception e)
            {
                throw e;
            }

        }
    }
}
