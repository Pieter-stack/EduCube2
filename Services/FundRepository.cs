using EduCube.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduCube.Services
{
    internal class FundRepository : IFundService
    {

        private SQLiteAsyncConnection _dbConnection;

        //setup using path
        private async Task SetUpDb()
        {
            if (_dbConnection == null)
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Fund.db3");
                _dbConnection = new SQLiteAsyncConnection(dbPath);
                await _dbConnection.CreateTableAsync<FundModel>();
            }
        }

        public async Task<int> AddFunds(FundModel fundModel)
        {
            await SetUpDb();
            return await _dbConnection.InsertAsync(fundModel);
        }

        public async Task<List<FundModel>> GetFundsList()
        {
            await SetUpDb();
            var fundList = await _dbConnection.Table<FundModel>().ToListAsync();
            return fundList;
        }

        public async Task<int> EditFunds(FundModel fundModel)
        {
            await SetUpDb();
            return await _dbConnection.UpdateAsync(fundModel);
        }

        public async Task<int> DeleteFunds(FundModel fundModel)
        {
            await SetUpDb();
            return await _dbConnection.DeleteAsync(fundModel);
        }

    }
}





