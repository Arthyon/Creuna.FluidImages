define([
	"dojo/_base/declare",
	"dijit/_Widget",
	"dijit/_TemplatedMixin",
	"epi-cms/_ContentContextMixin",
], function (declare, _WidgetBase, _TemplatedMixin, _ContentContextMixin) {

    return declare("creuna.editors.ImageFocusPointEditor",
		[_WidgetBase, _TemplatedMixin, _ContentContextMixin], {
		    //templateString: dojo.cache('/FocusPointEditor/Index/'),
		    templateString: '<div class="hotspotseditor-wrapper">  <input type="hidden" class="value" data-dojo-attach-point="focuspoint" /> <div class="image-container" style="display:inline-block;position: relative;cursor: pointer"> <div class="focus" style="border:1px solid white;position:absolute; border-radius:100%; background-color: rgba(255, 0, 255, .5); height:30px;width:30px;transform:translate(-50%, -50%)"></div> <div class="image"><img src="${_currentContext.previewUrl}" style="max-width: 100%;" /></div> </div> </div>',

		    //********************************************************************************
		    //*PROTOTYPE/PUBLIC FUNCTIONS*****************************************************
		    //********************************************************************************

		    postCreate: function () {
		        this.set('value', this.value);

		        var container = this.domNode;

		        this._$el = $(container);
		        this._$imageContainer = this._$el.find('.image');
		        this._$image = this._$imageContainer.find('img');
		        this._$marker = this._$el.find('.focus');
		        this._attachEventListeners();
		        this._waitForImageLoad();

		    },

		    focus: function () {
		        dijit.focus(this.focuspoint);
		    },

		    _setValueAttr: function (value) {
		        this._set('value', value);
		        this.focuspoint.value = this.value;
		    },


		    //********************************************************************************
		    //*PRIVATE OBJECT METHODS ********************************************************
		    //********************************************************************************

		    /**
			 * Attach events here
			 *
			 * @private
			 */
		    _attachEventListeners: function () {
		        window.addEventListener('resize', this._onWindowResize.bind(this));
		        this._$image[0].addEventListener('click', this._changeFocusPoint.bind(this));
		    },

		    _waitForImageLoad: function () {
		        // Wait for the image to load before calculating image width and height
		        if (this._$image.height() > 0) {
		            this._onImageLoaded();
		        } else {
		            this._$image[0].addEventListener('load', this._onImageLoaded.bind(this));
		        }

		    },

		    _onImageLoaded: function () {
		        // check if there is something to do
		        if (typeof (this.value) === 'undefined' || this.value === '') {
		            return;
		        }

		        var coordinates = this.value;
		        this._updateFocusMarkerPosition(coordinates);
		    },

		    _onWindowResize: function () {
		        var coordinates = this.value;
		        this._updateFocusMarkerPosition(coordinates);
		    },

		    _changeFocusPoint: function (e) {
		        var pixelPos = this._getPixelCoordinatesRelativeToImageOffset(e);
		        var pos = this._pixelsToPercent(pixelPos);

		        this._updateFocusMarkerPosition(pos);
		        this._updatePropertyValue(pos);
		    },

		    _getPixelCoordinatesRelativeToImageOffset: function (clickEvent) {
		        var offset = this._$image.offset();
		        var x;
		        var y;
		        if (clickEvent.pageX || clickEvent.pageY) {
		            x = clickEvent.pageX;
		            y = clickEvent.pageY;
		        }
		        else {
		            x = clickEvent.clientX + document.body.scrollLeft + document.documentElement.scrollLeft;
		            y = clickEvent.clientY + document.body.scrollTop + document.documentElement.scrollTop;
		        }

		        x -= offset.left;
		        y -= offset.top;

		        return { x: x, y: y };
		    },

		    _pixelsToPercent: function (pixels) {
		        var width = this._$image.width();
		        var height = this._$image.height();

		        return {
		            x: (pixels.x / width) * 100,
		            y: pixels.y / height * 100
		        };
		    },

		    _updatePropertyValue: function (percent) {
		        var jsonString = JSON.stringify(percent);
		        this._set('value', percent);
		        this.focuspoint.value = percent;
		        this.onChange(this.value);
		    },

		    _updateFocusMarkerPosition: function (percent) {
		        this._$marker
                    .css('top', percent.y + '%')
                    .css('left', percent.x + '%');
		    },
		});
});
