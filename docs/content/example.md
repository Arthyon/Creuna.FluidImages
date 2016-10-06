Example Usage
=============

When an editor sets the focus point of an image, the x and y percentage coordinates of the focus point can be added to the fluid-image element as background-position in an inline style.
An img tag should also be included to maintain accessibility.

We are using [this CSS](style/fluidStyle.css) to get these examples to work.

<main class="content-container">
<div class="fluid-container">
	<img src="img/table.jpg" alt="" class="reference">
	<div class="image-container-wide">
		<div class="image" style="background-image: url(img/table.jpg); background-position: 25% 50%;">
			<img src="img/table.jpg" alt="Table">
		</div>
	</div>
	<div class="image-container-square">
		<div class="image" style="background-image: url(img/table.jpg); background-position: 25% 50%;">
			<img src="img/table.jpg" alt="Table">
		</div>
	</div>
	<div class="image-container-tall">
		<div class="image" style="background-image: url(img/table.jpg); background-position: 25% 50%;">
			<img src="img/table.jpg" alt="Table">
		</div>
	</div>
</div>

<pre>
<a href="https://www.flickr.com/photos/145562044@N06/29850627310/" target="_blank">Photo</a> by <a href="https://www.flickr.com/photos/145562044@N06/" target="_blank">tagcoor 10_2</a> is licensed under [CC BY 2.0](https://creativecommons.org/licenses/by/2.0/)
</pre>

<div class="fluid-container">
	<img src="img/portrait.jpg" alt="" class="reference">
	<div class="image-container-wide">
		<div class="image" style="background-image: url(img/portrait.jpg); background-position: 80% 20%;">
			<img src="img/portrait.jpg" alt="portrait">
		</div>
	</div>
	<div class="image-container-square">
		<div class="image" style="background-image: url(img/portrait.jpg); background-position: 80% 20%;">
			<img src="img/portrait.jpg" alt="portrait">
		</div>
	</div>
	<div class="image-container-tall">
		<div class="image" style="background-image: url(img/portrait.jpg); background-position: 80% 20%;">
			<img src="img/portrait.jpg" alt="portrait">
		</div>
	</div>
</div>
<pre>
 <a href="https://www.flickr.com/photos/144880903@N08/29518211673/" target="_blank">Photo</a> by <a href="https://www.flickr.com/photos/144880903@N08/" target="_blank">cff 5_2</a> is licensed under [CC BY 2.0](https://creativecommons.org/licenses/by/2.0/)
</pre>
	
</main>
