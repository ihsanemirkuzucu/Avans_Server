using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvansProjeServer.Core.Entities;
using AvansProjeServer.DAL.Abstract.IWorker;
using AvansProjeServer.DAL.Context;
using AvansProjeServerDTO.Models.WorkerDTOs;
using Dapper;

namespace AvansProjeServer.DAL.Concrete
{
    public class WorkerDAL : IWorkerDAL
    {
        private MyConnectionContext _dbContext;

        public WorkerDAL(MyConnectionContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<List<Worker>> GetAllWorkersAsync()
        {
            string query = @"SELECT W.WorkerID,W.WorkerName,W.WorkerEmail, W.WorkerPhonenumber, T.TitleID,T.TitleName, U.UnitID,U.UnitName, W.UpperWorkerID, W.PasswordSalt, W.PasswordHash
                    FROM Worker W
                    INNER JOIN Title T ON W.TitleID=T.TitleID
                    INNER JOIN Unit U ON W.UnitID=U.UnitID";
            using IDbConnection connection = _dbContext.CreateConnection();
            IEnumerable<Worker> datas = await connection.QueryAsync<Worker, Unit, Title, Worker>(query, (worker, unit, title) =>
                {
                    worker.Unit = unit;
                    worker.Title = title;
                    return worker;
                },
                splitOn: "UnitID, TitleID");
            return datas.ToList();
        }

        public async Task<Worker> GetWorkerByIdAsync(int id)
        {
            string query = @"SELECT W.WorkerID,W.WorkerName,W.WorkerEmail, W.WorkerPhonenumber, T.TitleID,T.TitleName, U.UnitID,U.UnitName, 
                            W.UpperWorkerID, W.PasswordSalt, W.PasswordHash
                            FROM Worker W
                            INNER JOIN Title T ON W.TitleID=T.TitleID
                            INNER JOIN Unit U ON W.UnitID=U.UnitID
                            WHERE W.WorkerID=@WORKERID";
            using IDbConnection connection = _dbContext.CreateConnection();
            var parameters = new DynamicParameters();
            parameters.Add("WORKERID", id, DbType.Int16);
            IEnumerable<Worker> datas = await connection.QueryAsync<Worker, Unit, Title, Worker>(query, (worker, unit, title) =>
               {
                   worker.Unit = unit;
                   worker.Title = title;
                   return worker;
               },
               splitOn: "UnitID, TitleID",
               param: parameters);
            return datas.FirstOrDefault();

        }

        public async Task<int> AddWorkerAsync(Worker worker)
        {
            string query = @"INSERT INTO Worker (WorkerName, WorkerEmail, WorkerPhonenumber, UnitID, TitleID, UpperWorkerID, PasswordSalt, PasswordHash)
                VALUES (@WORKERNAME, @WORKEREMAIL, @WORKERPHONENUMBER, @UNITID, @TITLEID, @UPPERWORKERID, @PASSALT, @PASSHASH)";
            using IDbConnection conn = _dbContext.CreateConnection();
            var parameters = new DynamicParameters();
            parameters.Add("WORKERNAME", worker.WorkerName, DbType.String);
            parameters.Add("WORKEREMAIL", worker.WorkerEmail, DbType.String);
            parameters.Add("WORKERPHONENUMBER", worker.WorkerPhonenumber, DbType.String);
            parameters.Add("UNITID", worker.UnitID, DbType.Int16);
            parameters.Add("TITLEID", worker.UnitID, DbType.Int16);
            parameters.Add("UPPERWORKERID", worker.UnitID, DbType.Int16);
            parameters.Add("PASSALT", worker.UnitID, DbType.Binary);
            parameters.Add("PASSHASH", worker.UnitID, DbType.Binary);

            return await conn.ExecuteAsync(query, parameters);
        }

        public async Task<int> DeleteWorkerAsync(int id)
        {
            string query = "UPDATE Worker SET IsActive=0 WHERE WorkerID=@WORKERID";
            using IDbConnection conn = _dbContext.CreateConnection();

            return await conn.ExecuteAsync(query, new
            {
                WORKERID = id
            });

        }

        public async Task<int> UpdateWorkerAsync(Worker worker)
        {
            string query = @"UPDATE Worker SET WorkerName=@WORKERNAME, WorkerEmail=@WORKEREMAIL, WorkerPhonenumber=@WORKERPHONENUMBER, 
                        UnitID=@UNITID, TitleID=@TITLEID, UpperWorkerID=@UPPERWORKERID
                        WHERE WorkerID=@WORKERID";
            using IDbConnection conn = _dbContext.CreateConnection();
            var parameters = new DynamicParameters();
            parameters.Add("WORKERNAME", worker.WorkerName, DbType.String);
            parameters.Add("WORKEREMAIL", worker.WorkerEmail, DbType.String);
            parameters.Add("WORKERPHONENUMBER", worker.WorkerPhonenumber, DbType.String);
            parameters.Add("UNITID", worker.UnitID, DbType.Int16);
            parameters.Add("TITLEID", worker.UnitID, DbType.Int16);
            parameters.Add("UPPERWORKERID", worker.UnitID, DbType.Int16);
            parameters.Add("WORKERID", worker.WorkerID, DbType.Int16);
            return await conn.ExecuteAsync(query, parameters);
        }
    }
}
