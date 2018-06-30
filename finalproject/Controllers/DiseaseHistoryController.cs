using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using finalproject.Models;
using Microsoft.AspNetCore.Mvc;

namespace finalproject.Controllers
{
    public class DiseaseHistoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DiseaseHistoryController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.DiseaseHistories.ToList());
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(DiseaseHistory diseasehistory)
        {
            _context.DiseaseHistories.Add(diseasehistory);
            _context.SaveChanges();
            return RedirectToAction("Index") ;
        }
        public IActionResult Edit(int id)
        {
            var item = _context.DiseaseHistories.Find(id);
            return View(item);
        }
        public IActionResult Update(DiseaseHistory dishis)
        {
            var item = _context.DiseaseHistories.Find(dishis.DisHisID);
            item.DiseaseName = dishis.DiseaseName;
            item.duration = dishis.duration;
            item.Type = dishis.Type;
            _context.DiseaseHistories.Update(item);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}