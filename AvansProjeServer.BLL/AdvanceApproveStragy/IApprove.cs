using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvansProjeServer.Core.Entities;

namespace AvansProjeServer.BLL.AdvanceApproveStragy
{
    public interface IApprove
    {
        AdvanceApproveStatus ApproveMethod(decimal approvedAmount, int advanceID, Worker worker, List<ApprovalStatus> statusList, AdvanceApproveStatus advanceApproveStatus);
    }
}
