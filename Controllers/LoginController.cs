using paddle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace paddle.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login

        private paddleEntities db = new paddleEntities();
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(user objchk)
        {
            if(ModelState.IsValid)
            {
                using(paddleEntities db = new paddleEntities())
                {
                    var obj = db.users.Where(a => a.user_id.Equals(objchk.user_id) && a.pwd.Equals(objchk.pwd)).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["UserID"] = obj.id.ToString();
                        Session["UserName"] = obj.name.ToString();
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "The user Id or password is incorrect");
                    }
                }
            }
            
            return View(objchk);
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Login");
        }
    }
}