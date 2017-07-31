using System;

namespace TrafficControlSystem
{
    public class Button
    {
        private Boolean pushed;

        public Button()
        {
            pushed = false;
        }

        public Boolean getButtonState()
        {
            return pushed;
        }
        public void activate()
        {
            pushed = true;
        }

        public void deactivate()
        {
            pushed = false;
        }
    }
}