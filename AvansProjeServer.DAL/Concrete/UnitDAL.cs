using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvansProjeServer.Core.Entities;
using AvansProjeServer.DAL.Abstract.IUnit;
using AvansProjeServer.DAL.Context;
using Dapper;

namespace AvansProjeServer.DAL.Concrete
{
    public class UnitDAL : IUnitDAL
    {
        private MyConnectionContext _dbContext;

        public UnitDAL(MyConnectionContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> GetUnitByIDAsync(int id)
        {
            string query = "SELECT UnitID, UnitName FROM Unit WHERE UnitID=@UNITID";
            IDbConnection conn = _dbContext.CreateConnection();
            return await conn.QueryFirstOrDefaultAsync(query, new { UNITID = id });
        }
    }
}
