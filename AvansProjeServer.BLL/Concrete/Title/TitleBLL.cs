using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvansProjeServer.BLL.Abstract.ITitle;
using AvansProjeServer.Core.GeneralReturn;
using AvansProjeServer.DAL.Abstract.ITitle;
using AvansProjeServer.DAL.Abstract.IWorker;
using AvansProjeServer.DAL.Concrete;
using AvansProjeServer.DTO.MyMapper;
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

        public async Task<GeneralReturnType<List<TitleDTO>>> GetAllTitleAsync()
        {
            try
            {
                return new GeneralReturnType<List<TitleDTO>>(_mapper.Map<List<TitleDTO>, List<Core.Entities.Title>>
                    (await _titleDAL.GetAllTitleAsync()), true, "Titlelar Getirildi");
            }
            catch (Exception ex)
            {
                return new GeneralReturnType<List<TitleDTO>>(null, true, "Titlelar Getirilemedi: " + ex.Message);
            }
        }

        public async Task<GeneralReturnType<TitleDTO>> GetTitleByIDAsync(int id)
        {
            return new GeneralReturnType<TitleDTO>(_mapper.Map<TitleDTO, Core.Entities.Title>(await _titleDAL.GetTitleByIDAsync(id)), true, "Title Başarılya Alındı");
        }
    }
}
