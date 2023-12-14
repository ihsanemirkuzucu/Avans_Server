using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvansProjeServerDTO.Models.AuthDTOs;

namespace AvansProjeServer.DAL.Abstract.IAuth
{
    public interface IAuthDAL
    {
        Task<LogInDTO> LogInAsync();
    }
}
