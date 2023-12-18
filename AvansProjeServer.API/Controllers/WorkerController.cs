using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AvansProjeServer.BLL.Abstract.IProject;
using AvansProjeServer.BLL.Abstract.ITitle;
using AvansProjeServer.BLL.Abstract.IUnit;
using AvansProjeServer.BLL.Abstract.IWorker;
using AvansProjeServer.Core.GeneralReturn;
using AvansProjeServerDTO.Models.ProjectDTOs;
using AvansProjeServerDTO.Models.TitleDTOs;
using AvansProjeServerDTO.Models.UnitDTOs;
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
        private readonly ITitleBLL _titleBLL;
        private readonly IUnitBLL _unitBLL;
        private readonly IProjectBLL _projectBLL;
        IConfiguration _conf;

        public WorkerController(IWorkerBLL workerBll, ITitleBLL titleBll, IConfiguration conf, IUnitBLL unitBll, IProjectBLL projectBll)
        {
            _workerBLL = workerBll;
            _titleBLL = titleBll;
            _conf = conf;
            _unitBLL = unitBll;
            _projectBLL = projectBll;
        }

        [HttpGet("~/api/allworkers")]
        public async Task<GeneralReturnType<List<WorkerListDTO>>> AllWorkers()
        {
            return await _workerBLL.GetAllWorkersAsync();
        }

        [HttpGet("~/api/alltitle")]
        public async Task<GeneralReturnType<List<TitleDTO>>> AllTitle()
        {
            return await _titleBLL.GetAllTitleAsync();
        }

        [HttpGet("~/api/allunit")]
        public async Task<GeneralReturnType<List<UnitDTO>>> AllUnit()
        {
            return await _unitBLL.GetAllUnitAsync();
        }

        [HttpGet("~/api/allproject")]
        public async Task<GeneralReturnType<List<ProjectDTO>>> AllProject()
        {
            return await _projectBLL.GetAllProjectAsync();
        }

        [HttpGet("~/api/allprojectbyworkerid/{id}")]
        public async Task<IActionResult> GetAllProjects(int id)
        {
            var result = await _projectBLL.GetAllProjectsByWorkerIDAsync(id);
            if (!result.Success)
            {
                return null;
            }
            return Ok(result.Data);
        }


        [HttpGet("~/api/allworkers/{id}")]
        public async Task<GeneralReturnType<WorkerDTO>> WorkersById(int id)
        {
            return await _workerBLL.GetWorkerByIdAsync(id);
        }

        [HttpPost("~/api/register")]
        public async Task<IActionResult> Register([FromBody] WorkerRegisterDTO dto)
        {
            var data = await _workerBLL.RegisterAsync(dto);
            if (!data.Success)
            {
                return null;
            }
            return Ok(data.Data);
        }

        [HttpPost("~/api/login")]
        public async Task<IActionResult> Login([FromBody] WorkerLoginDTO dto)
        {
            var worker = await _workerBLL.LoginAsync(dto);
            if (worker == null)
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
                        new Claim(ClaimTypes.Role,worker.Data.TitleID.ToString()),
                    }),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_conf["apisecretkey"])), SecurityAlgorithms.HmacSha512Signature),
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(desc);
            var workerToken = tokenHandler.WriteToken(token);
           
            return Ok(new WorkerLoginDTO()
            {
                WorkerID = worker.Data.WorkerID,
                WorkerEmail = worker.Data.WorkerEmail,
                WorkerName = worker.Data.WorkerName,
                Password = "",
                TitleID = worker.Data.TitleID,
                TitleName = _titleBLL.GetTitleByIDAsync(worker.Data.TitleID).Result.Data.TitleName,
                Token = workerToken
            });




        }
    }
}
