using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvansProjeServer.Core.Entities;
using AvansProjeServer.DAL.Abstract.IProject;
using AvansProjeServer.DAL.Context;
using Dapper;
using Microsoft.EntityFrameworkCore;

namespace AvansProjeServer.DAL.Concrete
{
    public class ProjectDAL : IProjectDAL
    {
        private MyConnectionContext _dbContext;

        public ProjectDAL(MyConnectionContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Project>> GetAllProjectAsync()
        {
            string query = "SELECT ProjectID, ProjectName FROM Project";
            using IDbConnection connection = _dbContext.CreateConnection();
            IEnumerable<Project> data = await connection.QueryAsync<Project>(query);
            return data.ToList();   
        }

        public async Task<Project> GetProjectByIDAsync(int id)
        {
            string query = "SELECT ProjectID, ProjectName FROM Project WHERE ProjectID=@PROJECTID";
            IDbConnection conn = _dbContext.CreateConnection();
            return await conn.QueryFirstOrDefaultAsync(query, new { PROJECTID = id });
        }

        public async Task<List<Project>> GetAllProjectsByWorkerIDAsync(int id)
        {
            string query = @"SELECT P.ProjectID, P.ProjectName, P.StartDate, P.EndDate, P.ProjectExplanation 
                                FROM Project P 
                                LEFT JOIN ProjectWorker PW ON PW.ProjectID = P.ProjectID 
                                LEFT JOIN Worker W ON W.WorkerID = PW.WorkerID 
                                WHERE W.WorkerID = @WORKERID";
            IDbConnection conn = _dbContext.CreateConnection();
            var data = await conn.QueryAsync<Project>(query, new
            {
                WorkerID = id
            });
            return data.ToList();
        }
    }
}
