using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
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
            string query = @"SELECT W.WorkerID,W.WorkerName,W.WorkerEmail, W.WorkerPhonenumber, W.UpperWorkerID, W.PasswordSalt, W.PasswordHash, T.TitleID, T.TitleName, U.UnitID, U.UnitName 
                    FROM Worker W
                    INNER JOIN Title T ON W.TitleID=T.TitleID
                    INNER JOIN Unit U ON W.UnitID=U.UnitID";
            using IDbConnection connection = _dbContext.CreateConnection();
            var datas = await connection.QueryAsync<Worker, Unit, Title, Worker>(query, (worker, unit, title) =>
                {
                    worker.Unit = unit;
                    worker.Title = title;
                    return worker;
                },
                splitOn: "TitleID, UnitID");
            return datas.ToList();
        }

        public async Task<Worker> GetWorkerByIdAsync(int id)
        {
            string query = @"SELECT W.WorkerID,W.WorkerName,W.WorkerEmail, W.WorkerPhonenumber, W.UpperWorkerID, W.PasswordSalt, W.PasswordHash, U.UnitID,U.UnitName, T.TitleID,T.TitleName                             
                            FROM Worker W
                            INNER JOIN Title T ON W.TitleID=T.TitleID
                            INNER JOIN Unit U ON W.UnitID=U.UnitID
                            WHERE W.WorkerID=@WORKERID";
            using IDbConnection connection = _dbContext.CreateConnection();
            var parameters = new DynamicParameters();
            parameters.Add("WORKERID", id, DbType.Int16);
            IEnumerable<Worker> datas = await connection.QueryAsync<Worker, Unit, Title, Worker>(query, (worker, unit, title) =>
               {
                   worker.UnitID = unit.UnitID;
                   worker.TitleID = title.TitleID;
                   worker.Unit = unit;
                   worker.Title = title;
                   return worker;
               },
               splitOn: "UnitID, TitleID",
               param: parameters);
            var dd = datas.SingleOrDefault(x => x.WorkerID == id);
            return dd;

        }

        public async Task<Worker> GetWorkerByMailAsync(string email)
        {

            string query = @"SELECT W.WorkerID,W.WorkerName,W.WorkerEmail, W.WorkerPhonenumber, T.TitleID,T.TitleName, U.UnitID,U.UnitName, 
                            W.UpperWorkerID, W.PasswordSalt, W.PasswordHash
                            FROM Worker W
                            INNER JOIN Title T ON W.TitleID=T.TitleID
                            INNER JOIN Unit U ON W.UnitID=U.UnitID
                            WHERE W.WorkerEmail=@WorkerEmail";
            using IDbConnection connection = _dbContext.CreateConnection();
            var parameters = new DynamicParameters();
            parameters.Add("WorkerEmail", email, DbType.String);
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

        public async Task<Worker> RegisterAsync(WorkerRegisterDTO workerRegisterDTO)
        {
            byte[] passHash, passSalt;
            CreatePassword(workerRegisterDTO.Password, out passHash, out passSalt);

            IDbConnection conn = _dbContext.CreateConnection();

            var sql = @"INSERT INTO Worker(WorkerName, WorkerEmail, WorkerPhonenumber, PasswordHash, PasswordSalt, UnitID, TitleID, UpperWorkerID)
             VALUES(@WorkerName, @WorkerEmail, @WorkerPhonenumber, @PasswordHash, @PasswordSalt, @UnitID, @TittleID, @UpperWorkerID)";
            var workerParameters = new DynamicParameters();
            workerParameters.Add("@WorkerName", workerRegisterDTO.WorkerName, DbType.String);
            workerParameters.Add("@WorkerEmail", workerRegisterDTO.WorkerEmail, DbType.String);
            workerParameters.Add("@WorkerPhonenumber", workerRegisterDTO.WorkerPhonenumber, DbType.String);
            workerParameters.Add("@UnitID", workerRegisterDTO.UnitID, DbType.Int32);
            workerParameters.Add("@TittleID", workerRegisterDTO.TitleID, DbType.Int32);
            workerParameters.Add("@UpperWorkerID", workerRegisterDTO.UpperWorkerID, DbType.Int32);
            workerParameters.Add("@PasswordHash", passHash, DbType.Binary);
            workerParameters.Add("@PasswordSalt", passSalt, DbType.Binary);
            var data = await conn.ExecuteAsync(sql, workerParameters);
            if (data > 0)
            {
                return await conn.QueryFirstAsync<Worker>("select * from Worker where WorkerEmail = @Mail", new
                {
                    Mail = workerRegisterDTO.WorkerEmail
                });
            }
            return null;
        }

        public async Task<Worker> LoginAsync(WorkerLoginDTO workerLoginDTO)
        {
            var sql = "SELECT * FROM Worker WHERE WorkerEmail=@WorkerEmail";
            IDbConnection conn = _dbContext.CreateConnection();

            var worker = await conn.QueryFirstOrDefaultAsync<Worker>(sql, new
            {
                WorkerEmail = workerLoginDTO.WorkerEmail
            });
            if (worker == null)
            {
                return null;
            }
            if (!PasswordControl(workerLoginDTO.Password, worker.PasswordHash, worker.PasswordSalt))
            {
                return null;
            }
            return worker;
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



         void CreatePassword(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        private bool PasswordControl(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var _passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < _passwordHash.Length; i++)
                {
                    if (passwordHash[i] != _passwordHash[i])
                    {
                        return false;
                    }
                }
                return true;
            }
        }
    }
}
