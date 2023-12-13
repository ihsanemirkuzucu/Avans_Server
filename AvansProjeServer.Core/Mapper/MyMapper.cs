using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace AvansProjeServer.Core.Mapper
{
    public class MyMapper : Profile
    {
        MapperConfiguration MapperConfig;

        public MyMapper(MapperConfiguration mapperConfig)
        {
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
            catch (Exception)
            {
                return null;
            }

        }
    }
}

