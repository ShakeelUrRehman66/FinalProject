using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using finalproject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace finalproject.Controllers
{
    public class AdminController : Controller
    {
        private readonly IHostingEnvironment _env;
        private readonly ApplicationDbContext _context;

        public int emailinuse(string email)
        {
            return _context.Admins.Where(x => x.Email.Contains(email)).Count();
        }
        public string Role { get; private set; }

        public AdminController(ApplicationDbContext context,IHostingEnvironment env)
        {
            _env = env;
            _context=context;
        }
       
        public IActionResult Index()
        {
            
            Role = HttpContext.Session.GetString("Role");
            if (Role == "Admin")
            {
                ApplicationViewModel viewModel = new ApplicationViewModel();
                viewModel.Admins = _context.Admins.ToList();
                return View(viewModel);
            }
            else
            {
                return Redirect("/Admin/login");
            }
          
        }
        public IActionResult Register()
        {
           
            return View();
        }
        public IActionResult ForgotPassword()
        {
            if(HttpContext.Session.GetString("Message")!=null){
                ViewBag.Message = HttpContext.Session.GetString("Message");
                HttpContext.Session.Remove("Message");
                return View();

            }
            return View();
        }
        [HttpPost]
        public IActionResult ResetPassword()
        {
            return View();
        }
        public IActionResult token()
        {
            ViewBag.email=HttpContext.Session.GetString("resetemail");
            return View();
        }
        public IActionResult Profile()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Register(Admin admin)
        {
            if (emailinuse(admin.Email) >= 1)
            {
                ModelState.AddModelError("Emailinuse", "This Email is Already A Part of An Account Use Another");
                HttpContext.Session.SetString("EmailUsed", "This Email is Already in Use");

                }
            if (ModelState.IsValid)
            {

                admin.Password = Helpers.encrypter(admin.Password);
                admin.userimages = null;
                admin.Role = "Admin";
            

                if (admin.userimage != null && admin.userimage.Length > 0)
                {
                    var uploads = Path.Combine(_env.WebRootPath, "images/Admin");
                    var fileName = ContentDispositionHeaderValue.Parse(admin.userimage.ContentDisposition).FileName.Trim('"');
                    using (var fileStream = new FileStream(Path.Combine(uploads,admin.userimage.FileName), FileMode.Create))
                    {
                        admin.userimage.CopyTo(fileStream);
                        admin.userimages = admin.userimages = Path.Combine(admin.userimage.FileName);
                    }
                }
                else
                {
                    admin.userimages = "team3.jpg";
                }
                _context.Admins.Add(admin);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
            
        }
        public IActionResult Delete(int id)
        {
            var item=_context.Admins.Find(id);
            _context.Admins.Remove(item);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult login()
        {
            ViewBag.Request=Request.Path;
            return View();
        }
        public IActionResult Edit(int id)
        {
           var item= _context.Admins.Find(id);
            return View(item);
        }
        [HttpPost]
        public IActionResult Update(Admin admin)
        {

            var item = _context.Admins.Find(admin.ID);
            item.Name = admin.Name;
            item.Password = admin.Password;
            item.Age = admin.Age;
            item.CNIC = admin.CNIC;
            _context.Admins.Update(item);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult login(Admin admin)
        {
          var logedadmin= _context.Admins.Where(x => x.Email == admin.Email && x.Password==admin.Password).FirstOrDefault();
            if (logedadmin != null)
            {
                HttpContext.Session.SetString("name", logedadmin.Name);
                HttpContext.Session.SetString("Email", logedadmin.Email);
                
                HttpContext.Session.SetInt32("Id", logedadmin.ID);
                HttpContext.Session.SetString("Role", logedadmin.Role);
                HttpContext.Session.SetString("ProfilePic", logedadmin.userimages);
                return Redirect("/Home/Index");
            }
            else{

                ModelState.AddModelError("", "Username OR Password Wrong");
                
            }
            return View();   
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return Redirect("/");
        }
    }
}