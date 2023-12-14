using AvansProjeServer.Core.Entities;
using AvansProjeServerDTO.Models.ProjectDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansProjeServer.BLL.Abstract.IProject
{
    public interface IProjectBLL
    {
        Task<List<ProjectDTO>> GetAllProject();
        Task<ProjectDTO> GetProjectByID(int id);
    }
}
