
namespace TrafficControlSystem
{
    public class ConfigurationModel : AbstractLaneModel
    {
        private string time;
        private string location;
        private bool turnOn;

        public string getTime()
        {
            return this.time;
        }

        public void setTime(string time)
        {
            this.time = time;
        }

        public string getLocation()
        {
            return this.location;
        }

        public void setLocation(string location)
        {
            this.location = location;
        }

        public bool getTurnOn()
        {
            return this.turnOn;
        }

        public void setTurnOn(bool turnOn)
        {
            this.turnOn = turnOn;
        }
    }
}