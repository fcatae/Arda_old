﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity;

namespace Arda.Authentication.Models
{
    public class AuthenticationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
    }
}
