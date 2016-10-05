using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.PlugIn;
using System;
using System.Web.Script.Serialization;
using System.Xml.Serialization;

namespace Creuna.FluidImages
{
    [Serializable]
    public class PercentageCoordinates
    {
        [XmlElement("X")]
        public float X { get; set; }
        [XmlElement("Y")]
        public float Y { get; set; }
    }

    [PropertyDefinitionTypePlugIn]
    [EditorHint(UIHint.FocusPoint)]
    public class PercentageCoordinatesBackingType : PropertyLongString
    {
        public override Type PropertyValueType
        {
            get { return typeof(PercentageCoordinates); }
        }


        public override object Value
        {
            get
            {
                var value = base.Value as string;
                if (value == null)
                {
                    return null;
                }
                var serializer = new JavaScriptSerializer();
                return serializer.Deserialize(value, typeof(PercentageCoordinates));
            }
            set
            {
                if (value is PercentageCoordinates)
                {
                    var serializer = new JavaScriptSerializer();
                    base.Value = serializer.Serialize(value);
                }
                else
                {
                    base.Value = value;
                }
            }
        }

        public override object SaveData(PropertyDataCollection properties)
        {
            return LongString;
        }
    }
}
