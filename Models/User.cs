﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace origami_backend.Models
{
    public enum Role { None, User, Admin }
    public class User : BaseEntity
    {
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string HashSalt { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; }
    }
}
