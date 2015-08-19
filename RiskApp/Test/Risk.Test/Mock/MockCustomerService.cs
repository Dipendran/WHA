using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Risk.Model;
using Risk.Service.Services;

namespace Risk.Test.Mock
{
    public class MockCustomerService:ICustomerService
    {
        private List<CustomerBet> m_CustomerSettledBets;
        public List<CustomerBet> CustomerSettledBets
        {
            get
            {
                if (m_CustomerSettledBets == null)
                    Init();
                return m_CustomerSettledBets;
            }
        }
        

        private List<CustomerBet> m_CustomerUnSettledBets;
        public List<CustomerBet> CustomerUnSettledBets
        {
            get
            {
                if (m_CustomerUnSettledBets == null)
                    Init();
                return m_CustomerUnSettledBets;
            }
        }


        public void Init()
        {
            m_CustomerSettledBets = new List<CustomerBet>();
            m_CustomerUnSettledBets = new List<CustomerBet>();


            Bet b = new Bet {CustomerId = 10, Win = 1100,Stake =10};
            CustomerBet c = new CustomerBet();
            c.Bet = new ObservableCollection<Bet>();
            c.Bet.Add(b);
            
            m_CustomerSettledBets.Add(c);
        }
    }
}
