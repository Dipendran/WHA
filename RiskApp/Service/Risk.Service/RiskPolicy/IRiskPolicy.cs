using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.ObjectBuilder2;
using Risk.Model;
using Risk.Service.Services;

namespace Risk.Service.RiskPolicy
{
    public interface IRiskPolicy
    {
        void Run(CustomerBet customerBet);
    }
}
