using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessHub.BLL;
using BusinessHub.DAL.Entities;
using BusinessHub.DAL.Repository;
using BusinessHub.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace BusinessHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository<UserInfo> _userRepository;

        private readonly AppSettings _appSettings;
        public UsersController(IUserRepository<UserInfo> userRepository,IOptions<AppSettings> appSettings)
        {
            _userRepository = userRepository;
            _appSettings = appSettings.Value;
        }

        [Authorize]
        [HttpGet]
        [Route("GetAllUsers")]
        public IActionResult GetAllUsers()
        {
            IEnumerable<UserInfo> users = _userRepository.GetAllUsers();
            return Ok(users);
        }


        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthenticationRequest authenticateRequest)
        {
            var response  = _userRepository.Authenticate(authenticateRequest, _appSettings.Secret);

            if (response == null)
                BadRequest(new { message = "Username or Password is invalid" });

            return Ok(response);
        }
    }
}