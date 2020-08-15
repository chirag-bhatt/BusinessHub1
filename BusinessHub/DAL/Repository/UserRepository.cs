using BusinessHub.BLL;
using BusinessHub.DAL.Entities;
using BusinessHub.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessHub.DAL.Repository
{

    public interface IUserRepository<T>
    {
        IEnumerable<T> GetAllUsers();
        AuthenticationResponse Authenticate(AuthenticationRequest Request, string Secret);

        UserInfo GetById(Guid id);
    }

    public class UserRepository : IUserRepository<UserInfo>
    {
        BusinessHubDBContext _businessHubDBContext;
        public UserRepository(BusinessHubDBContext businessHubDBContext)
        {
            _businessHubDBContext = businessHubDBContext;
        }

        public AuthenticationResponse Authenticate(AuthenticationRequest Request, string Secret)
        {
            var user = _businessHubDBContext.UserInfo.SingleOrDefault(user => user.UserName == Request.UserName && user.Password == Request.Password);

            if (user == null) return null;

            var token = JwtTokenManager.GenerateJwtToken(user, Secret);

            return new AuthenticationResponse(user, token);
        }

        public IEnumerable<UserInfo> GetAllUsers()
        {
            return _businessHubDBContext.UserInfo.ToList();
        }

        public UserInfo GetById(Guid id)
        {
            return _businessHubDBContext.UserInfo.SingleOrDefault(user => user.UserId == id);
        }
    }
}
