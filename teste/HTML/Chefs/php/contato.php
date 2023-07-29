<?php
	$para = 'eleonora.perobelli@aluno.unip.br';
	$assunto = 'Corrida dos Chefs';
	$name = $_POST['nome'];
	$email = $_POST['email'];
	$fone = $_POST['telefone'];
	$msg = $_POST['mensagem'];

	$corpo = "Nome: $name \n";
	$corpo .= "E-mail: $email \n";
	$corpo .= "Telefone: $fone \n";
	$corpo .= "Mensagem: $msg \n";

	$header = "Contato";
?>

<!DOCTYPE html>
<html lang="pt-br">
	<head>
        <meta charset="utf-8" name="viewport" content="width=device-width, initial-scale=1.0">
        <link rel="shortcut icon" type="image/x-icon" href="../img/favicon.ico" />
		<meta http-equiv="refresh" content="1;url=../index.html">
        <title>Corrida dos Chefs</title>
	</head>

	<body>
		<?php
			try {
				if(mail($para,$assunto,$corpo,$header)) {
					echo 'Email enviado com sucesso!<br>';
					echo 'Aguarde, você será redirecionado.';
				} else {
					echo 'Email não enviado';
				}
			} catch (Exception $e) {
				echo 'Erro ao enviar mensagem: {$mail->ErrorInfo}';
			}
		?>
	</body>
</html>