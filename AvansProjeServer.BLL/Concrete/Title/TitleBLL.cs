using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvansProjeServer.BLL.Abstract.ITitle;
using AvansProjeServer.Core.GeneralReturn;
using AvansProjeServer.Core.Mapper;
using AvansProjeServer.DAL.Abstract.ITitle;
using AvansProjeServer.DAL.Abstract.IWorker;
using AvansProjeServer.DAL.Concrete;
using AvansProjeServerDTO.Models.TitleDTOs;
using AvansProjeServerDTO.Models.WorkerDTOs;

namespace AvansProjeServer.BLL.Concrete.Title
{
    public class TitleBLL: ITitleBLL
    {
        private readonly MyMapper _mapper;
        private readonly ITitleDAL _titleDAL;

        public TitleBLL(MyMapper mapper, ITitleDAL titleDal)
        {
            _mapper = mapper;
            _titleDAL = titleDal;
        }

        public async Task<GeneralReturnType<TitleDTO>> GetTitleByID(int id)
        {
            return new GeneralReturnType<TitleDTO>(_mapper.Map<TitleDTO, Core.Entities.Title>(await _titleDAL.GetTitleByIDAsync(id)), true, "Title Başarılya Alındı");
        }
    }
}
