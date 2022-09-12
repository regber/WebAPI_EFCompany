﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_EFCompany.Model
{
    public class Member
    {
        public int Id { get; set; }

        public int Age { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? MiddleName { get; set; }

        public string PassportNumber { get; set; }
        public string PassportSeries { get; set; }
    }
}
