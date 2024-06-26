﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AvansProjeServer.BLL.Abstract.IAdvance;
using AvansProjeServerDTO.Models.AdvanceDTOs;
using Microsoft.AspNetCore.Authorization;

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

        [HttpPost("~/api/approveadvance")]
        public async Task<string> ApproveAdvance(AdvanceApproveStatusUpdateDTO advanceApproveStatusUpdateDTO)
        {
            var result = await _advanceBLL.ApproveAdvanceAsync(advanceApproveStatusUpdateDTO);
            if (!result.Success)
            {
                return result.Data;
            }
            return result.Data;
        }
        
        [HttpPost("~/api/rejectadvance")]
        public async Task<string> RejectAdvance(AdvanceApproveStatusUpdateDTO advanceApproveStatusUpdateDTO)
        {
            var result = await _advanceBLL.RejectAdvanceAsync(advanceApproveStatusUpdateDTO);
            if (!result.Success)
            {
                return result.Data;
            }
            return result.Data;
        }

        [HttpGet("~/api/advancepaymentdetails/{advanceID}")]
        public async Task<AdvanceApproveDTO> GetAdvancePaymentDetails(int advanceID)
        {
            var result = await _advanceBLL.GetAdvancePaymentDetailsAsync(advanceID);
            if (!result.Success)
            {
                return null;
            }
            return result.Data;
        }

        [HttpPost("~/api/determineadvancedate")]
        public async Task<string> DetermineAdvanceDate(AdvanceApproveStatusUpdateDTO advanceApproveStatusUpdateDTO)
        {
            var result = await _advanceBLL.DetermineAdvanceDateAsync(advanceApproveStatusUpdateDTO);
            if (!result.Success)
            {
                return result.Data;
            }
            return result.Data;
        }

        [HttpGet("~/api/advancepaymentlist")]
        public async Task<List<AdvancePaymentDTO>> GetAdvancePaymentList()
        {
            var result = await _advanceBLL.GetAdvancePaymentListAsync();
            if (!result.Success)
            {
                return null;
            }
            return result.Data;
        }
    }


}
