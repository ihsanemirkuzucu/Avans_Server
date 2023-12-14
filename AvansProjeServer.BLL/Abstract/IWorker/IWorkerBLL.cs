using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvansProjeServer.Core.GeneralReturn;
using AvansProjeServerDTO.Models.WorkerDTOs;

namespace AvansProjeServer.BLL.Abstract.IWorker
{
    public interface IWorkerBLL
    {
        Task<GeneralReturnType<List<WorkerListDTO>>> GetAllWorkersAsync();
        Task<GeneralReturnType<WorkerDTO>> GetWorkerByIdAsync(int id);
        Task<GeneralReturnType<WorkerDTO>> GetWorkerByMailAsync(string email);
        Task<GeneralReturnType<WorkerRegisterDTO>> RegisterAsync(WorkerRegisterDTO workerRegisterDTO);
        Task<GeneralReturnType<WorkerLoginDTO>> LoginAsync(WorkerLoginDTO workerLoginDTO);
        Task<int> AddWorkerAsync(WorkerDTO workerDTO);
        Task<int> DeleteWorkerAsync(int id);
        Task<int> UpdateWorkerAsync(WorkerDTO workerDTO);
    }
}
