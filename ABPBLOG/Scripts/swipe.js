function swipe(container) {
    // 获取第一个子节点
    var element = container.find(":first");
    // li页面数量
    var slides = element.find("li");
    // 获取容器尺寸
    var width = container.width();
    var height = container.height();
    // 设置li页面总宽度
    element.css({
        width  : (slides.length * width) + 'px',
        height : height + 'px'
    });
    $.each(slides,function (i) {
        var salidli=slides.eq(i);
        salidli.css({
            width  : width + 'px',
            height : height + 'px'
        })
    })
    //控制元素移动
   return function () {
       $(element).css({
           'transition-timing-function': 'linear',
           'transition-duration': '5000ms',
           'transform': 'translate3d(-' + (width * 2) + 'px,0px,0px)' //设置页面X轴移动
       });
   };
}