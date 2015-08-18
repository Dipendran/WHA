using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Risk.Model;
using Risk.Service.ContainerSetup;
using Microsoft.Practices.Unity;
using Risk.Service.Managers;
using Risk.Service.Repositories;

namespace Risk.Test
{
    [TestClass]
    public class RepositoryTest
    {
        private IBetRepository m_BetRepository;

        [TestInitialize]
        public void Init()
        {
            m_BetRepository = Container.UnityContainer.Resolve<IBetRepository>();
        }
        [TestMethod]
       public void ShouldLoadAllUniqueCustomers()
        {
            var uniqueCustomers = m_BetRepository.GetUniqueCustomerID();

            Assert.IsFalse(uniqueCustomers.GroupBy(n => n).Any(c => c.Count() > 1));
        }

        [TestMethod]
        public void ShouldLoadAllSettledBetForCustomer()
        {
            var uniqueCustomers = m_BetRepository.GetUniqueCustomerID();

            Assert.IsFalse(uniqueCustomers.GroupBy(n => n).Any(c => c.Count() > 1));

            var settleBets = m_BetRepository.GetSettledBetForCustomer(uniqueCustomers.First());

            Assert.IsNotNull(settleBets);

        }
    }
}
