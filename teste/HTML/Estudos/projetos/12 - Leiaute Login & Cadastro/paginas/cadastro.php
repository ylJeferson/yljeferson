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

		<link rel="stylesheet" href="../css/cadastro.css">
		<link href="https://fonts.googleapis.com/css?family=Lobster" rel="stylesheet">
	</head>

	<body>
		<section>
			<form method="post" action="">
				<fieldset>
					<legend>Credenciais</legend>

					<input id="nome" class="campos" name="nome" type="text" minlength="6" maxlength="20" placeholder="Usuario" required><br>
					<!-- autofocus: dar foco assim que a pagina é carregada -->

					<input id="email" class="campos" name="email" type="text" maxlength="40" placeholder="E-Mail" required><br>

					<input id="senha" class="campos" name="senha" type="password" minlength="8" maxlength="16" placeholder="Senha" required><br>

					<input id="repsenha" class="campos" name="repsenha" type="password" minlength="8" maxlength="16" placeholder="Repetir Senha" required><br>
				</fieldset>

				<fieldset>
					<legend>Informações Pessoais</legend>

					<input id="nomecompleto" class="campos" name="nomecompleto" type="text" minlength="6" maxlength="40" placeholder="Nome Completo" required><br>
					<!-- autofocus: dar foco assim que a pagina é carregada -->

					<input id="nascimento" class="campos" name="nascimento" type="text" minlength="8" maxlength="16" placeholder="Data de Nascimento" required><br>

					<input id="masculino" class="radio" name="genero" type="radio" value="1" checked><label for="masculino"> Masculino &nbsp&nbsp&nbsp</label>
					<input id="feminino" class="radio" name="genero" type="radio" value="2"><label for="feminino"> Feminino</label><br>

					<input id="rg" class="campos" name="rg" type="text" minlength="9" maxlength="12" placeholder="RG" required><br>

					<input id="cpf" class="campos" name="cpf" type="text" minlength="11" maxlength="14" placeholder="CPF" required><br>

					<input id="celular" class="campos" name="celular" type="tel" minlength="8" maxlength="12" placeholder="Celular" required><br>

					<input id="telefone" class="campos" name="telefone" type="tel" minlength="8" maxlength="11" placeholder="Telefone"><br>
				</fieldset>

					<input class="botao" type="reset" value="Limpar">
					<input class="botao" type="submit" value="Confirmar">
					<a href="../index.html"><input class="botao" type="button" value="Voltar"></a>
			</form>
		</section>
	</body>
</html>