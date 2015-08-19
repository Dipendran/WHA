using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Risk.Service.ContainerSetup;
using Risk.Service.Services;
using Microsoft.Practices.Unity;
using Risk.Test.Mock;

namespace Risk.Test
{
    [TestClass]
    public class CustomerServiceTest
    {
        private ICustomerService m_CustomerService;


        [TestInitialize]
        public void Init()
        {
            m_CustomerService = new MockCustomerService();
        }

        [TestMethod]
        public void ShouldHaveBigWin()
        {
            m_CustomerService.Init();
            Assert.IsNotNull(m_CustomerService.CustomerUnSettledBets.SelectMany(x=>x.Bet.Where(y=>y.BigWin)).ToList());
        }

        [TestMethod]
        public void ShouldHaveUnusalWinning()
        {
            m_CustomerService.Init();
            Assert.IsNotNull(m_CustomerService.CustomerUnSettledBets.SelectMany(x => x.Bet.Where(y => y.WinningAtUnusalRate)).ToList());
        }

        [TestMethod]
        public void ShouldHaveHighUnusalWinning()
        {
            m_CustomerService.Init();
            Assert.IsNotNull(m_CustomerService.CustomerUnSettledBets.SelectMany(x => x.Bet.Where(y => y.HighlyUnusual)).ToList());
        }
    }
}
