<?php
	$para = $_POST['email'];
	$assunto = 'Corrida dos Chefs - Pesquisa de Satisfação';
	$header = 'Mensagem de contato';
	$corpo = 'Agradecemos a sua parceria!' . "\n";
	$corpo .= 'Por isso, queremos saber o que você pensa.' . "\n";
	$corpo .= 'Ficaríamos muito gratos se você pudesse reservar 5 minutos para nos contar sobre sua experiência com o nosso jogo.' . "\n";
	$corpo .= 'Clique no link abaixo: ' . "\n";
	$corpo .= 'https://docs.google.com/forms/d/e/1FAIpQLSe9VDDdYCHE1ZOmqPMLNumMb_2iKwPjvt9MXRWkiVMmbR6Bxg/viewform?fbzx=-8920728136738379722"' . "\n";
	$corpo .= "\n";
	$corpo .= 'Atenciosamente,' . "\n";
	$corpo .= 'Corrida dos Chefs';
?>

<!DOCTYPE html>
<html lang='pt-br'>
	<head>
        <link rel='shortcut icon' type='image/x-icon' href='../img/favicon.ico' />
		<meta http-equiv='refresh' content='1;url=../index.html'>
        <title>Corrida dos Chefs</title>
	</head>
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
	<body>
	</body>
</html>