using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kurcova_1.Models
{
    public class Users
    {
        public long Id { get; set; }
        public string User { get; set; }
    }

    public class MyRecipes
    {
        public long Id { get; set; }
        public string NameRecipe { get; set; }
        public string[] Recipe { get; set; }

        public DateTimeOffset Time { get; set; }
    }
}
