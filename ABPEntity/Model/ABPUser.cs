using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABPEntity.Model
{
    public class ABPUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int user_id { get; set; }
        public int group_id { get; set; }
        public string user_name { get; set; }
        public string user_pwd { get; set; }
        public string user_phone { get; set; }
        public bool user_sex { get; set; }
        public string user_qq { get; set; }
        public string user_email { get; set; }
        public string user_address { get; set; }
        public int user_mark { get; set; }
        public int user_rank_id { get; set; }
        public string user_last_login_ip { get; set; }
        public DateTime user_birthday { get; set; }
        public string user_description { get; set; }
        public string user_image_url { get; set; }
        public DateTime user_register_time { get; set; }
        public bool user_lock { get; set; }
        public bool user_freeze { get; set; }
        public string user_power { get; set; }
    }
}
