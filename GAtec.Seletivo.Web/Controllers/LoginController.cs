using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GAtec.Seletivo.Domain.Model.Extended;
using GAtec.Seletivo.Util.Libs;
using GAtec.Seletivo.Domain.Business;
using GAtec.Seletivo.Domain.Model;

namespace GAtec.Seletivo.Web.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private IUserService _userService;

        public LoginController(IUserService userService)
        {
            this._userService = userService;
        }

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(User input)
        {
            //if (!ModelState.IsValid)
            //    return View(input);

            if (!_userService.ExistCpf(input.CPF))
            {
                _userService.Add(input);
            }

            var getUser = _userService.GetInfo(input.CPF);

            if (getUser != null)
            {
                if (getUser.Type.Equals(Domain.Model.UserType.Candidate))
                {
                   
                    //string tipo;

                    Auth.LogIn(getUser.Name, "Candidato");

                    return RedirectToAction("Index", "Home");
                }
                else if (getUser.Type.Equals(Domain.Model.UserType.Admin))
                {
                    Auth.LogIn(input.UserName, "Admin");

                    return RedirectToAction("Index", "Admin");
                }
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