using AvansProjeServer.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansProjeServer.DAL.Abstract.ITitle
{
    public interface ITitleDAL
    {
        Task<List<Title>> GetAllTitleAsync();
        Task<Title> GetTitleByIDAsync(int id);
    }
}
