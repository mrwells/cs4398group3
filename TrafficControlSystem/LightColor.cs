using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficControlSystem.Models
{
    /// <summary>
    /// Creates an enumerator for each Light Color
    /// </summary>
    /// <remarks>
    /// Colors include:
    /// Green, GreenArrow, Yellow, YellowArrow,
    /// Red, RedArrow
    /// </remarks>
    public enum LightColor
    {
        /// <summary>
        /// Used to specify a round green traffic light.
        /// </summary>
        Green,

        /// <summary>
        /// Used to specify a green arrow traffic light.
        /// </summary>
        GreenArrow,

        /// <summary>
        /// Used to specify a round yellow traffic light.
        /// </summary>
        Yellow,

        /// <summary>
        /// Used to specify a yellow arrow traffic light.
        /// </summary>
        YellowArrow,

        /// <summary>
        /// Used to specify a round red traffic light.
        /// </summary>
        Red,

        /// <summary>
        /// Used to specify a red arrow traffic light.
        /// </summary>
        RedArrow,
    }
}
