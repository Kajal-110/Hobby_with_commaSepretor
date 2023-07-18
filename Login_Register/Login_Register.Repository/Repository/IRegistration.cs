using Login_Register.Model.DBContext;
using Login_Register.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login_Register.Repository.Repository
{
    public interface IRegistration
    {
        string UserRegister(RegistrationModel registrationModel);
        string LoginUser(RegistrationModel registrationModel);


        List<Country> GetAllCountry();
        List<State> GetAllState(int CountryId);

        List<City> GetAllCity(int StateId);
        //string Register(RegistrationModel registrationModel);

        List<RegistrationModel> GetAllUser();
        RegistrationModel GetUserByUserId(int Id);
    }
}
