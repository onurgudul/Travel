using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelGuide.Business.Abstract;

namespace TravelGuide.Web.Controllers
{
    public class NoteController : Controller
    {
        private readonly INoteService _noteService;
        public NoteController(INoteService noteService)
        {
            _noteService = noteService;
        }
        // GET: Note
        public ActionResult Index()
        {
            var notes = _noteService.NoteWithAll().Data;

            return View(notes);
        }
        public ActionResult Details(int? id)
        {
            if (id==null)
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
    }
}