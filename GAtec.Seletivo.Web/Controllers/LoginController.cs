using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GAtec.Seletivo.Domain.Model.Extended;
using GAtec.Seletivo.Util.Libs;

namespace GAtec.Seletivo.Web.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginInfo input)
        {
            if (!ModelState.IsValid)
                return View(input);

            if (input.Username == "gatec" && input.Password == "12345")
            {
                Auth.LogIn(input.Username, "Candidato");

                return RedirectToAction("Home", "Home");
            }
            else if (input.Username == "admin" && input.Password == "admin")
            {
                Auth.LogIn(input.Username, "Admin");

                return RedirectToAction("Home", "Home");
            }

            return View(input);

        }

        public ActionResult Logout()
        {
            Auth.LogOut();

            return RedirectToAction("Index", "Home");
        }
    }
}