using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Login_Register.Model.Models
{
    public class ImageModel
    {
        public int id { get; set; }
        public string Title { get; set; }
        [DisplayName("Upload File")]
        public string ImagePath { get; set; }

        public  HttpPostedFileBase ImageFile { get; set; }
    }
}
