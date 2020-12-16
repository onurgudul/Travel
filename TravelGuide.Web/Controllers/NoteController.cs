using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TravelGuide.Business.Abstract;
using TravelGuide.Entities.Concreate;

namespace TravelGuide.Web.Controllers
{
    public class NoteController : Controller
    {
        private readonly INoteService _noteService;
        private readonly ICategoryService _categoryService;
        public NoteController(INoteService noteService, ICategoryService categoryService)
        {
            _noteService = noteService;
            _categoryService = categoryService;
        }
        // GET: Note
        public ActionResult Index()
        {
            var notes = _noteService.NoteWithAll().Data;

            return View(notes);
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var notes = _noteService.GetById(id.Value);
            if (!notes.Success)
            {
                return HttpNotFound();
            }
            return View(notes.Data);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var result = _noteService.GetById(id.Value);
            if (!result.Success)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.CategoryId = new SelectList(_categoryService.GetList().Data, "Id", "Title", result.Data.CategoryId);
            return View(result.Data);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Note note)
        {
            var notes = _noteService.GetById(note.Id);
            if (!notes.Success)
            {
                return HttpNotFound();
            }
            notes.Data.IsDraft = note.IsDraft;
            notes.Data.CategoryId = note.CategoryId;
            notes.Data.Text = note.Text;
            notes.Data.Title = note.Text;
            _noteService.Update(notes.Data);
            ViewBag.CategoryId = new SelectList(_categoryService.GetList().Data, "Id", "Title", notes.Data.CategoryId);
            return RedirectToAction("Index");
        }
    }
}