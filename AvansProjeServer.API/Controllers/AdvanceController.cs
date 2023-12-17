using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AvansProjeServer.BLL.Abstract.IAdvance;
using AvansProjeServerDTO.Models.AdvanceDTOs;

namespace AvansProjeServer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvanceController : ControllerBase
    {
        IAdvanceBLL _advanceBLL;

        public AdvanceController(IAdvanceBLL advanceBll)
        {
            _advanceBLL = advanceBll;
        }

        [HttpPost("~/api/addadvance")]
        public async Task<string> CreateNewAdvance([FromBody] AdvanceAddDTO dto)
        {
            var result = await _advanceBLL.AdvanceAddAsync(dto);
            if (!result.Success)
            {
                return null;
            }
            return result.Data;
        }

        [HttpGet("~/api/workeradvancelist/{workerID}")]
        public async Task<List<WorkerAdvanceListDTO>> GetWorkerAdvanceList(int workerID)
        {
            var result = await _advanceBLL.GetWorkerAdvanceListAsync(workerID);
            if (!result.Success)
            {
                return null;
            }
            return result.Data;
        }

        [HttpGet("~/api/advanceapprovelistbyworkerID/{workerID}")]
        public async Task<List<AdvanceApproveListDTO>> GetAdvanceApproveListByWorkerID(int workerID)
        {
            var result = await _advanceBLL.GetAdvanceApproveListByWorkerIDAsync(workerID);
            if (!result.Success)
            {
                return null;
            }
            return result.Data;
        }

        [HttpGet("~/api/advancedetails/{advanceID}")]
        public async Task<AdvanceDetailsDTO> GetAdvanceDetails(int advanceID)
        {
            var result = await _advanceBLL.GetAdvanceDetailsAsync(advanceID);
            if (!result.Success)
            {
                return null;
            }
            return result.Data;
        }

        [HttpGet("~/api/advanceapprovedetails/{advanceID}")]
        public async Task<AdvanceApproveDTO> GetAdvanceApproveDetails(int advanceID)
        {
            var result = await _advanceBLL.GetAdvanceApproveDetailsAsync(advanceID);
            if (!result.Success)
            {
                return null;
            }
            return result.Data;
        }
    }


}
