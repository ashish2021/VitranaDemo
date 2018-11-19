using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using vitiranaDemo.Models;

namespace vitiranaDemo.Helpers
{
    public static class Utility
    {
        public static Users ReadJSONFile(string path)
        {
            var fileContents = System.IO.File.ReadAllText(path);
            var users = JsonConvert.DeserializeObject<Users>(fileContents);
            return users;
        }
    }
}