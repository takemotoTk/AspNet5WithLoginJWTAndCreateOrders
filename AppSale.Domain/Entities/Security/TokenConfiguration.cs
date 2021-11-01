﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSale.Domain.Entities.Security
{
    public class TokenConfiguration
    {
        public string AccessRole { get; set; }
        public string SecretKey { get; set; }
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public int Hours { get; set; }
    }
}
