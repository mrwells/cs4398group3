using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using TrafficControlSystem;
using TrafficControlSystem.Models;

namespace TrafficControlSystem.Tests
{
    [TestClass]
    public class ConfigurationTests
    {
        [TestMethod]
        public void LoadConfiguration()
        {
            var configuration = Configuration.Load("universityblvd_sunriserd.txt");
            
            Assert.IsNotNull(configuration);
            Assert.AreEqual(1, configuration.Intersections.Count);
            Assert.AreEqual(2, configuration.Roadways.Count);
        }
    }
}
