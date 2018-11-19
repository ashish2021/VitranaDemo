using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using vitiranaDemo.Helpers;
using vitiranaDemo.Models;

namespace vitiranaDemo
{
    public class MvcApplication : System.Web.HttpApplication
    {

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        protected void FormsAuthentication_OnAuthenticate(Object sender, FormsAuthenticationEventArgs e)
        {
            if (FormsAuthentication.CookiesSupported == true)
            {
                if (Request.Cookies[FormsAuthentication.FormsCookieName] != null)
                {
                    try
                    {
                        //let us take out the username now                
                        string username = FormsAuthentication.Decrypt(Request.Cookies[FormsAuthentication.FormsCookieName].Value).Name;
                        string roles = string.Empty;
                        //var json = "{\"users\":[{\"username\":\"user 1\", \"password\":\"password1\",\"roles\":\"admin\"},{\"username\":\"user 2\", \"password\":\"password2\",\"roles\":\"user\"},{\"username\":\"user 3\", \"password\":\"password3\",\"roles\":\"user\"}]}";
                        var users = Utility.ReadJSONFile(Server.MapPath(@"~/Models/user.json"));
                        //var users = JsonConvert.DeserializeObject<Users>(json);
                        User user = users.users.SingleOrDefault(u => u.username == username);
                        roles = user.roles.ToString();
                        //let us extract the roles from our own custom cookie


                        //Let us set the Pricipal with our user specific details
                        e.User = new System.Security.Principal.GenericPrincipal(
                          new System.Security.Principal.GenericIdentity(username, "Forms"), roles.Split(';'));
                    }
                    catch (Exception)
                    {
                        //somehting went wrong
                    }
                }
            }
        }
    }
}
