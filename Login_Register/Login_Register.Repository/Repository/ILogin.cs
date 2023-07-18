using Login_Register.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login_Register.Repository.Repository
{
    public interface ILogin
    {
        string Login(RegistrationModel registrationModel);
    }
}
