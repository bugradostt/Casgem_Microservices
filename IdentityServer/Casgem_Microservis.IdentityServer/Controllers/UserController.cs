using Casgem_Microservis.IdentityServer.Dtos;
using Casgem_Microservis.IdentityServer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Casgem_Microservis.IdentityServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> SignUp(SignUpDto p)
        {
            var user = new ApplicationUser
            {   UserName = p.UserName, 
                City = p.City,
                Email = p.Email 
            };

            var result = await _userManager.CreateAsync(user, p.Password);
            if (result.Succeeded) 
            {
                return Ok("Kullanıcı kaydı oluştu");
            }
            else
            {
                return BadRequest("Bir hata oluştu");
            }
        }
    }
}
