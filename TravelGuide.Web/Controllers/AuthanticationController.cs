using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TravelGuide.Business.Abstract;
using TravelGuide.Entities.Dto;

namespace TravelGuide.Web.Controllers
{
    public class AuthanticationController : Controller
    {
        private readonly IAuthanticationService _authService;
        public AuthanticationController(IAuthanticationService authService)
        {
            _authService = authService;
        }
        // GET: Authantication
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserForLoginDto userForLoginDto)
        {
            var userToLogin = _authService.Login(userForLoginDto);
            if (!userToLogin.Success)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(UserForRegisterDto userForRegisterDto)
        {
            var userRePassword = _authService.RePasswordControl(userForRegisterDto);
            if (userRePassword == false)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }
            var userExist = _authService.UserExists(userForRegisterDto.Username);
            if (!userExist.Success)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var RegisterResult = _authService.Register(userForRegisterDto, userForRegisterDto.Password);
            if (!RegisterResult.Success)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return RedirectToAction("Index", "Home");

        }
    }
}