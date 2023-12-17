using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvansProjeServer.BLL.Abstract.IAdvance;
using AvansProjeServer.Core.GeneralReturn;
using AvansProjeServerDAL.Abstract.IAdvance;
using AvansProjeServerDTO.Models.AdvanceDTOs;

namespace AvansProjeServer.BLL.Concrete.Advance
{
    public class AdvanceBLL : IAdvanceBLL
    {
        private IAdvanceDAL _advanceDAL;

        public AdvanceBLL(IAdvanceDAL advanceDal)
        {
            _advanceDAL = advanceDal;
        }

        public Task<GeneralReturnType<List<AdvanceApproveListDTO>>> GetAdvanceApproveListByWorkerIDAsync(int workerID)
        {
            throw new NotImplementedException();
        }

        public async Task<GeneralReturnType<List<WorkerAdvanceListDTO>>> GetWorkerAdvanceListAsync(int workerID)
        {
            try
            {
                return new GeneralReturnType<List<WorkerAdvanceListDTO>>(await _advanceDAL.GetWorkerAdvanceListAsync(workerID), true, "İşlem başarılı.");
            }
            catch (Exception ex)
            {
                return new GeneralReturnType<List<WorkerAdvanceListDTO>>(null, false, "İşlem Başarısız.");
            }
        }

        public async Task<GeneralReturnType<AdvanceDetailsDTO>> GetAdvanceDetailsAsync(int advanceID)
        {
            try
            {
                return new GeneralReturnType<AdvanceDetailsDTO>(await _advanceDAL.GetAdvanceDetailsAsync(advanceID), true, "Başarılı");
            }
            catch (Exception ex)
            {
                return new GeneralReturnType<AdvanceDetailsDTO>(null, false, ex.Message);
            }
        }

        public async Task<GeneralReturnType<AdvanceApproveDTO>> GetAdvanceApproveDetailsAsync(int advanceID)
        {
            try
            {
                return new GeneralReturnType<AdvanceApproveDTO>(await _advanceDAL.GetAdvanceApproveDetailsAsync(advanceID), true, "Success");
            }
            catch (Exception ex)
            {
                return new GeneralReturnType<AdvanceApproveDTO>(null, false, ex.Message);
            }
        }

        public async Task<GeneralReturnType<string>> AdvanceAddAsync(AdvanceAddDTO advanceAddDTO)
        {
            try
            {
                int result = await _advanceDAL.AdvanceAddAsync(advanceAddDTO);
                if (result > 0)
                {
                    return new GeneralReturnType<string>("Avans Talebi Oluşturuldu.", true, "Başarılı");
                }
                return new GeneralReturnType<string>("Avans Talebi Oluşturulamadı.", false, "Başarısız");
            }
            catch (Exception ex)
            {
                return new GeneralReturnType<string>("Avans Talebi Oluşturulamadı.", false, ex.Message);
            }
        }
    }
}
