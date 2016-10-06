Example Usage
=============

When an editor sets the focus point of an image, the x and y percentage coordinates of the focus point can be added to the fluid-image element as background-position in an inline style.
An img tag should also be included to maintain accessibility.

The CSS that is needed to make this work is this:  

	[lang=css]
	.fluid-image {
		height: 100%;
		overflow: hidden;
		background-size: cover;
	}

	.fluid-image img {
		min-width: 100%;
		min-height: 100%;
		opacity: 0;
	}

Then set the background-position using the *Creuna.FluidImages.PercentageCoordinates*-property in your ImageFile-class:  
	
	[lang=razor]
    <div class="fluid-image" style="background-image: url(@Url.ContentUrl(Model)); background-position: @image.X% @image.Y%;">
        <img src="@Url.ContentUrl(Model)" alt="Alt text">
    </div>

We are using [this CSS](style/fluidStyle.css) with some additional styling to get the following examples to work:

<div class="demo-fluid-container">
	<img src="img/table.jpg" alt="" class="demo-reference">
	<div class="demo-image-container-wide">
		<div class="fluid-image" style="background-image: url(img/table.jpg); background-position: 25% 50%;">
			<img src="img/table.jpg" alt="Table">
		</div>
	</div>
	<div class="demo-image-container-square">
		<div class="fluid-image" style="background-image: url(img/table.jpg); background-position: 25% 50%;">
			<img src="img/table.jpg" alt="Table">
		</div>
	</div>
	<div class="demo-image-container-tall">
		<div class="fluid-image" style="background-image: url(img/table.jpg); background-position: 25% 50%;">
			<img src="img/table.jpg" alt="Table">
		</div>
	</div>
</div>

<pre>
<a href="https://www.flickr.com/photos/145562044@N06/29850627310/" target="_blank">Photo</a> by <a href="https://www.flickr.com/photos/145562044@N06/" target="_blank">tagcoor 10_2</a> is licensed under [CC BY 2.0](https://creativecommons.org/licenses/by/2.0/)
</pre>

<div class="demo-fluid-container">
	<img src="img/portrait.jpg" alt="" class="demo-reference">
	<div class="demo-image-container-wide">
		<div class="fluid-image" style="background-image: url(img/portrait.jpg); background-position: 80% 20%;">
			<img src="img/portrait.jpg" alt="portrait">
		</div>
	</div>
	<div class="demo-image-container-square">
		<div class="fluid-image" style="background-image: url(img/portrait.jpg); background-position: 80% 20%;">
			<img src="img/portrait.jpg" alt="portrait">
		</div>
	</div>
	<div class="demo-image-container-tall">
		<div class="fluid-image" style="background-image: url(img/portrait.jpg); background-position: 80% 20%;">
			<img src="img/portrait.jpg" alt="portrait">
		</div>
	</div>
</div>
<pre>
 <a href="https://www.flickr.com/photos/144880903@N08/29518211673/" target="_blank">Photo</a> by <a href="https://www.flickr.com/photos/144880903@N08/" target="_blank">cff 5_2</a> is licensed under [CC BY 2.0](https://creativecommons.org/licenses/by/2.0/)
</pre>
	
