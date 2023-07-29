<section id="competencias" class="competencias">
	<div id="carouselExampleIndicators" class="carousel slide carousel-fade" data-ride="carousel">
		<ol class="carousel-indicators">
			<?php
				foreach ($olCPT as $olCPT) {
					echo $olCPT;
				}
			?>
		</ol>

		<div class="carousel-inner">
			<?php 
				foreach ($crsCPT as $crsCPT) {
					echo $crsCPT;
				}
			?>
		</div>
		<a class="carousel-control-prev" href="#carouselExampleIndicators" role="button" data-slide="prev">
			<span class="carousel-control-prev-icon" aria-hidden="true"></span>
			<span class="sr-only">Previous</span>
		</a>
		<a class="carousel-control-next" href="#carouselExampleIndicators" role="button" data-slide="next">
			<span class="carousel-control-next-icon" aria-hidden="true"></span>
			<span class="sr-only">Next</span>
		</a>
	</div>
</section>







