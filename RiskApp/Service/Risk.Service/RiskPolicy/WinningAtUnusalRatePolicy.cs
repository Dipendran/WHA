using System.Collections.Generic;
using System.Linq;
using Risk.Model;

namespace Risk.Service.RiskPolicy
{
    public class WinningAtUnusalRatePolicy : IRiskPolicy
    {
        public void Run(CustomerBet customerBet)
        {
                //Get Winning Bet and Total Bet for each customer
                var wins = customerBet.Bet.Count(x => x.Win > 0);
                var totalBets = customerBet.Bet.Count;

                //Prevent div by zero
                if (wins > 0 && totalBets > 0)
                {
                    if((float)((float)wins / (float)totalBets) * 100 >= 60)
                        customerBet.Bet.ToList().ForEach(y=>y.WinningAtUnusalRate = true);
                }    
            
        }
    }
}