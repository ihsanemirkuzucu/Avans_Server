using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvansProjeServer.BLL.Abstract.IAdvance;
using AvansProjeServer.BLL.AdvanceApproveStragy;
using AvansProjeServer.Core.GeneralReturn;
using AvansProjeServerDAL.Abstract.IAdvance;
using AvansProjeServerDTO.Models.AdvanceDTOs;

namespace AvansProjeServer.BLL.Concrete.Advance
{
    public class AdvanceBLL : IAdvanceBLL
    {
        private IAdvanceDAL _advanceDAL;
        private ApproveFlow _approveFlow;

        public AdvanceBLL(IAdvanceDAL advanceDal, ApproveFlow approveFlow)
        {
            _advanceDAL = advanceDal;
            _approveFlow = approveFlow;
        }

        public async Task<GeneralReturnType<List<AdvanceApproveListDTO>>> GetAdvanceApproveListByWorkerIDAsync(int workerID)
        {
            try
            {
                return new GeneralReturnType<List<AdvanceApproveListDTO>>(await _advanceDAL.GetAdvanceApproveListByWorkerIDAsync(workerID),  true, "Başarılı");
            }
            catch (Exception ex)
            {
                return new GeneralReturnType<List<AdvanceApproveListDTO>>(null, false, ex.Message);
            }
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

        public async Task<GeneralReturnType<List<AdvancePaymentDTO>>> GetAdvancePaymentListAsync()
        {
            try
            {
                return new GeneralReturnType<List<AdvancePaymentDTO>>(await _advanceDAL.GetAdvancePaymentListAsync(), true, "Başarılı");
            }
            catch (Exception ex)
            {
                return new GeneralReturnType<List<AdvancePaymentDTO>>(null, true, "Hata");
            }
        }

        public async Task<GeneralReturnType<AdvanceApproveDTO>> GetAdvancePaymentDetailsAsync(int advanceID)
        {
            try
            {
                return new GeneralReturnType<AdvanceApproveDTO>(await _advanceDAL.GetAdvancePaymentDetailsAsync(advanceID), true, "Başarılı");
            }
            catch (Exception ex)
            {
                return new GeneralReturnType<AdvanceApproveDTO>(null, false, "Hata: " + ex.Message);
            }
        }

        public async Task<GeneralReturnType<string>> ApproveAdvanceAsync(AdvanceApproveStatusUpdateDTO advanceApproveStatusUpdateDTO)
        {
            try
            {
                var data = await _approveFlow.ApproveAdvance(advanceApproveStatusUpdateDTO);
                if (!(await _advanceDAL.ApproveAdvanceAsync(data)))
                {
                    throw new Exception("Hata");
                }
                if (!(await _advanceDAL.SetReviewedApproveAdvanceStatusByIDAsync(advanceApproveStatusUpdateDTO.ApproveAdvanceStatusID)))
                {
                    throw new Exception("Hata");
                }

                return new GeneralReturnType<string>("Avans Onaylandı", true, "Başarılı");
            }
            catch (Exception ex)
            {
                return new GeneralReturnType<string>(ex.Message, true, "Hata oluştu");
            }
        }

        public async Task<GeneralReturnType<string>> RejectAdvanceAsync(AdvanceApproveStatusUpdateDTO advanceApproveStatusUpdateDTO)
        {
            try
            {
                if (!(await _advanceDAL.RejectAdvanceAsync(advanceApproveStatusUpdateDTO)))
                {
                    throw new Exception("Hata");
                }
                if (!(await _advanceDAL.SetReviewedApproveAdvanceStatusByIDAsync(advanceApproveStatusUpdateDTO.ApproveAdvanceStatusID)))
                {
                    throw new Exception("Hata");
                }

                return new GeneralReturnType<string>("Avans Reddedildi.", true, "Başarılı");
            }
            catch (Exception ex)
            {
                return new GeneralReturnType<string>(ex.Message, true, "Başarısız");
            }
        }

        public async Task<GeneralReturnType<string>> DetermineAdvanceDateAsync(AdvanceApproveStatusUpdateDTO advanceApproveStatusUpdateDTO)
        {
            try
            {
                if (!(await _advanceDAL.SetAdvanceDateAsync(advanceApproveStatusUpdateDTO)))
                {

                    throw new Exception("Hata meydana geldi");
                }
                await _advanceDAL.SetReviewedApproveAdvanceStatusByIDAsync(advanceApproveStatusUpdateDTO.ApproveAdvanceStatusID);
                return new GeneralReturnType<string>("Avans Tarihi Belirlendi", true, "Başarılı");

            }
            catch (Exception ex)
            {
                return new GeneralReturnType<string>(ex.Message, true, "Hata");
            }
        }
    }
}
