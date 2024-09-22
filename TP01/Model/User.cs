using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP01.Model
{
    public class User
    {
        public string Identifier { get; set; }
        public string Password { get; set; }

        public bool isAuthenticated()
        {
            return Identifier == "admin" && Password == "senha@dmin"; 
        }
    }
}
