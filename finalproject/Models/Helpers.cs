using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace finalproject.Models
{
    public static class Helpers
    {
        public static string encrypter(string password)
        {
           password= password.Substring(4);
            return password;

        }
    }
}
