using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvansProjeServer.DAL.Abstract.IAuth;
using AvansProjeServer.DAL.Context;
using AvansProjeServerDTO.Models.AuthDTOs;
using AvansProjeServerDTO.Models.TitleDTOs;
using AvansProjeServerDTO.Models.UnitDTOs;
using AvansProjeServerDTO.Models.WorkerDTOs;
using Dapper;

namespace AvansProjeServer.DAL.Concrete
{
    public class AuthDAL : IAuthDAL
    {
        private MyConnectionContext _dbContext;

        public AuthDAL(MyConnectionContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<RequiredDataDTO> GetRequiredDataAsync()
        {
            var data = new RequiredDataDTO();
            var unit = "SELECT UnitID, UnitName FROM Unit";
            var title = "SELECT TitleID, TitleName FROM Title";
            var worker = "SELECT * FROM Worker";
            IDbConnection conn = _dbContext.CreateConnection();
            data.Title = conn.Query<TitleDTO>(title).ToList();
            data.Worker = conn.Query<UpperWorkerDTO>(worker).ToList();
            data.Unit = conn.Query<UnitDTO>(unit).ToList();
            return data;

        }
    }
}
