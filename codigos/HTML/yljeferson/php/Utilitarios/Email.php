<?php
	$para = 'contato@yljeferson.com';
	$assunto = 'Contato';
	$name = $_POST['nome'];
	$email = $_POST['email'];
	$fone = $_POST['telefone'];
	$msg = $_POST['mensagem'];

	$corpo = "<strong> Mensagem de contato </strong> <br> <br>";
	$corpo .= "<strong> Nome: </strong> $name <br>";
	$corpo .= "<strong> E-Mail: </strong> $email <br>";
	$corpo .= "<strong> Telefone: </strong> $fone <br>";
	$corpo .= "<strong> Mensagem: </strong> $msg <br>";

	$header = "Content-Type: text/html; charset=utf-8\n";
	$header .= "From: $email\n";

	
	mail($para,$assunto,$corpo,$header);

	$mensagem = "E-Mail enviado com sucesso!";
	$site = 'https://yljeferson.com/yljeferson';
    include 'Mensagem.php';
?>