using FinPulse.BL;
using FinPulse.DAL;
using FinPulse.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinPulse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenService tokenService) : ControllerBase
    {
        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            try
            {
                var appUser = new AppUser
                {
                    UserName = registerDto.Username,
                    Email = registerDto.Email
                };
                
                var createdUser = await userManager.CreateAsync(appUser, registerDto.Password);

                if (createdUser.Succeeded)
                {
                    var roleResult = await userManager.AddToRoleAsync(appUser, "User");
                    if (roleResult.Succeeded)
                    {
                        return new UserDto
                        {
                            Username = appUser.UserName,
                            Email = appUser.Email,
                            Token = tokenService.GenerateToken(appUser)
                        };
                    }
                    else
                    {
                        return BadRequest(roleResult.Errors);
                    }
                } else
                {
                   return BadRequest(createdUser.Errors); 
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await userManager.Users.FirstOrDefaultAsync(x => x.UserName == loginDto.Username);
            
            if(user == null) return Unauthorized("Invalid username");
            
            var result = await signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);
            
            if(!result.Succeeded) return Unauthorized("Username and/or password incorrect");

            return new UserDto
            {
                Username = user.UserName,
                Email = user.Email,
                Token = tokenService.GenerateToken(user)
            };
        }
    }
}
