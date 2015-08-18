using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;

namespace Risk.Service.ContainerSetup
{
    public static class ContainerHelper
    {
        private static IUnityContainer m_container;
        static ContainerHelper()
        {
            m_container = new UnityContainer();
            
        }

        public static IUnityContainer Container
        {
            get { return m_container; }
        }
    }
}
