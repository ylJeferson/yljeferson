<?php 
	include_once("../php/conexao.php");

	$filtro = isset($_GET['filtro'])?$_GET['filtro']:"";

	$sql = "select * from usuarios where login like '%$filtro%' order by login";
	$consulta = mysqli_query($conexao, $sql);
	$registros = mysqli_num_rows($consulta);
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
		<!-- <meta http-equiv="refresh" content=" 3 ;url=../paginas/consultas.php"> -->

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
				<h1>Consultas</h1>

				<hr><br>
				
				<form action="" method="get">
					Filtrar por nome: <input type="text" name="filtro" autofocus>
					<input type="submit" value="Pesquisar" class="btn">
				</form>

				<?php 

					if ($filtro == "" || $filtro == null)
						print "Total de $registros registros encontrados.";
					else
						print "<b>$filtro</b>: $registros registros encontrados.";

					print "<br><br>";

					while ($exibirRegistros = mysqli_fetch_array($consulta)) {
							$ID = $exibirRegistros[0];
							$login = $exibirRegistros[1];
							$senha = $exibirRegistros[2];

							print "<article>";

							print "$ID<br>";
							print "$login<br>";
							print "$senha<br>";

							print "</article>";
					}

					mysqli_close($conexao);
				?>

			</section>
		</div>
	</body>
</html>