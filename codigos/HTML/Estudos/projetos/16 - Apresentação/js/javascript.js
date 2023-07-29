(function(){

	var button = document.getElementById('mnButton'),
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
	 	e.stopPropagation();//so that it doesn't trigger click event on document

	  	if(!open){
	    	openNav();
	  	}
	 	else{
	    	closeNav();
	  	}
	}
	function openNav(){
		open = true;
	    overlay.classList.add('onOverlay');
	    wrapper.classList.add('onMenu');
	    button.classList.add('onMenuX');
		button.classList.remove('onMenu2');
	}
	function closeNav(){
		open = false;
		overlay.classList.remove('onOverlay');
		wrapper.classList.remove('onMenu');
		button.classList.remove('onMenuX');
		button.classList.add('onMenu2');
	}
	document.addEventListener('click', closeNav);
})();