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
        Green,
        GreenArrow,
        Yellow,
        YellowArrow,
        Red,
        RedArrow,
    }
}
