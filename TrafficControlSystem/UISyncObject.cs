using TrafficControlSystem.Models;

namespace TrafficControlSystem
{
    public delegate void UIEvent(Intersection intersection);
    public delegate void CrosswalkEvent(Roadway roadway);

    public class UISyncObject
    {
        public event UIEvent TimeToUpdate;
        public event CrosswalkEvent CrosswalkPressed;
        
        public void OnTimeToUpdate(Intersection intersection)
        {
            if (TimeToUpdate != null)
                TimeToUpdate(intersection);
        }

        public void OnCrosswalkPressed(Roadway roadway)
        {
            if (CrosswalkPressed != null)
                CrosswalkPressed(roadway);
        }
    }
}
