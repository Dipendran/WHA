using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Risk.Model
{
    public class CustomerBet:BindingObject
    {
        private Bet _bet;
        private bool _unusual;
        private bool _highlyUnusual;
        private bool _bigWin;
        private bool _winningAtUnusalRate;

        public Bet Bet
        {
            get { return _bet; }
            set
            {
                _bet = value;
                OnPropertyChanged("Bet");
            }
        }

        public bool Unusual
        {
            get { return _unusual; }
            set
            {
                _unusual = value;
                OnPropertyChanged("Unusual");
            }
        }

        public bool HighlyUnusual
        {
            get { return _highlyUnusual; }
            set
            {
                _highlyUnusual = value;
                OnPropertyChanged("HighlyUnusual");
            }
        }

        public bool BigWin
        {
            get { return _bigWin; }
            set
            {
                _bigWin = value;
                OnPropertyChanged("BigWin");
            }
        }

        public bool WinningAtUnusalRate
        {
            get { return _winningAtUnusalRate; }
            set
            {
                _winningAtUnusalRate = value;
                OnPropertyChanged("WinningAtUnusalRate");
            }
        }
    }
}
