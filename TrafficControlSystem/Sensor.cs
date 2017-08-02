using System;

namespace TrafficControlSystem
{
    public class Sensor
    {

        private Boolean activated;

        public Sensor()
        {
            activated = false;
        }

        public Boolean getSensorState()
        {
            return activated;
        }
        public void activate()
        {
            activated = true;
        }

        public void deactivate()
        {
            activated = false;
        }
    }
}