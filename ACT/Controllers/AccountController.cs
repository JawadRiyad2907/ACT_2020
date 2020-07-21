using ACT.Authentication;
using ACT.Utilities.Helper;
using ACT.ViewModel;
using AutoMapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ACT.Controllers
{
    [AllowAnonymous]
    public class AccountController : BaseController
    {
        // GET: Login
        public ActionResult Login()
        {
            if (Request.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home", new { Area = "" });
            }
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {

            if (ModelState.IsValid)
            {
                model.Password = Cryptor.Encrypt(model.Password);
                var _ActMembership = new ActMembershipProvider();
                var userResult = _ActMembership.ValidateUser(model.Email, model.Password);
                if (userResult)
                {
                    var user = (ActMembershipUser)_ActMembership.GetUser(model.Email, false);
                    AuthenticationUser(user, model.RememberMe);
                    return RedirectToAction("Index", "Home", new { Area = "" });
                }
                ModelState.AddModelError("e", "Invalid UserName Or Password");
            }
            return View(model);
        }


        public ActionResult Logout()
        {
            HttpCookie cookie = new HttpCookie("ActCookie", "");
            cookie.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(cookie);
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }


        public ActionResult AccessDenied()
        {
            ViewBag.ResourceMessage = TempData["ResourceMessage"];
            return View("~/Views/Shared/AccessDenied.cshtml");
        }


        [NonAction]
        private void AuthenticationUser(ActMembershipUser user, bool isPersist = false)
        {
            var userModel = Mapper.Map<ActSerializeModel>(user);
            string userData = JsonConvert.SerializeObject(userModel);
            FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(
                1,
                userModel.Email,
                DateTime.Now,
                isPersist ? DateTime.Now.AddMonths(1) : DateTime.Now.AddMinutes(60),
                isPersist,
                userData);

            string enTicket = FormsAuthentication.Encrypt(authTicket);
            HttpCookie faCookie = new HttpCookie("ActCookie", enTicket);
            faCookie.Expires = authTicket.Expiration;
            Response.Cookies.Add(faCookie);
        }





    }
}