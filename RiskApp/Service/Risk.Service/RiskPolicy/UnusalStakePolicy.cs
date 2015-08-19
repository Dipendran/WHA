using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Risk.Model;

namespace Risk.Service.RiskPolicy
{
    public class UnusalStakePolicy : IRiskPolicy
    {
        public void Run(CustomerBet customerBet)
        {
            foreach (var bet in customerBet.Bet)
            {
                if (bet.Stake >= (10 * customerBet.AverageBettingStake))
                    bet.Unusual = true;
            }
        }
    }
}
