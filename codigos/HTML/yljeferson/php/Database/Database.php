<?php
	header("Content-type:text/html; charset=utf-8");

	// $hostname = "localhost";
	// $user = "yljefers_user";
	// $password = "{[}RR[tZ(KiX";
	// $database = "yljefers_Database";

	$hostname = "br56.hostgator.com.br";
	$user = "yljefers_admin";
	$password = "@Lire8521";
	$database = "yljefers_Database";

	$conexao = mysqli_connect($hostname,$user,$password,$database);

	if (!$conexao){
		die("Falha na conexão: " . mysqli_connect_error());
	} else {
		//echo "Conexão realizada com sucesso!";
	}

	if (!mysqli_set_charset($conexao, 'utf8')) {
	    printf('Error ao usar utf8: %s', mysqli_error($conexao));
	    exit;
	}
?>