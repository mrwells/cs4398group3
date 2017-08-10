

namespace TrafficControlSystem
{
    /// <summary>
    /// A delegate definition used to pass the current intersection to the GUI
    /// </summary>
    /// <param name="intersection">This is an Intersection object that is the current state of the intersection in the system.</param>
    public delegate void UIEvent(Intersection intersection);

    /// <summary>
    /// A delegate definition used to pass the current roadway with pressed crosswalk button to the intersection controller.
    /// </summary>
    /// <param name="roadway"></param>
    public delegate void CrosswalkEvent_EastWest(Roadway roadway);

    /// <summary>
    /// A delegate definition used to pass the current roadway with pressed crosswalk button to the intersection controller. 
    /// </summary>
    /// <param name="roadway"></param>
    public delegate void CrosswalkEvent_NorthSouth(Roadway roadway);

    /// <summary>
    /// An object of this type is passed to the GUI to allow it to subscribe to changes in the intersection
    /// and make those changes when an update event happens in the intersection.
    /// </summary>
    public class UISyncObject
    {
        /// <summary>
        /// A delegate UIEvent object used to pass the current intersection to the GUI.
        /// </summary>
        public event UIEvent TimeToUpdate;

        /// <summary>
        /// A delegate CrosswalkEvent_EastWest object with the crosswalk button pressed event.
        /// </summary>       
        public event CrosswalkEvent_EastWest CrosswalkPressed_EastWest;

        /// <summary>
        /// A delegate CrosswalkEvent_NorthSouth object with the crosswalk button pressed event.
        /// </summary>        
        public event CrosswalkEvent_NorthSouth CrosswalkPressed_NorthSouth;

        /// <summary>
        /// A boolean property that indicates if the crosswalk button have been pressed.
        /// </summary>
        public bool[] crosswalkPressed = new bool[] { false, false };
        
        /// <summary>
        /// A boolean property that indicates if the emergency vehicle sensor has been activated.
        /// </summary>
        public bool[] EMTripped = new bool[] { false, false };

        /// <summary>
        /// A method that triggers the GUI that the intersection has changed and it is time
        /// for the GUI to update.
        /// </summary>
        /// <param name="intersection">The Intersection object that will be used to update the user interface.</param>
        public void OnTimeToUpdate(Intersection intersection)
        {
            if (TimeToUpdate != null)
                TimeToUpdate(intersection);
        }

        /// <summary>
        /// The functioned called when a crosswalk button for the east/west road is pressed.
        /// </summary>
        public void OnCrosswalkPressed_EastWest()
        {
            crosswalkPressed[0] = true;
        }

        /// <summary>
        /// The functioned called when a crosswalk button for the north/south road is pressed.
        /// </summary>
        public void OnCrosswalkPressed_NorthSouth()
        {
            crosswalkPressed[1] = true;
        }

        /// <summary>
        /// The functioned called when aa emergency vehicle sensor is activated.
        /// </summary>
        /// <param name="index">An integer that is the index of the emergency sensor that is activated.</param>
        public void OnEMTripped(int index)
        {
            EMTripped[index] = true;
        }
    }
}
