using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using APIAngularReact.Models;
using APIAngularReact.Dtos;

namespace APIAngularReact.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcountController : ControllerBase
    {

        private readonly UserManager<User> _userManager;

        public AcountController(UserManager<User> userManager) 
        {
            userManager = _userManager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(dtoNewUser user)
        {

            if(ModelState.IsValid) 
             {

                User user2 = new User()
                {
                    UserName = user.UserName,
                    Email = user.Email
                };

                try
                {
                    IdentityResult result = await _userManager.CreateAsync(user2, user.Password);
                    if (result.Succeeded)
                    {
                        return Ok("success");
                    }
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message); // Voir le message d'erreur ici
                }


            }

            return BadRequest(ModelState);

        }

        [HttpPost]
       public async Task<IActionResult> Login(dtoLogin login)
        {

            if (ModelState.IsValid)
            {

                User? user= await _userManager.FindByNameAsync(login.UserName);

                if (user != null)
                {
                    if (await _userManager.CheckPasswordAsync(user, login.Password))
                    {
                        return Ok("Token");
                    }
                    else
                    {
                        Unauthorized();
                    }
                }
                else
                {
                    ModelState.AddModelError("", "User Name is invalid");
                }

            }

            return BadRequest(ModelState);
        }
        

    }
}
