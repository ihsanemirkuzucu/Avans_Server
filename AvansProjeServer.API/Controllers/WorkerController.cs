using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AvansProjeServer.BLL.Abstract.IWorker;
using AvansProjeServer.DAL.Abstract.IWorker;
using AvansProjeServerDTO.Models.WorkerDTOs;

namespace AvansProjeServer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkerController : Controller
    {
        private readonly IWorkerBLL _workerBLL;

        public WorkerController(IWorkerBLL workerBll)
        {
            _workerBLL = workerBll;
        }

        [HttpGet("~/api/allworkers")]
        public async Task<List<WorkerListDTO>> AllWorkers()
        {
            return await _workerBLL.GetAllWorkersAsync();
        }

        [HttpGet("~/api/allworkers/{id}")]
        public async Task<WorkerDTO> WorkersById(int id)
        {
            return await _workerBLL.GetWorkerByIdAsync(id);
        }
    }
}
