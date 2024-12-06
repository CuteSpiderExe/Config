using Config.Repository;
using Config.Repository.Models;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;


namespace Config.Controllers
{
    public class LoginController : Controller
    {
        
        private MagazDbContext db = new MagazDbContext();

        // GET: Login
        public ActionResult Register()
        {
            return View();
        }
        //POST: Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                db.User.Add(user);
                db.SaveChanges();
                ModelState.Clear();
            }
            else
            {
                ModelState.AddModelError("", "Ошибка регистрации");
            }
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Login login)
        {
           
            using (MagazDbContext db = new MagazDbContext()) 
            {
                
                var user = db.User.Where(a => a.Login == login.Log && a.Password == login.Password).FirstOrDefault();
                
                if (user != null)
                {
                    var Ticket = new FormsAuthenticationTicket(login.Log, true, 3000);
                    string Encrypt = FormsAuthentication.Encrypt(Ticket);
                    var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, Encrypt);
                    cookie.Expires = DateTime.Now.AddHours(3000);
                    cookie.HttpOnly = true;
                    Response.Cookies.Add(cookie);                   
                    if (user.IdRole == 1)
                    {
                        return RedirectToAction("Index", "PcBuilder");
                    }
                    else
                    {
                        return RedirectToAction("AdminPanel", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Неверный логин или пароль");
                }
                
            }
            return View();
        }
        
        public ActionResult Logout()
        {           
            FormsAuthentication.SignOut();                
            return RedirectToAction("Index", "Home");
        }
    }
}