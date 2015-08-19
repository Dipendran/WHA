using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.ObjectBuilder2;
using Risk.Client.Command;
using Risk.Model;
using Risk.Service.Services;

namespace Risk.Client
{
    public class RiskAnalyserViewModel:BindingObject
    {
        private readonly ICustomerService _customerService;
        public DelegateCommand ShowSettled { get; private set; }
        public DelegateCommand ShowUnSettled { get; private set; }
        public DelegateCommand ShowUnusalWinning { get; private set; }
        public DelegateCommand ShowUnusalStake { get; private set; }
        public DelegateCommand ShowHighlyUnusalStake { get; private set; }
        public DelegateCommand ShowBigWin { get; private set; }


        private readonly ObservableCollection<CustomerBet> cutSettledBets;
        private ObservableCollection<CustomerBet> cutUnSettledBets;
        public RiskAnalyserViewModel(ICustomerService customerService)
        {
            _customerService = customerService;

            try
            {
                _customerService.Init();
                cutSettledBets = new ObservableCollection<CustomerBet>(_customerService.CustomerSettledBets);
                cutUnSettledBets = new ObservableCollection<CustomerBet>(_customerService.CustomerUnSettledBets);
            }
            catch (Exception e)
            {
                Header = e.Message;
            }
            

            SettleBets = new ObservableCollection<Bet>(cutSettledBets.SelectMany(d => d.Bet).ToList());
            UnSettleBets = new ObservableCollection<Bet>(cutUnSettledBets.SelectMany(d => d.Bet).ToList());

            ShowSettled = new DelegateCommand(VisibleSettled);

            ShowUnSettled = new DelegateCommand(VisibleUnSettled);

            ShowUnusalWinning = new DelegateCommand(UnsualWinning);

            ShowUnusalStake = new DelegateCommand(UnusalStake);

            ShowHighlyUnusalStake = new DelegateCommand(HighlyUnusalStake);

            ShowBigWin = new DelegateCommand(BigWin);

            Header = "Settled Bets";

        }

        private String m_Header;
        public String Header
        {
            get { return m_Header; }
            set
            {
                m_Header = value;
                OnPropertyChanged("Header");
            }
        }

        private void VisibleSettled()
        {

            ChangeUI(false, "Settled Bets");
        }

        private void ChangeUI(bool visibility, string header)
        {
            ShowSettle = visibility;
            Header = header;
        }

        private void VisibleUnSettled()
        {
            ChangeUI(true, "UnSettled Bets");
        }

        private void UnsualWinning()
        {
            ChangeUI(false,"Winning At Unusal Rate");
            SettleBets = new ObservableCollection<Bet>(cutSettledBets.SelectMany(x => x.Bet.Where(y => y.WinningAtUnusalRate)));
        }

        private void UnusalStake()
        {
            ChangeUI(true, "Unusal Stake");
            UnSettleBets = new ObservableCollection<Bet>(cutUnSettledBets.SelectMany(x => x.Bet.Where(y => y.Unusual)));
        }

        private void HighlyUnusalStake()
        {
            ChangeUI(true, "Highly Unusal Stake");
            UnSettleBets = new ObservableCollection<Bet>(cutUnSettledBets.SelectMany(x => x.Bet.Where(y => y.HighlyUnusual)));
        }

        private void BigWin()
        {
            ChangeUI(true, "Big Win");
            UnSettleBets = new ObservableCollection<Bet>(cutUnSettledBets.SelectMany(x => x.Bet.Where(y => y.BigWin)));
        }

        private bool m_ShowSettle;
        public bool ShowSettle
        {
            get { return m_ShowSettle; }
            set
            {
                m_ShowSettle = value;
                OnPropertyChanged("ShowSettle");
            }
        }
        
        private ObservableCollection<Bet> m_SettleBets;
        public ObservableCollection<Bet> SettleBets
        {
            get { return m_SettleBets; }
            set
            {
                m_SettleBets = value;
                OnPropertyChanged("SettleBets");
            }
        }

        private ObservableCollection<Bet> m_UnSettleBets;
        public ObservableCollection<Bet> UnSettleBets
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
