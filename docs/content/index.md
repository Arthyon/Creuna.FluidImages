Creuna.FluidImages
===================

An EPiServer plugin enabling editors to set the focus point of an image.

Used to create an image that covers an area, always keeping the subject within the area, independent of container dimensions.

Check out the [releases page](https://github.com/Arthyon/Creuna.FluidImages/releases) to download. This is not totally stable yet, so it's not on NuGet.

Getting Started
-------

This example demonstrates how to enable the editor for a property.
To use the editor you need to define an image file inheriting from ImageData.

	[lang=csharp]
	[ContentType(GUID = "0A89E464-56D4-449F-AEA8-2BF774AB8730")]
    [MediaDescriptor(ExtensionString = "jpg,jpeg,jpe,ico,gif,bmp,png")]
    public class ImageFile : ImageData, IFileProperties

Then you can add the focus point property to this class, using the type *Creuna.FluidImages.PercentageCoordinates*:
	
	[lang=csharp]
	public virtual PercentageCoordinates FocusPoint { get; set; }

This class contains two properties, X and Y, which are the coordinates of the chosen focus point in percent of the image size.
  
See [Example Usage](example.html) for suggestions on how to use the focus point in the frontend.