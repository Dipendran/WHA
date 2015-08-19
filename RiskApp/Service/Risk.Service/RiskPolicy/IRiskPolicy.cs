using Risk.Model;

namespace Risk.Service.RiskPolicy
{
    public interface IRiskPolicy
    {
        void Run(CustomerBet customerBet);
    }
}
