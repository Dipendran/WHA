using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Risk.Service.ContainerSetup;
using Risk.Service.Services;
using Microsoft.Practices.Unity;

namespace Risk.Test
{
    [TestClass]
    public class CustomerServiceTest
    {
        private ICustomerService m_CustomerService;


        [TestInitialize]
        public void Init()
        {
            m_CustomerService = Container.UnityContainer.Resolve<ICustomerService>();
        }

        [TestMethod]
        public void ShouldHighLightBigWin()
        {
            m_CustomerService.Init();
            var n = m_CustomerService.CustomerUnSettledBets.Where(x=>x.Bet.Any(y=>y.BigWin));
            
        }
    }
}
