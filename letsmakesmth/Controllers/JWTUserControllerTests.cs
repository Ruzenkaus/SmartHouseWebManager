using letsmakesmth.JWTHelper;
using letsmakesmth.Classes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using letsmakesmth.Contexts;
using System.Linq;
using letsmakesmth.Models;

namespace letsmakesmth.Controllers
{
    public class JWTUserControllerTests : Controller
    {
        private readonly JWTService _jwtTokenService;
        private readonly UserContext _userContext;
        public JWTUserControllerTests(JWTService jwtTokenService, UserContext userContext)
        {
            _jwtTokenService = jwtTokenService;
            _userContext = userContext;
        }


        
        [HttpPost("register")]
        public IActionResult Register([FromQuery] Classes.RegisterRequest registerRequest)
        {

            var newUser = new UserModel {Password = registerRequest.Password, Username = registerRequest.Username, Role = registerRequest.Role };
            try
            {
                if (_userContext.Users.FirstOrDefault(x => x.Username == registerRequest.Username) != null)
                {
                    throw new Exception("User with these name already registered");
                }
                _userContext.Users.Add(newUser);
                _userContext.SaveChanges();
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
            
            return Ok();
        }


        [HttpPost("login")]
        public IActionResult Login([FromQuery] Classes.LoginRequest loginRequest)
        {


            var foundUser = _userContext.Users.FirstOrDefault(x=> loginRequest.Username == x.Username);
            bool approveUser = false;
            if (foundUser != null) 
            {
                approveUser = foundUser.Password == loginRequest.Password ? true : false;
            }

            if (approveUser)
            {
                var token = _jwtTokenService.GenerateToken(Convert.ToString(foundUser.id), foundUser.Username, foundUser.Role);
                return Ok(new { Token = token });
            }

            return Unauthorized("Invalid username or password.");
        }

        [HttpPut("rolechange")]
        [Authorize(Roles = "Admin")]
        public IActionResult RoleChange([FromQuery] Classes.RoleChangerRequest roleChangerRequest)
        {
            var userToChange = _userContext.Users.FirstOrDefault(x=> x.Username == roleChangerRequest.UsernameToChange);

            if (userToChange != null) 
            {
                userToChange.Role = roleChangerRequest.NewRole;
                
                _userContext.SaveChanges();
                return Ok();
            }

            return BadRequest("Something went wrong");
        
        }


        [HttpGet("admin")]
        [Authorize(Roles = "Admin")] 
        public IActionResult GetAdminResource()
        {
            return Ok("Welcome, Admin! You have access to this protected resource.");
        }

        [HttpGet("policy")]
        [Authorize(Policy = "MustBeAdmin")]
        public IActionResult GetPolicyResource()
        {
            return Ok("You passed the policy-based authorization check!");
        }
    }
}
