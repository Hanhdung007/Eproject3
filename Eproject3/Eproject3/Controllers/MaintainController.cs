using Eproject3.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Eproject3.Controllers
{
    public class MaintainController : Controller
    {
        private eProject3Context _context;
        public MaintainController (eProject3Context context)
        {
            _context = context;
        }
        // GET: MaintainController
        public ActionResult Index()
        {
            var model = _context.MaintainceDevices.Include(m => m.DevicesId).Include(a=>a.Id).ToList();
            return View(model);
        }

        // GET: MaintainController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MaintainController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MaintainController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MaintainController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MaintainController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MaintainController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MaintainController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
