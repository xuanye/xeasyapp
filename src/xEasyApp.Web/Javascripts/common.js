function getiev() {
    var userAgent = window.navigator.userAgent.toLowerCase();
    $.browser.msie8 = $.browser.msie && /msie 8\.0/i.test(userAgent);
    $.browser.msie7 = $.browser.msie && /msie 7\.0/i.test(userAgent);
    $.browser.msie6 = !$.browser.msie8 && !$.browser.msie7 && $.browser.msie && /msie 6\.0/i.test(userAgent);
    var v;
    if ($.browser.msie8) {
        v = 8;
    }
    else if ($.browser.msie7) {
        v = 7;
    }
    else if ($.browser.msie6) {
        v = 6;
    }
    else { v = -1; }
    return v;
}
$(document).ready(function () {
    var v = getiev()
    if (v > 0) {
        $(document.body).addClass("ie ie" + v);
    }
});
/*
(function($){
    $.documentCenter = function (el) {
    el = $(el);
    el.css({
        position: 'absolute',
        left: Math.max((document.documentElement.clientWidth - el.width()) / 2 + document.documentElement.scrollLeft, 0) + 'px',
        top: Math.max((document.documentElement.clientHeight - el.height()) / 2 + document.documentElement.scrollTop, 0) + 'px'
    });
};
})(jQuery);
*/