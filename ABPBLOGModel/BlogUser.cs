using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABPBLOGModel
{
    public class BlogUser
    {
        public virtual Guid UserID { get; set; }
        public virtual Guid UsergroupID { get; set; }
        public virtual string Username { get; set; }
        public virtual string UserAcc { get; set; }
        public virtual string UserPass { get; set; }
        public virtual bool UserSex { get; set; }
        public virtual string UserEmail { get; set; }
        /// <summary>
        /// 用户等级
        /// </summary>
        public virtual int UserRank { get; set; }
        /// <summary>
        /// 用户积分
        /// </summary>
        public virtual int UserMark { get; set; }
        /// <summary>
        /// 用户上一次登录IP地址
        /// </summary>
        public virtual string UserLastIP { get; set; }
        /// <summary>
        /// 自我描述
        /// </summary>
        public virtual string UserDescription { get; set; }
        /// <summary>
        /// 用户注册时间
        /// </summary>
        public virtual DateTime UserRegister { get; set; }
        /// <summary>
        /// 用户头像存储路径
        /// </summary>
        public virtual string UserImgPath { get; set; }
        /// <summary>
        /// 用户上次更新博客时间
        /// </summary>
        public virtual DateTime UserUpdateTime { get; set; }
        /// <summary>
        /// 是否锁定，0为不锁定，1为锁定
        /// </summary>
        public virtual int UserLock { get; set; }
        /// <summary>
        /// 是否冻结，0为不冻结，1为冻结
        /// </summary>
        public virtual int Userfreeze { get; set; }
        /// <summary>
        /// 拥有权限
        /// </summary>
        public virtual string UserPower { get; set; }

    }
}
