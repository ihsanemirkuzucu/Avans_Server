using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvansProjeServer.BLL.Abstract.IUnit;
using AvansProjeServer.Core.GeneralReturn;
using AvansProjeServer.DAL.Abstract.IUnit;
using AvansProjeServer.DTO.MyMapper;
using AvansProjeServerDTO.Models.UnitDTOs;

namespace AvansProjeServer.BLL.Concrete.Unit
{
    public class UnitBLL : IUnitBLL
    {
        private readonly IUnitDAL _unitDAL;
        private readonly MyMapper _mapper;

        public UnitBLL(IUnitDAL unitDal, MyMapper mapper)
        {
            _unitDAL = unitDal;
            _mapper = mapper;
        }

        public async Task<GeneralReturnType<List<UnitDTO>>> GetAllUnitAsync()
        {
            try
            {
                return new GeneralReturnType<List<UnitDTO>>(_mapper.Map<List<UnitDTO>, List<Core.Entities.Unit>>
                    (await _unitDAL.GetAllUnitAsync()), true, "Birimler Getirildi");
            }
            catch (Exception ex)
            {
                return new GeneralReturnType<List<UnitDTO>>(null, true, "Birimler Getirilemedi: " + ex.Message);
            }
        }

        public async Task<GeneralReturnType<UnitDTO>> GetUnitByID(int id)
        {
            return new GeneralReturnType<UnitDTO>(_mapper.Map<UnitDTO, Core.Entities.Unit>(await _unitDAL.GetUnitByIDAsync(id)), true, "Birim Başarılya Alındı");
        }
    }
}
