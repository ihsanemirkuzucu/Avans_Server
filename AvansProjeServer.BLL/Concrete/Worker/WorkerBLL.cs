using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvansProjeServer.BLL.Abstract.IWorker;
using AvansProjeServer.Core.GeneralReturn;
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

        public async Task<GeneralReturnType<List<WorkerListDTO>>> GetAllWorkersAsync()
        {
            try
            {
                return new GeneralReturnType<List<WorkerListDTO>>(_mapper.Map<List<WorkerListDTO>, List<Core.Entities.Worker>>
                    (await _workerDAL.GetAllWorkersAsync()), true, "Çalışanlar Getirildi");
            }
            catch (Exception ex)
            {
                return new GeneralReturnType<List<WorkerListDTO>>(null, true, "Çalışanlar Getirilemedi: " + ex.Message);
            }
        }

        public async Task<GeneralReturnType<WorkerDTO>> GetWorkerByIdAsync(int id)
        {
            try
            {
                return new GeneralReturnType<WorkerDTO>(_mapper.Map<WorkerDTO, Core.Entities.Worker>
                    (await _workerDAL.GetWorkerByIdAsync(id)), true, "Çalışan Getirildi");
            }
            catch (Exception ex)
            {
                return new GeneralReturnType<WorkerDTO>(null, true, "Çalışan Getirilemedi: " + ex.Message);
            }
           
        }

        public async Task<GeneralReturnType<WorkerDTO>> GetWorkerByMailAsync(string email)
        {
            try
            {
                return new GeneralReturnType<WorkerDTO>(_mapper.Map<WorkerDTO, Core.Entities.Worker>
                    (await _workerDAL.GetWorkerByMailAsync(email)), true, "Çalışan Getirildi");
            }
            catch (Exception ex)
            {
                return new GeneralReturnType<WorkerDTO>(null, true, "Bu Maile sahip kullanıcı bulunamadı" + ex.Message);
            }
        }

        public async Task<GeneralReturnType<WorkerRegisterDTO>> RegisterAsync(WorkerRegisterDTO workerRegisterDTO)
        {
            try
            {
                return new GeneralReturnType<WorkerRegisterDTO>(_mapper.Map<WorkerRegisterDTO, Core.Entities.Worker>(await _workerDAL.RegisterAsync(workerRegisterDTO)), true, "Kayıt İşlemi Başarılı");
            }
            catch (Exception ex)
            {
                return new GeneralReturnType<WorkerRegisterDTO>(null, true, "Kayıt İşlemi Başarısız: " + ex.Message);
            }
        }

        public async Task<GeneralReturnType<WorkerLoginDTO>> LoginAsync(WorkerLoginDTO workerLoginDTO)
        {
            try
            {
                var data = _mapper.Map<WorkerLoginDTO, Core.Entities.Worker>(await _workerDAL.LoginAsync(workerLoginDTO));
                return new GeneralReturnType<WorkerLoginDTO>(data, true, "Giriş başarılı");
            }
            catch (Exception ex)
            {
                return new GeneralReturnType<WorkerLoginDTO>(null, true, "Giriş başarısız: " + ex.Message);
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
