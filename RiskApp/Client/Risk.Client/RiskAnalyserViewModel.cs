using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Risk.Model;
using Risk.Service.Services;

namespace Risk.Client
{
    public class RiskAnalyserViewModel:BindingObject
    {
        private readonly ICustomerService _customerService;

        public RiskAnalyserViewModel(ICustomerService customerService)
        {
            _customerService = customerService;

            _customerService.Init();

            SettleBets = new ObservableCollection<CustomerBet>(_customerService.CustomerSettledBets);
            UnSettleBets = new ObservableCollection<CustomerBet>(_customerService.CustomerUnSettledBets);
            
        }
        
        
        private ObservableCollection<CustomerBet> m_SettleBets;
        public ObservableCollection<CustomerBet> SettleBets
        {
            get { return m_SettleBets; }
            set
            {
                m_SettleBets = value;
                OnPropertyChanged("SettleBets");
            }
        }

        private ObservableCollection<CustomerBet> m_UnSettleBets;
        public ObservableCollection<CustomerBet> UnSettleBets
        {
            get { return m_UnSettleBets; }
            set
            {
                m_UnSettleBets = value;
                OnPropertyChanged("UnSettleBets");
            }
        }



    }
}
