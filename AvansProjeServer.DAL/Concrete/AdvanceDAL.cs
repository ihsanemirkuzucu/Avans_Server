using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvansProjeServer.Core.Entities;
using AvansProjeServer.DAL.Context;
using AvansProjeServerDAL.Abstract.IAdvance;
using AvansProjeServerDTO.Models.AdvanceDTOs;
using Dapper;

namespace AvansProjeServerDAL.Concrete
{
    public class AdvanceDAL : IAdvanceDAL
    {
        private MyConnectionContext _dbContext;

        public AdvanceDAL(MyConnectionContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<AdvanceApproveListDTO>> GetAdvanceApproveListByWorkerIDAsync(int workerID)
        {
            string query =
                @"SELECT TAAR.ID, A.AdvanceID, W.WorkerName, T.TitleName, U.UnitName, AST.ApprovalName, A.RequestDate, A.DesiredDate, A.AdvanceAmount, P.ProjectName
                FROM Advance A
                INNER JOIN Worker W ON W.WorkerID = A.WorkerID
                INNER JOIN Unit U ON U.UnitID = W.UnitID 
                INNER JOIN Title T ON T.TitleID = W.TitleID 
                LEFT JOIN Worker NW ON NW.WorkerID = W.UpperWorkerID 
                INNER JOIN AdvanceApproveStatus AAS ON AAS.AdvanceID = A.AdvanceID 
                INNER JOIN ApprovalStatus AST ON AAS.ApprovalStatusID = AST.ApprovalStatusID
                INNER JOIN Project P ON P.ProjectID = A.ProjectID 
                INNER JOIN Amount AM ON AM.MaxAmount > A.AdvanceAmount AND AM.MinAmount < A.AdvanceAmount 
                INNER JOIN TitleAmountApprovalRule TAAR ON TAAR.AmountID = AM.AmountID 
                WHERE AAS.NextApproverID = @WORKERID and TAAR.TitleID >= NW.TitleID and AAS.IsReview = 0";
            IDbConnection conn = _dbContext.CreateConnection();
            var datas = await conn.QueryAsync<AdvanceApproveListDTO>(query, new
            {
                WorkerID = workerID
            });
            return datas.ToList();
        }

        public async Task<List<WorkerAdvanceListDTO>> GetWorkerAdvanceListAsync(int workerID)
        {
            string query = "SELECT AdvanceID FROM Advance WHERE WorkerID=@WORKERID";
            IDbConnection conn = _dbContext.CreateConnection();
            var advanceIdList = conn.Query<int>(query, new
            {
                WORKERID = workerID
            }).ToList();

            List<WorkerAdvanceListDTO> advanceList = new List<WorkerAdvanceListDTO>();
            foreach (var item in advanceIdList)
            {
                advanceList.Add(await conn.QueryFirstOrDefaultAsync<WorkerAdvanceListDTO>
                ("SP_GETADVANCEDETAILSBYADVANCEID", new
                {
                    AdvanceID = item
                }, commandType: CommandType.StoredProcedure));
            }
            return advanceList;
        }

        public async Task<AdvanceDetailsDTO> GetAdvanceDetailsAsync(int advanceID)
        {
            string advanceDetailQuery = @"SELECT TOP(1) A.AdvanceAmount, A.AdvanceExplanation, A.RequestDate, A.DesiredDate, P.ProjectName, AAS.ApprovedAmount, AST.ApprovalName, AR.PaybackReceiptID
                FROM Advance A
                INNER JOIN Project P ON P.ProjectID = A.ProjectID
                INNER JOIN AdvanceApproveStatus AAS ON AAS.AdvanceID = A.AdvanceID
                INNER JOIN ApprovalStatus AST ON AAS.ApprovalStatusID = AST.ApprovalStatusID
                LEFT JOIN AdvanceReceipt AR ON AR.AdvanceID = A.AdvanceID
                WHERE A.AdvanceID = @ADVANCEID
                ORDER BY AAS.ApprovalStatusID
                DESC";
            IDbConnection conn = _dbContext.CreateConnection();
            var detail = await conn.QueryFirstOrDefaultAsync<AdvanceDetailDTO>(advanceDetailQuery, new
            {
                ADVANCEID = advanceID
            });

            string advanceHistoryQuery = @"SELECT AST.ApprovalName, AAS.[Approved/DeclinedDate] AS ApprovedDeclinedDate, 
                        W.WorkerName AS ApprovedDeclinedName, NW.WorkerName AS NextApprovedDeclinedName,
                        AST.NextApprovalName, AAS.ApprovedAmount, AR.PaybackDate 
                        FROM AdvanceApproveStatus AAS 
                        INNER JOIN ApprovalStatus AST ON AAS.ApprovalStatusID = AST.ApprovalStatusID 
                        INNER JOIN Worker W ON W.WorkerID = AAS.ApproverOrRejecterID 
                        INNER JOIN Worker NW ON NW.WorkerID = W.UpperWorkerID 
                        LEFT JOIN AdvanceReceipt AR ON AAS.AdvanceID = AR.AdvanceID 
                        WHERE AAS.AdvanceID = @ADVANCEID 
                        ORDER BY AAS.ApprovalStatusID 
                        DESC";
            var history = await conn.QueryAsync<AdvanceHistoryDTO>(advanceHistoryQuery, new { ADVANCEID = advanceID });
            return new AdvanceDetailsDTO()
            {
                AdvanceDetail = detail,
                AdvanceHistoryList = history.ToList()
            };
        }

        public async Task<AdvanceApproveDTO> GetAdvanceApproveDetailsAsync(int advanceID)
        {
            string query = @"SELECT TAAR.ID, A.AdvanceID, W.WorkerName, T.TitleName, U.UnitName, AST.ApprovalName, A.RequestDate, A.DesiredDate, A.AdvanceAmount, P.ProjectName, AAS.ApprovedAmount 
                FROM Advance A 
                INNER JOIN AdvanceApproveStatus AAS ON AAS.AdvanceID = a.AdvanceID 
                INNER JOIN ApprovalStatus AST ON AAS.ApprovalStatusID = AST.ApprovalStatusID 
                INNER JOIN Worker W ON W.WorkerID = A.WorkerID 
                INNER JOIN Title T ON T.TitleID = W.TitleID 
                INNER JOIN Unit U ON U.UnitID = W.UnitID 
                INNER JOIN Project P ON P.ProjectID = A.ProjectID 
                INNER JOIN Worker NW ON NW.WorkerID = W.UpperWorkerID 
                LEFT JOIN Amount AM ON AM.MaxAmount > A.AdvanceAmount AND AM.MinAmount < A.AdvanceAmount 
                LEFT JOIN TitleAmountApprovalRule TAAR ON TAAR.AmountID = AM.AmountID
                WHERE A.AdvanceID = @ADVANCEID";
            IDbConnection conn = _dbContext.CreateConnection();
            return await conn.QueryFirstOrDefaultAsync<AdvanceApproveDTO>(query, new
            {
                ADVANCEID = advanceID
            });
        }

        public async Task<int> AdvanceAddAsync(AdvanceAddDTO advanceAddDTO)
        {
            IDbConnection conn = _dbContext.CreateConnection();
            int addedAdvance = 0;
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

            using (IDbTransaction tran = conn.BeginTransaction())
            {
                try
                {
                    string workerQuery = "SELECT * FROM Worker WHERE WorkerID=@WORKERID";
                    var worker = await conn.QueryFirstAsync<Worker>(workerQuery, new
                    {
                        WORKERID = advanceAddDTO.WorkerID
                    }, tran);

                    var advanceQuery = @"INSERT INTO Advance(TitleAmountApprovalRuleID, AdvanceAmount, AdvanceExplanation, WorkerID, DesiredDate, ProjectID) 
                    values (@TitleAmountApprovalRuleID, @AdvanceAmount, @AdvanceExplanation, @WorkerID, @DesiredDate, @ProjectID)
                    SELECT SCOPE_IDENTITY()";
                    var advanceParameters = new DynamicParameters();
                    advanceParameters.Add("@TitleAmountApprovalRuleID", GetTitleAmountApprovalRuleID(advanceAddDTO.AdvanceAmount), System.Data.DbType.Int32);
                    advanceParameters.Add("@AdvanceAmount", advanceAddDTO.AdvanceAmount, System.Data.DbType.Decimal);
                    advanceParameters.Add("@AdvanceExplanation", advanceAddDTO.AdvanceExplanation, System.Data.DbType.String);
                    advanceParameters.Add("@WorkerID", advanceAddDTO.WorkerID, System.Data.DbType.Int32);
                    advanceParameters.Add("@DesiredDate", advanceAddDTO.RequestDate, System.Data.DbType.DateTime);
                    advanceParameters.Add("@ProjectID", advanceAddDTO.ProjectID, System.Data.DbType.Int32);

                    int advanceID = conn.Query<int>(advanceQuery, advanceParameters, tran).SingleOrDefault();

                    var approvalStatusQuery = "insert into AdvanceApproveStatus(AdvanceID,ApproverOrRejecterID,[Approved/DeclinedDate],ApprovalStatusID,NextApproverID)  values(@AdvanceID,  @ApproverOrRejecterID,@ApprovedDeclinedDate,@ApprovalStatusID,@NextApproverID)";
                    var approvalStatusParameters = new DynamicParameters();
                    approvalStatusParameters.Add("@AdvanceID", advanceID, System.Data.DbType.Int32);
                    approvalStatusParameters.Add("@ApproverOrRejecterID", advanceAddDTO.WorkerID, System.Data.DbType.Int32);
                    approvalStatusParameters.Add("@NextApproverID", worker.UpperWorkerID, System.Data.DbType.Int32);
                    approvalStatusParameters.Add("@ApprovedDeclinedDate", DateTime.UtcNow, System.Data.DbType.DateTime);
                    approvalStatusParameters.Add("@ApprovalStatusID", 1, System.Data.DbType.Int32);

                    addedAdvance = conn.Execute(approvalStatusQuery, approvalStatusParameters, tran);
                    tran.Commit();
                }
                catch (Exception e)
                {
                    tran.Rollback();
                    addedAdvance = 0;
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }
                return addedAdvance;

            }
        }

        private int GetTitleAmountApprovalRuleID(decimal advanceAmount)
        {
            string query = @"SELECT TAAP.ID 
                            FROM TitleAmountApprovalRule TAAP 
                            LEFT JOIN Amount A on A.AmountID = TAAP.AmountID
                            where A.MaxAmount > @AmountMax and A.MinAmount < @AmountMin";
            using var conn = _dbContext.CreateConnection();
            return conn.ExecuteScalar<int>(query, new
            {
                AmountMax = advanceAmount, 
                AmountMin = advanceAmount
            });
        }
    }
}
