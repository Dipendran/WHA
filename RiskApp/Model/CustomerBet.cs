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
        
        private List<Bet> _bet;
        public List<Bet> Bet
        {
            get { return _bet; }
            set
            {
                _bet = value;
                OnPropertyChanged("Bet");
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
