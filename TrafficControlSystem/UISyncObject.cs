

namespace TrafficControlSystem
{
    /// <summary>
    /// A delegate definition used to pass the current intersection to the GUI
    /// </summary>
    /// <param name="intersection">This is an Intersection object that is the current state of the intersection in the system.</param>
    public delegate void UIEvent(Intersection intersection);
    public delegate void CrosswalkEvent_EastWest(Roadway roadway);
    public delegate void CrosswalkEvent_NorthSouth(Roadway roadway);


    /// <summary>
    /// An object of this time is passed to the GUI to allow it to subscribe to changes in the intersection
    /// and make those changes when an update event happens in the intersection.
    /// </summary>
    public class UISyncObject
    {
        /// <summary>
        /// A delegate UIEvent object used to pass the current intersection to the GUI.
        /// </summary>
        public event UIEvent TimeToUpdate;


        public event CrosswalkEvent_EastWest CrosswalkPressed_EastWest;
        public event CrosswalkEvent_NorthSouth CrosswalkPressed_NorthSouth;

        public bool[] crosswalkPressed = new bool[] { false, false };

        /// <summary>
        /// a method that triggers the GUI that the intersection has changed and it is time
        /// for the GUI to update.
        /// </summary>
        /// <param name="intersection"></param>
        public void OnTimeToUpdate(Intersection intersection)
        {
            if (TimeToUpdate != null)
                TimeToUpdate(intersection);
        }

        public void OnCrosswalkPressed_EastWest()
        {
            crosswalkPressed[0] = true;
        }

        public void OnCrosswalkPressed_NorthSouth()
        {
            crosswalkPressed[1] = true;
        }
    }
}
