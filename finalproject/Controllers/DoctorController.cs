using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using finalproject.Models;
using Microsoft.AspNetCore.Mvc;

namespace finalproject.Controllers
{
    public class DoctorController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DoctorController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            ApplicationViewModel viewModel = new ApplicationViewModel();
            viewModel.Doctors = _context.Doctors.ToList();
            return View(viewModel.Doctors);
           
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(Doctor doctor)
        {
            _context.Doctors.Add(doctor);
            _context.SaveChanges();
            return RedirectToAction("Register");
        }
        public IActionResult Edit(int id)
        {
            var item=_context.Doctors.Find(id);
            return View(item);
        }
        public IActionResult Update(Doctor doctor)
        {
            var item = _context.Doctors.Find(doctor.DoctorId);
            item.Name =doctor.Name;
            item.Password =doctor.Password;
            item.Qualification =doctor.Qualification;
            item.Specialization =doctor.Specialization;
            item.Timings =doctor.Timings;
            item.Hospital =doctor.Hospital;
            item.Email=doctor.Email;
            item.Age =doctor.Age;
            _context.Doctors.Update(item);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var item=_context.Doctors.Find(id);
            _context.Doctors.Remove(item);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}