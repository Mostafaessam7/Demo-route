using Demo.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Helper
{
    public static class MailSender
    {
        public static string SendMail(MailVM model)
        {
            try
            {
                using (var smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.EnableSsl = true;
                    smtp.Credentials = new NetworkCredential("mostafaesam.farhat@gmail.com", "mostafatefa10halwsa10&&mostafamtefa11halwsa10");
                    smtp.Send("mostafaesam.farhat@gmail.com", "mtefa2777@gmail.com", model.Titel, model.Message);


                }

                return "Done , Mail Send Successfully";
            }
            catch (Exception ex)
            {

                return "Faild to send";
            }
        }

    }
}
