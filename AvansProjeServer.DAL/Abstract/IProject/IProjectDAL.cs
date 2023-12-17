using AvansProjeServer.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansProjeServer.DAL.Abstract.IProject
{
    public interface IProjectDAL
    {
        Task<List<Project>> GetAllProjectAsync();
        Task<Project> GetProjectByIDAsync(int id);
        Task<List<Project>> GetAllProjectsByWorkerIDAsync(int id);
    }
}
