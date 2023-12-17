using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
