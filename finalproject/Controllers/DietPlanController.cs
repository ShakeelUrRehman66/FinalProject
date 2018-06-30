using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using finalproject.Models;
using Microsoft.AspNetCore.Mvc;

namespace finalproject.Controllers
{
    public class DietPlanController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DietPlanController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.DietPlans.ToList());
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(DietPlan dietplan)
        {
            _context.DietPlans.Add(dietplan);
            _context.SaveChanges();
            return View();
        }
        public IActionResult Edit(int id)
        {
            var item = _context.DietPlans.Find(id);
            return View(item);
        }
        public IActionResult Update(DietPlan dp)
        {
            var item = _context.DietPlans.Find(dp.Id);
            item.DateFrom = dp.DateFrom;
            item.DateTo = dp.DateTo;
            item.DietName = dp.DietName;
            item.pateintID = dp.pateintID;
            item.Description = dp.Description;
            _context.DietPlans.Update(item);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
           var item= _context.DietPlans.Find(id);
            _context.DietPlans.Remove(item);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}