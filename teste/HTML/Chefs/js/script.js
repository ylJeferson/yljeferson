  /* ///////// */
 /* Variaveis */
/* ///////// */
var vw = $(window).width() / 100;
var vh = $(window).height() / 100;
var v_wh = vw / vh

var slItens = document.getElementsByClassName('gmSliderItem');
var qtItens = slItens.length;
var currentPosition = 0
var itAtual = 1

var navList = document.querySelectorAll('.navButton');

/* ------------------------------------------------------------------- */

  /* ////// */
 /* Slider */
/* ////// */
$('.gmSliderNext').on('click', function(e) {
  mxItens = parseInt(slWidth = $('.gmSliderInner').width() / ($('.gmSliderItem.'+itAtual).width() + parseFloat($('.gmSliderItem.'+itAtual).css('margin-left')) + parseFloat($('.gmSliderItem.'+itAtual).css('margin-right'))));
  if (currentPosition < qtItens - mxItens) {
      itAtual += 1;
      currentPosition += 1;
    }

    $('.gmSliderItem.'+currentPosition).addClass('gmSliderAnimation');
});

$('.gmSliderPrev').on('click', function(e) {
    mxItens = parseInt(slWidth = $('.gmSliderInner').width() / ($('.gmSliderItem.'+itAtual).width() + parseFloat($('.gmSliderItem.'+itAtual).css('margin-left')) + parseFloat($('.gmSliderItem.'+itAtual).css('margin-right'))));
    $('.gmSliderItem.'+currentPosition).removeClass('gmSliderAnimation');

    if (currentPosition > 0) {
      itAtual -= 1;
      currentPosition -= 1;
    }
});

/* ------------------------------------------------------------------- */

  /* /////////////// */
 /* Menu Responsivo */
/* /////////////// */
try {
  $('.navLink, .navList').on('click', function(e) {
    $('nav').removeClass('navActive');
    $('.navList').removeClass('navActive');
    $('.navSideMenu').removeClass('navActive');
    animatedLinks();
  });

  $('.navSideMenu').on('click', function(e) {
    animatedLinks();
    $('nav').toggleClass('navActive');
    $('.navList').toggleClass('navActive');
    $('.navSideMenu').toggleClass('navActive');
  });
}
catch (e) {

}


function animatedLinks() {
  navList.forEach(function(navButton, index) {
    navButton.style.animation
      ? (navButton.style.animation = "")
      : (navButton.style.animation = `navLinkFade .5s linear forwards ${index / 10 + .3}s`);
  })
}

/* ------------------------------------------------------------------- */

  /* ////// */
 /* JQuery */
/* ////// */
// var Start = 
(function(){
  try {
    /* USADA PARA REALIZAR O SCROLL NA PAGINA SEM ALTERAR A URL*/
    'use strict'; // Start of use strict

    $('.navList a[href^="#"]').on('click', function(e) {
      e.preventDefault();
      var id = $(this).attr('href'),
        targetOffset = $(id).offset().top - 9 * vh;
          
      $('html, body').animate({
        scrollTop: targetOffset
      }, 0);
      
      animatedLinks();
    });

    $('.hdrNextSection[href^="#"], .gmNextGame[href^="#"], .naviBrand[href^="#"]').on('click', function(e) {
      e.preventDefault();
      var id = $(this).attr('href'),
        targetOffset = $(id).offset().top - 9 * vh;
          
      $('html, body').animate({
        scrollTop: targetOffset
      }, 0);
    });

/* ------------------------------------------------------------------- */

    /* FUNCAO USADA PRA QUANDO ABAIXAR O SCROLL, COLOCAR UMA NOVA CLASSE NA NAV */
    // tanto de scroll que vai precisar para a barra ficar fixa.
    if (v_wh < 1) {
      var num = 10 * vh;
    } else {
      var num = 40 * vh;
    }

    $(window).bind('scroll', function () {
        if ($(window).scrollTop() > num) {
            $('#mainNav').addClass('navScroll');
        } else {
           //Quando o menu ficar fixo
            $('#mainNav').removeClass('navScroll');
        }
    });

/* ------------------------------------------------------------------- */

    /* FUNCAO USADA PRA QUANDO ABAIXAR O SCROLL, COLOCAR UMA NOVA CLASSE NA NAV */
    /*NO CARREGAMENTO DA PAGINA */
    window.onload = function() {
        if ($(window).scrollTop() > num) {
            $('#mainNav').addClass('navScroll');
        } else {
           //Quando o menu ficar fixo
            $('#mainNav').removeClass('navScroll');
        }
    };

  }
  catch (e) {
    
  }
})();

/* ------------------------------------------------------------------- */

  /* ///////////////////////// */
 /* jQuery Mascara de Celular */
/* ///////////////////////// */
(function(){
  $(document).ready(function(){
    try {
      var SPMaskBehavior = function (val) {
          return val.replace(/\D/g, '').length === 11 ? '(00) 00000-0000' : '(00) 0000-00009';
      },
      spOptions = {
          onKeyPress: function(val, e, field, options) {
              field.mask(SPMaskBehavior.apply({}, arguments), options);
          }
      };

      $("input[name='telefone']").mask(SPMaskBehavior, spOptions);
    }
    catch (e) {
      
    }
  });
})();