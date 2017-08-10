using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrafficControlSystem;

namespace TrafficControlSystem.Tests
{
    [TestClass]
    public class ConfigurationTests
    {
        public LightColor CurrentLight { get; private set; }
		
        /// <summary>
        /// Tests to make sure the configuration file is loaded properly
        /// </summary>
        /// <remarks>
        /// Configurataion variable is loaded with info from text file.
        /// Configuration variable is tested to make sure it is not NULL.
        /// Intersection count in configuration variable is checked to make sure 
        /// it is equal to expected amount of Interesections.
        /// Roadways count in configuration variable is checked to make sure
        /// it is equal to expected amount of Roadways.
        /// </remarks>
        [TestMethod]
        public void LoadConfiguration()
        {
            var configuration = Configuration.Load("universityblvd_sunriserd.txt");
            
            Assert.IsNotNull(configuration);
            Assert.AreEqual(1, configuration.Intersections.Count);
            Assert.AreEqual(2, configuration.Roadways.Count);
        }
        
        /// <summary>
        /// Tests to make sure that all lights are turned Red
        /// </summary>
        /// <remarks>
        /// Configuration file is loaded.
        /// Intersection controller is instansiated, and loaded with intersection.
        /// Controller sets all to red.
        /// All lights are iterated through and tested for being Red.</remarks>
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
        
        /// <summary>
        /// Tests to make sure the SignalGroup actually
        /// changes the lights to Yellow.
        /// </summary>
        /// <remarks>
        /// Configuration variable is loaded with text file.
        /// Intersection controller is instansiated, and loaded with intersection.
        /// SignalGroup variable is loaded with a Signal Group.
        /// Intersection controller sets the Signal Group to Yellow.
        /// Each signal in the group is iterated through and checked to see 
        /// if it is Yellow.
        /// </remarks>
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

        /// <summary>
        /// Tests to make sure the SignalGroup actually
        /// changes the lights to Green.
        /// </summary>
        /// <remarks>
        /// Configuration variable is loaded with text file.
        /// Intersection controller is instansiated, and loaded with intersection.
        /// SignalGroup variable is loaded with a Signal Group.
        /// Intersection controller sets the Signal Group to Green.
        /// Each signal in the group is iterated through and checked to see 
        /// if it is Green.
        /// </remarks>
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

        /// <summary>
        /// Tests to make sure the SignalGroup function actually
        /// changes the lights to Red.
        /// </summary>
        /// <remarks>
        /// Configuration variable is loaded with text file.
        /// Intersection controller is instansiated, and loaded with intersection.
        /// SignalGroup variable is loaded with a Signal Group.
        /// Intersection controller sets the Signal Group to Red.
        /// Each signal in the group is iterated through and checked to see 
        /// if it is Red.
        /// </remarks>
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

        /// <summary>
        /// Tests to make sure that SetConsoleColor function,
        /// actually sets the Console Color.
        /// </summary>
        /// <remarks>
        /// Intersection is instansiated.
        /// SetConsoleColor goes through and sets the console color to a different
        /// color and then check it to make sure the color is the same as the input
        /// color and then checks to make sure it is not the same as the input color.
        /// </remarks>
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

        /// <summary>
        /// Tests to make sure that the correct amount
        /// of Roadways are created during initial loading.
        /// </summary>
        [TestMethod]
        public void TestRoadwayCreation()
        {
            var configuration = Configuration.Load("universityblvd_sunriserd.txt");

            Assert.AreEqual(2, configuration.Roadways.Count);
        }

        /// <summary>
        /// Tests to make sure that the correct amont of 
        /// Lights are created during initial loading.
        /// </summary>
        [TestMethod]
        public void TestLightCreation()
        {
            var configuration = Configuration.Load("universityblvd_sunriserd.txt");
            Assert.AreEqual(2, configuration.Intersections[0].SignalGroups[0].Signals.Count);
        }

        /// <summary>
        /// Tests to make sure the button is not active at 
        /// initialization and then is active when pushed.
        /// </summary>
        //[TestMethod]
        //public void TestButton()
        //{
        //    Button button = new Button();
        //    Assert.IsTrue(!button.getButtonState());

        //    button.activate();
        //    Assert.IsTrue(button.getButtonState());
        //}
        
        //[TestMethod]
        //public void TestSensor()
        //{
        //    Sensor sensor = new Sensor();
        //    Assert.IsTrue(!sensor.getSensorState());

        //    sensor.activate();
        //    Assert.IsTrue(sensor.getSensorState());
        //}

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
            //checking for concurrent green lights on "sunriserd_north_south" and "CrossWays returns ok to walk == true" 
            if ((configuration.Intersections[0].SignalGroups[2].Signals[0].CurrentLight == configuration.Intersections[0].SignalGroups[1].Signals[0].CurrentLight)
                && (configuration.Intersections[0].SignalGroups[2].Roadway.CrosswalkOkToWalk))
                return true;

            return false;
                 
        }
    }
 }




