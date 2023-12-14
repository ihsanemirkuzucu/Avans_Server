using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvansProjeServer.BLL.Abstract.IProject;
using AvansProjeServer.Core.Mapper;
using AvansProjeServer.DAL.Abstract.IProject;
using AvansProjeServer.DAL.Abstract.IWorker;
using AvansProjeServerDTO.Models.ProjectDTOs;
using AvansProjeServerDTO.Models.WorkerDTOs;

namespace AvansProjeServer.BLL.Concrete.Project
{
    public class ProjectBLL : IProjectBLL
    {
        private readonly IProjectDAL _projectDAL;
        private readonly MyMapper _mapper;

        public ProjectBLL(IProjectDAL projectDal, MyMapper mapper)
        {
            _projectDAL = projectDal;
            _mapper = mapper;
        }

        public async Task<List<ProjectDTO>> GetAllProject()
        {
            try
            {
                List<Core.Entities.Project> data = await _projectDAL.GetAllProjectAsync();
                if (data == null)
                {
                    throw new InvalidOperationException("Projeler görüntülenemedi");
                }
                return _mapper.Map<List<ProjectDTO>, List<Core.Entities.Project>>(data);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<ProjectDTO> GetProjectByID(int id)
        {
            try
            {
                if (id < 0)
                {
                    throw new ArgumentException("Geçersiz ID");
                }
                Core.Entities.Project data = await _projectDAL.GetProjectByIDAsync(id);
                if (data == null)
                {
                    throw new InvalidOperationException("Bu Idde bir proje bulunamadı");
                }
                return _mapper.Map<ProjectDTO, Core.Entities.Project>(data);
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
