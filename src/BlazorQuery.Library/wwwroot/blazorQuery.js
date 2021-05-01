"use strict";

var blazorQueryInterop = blazorQueryInterop || {};

// jQuery Selector
blazorQueryInterop.BQ_Select = (selector) => {
	var data = $(selector).map(function () {
		return {
			Selector: selector,
			ClassName: $(this).attr('class'),
			Id: $(this).attr('id'),
			Name: $(this).attr('name'),
			Value: $(this).attr('value'),
			Href: $(this).attr('href'),
			Text: $(this).text()
		};
	}).get();

	return JSON.stringify(data);
};

// Utils
blazorQueryInterop.BQ_Utils_Alert = (message) => { alert(message); };
blazorQueryInterop.BQ_Utils_ConsoleLog = (message) => { console.log(message); };

// Functions - Actions
blazorQueryInterop.BQ_AddClass = (selector, className) => { $(selector).addClass(className); };
blazorQueryInterop.BQ_RemoveClass = (selector, className) => { $(selector).removeClass(className); };
blazorQueryInterop.BQ_CSS = (selector, style, styleValue) => { $(selector).css(style, styleValue); };
blazorQueryInterop.BQ_Height_Set = (selector, height) => { $(selector).height(height); };
blazorQueryInterop.BQ_Width_Set = (selector, width) => { $(selector).width(width); };
blazorQueryInterop.BQ_Text_Set = (selector, text) => { $(selector).text(text); };
blazorQueryInterop.BQ_FadeOut = (selector, dotNetObjectRef) => {
	$(selector).fadeOut(2000,
		function () {
			dotNetObjectRef.invokeMethodAsync("ActionCallback", $(selector).text());
		});
};

// Functions - Chain-enders
blazorQueryInterop.BQ_Height_Get = (selector) => { return $(selector).height(); };
blazorQueryInterop.BQ_Width_Get = (selector) => { return $(selector).width(); };
blazorQueryInterop.BQ_Text_Get = (selector) => { return $(selector).text(); };