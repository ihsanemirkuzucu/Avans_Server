using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvansProjeServer.Core.GeneralReturn;
using AvansProjeServerDTO.Models.TitleDTOs;
using AvansProjeServerDTO.Models.UnitDTOs;

namespace AvansProjeServer.BLL.Abstract.IUnit
{
    public interface IUnitBLL
    {
        Task<GeneralReturnType<List<UnitDTO>>> GetAllUnitAsync();
        Task<GeneralReturnType<UnitDTO>> GetUnitByID(int id);
    }
}
