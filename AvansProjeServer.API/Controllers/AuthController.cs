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

        [HttpGet("~/api/requireddata")]
        public async Task<IActionResult> RegisterScreenRequireds()
        {
            var result = await _authBLL.GetRequiredDataAsync();
            if (!result.Success)
            {
                return null;
            }
            return Ok(result.Data);
        }
    }
}
