using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Risk.Service.Repositories;
using Risk.Service.Services;

namespace Risk.Service.ContainerSetup
{
    public static class Container
    {
        private static readonly IUnityContainer m_unityContainer;
        static Container()
        {
            m_unityContainer = new UnityContainer();
            m_unityContainer.RegisterType<IBetRepository, BetRepository>(new ContainerControlledLifetimeManager());
            m_unityContainer.RegisterType<ICustomerService, CustomerService>();
            
        }

        public static IUnityContainer UnityContainer
        {
            get { return m_unityContainer; }
        }
    }
}
