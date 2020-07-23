"use strict";

// jQuery Selector
window.BQ_Select = (selector) => {
    var data = $(selector).map(function () {
        return {
            Selector: selector,
            ClassName: $(this).attr('class'),
            Id: $(this).attr('id'),
            Name: $(this).attr('name'),
            Value: $(this).attr('value'),
            Text: $(this).text()
        };
    }).get();

    return JSON.stringify(data);
};

// Utils
window.BQ_Utils_Alert = (message) => { alert(message); };
window.BQ_Utils_ConsoleLog = (message) => { console.log(message); };

// Functions - Actions
window.BQ_AddClass = (selector, className) => { $(selector).addClass(className); };
window.BQ_RemoveClass = (selector, className) => { $(selector).removeClass(className); };
window.BQ_CSS = (selector, style, styleValue) => { $(selector).css(style, styleValue); };
window.BQ_Height_Set = (selector, height) => { $(selector).height(height); };
window.BQ_Width_Set = (selector, width) => { $(selector).width(width); };
window.BQ_Text_Set = (selector, text) => { $(selector).text(text); };
window.BQ_FadeOut = (selector) => { $(selector).fadeOut(5000, function () { alert('done');}); };

// Functions - Chain-enders
window.BQ_Height_Get = (selector) => { return $(selector).height(); };
window.BQ_Width_Get = (selector) => { return $(selector).width(); };
window.BQ_Text_Get = (selector) => { return $(selector).text(); };