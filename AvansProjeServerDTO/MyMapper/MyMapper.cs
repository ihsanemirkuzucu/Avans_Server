using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AvansProjeServer.Core.Entities;
using AvansProjeServerDTO.Models.ProjectDTOs;
using AvansProjeServerDTO.Models.TitleDTOs;
using AvansProjeServerDTO.Models.UnitDTOs;
using AvansProjeServerDTO.Models.WorkerDTOs;

namespace AvansProjeServer.DTO.MyMapper
{
    public class MyMapper : Profile
    {
        MapperConfiguration MapperConfig;

        public MyMapper()
        {
            CreateMap<WorkerDTO, Worker>().ReverseMap();
            CreateMap<UpperWorkerDTO, Worker>().ReverseMap();
            CreateMap<WorkerListDTO, Worker>().ReverseMap();
            CreateMap<WorkerLoginDTO, Worker>().ReverseMap();
            CreateMap<WorkerRegisterDTO, Worker>().ReverseMap();

            CreateMap<ProjectDTO, Project>().ReverseMap();
            CreateMap<UnitDTO, Unit>().ReverseMap();
            CreateMap<TitleDTO, Title>().ReverseMap();

            MapperConfig = new MapperConfiguration(config => { config.AddProfile(this); });
           
        }


        public TCikis Map<TCikis, TGiris>(TGiris giris)
            where TGiris : class, new()
            where TCikis : class, new()
        {
            IMapper mapper = MapperConfig.CreateMapper();

            try
            {
                return mapper.Map<TCikis>(giris);
            }
            catch (Exception ex)
            {
                return null;
            }

        }
    }
}
