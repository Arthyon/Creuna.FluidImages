using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Framework.DataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace Creuna.FluidImages.TestSite.Models.Media
{
    [ContentType(DisplayName = "Image", GUID = "79a4e457-e026-4ce7-a5a7-37893e2b0db8", Description = "")]
    [MediaDescriptor(ExtensionString = "jpg,jpeg,png,gif")]
    public class ImageFile : ImageData
    {
        [Editable(true)]
        [Display(
            Name = "Focus point",
            Description = "Choose the focus point of an image",
            GroupName = "Focus",
            Order = 1)]
        public virtual PercentageCoordinates FocusPoint { get; set; }

        [Display(GroupName = "Creative Commons")]
        public virtual string Attribution { get; set; }

        [Display(GroupName = SystemTabNames.Content)]
        public virtual string AlternateText { get; set; }
    }
}
