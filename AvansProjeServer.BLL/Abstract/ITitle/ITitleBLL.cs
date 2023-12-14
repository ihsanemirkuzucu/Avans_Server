using AvansProjeServer.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvansProjeServerDTO.Models.TitleDTOs;

namespace AvansProjeServer.BLL.Abstract.ITitle
{
    public interface ITitleBLL
    {
        Task<TitleDTO> GetTitleByID(int id);
    }
}
