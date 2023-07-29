<!-- FORMULARIO APRESENTACAO -->
	<?php
		$sltHeader = "SELECT * FROM ylHeader WHERE ID = (SELECT MAX(ID) FROM ylHeader);";
		$tblHeader = mysqli_query($conexao, $sltHeader);

		if (mysqli_num_rows($tblHeader) > 0) {
			while ($dtHeader = mysqli_fetch_assoc($tblHeader)) {
				$varHeader = $dtHeader['Frases'];
			}
		}
	?>
<!-- FIM FORMULARIO APRESENTACAO -->



<!-- FORMULARIO SOBRE -->
	<?php
		$sltSobre = "SELECT Frases FROM ylSobre";
		$tblFrases = mysqli_query($conexao, $sltSobre);

		if (mysqli_num_rows($tblFrases) > 0) {
			while ($dtFrases = mysqli_fetch_assoc($tblFrases)) {
				$arrSobre[] = $dtFrases['Frases'];
			}
		}
	?>

	<script>
		var arrSobre = [];
		<?php 
			foreach ($arrSobre as $arrSobre) { 
				?> arrSobre.push("<?php echo $arrSobre; ?>"); <?php
			} 
		?>
	</script>
<!-- FIM FORMULARIO SOBRE -->



<!-- FORMULARIO COMPETENCIAS -->
	<?php
		$sltCPT = "SELECT * FROM ylCompetencias ORDER BY ID";
		$tblCPT = mysqli_query($conexao, $sltCPT);
		$a = 0;

		while($dtCPT = mysqli_fetch_assoc($tblCPT)) {
			$crsCPT[] = '<div class="' . $dtCPT['Tipo'] . '"> <div class="crsContainer"> <div class="cpCaixa"> <div class="row cpform"> <div class="col align-self-center"> <span class="fa-stack fa-3x"> <i class="cpIcon fa fa-' . $dtCPT['Icone'] . ' fa-stack-1x"></i> </span> <h2 class="service-heading">' . $dtCPT['Titulo'] . '</h2> <p class="text-muted">' . $dtCPT['Texto'] . '</p> </div> </div> </div> </div> </div>';

			if ($a == 0) {
				$olCPT[] = '<li data-slide-to="' . $a++ . '" class="active"></li>';
			} else {
				$olCPT[] = '<li data-slide-to="' . $a++ . '"></li>';
			}
			
		}
	?>
<!-- FIM FORMULARIO COMPETENCIAS -->



<!-- FORMULARIO PORTFOLIO -->
	<?php
		$sltPTF = "SELECT * FROM ylPortfolio ORDER BY ID";
		$tblPTF = mysqli_query($conexao, $sltPTF);

		while($dtPTF = mysqli_fetch_assoc($tblPTF)) {
			$articlePTF[] = "<div class='row'><div class='col-md-4 col-sm-6 pItem'><a class='piLink'><div class='piHover'><div class='pihConteudo'><i class='fa fa-search fa-3x'></i></div></div><img class='img-fluid' src='" . $dtPTF['Imagem'] . "' alt='" . $dtPTF['Alt'] . "'></a><div class='piLegenda'><h4>" . $dtPTF['Titulo'] . "</h4><p class='text-muted'>" . $dtPTF['Subtitulo'] . "</p></div></div></div>";
		}
	?>
<!-- FIM FORMULARIO PORTFOLIO -->



