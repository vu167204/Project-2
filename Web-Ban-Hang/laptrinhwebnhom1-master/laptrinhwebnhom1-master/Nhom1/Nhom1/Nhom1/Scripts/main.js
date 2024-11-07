$(".slider-one")
  .not(".slick-intialized")
  .slick({
    autoplay: true,
    autoplaySpeed: 2000,
    dots: true,
    prevArrow: ".site-slider .slider-btn .prev",
    nextArrow: ".site-slider .slider-btn .next"
  });

$(".slider-two")
  .not(".slick-intialized")
  .slick({
    prevArrow: ".site-slider-two .prev",
    nextArrow: ".site-slider-two .next",
    slidesToShow: 5,
    slidesToScroll: 1,
    autoplay: true,
    autoplaySpeed: 2000
  });

// $("html").scroll(function(e) {
//   console.log($(document).)
// });
$(document).ready(function () {
  $(window).scroll(function () {
    if ($(this).scrollTop() < 250) {
      $('#on_top').addClass("hide");
    } else {
      $('#on_top').removeClass("hide");
    }
  });
  $('#on_top').click(function () {
    $("html, body").animate({ scrollTop: 0 }, 600);
    return false;
  });
});