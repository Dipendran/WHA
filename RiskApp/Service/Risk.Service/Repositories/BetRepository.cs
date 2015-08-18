using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Risk.Model;
using Risk.Service.Managers;

namespace Risk.Service.Repositories
{
    public class BetRepository : IBetRepository
    {
        public List<Bet> GetSettledBetForCustomer(int customerID)
        {
            return CSVLoaderManager.CSVData.SettledBets.Where(x => x.CustomerId == customerID).ToList();
        }

        public List<Bet> GetUnSettledBetForCustomer(int customerID)
        {
            return CSVLoaderManager.CSVData.UnSettledBets.Where(x => x.CustomerId == customerID).ToList();
        }

        public List<int> GetUniqueCustomerID()
        {
            return CSVLoaderManager.CSVData.SettledBets.Select(x => x.CustomerId).Distinct().ToList();
        }



    }
}