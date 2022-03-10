using System;
using System.Collections.Generic;

namespace Domain_CodigoPenal.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

    }
}
