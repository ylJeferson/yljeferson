<DOCTYPE html>
<html lang="pt-br">
	<head>
		<meta charset="UTF-8">

		<title>HTML5 - CSS3</title>

		<meta name="author" content="Jeferson Hugo">
		<meta name="description" content="Aprendendo HTML5, CSS3">
		<meta name="keywords" content="sites, web, código, html, css">
		<meta name="viewport" content="width=device-width, initial-scale=1.0">
		<meta http-equiv="content-language" content="pt-br">
		<!-- <meta http-equiv="refresh" content=" 0 ;url=http://www.google.com/"> -->

		<link rel="stylesheet" href="../css/login.css">
		<link href="https://fonts.googleapis.com/css?family=Lobster" rel="stylesheet">
	</head>

	<body>
		<section>
			<form method="post" action="">
				<input id="nome" class="campos" name="nome" type="text" minlength="6" maxlength="20" placeholder="Usuario" required><br>
				<!-- autofocus: dar foco assim que a pagina é carregada -->

				<input id="senha" class="campos" name="senha" type="password" minlength="8" maxlength="16" placeholder="Senha" required><br>
				
				<p class="lembrarusuario"><input id="lembrar" class="checkbox" type="checkbox" value="lembrar"><label for="lembrar">	Lembrar minhas credenciais?</label></p>
				<p class="cadastro1"><a href="cadastro.html">Cadastre-se!</a></p>

				<input class="botao" type="submit" value="Log In">

				<p class="cadastro2"><a href="cadastro.html">Cadastre-se!</a></p>
				<p class="recuperar"><a href="#">Esqueci minha senha!</a></p>
			</form>
		</section>
	</body>
</html>