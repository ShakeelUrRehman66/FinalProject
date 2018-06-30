using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using finalproject.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace finalproject.Controllers
{
    public class ReportsController : Controller
    {
        private readonly IHostingEnvironment _env;
        private readonly ApplicationDbContext _context;

        public ReportsController(ApplicationDbContext context,IHostingEnvironment env)
        {
            _env = env;
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.MedicalRecords.ToList());
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(MedicalRecord reports)
        {
            if (ModelState.IsValid)
            {
                reports.images = null;
                if (reports.image != null && reports.image.Length > 0)
                {
                    var uploads = Path.Combine(_env.WebRootPath, "images/Reports");
                    var fileName = ContentDispositionHeaderValue.Parse(reports.image.ContentDisposition).FileName.Trim('"');
                    using (var fileStream = new FileStream(Path.Combine(uploads, reports.image.FileName), FileMode.Create))
                    {
                        reports.image.CopyTo(fileStream);
                        reports.images = reports.images = Path.Combine(reports.image.FileName);
                    }
                }
                _context.MedicalRecords.Add(reports);
            _context.SaveChanges();
            }
            return View();
        }
        public IActionResult Edit(int id)
        {
            var item = _context.MedicalRecords.Find(id);
            return View(item);
        }
        public IActionResult Update(MedicalRecord medicalRecord)
        {
            var item = _context.MedicalRecords.Find(medicalRecord.Id);
            item.PatientId = medicalRecord.PatientId;
            item.ShortDescription = medicalRecord.ShortDescription;
            _context.Update(item);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var item = _context.MedicalRecords.Find(id);
            _context.Remove(item);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }

}