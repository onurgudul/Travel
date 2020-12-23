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
        public HomeController(INoteService noteService)
        {
            _noteService = noteService;
        }
        // GET: Home
        public ActionResult Index()
        {
            var noteList = _noteService.NoteWithAll().Data;
            return View(noteList);
        }
    }
}