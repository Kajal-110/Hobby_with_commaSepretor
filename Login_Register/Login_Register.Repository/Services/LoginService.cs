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
    public class LoginService : ILogin
    {
        KajalPatel_01_07_2023Entities1 _context = new KajalPatel_01_07_2023Entities1();
        public string Login(RegistrationModel registrationModel)
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
    }
}
