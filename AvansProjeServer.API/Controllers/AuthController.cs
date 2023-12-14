using System.Threading.Tasks;
using AvansProjeServer.BLL.Abstract.IAuth;
using AvansProjeServerDTO.Models.AuthDTOs;
using Microsoft.AspNetCore.Mvc;

namespace AvansProjeServer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthBLL _authBLL;

        public AuthController(IAuthBLL authBll)
        {
            _authBLL = authBll;
        }

        public async Task<IActionResult> Login()
        {
            LogInDTO result = await _authBLL.LogInAsync();
            if (result != null)
            {
                return Ok(result);
            }
            return null;
        }
    }
}
