<section id="portfolio" class="portfolio">
	<article class="container">
		<div class="row">
			<div class="col-lg-12 text-center">
				<h2 class="pTitle text-uppercase ylTitle">Portfolio</h2>
				<h3 class="pCaption ylCaption">Segue abaixo alguns dos meus trabalhos.</h3>
			</div>
		</div>
	</article>

	<article class="container">
		<?php 
			foreach ($articlePTF as $articlePTF) {
				echo $articlePTF;
			}
		?>
	</article>

	<article>
		<div id="pModal" class="pModal">
			<span class="pClose">&times;</span>
			<img id="imgZoom" class="pmConteudo">
			<div id="mdlCaption"></div>
		</div>
	</article>
</section>