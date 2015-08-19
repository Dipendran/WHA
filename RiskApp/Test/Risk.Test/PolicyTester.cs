using System;
using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.Practices.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Risk.Model;
using Risk.Service.ContainerSetup;
using Risk.Service.RiskPolicy;
using Risk.Service.Services;
using Risk.Test.Mock;

namespace Risk.Test
{
    [TestClass]
    public class PolicyTester
    {
        private ICustomerService m_CustomerService;


        [TestInitialize]
        public void Init()
        {
            m_CustomerService = new MockCustomerService();
            m_CustomerService.Init();
        }

        [TestMethod]
        public void BigWinRiskPolicy()
        {
            var bets = m_CustomerService.CustomerUnSettledBets;
            if (bets != null)
            {
                IRiskPolicy policy = new BigWinRiskPolicy();
                bets.ForEach(policy.Run);

                Assert.IsNotNull(bets.SelectMany(x => x.Bet.Where(n => n.BigWin)));
            }
        }

        [TestMethod]
        public void UnUsalStakePolicy()
        {
            var bets = m_CustomerService.CustomerUnSettledBets;
            if (bets != null)
            {
                IRiskPolicy policy = new UnusalStakePolicy();
                bets.ForEach(policy.Run);

                Assert.IsNotNull(bets.SelectMany(x => x.Bet.Where(n => n.Unusual)));
            }
        }

        [TestMethod]
        public void HighlyUnUsalStakePolicy()
        {
            var bets = m_CustomerService.CustomerUnSettledBets;
            if (bets != null)
            {
                IRiskPolicy policy = new HighlyUnusalStakePolicy();
                bets.ForEach(policy.Run);
                Assert.IsNotNull(!bets.SelectMany(x => x.Bet.Where(n => n.HighlyUnusual)).Any());
            }
        }

        [TestMethod]
        public void WinningAtUnsualRatePolicy()
        {
            var bets = m_CustomerService.CustomerUnSettledBets;
            if (bets != null)
            {
                IRiskPolicy policy = new UnusalStakePolicy();
                bets.ForEach(policy.Run);

                Assert.IsNotNull(bets.SelectMany(x => x.Bet.Where(n => n.WinningAtUnusalRate)));
            }
        }

    }
}
