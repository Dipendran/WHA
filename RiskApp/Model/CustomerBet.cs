using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Risk.Model
{
    public class CustomerBet:BindingObject
    {
        
        private ObservableCollection<Bet> _bet;
        public ObservableCollection<Bet> Bet
        {
            get { return _bet; }
            set
            {
                _bet = value;
                OnPropertyChanged("Bet");
            }
        }

        private bool _winningAtUnusalRate;
        public bool WinningAtUnusalRate
        {
            get { return _winningAtUnusalRate; }
            set
            {
                _winningAtUnusalRate = value;
                OnPropertyChanged("WinningAtUnusalRate");
            }
        }

        private double m_averageBettingStake;
        public double AverageBettingStake
        {
            get { return m_averageBettingStake; }
            set
            {
                m_averageBettingStake = value;
                OnPropertyChanged("AverageBettingStake");
            }
        }


    }
}
