// Created by etherneco
// jquery.paste_image_reader.js
(function($) {
	var defaults;
	$.event.fix = (function(originalFix) {
		return function(event) {
			event = originalFix.apply(this, arguments);
			if (event.type.indexOf("copy") === 0 || event.type.indexOf("paste") === 0) {
				event.clipboardData = event.originalEvent.clipboardData;
			}
			return event;
		};
	})($.event.fix);
	defaults = {
		callback: $.noop,
		matchType: /image.*/
	};
	return ($.fn.pasteImg = function(options) {
		if (typeof options === "function") {
			options = {
				callback: options
			};
		}
		options = $.extend({}, defaults, options);
		return this.each(function() {
			var $this, element;
			element = this;
			$this = $(this);
			return $this.bind("paste", function(event) {
				var clipboardData, found;
				found = false;
				clipboardData = event.clipboardData;
				return Array.prototype.forEach.call(clipboardData.types, function(type, i) {
					var file, reader;
					if (found) {
						return;
					}
					if (
						type.match(options.matchType) ||
						clipboardData.items[i].type.match(options.matchType)
					) {
						file = clipboardData.items[i].getAsFile();
						reader = new FileReader();
						reader.onload = function(evt) {
							return options.callback.call(element, {
								dataURL: evt.target.result,
								event: evt,
								file: file,
								name: file.name
							});
						};
						reader.readAsDataURL(file);
					return (found = true);
					}
				});
			});
		});
	});
})(jQuery);



var dataURL, filename;
$("html").pasteImg(function (results) {
    filename = results.filename, dataURL = results.dataURL;
	$data.text(dataURL);
	$size.val(results.file.size);
	$type.val(results.file.type);
	var img = document.createElement("img");
	img.src = dataURL;
	var w = img.width;
	var h = img.height;
	$width.val(w);
	$height.val(h);
    $('#textcopy').val(dataURL);

    return $("#imgpaste")
        .prop('src', dataURL)
        .css({
            width:'100%'
        })
        .data({ width: w, height: h });
    

});

var $data, $size, $type, $width, $height;
$(function() {
	$data = $(".data");
	$size = $(".size");
	$type = $(".type");
	$width = $("#width");
	$height = $("#height");
});

function copy(text) {

}
