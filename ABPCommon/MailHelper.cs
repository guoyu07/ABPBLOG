using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using System.Configuration;

namespace ABPCommon
{
    public class MailHelper
    {
        public static void SendMail(string subject, string content, string recive)
        {
            //实例化邮箱API
            MailMessage message = new MailMessage();
            //添加发件人邮箱地址
            MailAddress formadreess = new MailAddress("1570819807@qq.com");
            //设置发件人
            message.From = formadreess;
            //设置收件人
            message.To.Add(recive);
            //设置抄送
            //message.CC.Add("");
            message.Subject = subject;
            message.Body = content;
            //设置邮件发送服务器,服务器根据你使用的邮箱而不同,可以到相应的 邮箱管理后台查看,下面是QQ的
            SmtpClient client = new SmtpClient("smtp.qq.com", 25);
            client.Credentials = new NetworkCredential("1570819807@qq.com", "gxihjrnlspnqgied");
            client.EnableSsl = true;
            client.Send(message);
        }
    }
}
