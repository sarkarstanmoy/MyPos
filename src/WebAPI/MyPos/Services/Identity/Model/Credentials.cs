using System;

namespace Identity.API.Model
{
    public class Credentials
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime LastLogin { get; private set; } = DateTime.Now;
    }
}