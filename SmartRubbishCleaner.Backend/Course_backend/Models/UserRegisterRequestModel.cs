﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Course_backend.Models
{
    public class UserRegisterRequestModel : AuthModel
    {
        public string Role { get; set; }
    }
}
