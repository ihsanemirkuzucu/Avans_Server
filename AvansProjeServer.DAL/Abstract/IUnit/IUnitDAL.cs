using AvansProjeServer.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansProjeServer.DAL.Abstract.IUnit
{
    public interface IUnitDAL
    {
        Task<Unit> GetUnitByIDAsync(int id);
    }
}
