using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using vitiranaDemo.Helpers;
using vitiranaDemo.Models;

namespace vitiranaDemo.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User model, string returnUrl)
        {
            // Lets first check if the Model is valid or not
            if (ModelState.IsValid)
            {
                //Load Data From Db
                Users userData= Utility.ReadJSONFile(Server.MapPath(@"~/Models/user.json"));
                string username = model.username;
                string password = model.password;

                // Now if our password was enctypted or hashed we would have done the
                // same operation on the user entered password here, But for now
                // since the password is in plain text lets just authenticate directly

                bool userValid = userData.users.Any(user => user.username == username && user.password == password);

                // User found in the database
                if (userValid)
                {

                    FormsAuthentication.SetAuthCookie(username, false);
                    if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                        && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "The user name or password provided is incorrect.");
                }
            }
            return View(model);
        }

        //private Users ReadJSONFile1()
        //{
        //    var fileContents = System.IO.File.ReadAllText(Server.MapPath(@"~/Models/user.json"));

        //    var json = "{\"users\":[{\"username\":\"user 1\", \"password\":\"password1\",\"roles\":\"admin\"},{\"username\":\"user 2\", \"password\":\"password2\",\"roles\":\"user\"},{\"username\":\"user 3\", \"password\":\"password3\",\"roles\":\"user\"}]}";
        //    var users = JsonConvert.DeserializeObject<Users>(fileContents);
        //    return users;
        //}

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }
    }
}



