<?php
	if (isset($_POST['g-recaptcha-response'])) {
	    $captcha_data = $_POST['g-recaptcha-response'];
	}

	if (!$captcha_data) {
	    $mensagem = "Por favor, confirme o captcha.";
	    include 'Mensagem.php';
	    exit;
	}

	$contents = file_get_contents("https://www.google.com/recaptcha/api/siteverify?secret=6LcqCVsUAAAAAAUI2YPDSdodjYvfexONjQ1z0rC6&response=".$captcha_data."&remoteip=".$_SERVER['REMOTE_ADDR']);

	// IF para verificar se o captcha estava confirmado
	//Após isso, jogar o conteudo dentro do if
	if ($contents.success) {
		
	} else {
	    $mensagem = "Por favor, preencha o captcha!";
	    include 'Mensagem.php';
	    exit;
	}
?>

<!-- 
	<script src='https://www.google.com/recaptcha/api.js'>
	</script> 
	COLOCAR NO HEAD
-->

<!-- 
	<div class="g-recaptcha" data-sitekey="6LcqCVsUAAAAADIh1JMu3a7Vs-55e9OHvfWf6uXk">
	</div> 
	COLOCAR NO BODY
-->