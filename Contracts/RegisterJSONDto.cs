﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    internal class RegisterJSONDto
    {
        public Course Course { get; set; }
        public Date Date { get; set; }

    }
}
