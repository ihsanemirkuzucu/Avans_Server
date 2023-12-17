using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvansProjeServer.Core.GeneralReturn;
using AvansProjeServerDTO.Models.AdvanceDTOs;

namespace AvansProjeServer.BLL.Abstract.IAdvance
{
    public interface IAdvanceBLL
    {
        Task<GeneralReturnType<List<AdvanceApproveListDTO>>> GetAdvanceApproveListByWorkerIDAsync(int workerID);
        Task<GeneralReturnType<List<WorkerAdvanceListDTO>>> GetWorkerAdvanceListAsync(int workerID);
        Task<GeneralReturnType<AdvanceDetailsDTO>> GetAdvanceDetailsAsync(int advanceID);
        Task<GeneralReturnType<AdvanceApproveDTO>> GetAdvanceApproveDetailsAsync(int advanceID);
        Task<GeneralReturnType<string>> AdvanceAddAsync(AdvanceAddDTO advanceAddDTO);
    }
}
