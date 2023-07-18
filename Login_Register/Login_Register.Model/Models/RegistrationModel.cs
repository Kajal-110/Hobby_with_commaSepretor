using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Login_Register.Model.Models
{
    public class RegistrationModel
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public System.DateTime Date_of_birth { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public int CountryId { get; set; }
        [Required]
        public int StateId { get; set; }
        [Required]
        public int CityId { get; set; }
        
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        //public string Profile_photo { get; set; }

        [DisplayName("Upload File")]
        public string Profile_photo { get; set; }

        public HttpPostedFileBase ImageFile { get; set; }
        public string Attachment { get; set; }
        [Required]
        public string Gender { get; set; }
         
        public string Hobbies { get; set; }
        public bool hobby { get; set; }
    }
}
