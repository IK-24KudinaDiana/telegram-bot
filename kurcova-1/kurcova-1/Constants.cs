using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kurcova_1
{
    public class Constants
    {
        //public static string address = "recipe-by-api-ninjas.p.rapidapi.com";
        //public static string apikey = "34d7f3c379mshf511c2d5acb645fp1ddca2jsn939b03ca067e";

        public static string Host = "localhost";
        public static string Username = "postgres";
        public static string Password = "z1x2c3v4";
        public static string DatabaseName = "postgres";
        public static string Connect => $"Host={Host};Username={Username};Password={Password};Database={DatabaseName}";
    }
}
