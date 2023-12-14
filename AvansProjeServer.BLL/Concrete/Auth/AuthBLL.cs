using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvansProjeServer.BLL.Abstract.IAuth;
using AvansProjeServer.Core.GeneralReturn;
using AvansProjeServer.Core.Mapper;
using AvansProjeServer.DAL.Abstract.IAuth;
using AvansProjeServer.DAL.Abstract.IProject;
using AvansProjeServer.DAL.Concrete;
using AvansProjeServerDTO.Models.AuthDTOs;
using AvansProjeServerDTO.Models.ProjectDTOs;

namespace AvansProjeServer.BLL.Concrete.Auth
{
    public class AuthBLL : IAuthBLL
    {
        private readonly IAuthDAL _authDAL;
        private readonly MyMapper _mapper;

        public AuthBLL(IAuthDAL authDal, MyMapper mapper)
        {
            _authDAL = authDal;
            _mapper = mapper;
        }

        public async Task<GeneralReturnType<RequiredDataDTO>> GetRequiredDataAsync()
        {
            try
            {
                return new GeneralReturnType<RequiredDataDTO>(await _authDAL.GetRequiredDataAsync(), true, "Datalar Alındı");
            }
            catch (Exception ex)
            {
                return new GeneralReturnType<RequiredDataDTO>(null, false, ex.Message);
            }
        }
    }
}
