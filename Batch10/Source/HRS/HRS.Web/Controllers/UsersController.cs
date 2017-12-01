using HRS.Web.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRS.Web.Controllers
{
    public class UsersController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        UserStore<ApplicationUser> userStore;
        UserManager<ApplicationUser> userManager;

        public UsersController()
        {
            userStore = new UserStore<ApplicationUser>(db);
            userManager = new UserManager<ApplicationUser>(userStore);
        }

        // GET: Users
        public ActionResult Index()
        { 
            return View(db.Users.ToList());
        }

        // GET: Users/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email};
                var result = userManager.Create(user);
                if (result.Succeeded)
                {
                    var signinManager = Request.GetOwinContext().Get<ApplicationSignInManager>();
                    signinManager.SignIn(user, isPersistent: false, rememberBrowser: false);
                    return RedirectToAction("Index", "Home");
                }
                //AddErrors(result);
            }
            // If we got this far, something failed, redisplay form
            return View(model);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Users/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Users/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
