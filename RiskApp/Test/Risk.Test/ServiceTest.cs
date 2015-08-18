using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Risk.Service.Managers;

namespace Risk.Test
{
    [TestClass]
    public class ServiceTest
    {
        [TestMethod]
        public void ShouldLoadCSVData()
        {
            //Load Data
            var csvData = CSVLoaderManager.CSVData;

            Assert.IsNotNull(csvData.SettledBets);
            Assert.IsNotNull(csvData.UnSettledBets);

        }

        
    }
}
