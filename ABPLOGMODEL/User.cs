using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABPLOGMODEL
{
    public class User
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string UserPassWord { get; set; }
        public int UserSex { get; set; }
        public DateTime UserBirthday { get; set; }
        public string UserBirthPlace { get; set; }
        public string UserMailbox { get; set; }
        public string UserQQ { get; set; }
        public int UserState { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public int BlogID { get; set; }
        public int ImageUserID { get; set; }
        public int UserTypeID { get; set; }

    }
}
