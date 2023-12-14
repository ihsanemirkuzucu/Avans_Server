using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AvansProjeServer.BLL.Abstract.ITitle;
using AvansProjeServer.BLL.Abstract.IWorker;
using AvansProjeServer.Core.GeneralReturn;
using AvansProjeServer.DAL.Abstract.IWorker;
using AvansProjeServerDTO.Models.WorkerDTOs;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace AvansProjeServer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkerController : Controller
    {
        private readonly IWorkerBLL _workerBLL;
        ITitleBLL _titleBLL;
        IConfiguration _conf;

        public WorkerController(IWorkerBLL workerBll, ITitleBLL titleBll, IConfiguration conf)
        {
            _workerBLL = workerBll;
            _titleBLL = titleBll;
            _conf = conf;
        }

        [HttpGet("~/api/allworkers")]
        public async Task<GeneralReturnType<List<WorkerListDTO>>> AllWorkers()
        {
            return await _workerBLL.GetAllWorkersAsync();
        }

        [HttpGet("~/api/allworkers/{id}")]
        public async Task<GeneralReturnType<WorkerDTO>> WorkersById(int id)
        {
            return await _workerBLL.GetWorkerByIdAsync(id);
        }

        [HttpPost("~/api/register")]
        public async Task<IActionResult> Register([FromBody] WorkerRegisterDTO dto)
        {
            var result = await _workerBLL.RegisterAsync(dto);
            if (!result.Success)
            {
                return null;
            }
            return Ok(result.Data);
        }

        [HttpPost("~/api/login")]
        public async Task<IActionResult> Login([FromBody] WorkerLoginDTO dto)
        {
            var kisiVarMi = await _workerBLL.LoginAsync(dto);
            if (kisiVarMi == null)
            {
                return null;
            }

            var desc = new SecurityTokenDescriptor()
            {
                Audience = "Fineksus",
                Issuer = "İhsan",
                Expires = DateTime.Now.AddMinutes(20),
                Subject = new ClaimsIdentity(new Claim[] {
                    new Claim(ClaimTypes.Email,dto.WorkerEmail),
                    new Claim(ClaimTypes.Role,kisiVarMi.Data.TitleID.ToString()),
                }),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_conf["apisecretkey"])), SecurityAlgorithms.HmacSha512Signature),
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(desc);
            var kullaniciIcinUretilmisToken = tokenHandler.WriteToken(token);

            return Ok(new WorkerLoginDTO()
            {
                WorkerEmail = kisiVarMi.Data.WorkerEmail,
                WorkerName = kisiVarMi.Data.WorkerName,
                Password = "",
                TitleID = kisiVarMi.Data.TitleID,
                TitleName = _titleBLL.GetTitleByID(kisiVarMi.Data.TitleID).Result.Data.TitleName,
                Token = kullaniciIcinUretilmisToken
            });
        }
    }
}
