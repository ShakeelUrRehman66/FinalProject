using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace finalproject.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
       
        public IActionResult RegisterUser()
        {
            return View();
        }
        public IActionResult ForgotPassword()
        {
            return View();
        }
        public IActionResult LockScreen()
        {
            return View();
        }
        public IActionResult UserProfile()
        {
            return View();
        }
        public IActionResult UserProfileAccount()
        {
            return View();
        }
    }
}