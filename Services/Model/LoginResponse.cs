using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Model
{
     public class LoginResponse
    {
        public string Token { get; set; }
        public int Role { get; set; }
        public string Username { get; set; }
    }
}
