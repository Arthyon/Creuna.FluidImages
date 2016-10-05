using EPiServer.Shell.ObjectEditing;
using EPiServer.Shell.ObjectEditing.EditorDescriptors;
using System;
using System.Collections.Generic;

namespace Creuna.FluidImages.EditorDescriptors
{
    [EditorDescriptorRegistration(TargetType = typeof(PercentageCoordinates), UIHint = UIHint.FocusPoint)]
    public class ImageFocusPointEditorDescriptor : EditorDescriptor
    {
        public override void ModifyMetadata(ExtendedMetadata metadata, IEnumerable<Attribute> attributes)
        {
            ClientEditingClass = "creuna.ImageFocusPointEditor";

            base.ModifyMetadata(metadata, attributes);
        }
    }
}
