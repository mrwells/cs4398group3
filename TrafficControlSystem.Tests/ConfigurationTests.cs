using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrafficControlSystem;
using TrafficControlSystem.Models;

namespace TrafficControlSystem.Tests
{
    [TestClass]
    public class ConfigurationTests
    {
        public LightColor CurrentLight { get; private set; }

        [TestMethod]
        public void LoadConfiguration()
        {
            var configuration = Configuration.Load("universityblvd_sunriserd.txt");
            
            Assert.IsNotNull(configuration);
            Assert.AreEqual(1, configuration.Intersections.Count);
            Assert.AreEqual(2, configuration.Roadways.Count);
        }
        
        [TestMethod]
        public void SetAllToRed()
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
        public void SetSignalGroupYellow()
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

        [TestMethod]
        public void SetSignalGroupGreen()
        {
            var configuration = Configuration.Load("universityblvd_sunriserd.txt");

            IntersectionController controller = new IntersectionController(configuration.Intersections[0]);

            var signalgroup = configuration.Intersections[0].SignalGroups[0];

            controller.SetSignalGroupColor(signalgroup, LightColor.Green);

            signalgroup.Signals.ForEach(signal =>
            {
                Assert.AreEqual(LightColor.Green, signal.CurrentLight);
            });
        }

        [TestMethod]
        public void SetSignalGroupRed()
        {
            var configuration = Configuration.Load("universityblvd_sunriserd.txt");

            IntersectionController controller = new IntersectionController(configuration.Intersections[0]);

            var signalgroup = configuration.Intersections[0].SignalGroups[0];

            controller.SetSignalGroupColor(signalgroup, LightColor.Red);

            signalgroup.Signals.ForEach(signal =>
            {
                Assert.AreEqual(LightColor.Red, signal.CurrentLight);
            });
        }

        [TestMethod]
        public void TestSetConsoleColor()
        {
            Intersection intersection = new Intersection();

            intersection.SetConsoleColor(LightColor.Green);

            Assert.AreEqual(ConsoleColor.Green, Console.ForegroundColor);
            Assert.AreNotEqual(ConsoleColor.Red, Console.ForegroundColor);

            intersection.SetConsoleColor(LightColor.GreenArrow);

            Assert.AreEqual(ConsoleColor.Green, Console.ForegroundColor);
            Assert.AreNotEqual(ConsoleColor.Red, Console.ForegroundColor);

            intersection.SetConsoleColor(LightColor.Yellow);

            Assert.AreEqual(ConsoleColor.Yellow, Console.ForegroundColor);
            Assert.AreNotEqual(ConsoleColor.Red, Console.ForegroundColor);

            intersection.SetConsoleColor(LightColor.YellowArrow);

            Assert.AreEqual(ConsoleColor.Yellow, Console.ForegroundColor);
            Assert.AreNotEqual(ConsoleColor.Red, Console.ForegroundColor);

            intersection.SetConsoleColor(LightColor.Red);

            Assert.AreEqual(ConsoleColor.Red, Console.ForegroundColor);
            Assert.AreNotEqual(ConsoleColor.Green, Console.ForegroundColor);

            intersection.SetConsoleColor(LightColor.RedArrow);

            Assert.AreEqual(ConsoleColor.Red, Console.ForegroundColor);
            Assert.AreNotEqual(ConsoleColor.Green, Console.ForegroundColor);
 
        }

        [TestMethod]
        public void TestRoadwayCreation()
        {
            var configuration = Configuration.Load("universityblvd_sunriserd.txt");

            Assert.AreEqual(2, configuration.Roadways.Count);
        }

        [TestMethod]
        public void TestLightCreation()
        {
            var configuration = Configuration.Load("universityblvd_sunriserd.txt");
            Assert.AreEqual(2, configuration.Intersections[0].SignalGroups[0].Signals.Count);
        }

        [TestMethod]
        public void TestButton()
        {
            Button button = new Button();
            Assert.IsTrue(!button.getButtonState());

            button.activate();
            Assert.IsTrue(button.getButtonState());
        }
        
        [TestMethod]
        public void TestSensor()
        {
            Sensor sensor = new Sensor();
            Assert.IsTrue(!sensor.getSensorState());

            sensor.activate();
            Assert.IsTrue(sensor.getSensorState());
        }

        [TestMethod]
        public void TestGreenDuration()
        {
            var configuration = Configuration.Load("universityblvd_sunriserd.txt");

            //"universityblvd_turnlanes"

            int time = configuration.Intersections[0].TimingGroups[0].Timings[0].Duration;
            Assert.AreEqual(30, time);

            time = configuration.Intersections[0].TimingGroups[0].Timings[1].Duration;
            Assert.AreEqual(5, time);

            time = configuration.Intersections[0].TimingGroups[0].Timings[2].Duration;
            Assert.AreEqual(3, time);

            //"sunriserd_north_south"

            time = configuration.Intersections[0].TimingGroups[2].Timings[0].Duration;
            Assert.AreEqual(10, time);

            time = configuration.Intersections[0].TimingGroups[2].Timings[1].Duration;
            Assert.AreEqual(5, time);

            time = configuration.Intersections[0].TimingGroups[2].Timings[2].Duration;
            Assert.AreEqual(3, time);
        }

        [TestMethod]
        public void TestCollision()
        {   
            Assert.IsFalse(RunLightTest(5));//run for 5 seconds
            //Assert.IsFalse(RunLightTest(300));//run for 300 seconds = 5 minutes (if you dare...)
        }


        public Boolean RunLightTest(int duration)
        {
            var configuration = Configuration.Load("universityblvd_sunriserd.txt");
            
            var simulator = new IntersectionController(configuration.Intersections[0]);

            //Run for "duration" seconds
            
            simulator.Run(new TimeSpan(0, 0, duration));
           

            //checking for concurrent green lights on "sunriserd_north_south" and "universityblvd_east_west_turnlanes" 
            if ((configuration.Intersections[0].SignalGroups[2].Signals[0].CurrentLight == configuration.Intersections[0].SignalGroups[0].Signals[0].CurrentLight) 
                && (configuration.Intersections[0].SignalGroups[0].Signals[0].CurrentLight == LightColor.Green))
                return true;
            //checking for concurrent green lights on "sunriserd_north_south" and "universityblvd_east_west" 
            if ((configuration.Intersections[0].SignalGroups[2].Signals[0].CurrentLight == configuration.Intersections[0].SignalGroups[1].Signals[0].CurrentLight) 
                && (configuration.Intersections[0].SignalGroups[2].Signals[0].CurrentLight == LightColor.Green))
                return true;
            //checking for concurrent yellow lights on "sunriserd_north_south" and "universityblvd_east_west" 
            if ((configuration.Intersections[0].SignalGroups[2].Signals[0].CurrentLight == configuration.Intersections[0].SignalGroups[1].Signals[0].CurrentLight) 
                && (configuration.Intersections[0].SignalGroups[2].Signals[0].CurrentLight == LightColor.Yellow))
                return true;

            return false;
                 
        }
    }
 }




