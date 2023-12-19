using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvansProjeServer.Core.Entities;
using AvansProjeServer.DAL.Abstract.IWorker;
using AvansProjeServerDAL.Abstract.IAdvance;
using AvansProjeServerDTO.Models.AdvanceDTOs;

namespace AvansProjeServer.BLL.AdvanceApproveStragy
{
    public class ApproveFlow
    {
        private IApprove _approve;
        private readonly IAdvanceDAL _advanceDAL;
        private readonly IWorkerDAL _workerDAL;

        public ApproveFlow( IAdvanceDAL advanceDAL, IWorkerDAL workerDal)
        {
            _advanceDAL = advanceDAL;
            _workerDAL = workerDal;
        }

        public async Task<AdvanceApproveStatus> ApproveAdvance(AdvanceApproveStatusUpdateDTO dto)
        {

            int currentTitleID =  _workerDAL.GetWorkerByIdAsync(dto.ApproverOrRejecterID).Result.TitleID;
            var advance = await _advanceDAL.GetAdvanceIDAsync(dto.AdvanceID);
            var taar = await _advanceDAL.GetTitleAmountApprovalRuleByIDAsync(advance.TitleAmountApprovalRuleID);
            if (taar.TitleID == currentTitleID)
            {
                _approve = new LastApprove(_workerDAL);
                return _approve.ApproveMethod
                    (
                        dto.ApprovedAmount, 
                        dto.AdvanceID, 
                        await _advanceDAL.GetUpperWorkerByIDAsync(dto.ApproverOrRejecterID),
                        await _advanceDAL.GetApprovalStatusAsync(),
                        await _advanceDAL.GetAdvanceApproveStatusByAdvanceIDAsync(dto.AdvanceID)
                    );
            }
            _approve = new Approve(_workerDAL);
            return _approve.ApproveMethod
                (
                    dto.ApprovedAmount, 
                    dto.AdvanceID, 
                    await _advanceDAL.GetUpperWorkerByIDAsync(dto.ApproverOrRejecterID), 
                    await _advanceDAL.GetApprovalStatusAsync(), 
                    await _advanceDAL.GetAdvanceApproveStatusByAdvanceIDAsync(dto.AdvanceID)
                );
        }
    }
}
