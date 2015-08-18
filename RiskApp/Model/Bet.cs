using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Risk.Model
{
    public class Bet:BindingObject
    {
        private int _customerId;
        private int _eventId;
        private int _participantId;
        private int _stake;
        private int _win;
        private bool _unusual;
        private bool _highlyUnusual;
        private bool _bigWin;

        public int CustomerId
        {
            get { return _customerId; }
            set
            {
                _customerId = value;
                OnPropertyChanged("CustomerId");
            }
        }

        public int EventId
        {
            get { return _eventId; }
            set
            {
                _eventId = value;
                OnPropertyChanged("EventId");
            }
        }

        public int ParticipantId
        {
            get { return _participantId; }
            set
            {
                _participantId = value; 
                 OnPropertyChanged("ParticipantId");
            }
            
        }

        public int Stake
        {
            get { return _stake; }
            set
            {
                _stake = value;
                OnPropertyChanged("Stake");
            }
        }

        public int Win
        {
            get { return _win; }
            set
            {
                _win = value;
                OnPropertyChanged("Win");
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
    }
}
