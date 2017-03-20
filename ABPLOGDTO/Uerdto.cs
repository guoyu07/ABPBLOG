using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABPLOGDTO
{
    public class Uerdto
    {
        public string user_name_dto { get; set; }
        public string user_pwd_dto { get; set; }
        public string user_phone_dto { get; set; }
        public bool user_sex_dto { get; set; }
        public string user_email_dto { get; set; }
        public string user_last_login_ip_dto { get; set; }
        public string user_description_dto { get; set; }
        public string user_image_url_dto { get; set; }
        public DateTime user_register_time_dto { get; set; }
    }
}
