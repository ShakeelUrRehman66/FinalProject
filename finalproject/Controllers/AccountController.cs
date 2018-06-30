using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

namespace finalproject.Controllers
{
    public class AccountController : Controller
    {
      


        public static int randomnugenerator()
        {
            Random rndm = new Random();
            return rndm.Next(00000, 10000);
        }

        public IActionResult Login()
        {
            return Redirect("/Admin/login");
        }

        public int resettoken = randomnugenerator();
       [HttpPost]
        public IActionResult Resetpassword(string mailto)
        {
            if (mailto != null) {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("szs53@outlook.com"));
                message.To.Add(new MailboxAddress(mailto));
                message.Subject = "PasswordResetEmail";
                message.Body = new TextPart("Html")
                {
                    Text = "This is ResetToken " + resettoken + "<br>"
                    + "<br>"
                    + "Clcik On the link to reset" + "<a href='/Home/About'>ResetLink</a>"

                };
                using (var client = new SmtpClient())
                {
                    client.Connect("smtp.gmail.com", 587);
                    client.Authenticate("shakeelzain89@gmail.com", "xbcn41s17");
                    client.Send(message);
                    client.Disconnect(false);
                }
                HttpContext.Session.SetString("resetemail", mailto);
                return Redirect("/Admin/token");
            }
            else
            {
                HttpContext.Session.SetString("Message","Please Provide A Vlaid Email Address");
                return Redirect("/Admin/ForgotPassword");
            }
        
        }
    }
}