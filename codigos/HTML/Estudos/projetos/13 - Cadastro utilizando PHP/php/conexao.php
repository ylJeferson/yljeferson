<?php
	$hostname = "localhost";
	$user = "root";
	$password = "";
	$database = "lire";

	$conexao = mysqli_connect($hostname,$user,$password,$database);

	if (!$conexao){
		print "FALHA NA CONEXAO COM O BANCO";
	}
?>