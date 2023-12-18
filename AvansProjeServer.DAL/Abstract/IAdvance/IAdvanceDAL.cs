using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvansProjeServer.Core.Entities;
using AvansProjeServerDTO.Models.AdvanceDTOs;

namespace AvansProjeServerDAL.Abstract.IAdvance
{
    public interface IAdvanceDAL
    {
        Task<List<AdvanceApproveListDTO>> GetAdvanceApproveListByWorkerIDAsync(int workerID);
        Task<List<WorkerAdvanceListDTO>> GetWorkerAdvanceListAsync(int workerID);
        Task<AdvanceDetailsDTO> GetAdvanceDetailsAsync(int advanceID);
        Task<AdvanceApproveDTO> GetAdvanceApproveDetailsAsync(int advanceID);
        Task<int> AdvanceAddAsync(AdvanceAddDTO advanceAddDTO);


        Task<Advance> GetAdvanceIDAsync(int advanceID);
        Task<List<AdvancePaymentDTO>> GetAdvancePaymentListAsync();
        Task<AdvanceApproveDTO> GetAdvancePaymentDetailsAsync(int advanceID);
        Task<List<ApprovalStatus>> GetApprovalStatusAsync();
        Task<AdvanceApproveStatus> GetAdvanceApproveStatusByAdvanceIDAsync(int advanceID);
        Task<TitleAmountApprovalRule> GetTitleAmountApprovalRuleByIDAsync(int id);
        Task<Worker> GetUpperWorkerByIDAsync(int workerID);
        Task<bool> ApproveAdvanceAsync(AdvanceApproveStatus advanceApproveStatus);
        Task<bool> RejectAdvanceAsync(AdvanceApproveStatusUpdateDTO advanceApproveStatusUpdateDTO);
        Task<bool> SetAdvanceDateAsync(AdvanceApproveStatusUpdateDTO advanceApproveStatusUpdateDTO);
        Task<bool> SetReviewedApproveAdvanceStatusByIDAsync(int id);
    }
}
