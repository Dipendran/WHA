using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Risk.Service.Repositories;

namespace Risk.Service.ContainerSetup
{
    public static class Container
    {
        private static IUnityContainer m_unityContainer;
        static Container()
        {
            m_unityContainer = new UnityContainer();
            m_unityContainer.RegisterType<IBetRepository, BetRepository>(new ContainerControlledLifetimeManager());
            
        }

        public static IUnityContainer UnityContainer
        {
            get { return m_unityContainer; }
        }
    }
}
