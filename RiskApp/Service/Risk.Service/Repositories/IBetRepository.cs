using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Risk.Model;

namespace Risk.Service.Repositories
{
    public interface IBetRepository
    {
        List<Bet> GetSettledBetForCustomer(int customerID);
        List<Bet> GetUnSettledBetForCustomer(int customerID);
        List<int> GetUniqueCustomerID();
    }
}
