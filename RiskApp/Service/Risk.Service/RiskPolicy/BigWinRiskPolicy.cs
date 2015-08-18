using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Risk.Model;

namespace Risk.Service.RiskPolicy
{
    public class BigWinRiskPolicy:IRiskPolicy
    {
        public void Run(CustomerBet customerBet)
        {
            foreach (var bet in customerBet.Bet)
            {
                if (bet.Win >= 1000)
                    bet.BigWin = true;
            }
        }
    }
}
