using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvansProjeServer.Core.Entities;
using AvansProjeServer.DAL.Abstract.IWorker;

namespace AvansProjeServer.BLL.AdvanceApproveStragy
{
    public class Approve : IApprove
    {
        private IWorkerDAL _workerDAL;

        public Approve(IWorkerDAL workerDal)
        {
            _workerDAL = workerDal;
        }

        public AdvanceApproveStatus ApproveMethod(decimal approvedAmount, int advanceID, Worker worker, List<ApprovalStatus> statusList,
            AdvanceApproveStatus advanceApproveStatus)
        {
            int data = statusList.Where(x => x.ApprovalStatusID == advanceApproveStatus.ApprovalStatusID)
                .FirstOrDefault().NextApprovalStatusID;
            return new AdvanceApproveStatus()
            {
                ApproveStatusID = 0,
                AdvanceID = advanceID,
                ApproverOrRejecterID = worker.WorkerID,
                ApprovalStatusID = statusList.FirstOrDefault(x => x.ApprovalStatusID == advanceApproveStatus.ApprovalStatusID).NextApprovalStatusID,
                Approved_DeclinedDate = DateTime.Now,
                ApprovedAmount = approvedAmount,
                NextApproverID = worker.UpperWorkerID.Value,
                IsReview = false
            };
        }
    }
}
