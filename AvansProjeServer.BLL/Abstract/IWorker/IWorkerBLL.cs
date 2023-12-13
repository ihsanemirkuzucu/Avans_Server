using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvansProjeServerDTO.Models.WorkerDTOs;

namespace AvansProjeServer.BLL.Abstract.IWorker
{
    public interface IWorkerBLL
    {
        Task<List<WorkerListDTO>> GetAllWorkersAsync();
        Task<WorkerDTO> GetWorkerByIdAsync(int id);
        Task<int> AddWorkerAsync(WorkerDTO workerDTO);
        Task<int> DeleteWorkerAsync(int id);
        Task<int> UpdateWorkerAsync(WorkerDTO workerDTO);
    }
}
