using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using finalproject.Models;
using Microsoft.AspNetCore.Mvc;

namespace finalproject.Controllers
{
    public class PatientController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PatientController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            ApplicationViewModel viewModel = new ApplicationViewModel();
            viewModel.Patients = _context.Patients.ToList();
            return View(viewModel);
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(Patient patient)
        {
            if (ModelState.IsValid)
            {
                _context.Patients.Add(patient);
                _context.SaveChanges();
            }
            
            return View();
        }
        public IActionResult Edit(int id)
        {
            var item = _context.Patients.Find(id);
            return View(item);
        }
        public IActionResult Update(Patient patient)
        {
            var item = _context.Patients.Find(patient.PId);
            item.Name = patient.Name;
            item.Email = patient.Email;
            item.Age = patient.Age;
            item.Password = patient.Password;
            item.CNIC = patient.CNIC;
            item.Disease = patient.Disease;
            _context.Patients.Update(item);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var item = _context.Patients.Find(id);
            _context.Patients.Remove(item);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}