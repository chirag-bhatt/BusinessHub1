using BusinessHub.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessHub.Models
{
    public class AuthenticationResponse
    {
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }

        public AuthenticationResponse(UserInfo userInfo,string token)
        {
            UserId = userInfo.UserId;
            FirstName = userInfo.FirstName;
            LastName = userInfo.LastName;
            Username = userInfo.UserName;
            Token = token;
        }
    }
}
