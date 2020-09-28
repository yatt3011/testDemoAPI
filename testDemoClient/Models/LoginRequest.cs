﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace testDemoClient.Models
{
    public class LoginRequest
    {
        [Required,Key]
        public string userName { get; set; }
        [Required]
        public string password { get; set; }
    }
}
