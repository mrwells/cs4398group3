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

        [TestMethod]
        public void Test2()
        {
            var configuration = Configuration.Load("universityblvd_sunriserd.txt");
            
            IntersectionController controller = new IntersectionController(configuration.Intersections[0]);
            
            controller.SetAllToRed();

            configuration.Intersections[0].SignalGroups.ForEach(sg =>
            {
                sg.Signals.ForEach(signal =>
                {
                    Assert.AreEqual(LightColor.Red, signal.CurrentLight);
                });
            });
        }
        
        [TestMethod]
        public void Test3()
        {
            var configuration = Configuration.Load("universityblvd_sunriserd.txt");

            IntersectionController controller = new IntersectionController(configuration.Intersections[0]);

            var signalgroup = configuration.Intersections[0].SignalGroups[0];

            controller.SetSignalGroupColor(signalgroup, LightColor.Yellow);

            signalgroup.Signals.ForEach(signal =>
            {
                Assert.AreEqual(LightColor.Yellow, signal.CurrentLight);
            });
        }
    }
}
