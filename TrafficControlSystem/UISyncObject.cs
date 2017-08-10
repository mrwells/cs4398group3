

namespace TrafficControlSystem
{
    /// <summary>
    /// A delegate definition used to pass the current intersection to the GUI
    /// </summary>
    /// <param name="intersection">This is an Intersection object that is the current state of the intersection in the system.</param>
    public delegate void UIEvent(Intersection intersection);

    /// <summary>
    /// A delegate definition used to pass the current roadway to the GUI
    /// </summary>
    /// <param name="roadway"></param>
    public delegate void CrosswalkEvent(Roadway roadway);

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

        /// <summary>
        /// A delegate CrosswalkEvent object used to pass clicking of crosswalk button.
        /// </summary>
        public event CrosswalkEvent CrosswalkPressed;


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

        /// <summary>
        /// Sets CrosswalkPressed to true if it hasn't been.\n
        /// Based on the Roadway Object.
        /// </summary>
        /// <param name="roadway"></param>
        public void OnCrosswalkPressed(Roadway roadway)
        {
            if (CrosswalkPressed != null)
                CrosswalkPressed(roadway);
        }
    }
}
