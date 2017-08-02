using System;

namespace TrafficControlSystem
{
    /// <summary>
    /// Sensor Class
    /// </summary>
    /// <remarks>
    /// Sensor Class has 1 attribute:
    /// (Boolean) activated - State of the Sensor
    /// </remarks>
    public class Sensor
    {

        private Boolean activated;

        /// <summary>
        /// Sensor Constructor
        /// </summary>
        /// <remarks>
        /// Sets state of Sensor to false on instansiation.
        /// </remarks>
        public Sensor()
        {
            activated = false;
        }

        /// <summary>
        /// Returns the state of the Sensor
        /// </summary>
        /// <returns>
        /// activated</returns>
        public Boolean getSensorState()
        {
            return activated;
        }

        /// <summary>
        /// Activates the Sensor
        /// </summary>
        /// <remarks>
        /// Mimics a car rolling over the Sensor
        /// and activating it.
        /// </remarks>
        public void activate()
        {
            activated = true;
        }

        /// <summary>
        /// Deactivates the Sensor
        /// </summary>
        /// <remarks>
        /// Mimics a Car rolling off the sensor 
        /// and it deactiving.
        /// </remarks>
        public void deactivate()
        {
            activated = false;
        }
    }
}