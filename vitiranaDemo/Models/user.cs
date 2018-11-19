using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vitiranaDemo.Models
{
    public class User
    {
        public string username { get; set; }
        public string password { get; set; }
        public string roles { get; set; }
    }

    public class Users
    {
        public IList<User> users;
    }
}