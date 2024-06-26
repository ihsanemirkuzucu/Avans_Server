﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvansProjeServer.Core.GeneralReturn;
using AvansProjeServerDTO.Models.AuthDTOs;

namespace AvansProjeServer.BLL.Abstract.IAuth
{
    public interface IAuthBLL
    {
        Task<GeneralReturnType<RequiredDataDTO>> GetRequiredDataAsync();
    }
}
