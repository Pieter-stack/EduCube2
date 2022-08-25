using EduCube.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduCube.Services
{
    public interface IFundService
    {
        //Initialize CRUD operations
        Task<int> AddFunds(FundModel fundModel);
        Task<List<FundModel>> GetFundsList();
        Task<int> EditFunds(FundModel fundModel);
        Task<int> DeleteFunds(FundModel fundModel);
    }
}
