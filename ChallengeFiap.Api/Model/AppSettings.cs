﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeFiap.Api.Model
{
    public class AppSettings
    {
        public string Secret { get; set; }

        public int Expiration { get; set; }

        public string Issuer { get; set; }

        public string ValidAt { get; set; }
    }
}
