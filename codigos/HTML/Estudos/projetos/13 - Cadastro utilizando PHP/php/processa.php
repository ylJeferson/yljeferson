<?php 
	include_once("conexao.php");

	$usuario = $_POST['usuario'];
	$senha = $_POST['senha'];

		$sql = "insert into usuarios (login, senha) value ('$usuario','$senha')";

		$salvar = mysqli_query($conexao, $sql);

		$linhas = mysqli_affected_rows($conexao);

	mysqli_close($conexao);
 ?>

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
		<meta http-equiv="refresh" content=" 3 ;url=../paginas/consultas.php">

		<link rel="stylesheet" href="../css/processa.css">
	</head>

	<body>
		<div class="container">
			<nav>
				<ul class="menu">
					<a href="../paginas/cadusuarios.php">
						<li>Usuarios</li>
					</a>

						<a href="../paginas/cadfornecedores.php">
					<li>Fornecedores</li>
					</a>

					<a href="../paginas/cadclientes.php">
						<li>Clentes</li>
					</a>

					<a href="../paginas/cadservicos.php">
						<li>Serviços</li>
					</a>

					<a href="../paginas/consultas.php">
						<li>Consultas</li>
					</a>

					<a href="../paginas/login.php">
						<li>Sair</li>
					</a>
				</ul>
			</nav>
			<section>
				<h1>Confirmação de Cadastro</h1>

				<hr><br>
				
				<?php 

				if ($linhas == 1){
					print "Cadastro efetuado com sucesso";
				} else {
					print "Cadastro não efetuado.";
				}

				?>

			</section>
		</div>
	</body>
</html>