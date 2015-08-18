using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Risk.Model;

namespace Risk.Service.Services
{
    public interface ICustomerService
    {
        List<CustomerBet> CustomerSettledBets { get; }
        List<CustomerBet> CustomerUnSettledBets { get; }

        void Init();
    }
}
