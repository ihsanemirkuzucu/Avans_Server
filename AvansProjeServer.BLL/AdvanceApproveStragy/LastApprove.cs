using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvansProjeServer.Core.Entities;
using AvansProjeServer.DAL.Abstract.IWorker;

namespace AvansProjeServer.BLL.AdvanceApproveStragy
{
    public class LastApprove : IApprove
    {
        private readonly IWorkerDAL _workerDAL;

        public LastApprove(IWorkerDAL workerDal)
        {
            _workerDAL = workerDal;
        }

        public AdvanceApproveStatus ApproveMethod(decimal approvedAmount, int advanceID, Worker worker, List<ApprovalStatus> statusList,
            AdvanceApproveStatus advanceApproveStatus)
        {
            return new AdvanceApproveStatus()
            {
                ApproveStatusID = 0,
                AdvanceID = advanceID,
                ApproverOrRejecterID = worker.WorkerID,
                ApprovalStatusID = statusList.FirstOrDefault(x => x.ApprovalName == "FM Tarih Belirlemesi Bekliyor").ApprovalStatusID,
                Approved_DeclinedDate = DateTime.Now,
                ApprovedAmount = approvedAmount,
                //NextApproverID = , yeni finans müdürü kaydedilecek to do
                IsReview = false,
            };
        }
    }
}
