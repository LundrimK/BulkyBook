using BulkyBook.DataAccess;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CoverTypeController : Controller
    {
        private readonly IUnitOfWork _db;
        public CoverTypeController(IUnitOfWork db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<CoverType> objCoverTypeList = _db.CoverType.GetAll();
            return View(objCoverTypeList);
        }
        //GET
        public IActionResult Create()
        {
            return View();
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CoverType cover)
        {
            
            if (ModelState.IsValid)
            {
                _db.CoverType.Add(cover);
                _db.Save();
                TempData["success"] = "Category Created successfully";
                return RedirectToAction("Index");
            }
            return View(cover);
        }

        //GET
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var coverFromDb = _db.CoverType.GetFirstOrDefault(u => u.Id == id);

            if (coverFromDb == null)
            {
                return NotFound();
            }
            return View(coverFromDb);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CoverType cover)
        {
            if (cover.Name == cover.ToString())
            {
                ModelState.AddModelError("CustomError", "Ka je nis babo me dyjat tnjejta");
            }
            if (ModelState.IsValid)
            {
                _db.CoverType.Update(cover);
                _db.Save();
                TempData["success"] = "Category Updated successfully";
                return RedirectToAction("Index");
            }
            return View(cover);
        }
        //GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var coverFromDb = _db.CoverType.GetFirstOrDefault(u => u.Id == id);

            if (coverFromDb == null)
            {
                return NotFound();
            }
            return View(coverFromDb);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.CoverType.GetFirstOrDefault(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.CoverType.Remove(obj);
            _db.Save();
            TempData["success"] = "Category Removed successfully";
            return RedirectToAction("Index");


        }
    }
}
