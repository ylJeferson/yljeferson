  /* ////////// */
 /* animFrases */
/* ////////// */
(function(){
  try {
    function animFrases(Frases, ID) {
        var div = document.getElementById(ID);

        function escrever(str, done) {
            var char = str.split('').reverse();
            var typer = setInterval(function() {
                if (!char.length) {
                    clearInterval(typer);
                    return setTimeout(done, 500);
                }
                var next = char.pop();
                div.innerHTML += next;
            }, 50);
        }

        function limpar(done) {
            var char = div.innerHTML;
            var nr = char.length;
            var typer = setInterval(function() {
                if (nr-- == 2) {
                    clearInterval(typer);
                    return done();
                }
                div.innerHTML = char.slice(0, nr);
            }, 50);
        }

        function rodape(conteudos) {
            var atual = -1;
        	function prox(){
        		if (atual < conteudos.length - 1) atual++;
        		else atual = 0;
        		var str = conteudos[atual];
        		escrever(str, function(){
        			limpar(prox);
        		});
        	}
        	prox();
        }

        rodape(Frases);
    } 
    // animFrases(arrSobre, 'sbFrases');

  }
  catch (e) {

  }
})();


  /* ////////// */
 /* animScroll */
/* ////////// */
const go = (elem) => {
  window.scroll({       // 1
      top: document
    .querySelector( elem )
      .offsetTop,       // 2
      left: 0,
      behavior: 'smooth'// 3
   });
}

  /* /////////// */
 /* navCircular */
/* /////////// */
(function(){
  try {
  	var button = document.getElementById('mnWButton'),
      wrapper = document.getElementById('mnWrapper'),
      overlay = document.getElementById('mnOverlay');

  	//open and close menu when the button is clicked
  	var open = false;
  	button.addEventListener('click', handler, false);
  	wrapper.addEventListener('click', cnhandle, false);

  	function cnhandle(e){
  		e.stopPropagation();
  	}

  	function handler(e){
  		if (!e) var e = window.top;
  	 	e.stopPropagation(); //so that it doesn't trigger click event on document

  	  	if(!open){
  	    	openNav();
  	  	}
  	 	else{
  	    	closeNav();
  	  	}
  	}

  	function openNav(){
  		open = true;
      button.innerHTML = "-";
      overlay.classList.add('onOverlay');
      wrapper.classList.add('onMenu');
  	}
  	
  	function closeNav(){
  		open = false;
  		button.innerHTML = "+";
  		overlay.classList.remove('onOverlay');
  		wrapper.classList.remove('onMenu');
  	}

  	document.addEventListener('click', closeNav);
  	document.getElementById("mnItens").addEventListener("click", function() {
  		closeNav();
  	});
  }
  catch (e) {
    
  }
})();

(function(){
})();
  /* ////// */
 /* jqMask */
/* ////// */
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


  /* //////// */
 /* navLinha */
/* //////// */
(function(){
  try {
    "use strict"; // Start of use strict

    $('.navLinks a[href^="#"], .navbar-brand[href^="#"]').on('click', function(e) {
      e.preventDefault();
      var id = $(this).attr('href'),
          targetOffset = $(id).offset().top;
          
      $('html, body').animate({ 
        scrollTop: targetOffset
      }, 500);
    });

    // Closes responsive menu when a scroll trigger link is clicked
    $('.js-scroll-trigger').click(function() {
      $('.navbar-collapse').collapse('hide');
    });

    // Activate scrollspy to add active class to navbar items on scroll
    $('body').scrollspy({
      target: '#mainNav',
      offset: 56
    });

    // Collapse Navbar
    var navbarCollapse = function() {
      if ($("#mainNav").offset().top > 100) {
        $("#mainNav").addClass("navbar-shrink");
      } else {
        $("#mainNav").removeClass("navbar-shrink");
      }
    };
    // Collapse now if page is not at top
    navbarCollapse();
    // Collapse the navbar when page is scrolled
    $(window).scroll(navbarCollapse);
  }
  catch (e) {
    
  }
})();


  /* ///// */
 /* Modal */
/* ///// */
(function(){
  try {
    var modal = document.getElementById('pModal');
    var modalImg = document.getElementById("imgZoom");
    var captionText = document.getElementById("mdlCaption");

    $(document).on('click', '.piLink', function () {
        modalImg.src = this.children[1].src;
        captionText.innerHTML = this.children[1].alt;
        modal.style.display = "block";
    });

    // Get the <span> element that closes the modal
    var span = document.getElementsByClassName("pClose")[0];

    // When the user clicks on <span> (x), close the modal
    span.onclick = function() { 
      modal.style.display = "none";
    }
  }
  catch (e) {
    
  }
})();


  /* ////////// */
 /* ModalVideo */
/* ////////// */
(function(){
  try {
    var modal = document.getElementById('sbVideo');

    $(document).on('click', '#sbModal', function () {
        modal.style.display = "block";
    });

    // Get the <span> element that closes the modal
    var span = document.getElementsByClassName("sbClose")[0];

    // When the user clicks on <span> (x), close the modal
    span.onclick = function() { 
      modal.style.display = "none";
    }
  }
  catch (e) {
    
  }
})();