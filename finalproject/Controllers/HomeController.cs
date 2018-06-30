using finalproject.Models;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System.Diagnostics;

namespace finalproject.Controllers
{

    public class HomeController : Controller
    {
        
        public string Role { get; set; }
        
        public IActionResult Index()
        {

            if (HttpContext.Session.GetString("Role") == "Admin")
            {
                return View();
            }
            else
            {
                return Redirect("/Admin/login");
            }
               
            
            
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()

        {
           
        var message = new MimeMessage();
            message.From.Add(new MailboxAddress("szs53@outlook.com"));
            message.To.Add(new MailboxAddress("shakeelzain89@gmail.com"));
            message.Subject = "New Mail";
            message.Body = new TextPart("Html")
            {

            };
            using(var client=new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587);
                client.Authenticate("shakeelzain89@gmail.com", "xbcn41s17");
                client.Send(message);
                client.Disconnect(false);
            }

            return View();
        }
        public IActionResult Blank()
        {
           
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
