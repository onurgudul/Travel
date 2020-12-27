using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelGuide.Business.Abstract;

namespace TravelGuide.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly INoteService _noteService;
        private readonly ICategoryService _categoryService;
        public HomeController(INoteService noteService, ICategoryService categoryService)
        {
            _noteService = noteService;
            _categoryService = categoryService;
        }
        // GET: Home
        public ActionResult Index()
        {
            var noteList = _noteService.NoteWithAll().Data;
            ViewData["CategoryList"] = _categoryService.GetList().Data;
            return View(noteList);
        }
        public ActionResult ByCategory(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var list = _noteService.NoteWithAll().Data.Where(x => x.CategoryId == id);
            return View("Index", list);
        }
    }
}