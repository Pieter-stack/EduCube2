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
        //Create funds
        Task<int> AddFunds(FundModel fundModel);
        //Read funds details
        Task<List<FundModel>> GetFundsList();
        //Update funds
        Task<int> EditFunds(FundModel fundModel);
        //Delete funds
        Task<int> DeleteFunds(FundModel fundModel);
    }
}
