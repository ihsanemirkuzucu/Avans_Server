using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvansProjeServer.Core.Entities;
using AvansProjeServerDTO.Models.WorkerDTOs;


namespace AvansProjeServer.DAL.Abstract.IWorker
{
    public interface IWorkerDAL
    {
        Task<List<Worker>> GetAllWorkersAsync();
        Task<Worker> GetWorkerByIdAsync(int id);
        Task<Worker> GetWorkerByMailAsync(string email);
        Task<Worker> RegisterAsync(WorkerRegisterDTO workerRegisterDTO);
        Task<Worker> LoginAsync(WorkerLoginDTO workerLoginDTO);
        Task<int> AddWorkerAsync(Worker worker);
        Task<int> DeleteWorkerAsync(int id);
        Task<int> UpdateWorkerAsync(Worker worker);
    }
}
