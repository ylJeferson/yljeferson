<!DOCTYPE html>
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

		<link rel="stylesheet" href="../css/cadusuarios.css">
	</head>

	<body>
		<div class="container">
			<nav>
				<ul class="menu">
					<a href="cadusuarios.php">
						<li>Usuarios</li>
					</a>

						<a href="cadfornecedores.php">
					<li>Fornecedores</li>
					</a>

					<a href="cadclientes.php">
						<li>Clentes</li>
					</a>

					<a href="cadservicos.php">
						<li>Serviços</li>
					</a>

					<a href="consultas.php">
						<li>Consultas</li>
					</a>

					<a href="login.php">
						<li>Sair</li>
					</a>
				</ul>
			</nav>
			<section>
				<h1>Cadastro de usuários</h1>

				<hr><br>

				<form action="../php/processa.php" method="post" class="f1">
					<input class="btn salvar" type="submit" value="Salvar">
					
					<input class="btn limpar" type="reset" value="Limpar">

					<input class="btn excluir" type="button" value="Excluir">

					<br>
					<br>

					<!-- '-' -->

					Nome de usuário: <br>	
					<input type="text" class="campos" name="usuario" maxlength="20" placeholder="Nome de usuário" pattern="\d{3}\.\d{3}\.\d{3}-\d{2}" title="tem que te a b ou c" required autofocus> <br>

					Senha: <br>
					<input type="password" class="campos" name="senha" placeholder="Digite uma senha" required onchange="form.rsenha.pattern = this.value" > <br>

					Repetir Senha: <br>
					<input type="password" class="campos" name="rsenha" placeholder="Repita sua senha" title="slk catchuera"> <br>
				</form>
			</section>
		</div>
	</body>
</html>