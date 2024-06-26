﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvansProjeServer.BLL.Abstract.IProject;
using AvansProjeServer.Core.GeneralReturn;
using AvansProjeServer.DAL.Abstract.IProject;
using AvansProjeServer.DAL.Abstract.IWorker;
using AvansProjeServer.DTO.MyMapper;
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

        public async Task<GeneralReturnType<List<ProjectDTO>>> GetAllProjectAsync()
        {
            try
            {
                return new GeneralReturnType<List<ProjectDTO>>(_mapper.Map<List<ProjectDTO>, List<Core.Entities.Project>>
                    (await _projectDAL.GetAllProjectAsync()), true, "Projeler Getirildi");
            }
            catch (Exception ex)
            {
                return new GeneralReturnType<List<ProjectDTO>>(null, true, "Projeler Getirilemedi: " + ex.Message);
            }
        }

        public async Task<GeneralReturnType<ProjectDTO>> GetProjectByIDAsync(int id)
        {
            return new GeneralReturnType<ProjectDTO>(_mapper.Map<ProjectDTO, Core.Entities.Project>(await _projectDAL.GetProjectByIDAsync(id)), true, "Projeler Başarılya Getirildi");
        }

        public async Task<GeneralReturnType<List<ProjectDTO>>> GetAllProjectsByWorkerIDAsync(int id)
        {
            try
            {
                return new GeneralReturnType<List<ProjectDTO>>(_mapper.Map<List<ProjectDTO>, List<Core.Entities.Project>>(await _projectDAL.GetAllProjectsByWorkerIDAsync(id)), true, "Başarılı");
            }
            catch (Exception ex)
            {
                return new GeneralReturnType<List<ProjectDTO>>(null, false, "Başarısız " + ex.Message);
            }
        }
    }
}
