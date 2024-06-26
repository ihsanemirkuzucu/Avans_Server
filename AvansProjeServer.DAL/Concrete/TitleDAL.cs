﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvansProjeServer.Core.Entities;
using AvansProjeServer.DAL.Abstract.ITitle;
using AvansProjeServer.DAL.Context;
using Dapper;

namespace AvansProjeServer.DAL.Concrete
{
    public class TitleDAL : ITitleDAL
    {
        private MyConnectionContext _dbContext;

        public TitleDAL(MyConnectionContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Title>> GetAllTitleAsync()
        {
            string query = "SELECT TitleID, TitleName FROM Title";
            using IDbConnection connection = _dbContext.CreateConnection();
            IEnumerable<Title> data = await connection.QueryAsync<Title>(query);
            return data.ToList();
        }

        public async Task<Title> GetTitleByIDAsync(int id)
        {
            string query = "SELECT TitleID, TitleName FROM Title WHERE TitleID=@TITLEID";
            IDbConnection conn = _dbContext.CreateConnection();
            return await conn.QueryFirstOrDefaultAsync<Title>(query, new { TITLEID = id });
        }
    }
}
