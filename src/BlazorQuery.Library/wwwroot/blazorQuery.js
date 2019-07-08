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

window.BQ_AddClass = (selector, className) => { $(selector).addClass(className); return true; };
window.BQ_RemoveClass = (selector, className) => { $(selector).removeClass(className); return true; };
window.BQ_CSS = (selector, style, styleValue) => { $(selector).css(style, styleValue); return true; };