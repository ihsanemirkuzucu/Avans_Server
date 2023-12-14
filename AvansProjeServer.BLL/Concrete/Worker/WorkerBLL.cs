using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvansProjeServer.BLL.Abstract.IWorker;
using AvansProjeServer.Core.Mapper;
using AvansProjeServer.DAL.Abstract.IWorker;
using AvansProjeServerDTO.Models.WorkerDTOs;



namespace AvansProjeServer.BLL.Concrete.Worker
{
    public class WorkerBLL : IWorkerBLL
    {
        private readonly IWorkerDAL _workerDAL;
        private readonly MyMapper _mapper;

        public WorkerBLL(IWorkerDAL workerDal, MyMapper mapper)
        {
            _workerDAL = workerDal;
            _mapper = mapper;
        }

        public Task<List<WorkerListDTO>> GetAllWorkersAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<WorkerDTO> GetWorkerByIdAsync(int id)
        {
            try
            {
                if (id < 0)
                {
                    throw new ArgumentException("Geçersiz ID");
                }
                var data = await _workerDAL.GetWorkerByIdAsync(id);
                if (data == null)
                {
                    throw new InvalidOperationException("Bu Idde bir çalışan bulunamadı");
                }
                return _mapper.Map<WorkerDTO, Core.Entities.Worker>(data);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public Task<int> AddWorkerAsync(WorkerDTO workerDTO)
        {
            throw new NotImplementedException();
        }

        public async Task<int> DeleteWorkerAsync(int id)
        {
            try
            {
                if (id < 0)
                {
                    throw new ArgumentException("Geçersiz ID");
                }
                var data = await _workerDAL.GetWorkerByIdAsync(id);
                if (data == null)
                {
                    throw new InvalidOperationException("Bu Idde bir çalışan bulunamadı");
                }
                return await _workerDAL.DeleteWorkerAsync(id);
            }
            catch (Exception e)
            {
                return 0;
            }
        }

        public Task<int> UpdateWorkerAsync(WorkerDTO workerDTO)
        {
            throw new NotImplementedException();
        }
    }
}
