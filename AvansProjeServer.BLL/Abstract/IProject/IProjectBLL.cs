using AvansProjeServer.Core.Entities;
using AvansProjeServerDTO.Models.ProjectDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvansProjeServer.Core.GeneralReturn;

namespace AvansProjeServer.BLL.Abstract.IProject
{
    public interface IProjectBLL
    {
        Task<GeneralReturnType<List<ProjectDTO>>> GetAllProject();
        Task<GeneralReturnType<ProjectDTO>> GetProjectByID(int id);
    }
}
