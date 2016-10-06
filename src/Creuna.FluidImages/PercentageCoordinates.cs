using System;
using System.Xml.Serialization;

namespace Creuna.FluidImages
{
    /// <summary>
    /// The coordinates representing the chosen focus point of the image, in percent of image size.
    /// </summary>
    [Serializable]
    public class PercentageCoordinates
    {
        [XmlElement("X")]
        public float X { get; set; }
        [XmlElement("Y")]
        public float Y { get; set; }
    }

   
}
