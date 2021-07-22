﻿using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace OnlineTestSystem.Api.Infrastructure.Options
{
    public class TokenOptions
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string Key { get; set; }
        public int LifeTime { get; set; }

        public SymmetricSecurityKey GetSymmetricSecurityKey()
            => new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Key));
        
    }
}
