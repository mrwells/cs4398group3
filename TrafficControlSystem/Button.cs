using System;

namespace TrafficControlSystem
{
    /// <summary>
    /// Button Class
    /// </summary>
    /// <remarks>
    /// Button class has 1 attribute:
    /// (Boolean) pushed - State of the Button
    /// </remarks>
    public class Button
    {
        private Boolean pushed;

        /// <summary>
        /// Constructor for Button
        /// </summary>
        /// <remarks>
        /// Sets state of Button to false on instansiation.
        /// </remarks>
        public Button()
        {
            pushed = false;
        }

        /// <summary>
        /// Gets state of the Button
        /// </summary>
        /// <returns>
        /// pushed
        /// </returns>
        public Boolean getButtonState()
        {
            return pushed;
        }
        /// <summary>
        /// Activates button
        /// </summary>
        /// <remarks>
        /// Mimics button being pushed, changes state
        /// of pushed to true.
        /// </remarks>
        public void activate()
        {
            pushed = true;
        }

        /// <summary>
        /// Deactivates button
        /// </summary>
        /// <remarks>
        /// Mimics button resetting back to default state
        /// of not being pushed.
        /// </remarks>
        public void deactivate()
        {
            pushed = false;
        }
    }
}