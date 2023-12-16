using AvansProjeServer.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvansProjeServer.Core.GeneralReturn;
using AvansProjeServerDTO.Models.TitleDTOs;

namespace AvansProjeServer.BLL.Abstract.ITitle
{
    public interface ITitleBLL
    {
        Task<GeneralReturnType<List<TitleDTO>>> GetAllTitleAsync();
        Task<GeneralReturnType<TitleDTO>> GetTitleByIDAsync(int id);
    }
}
