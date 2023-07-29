<section id="contato" class="contato">
	<article class="gMaps" id="google_map" data-map-x="-22.5183621" data-map-y="-48.7227379" data-pin="img/gMaps/Pin.png" data-scrollwhell="0" data-draggable="1"></article>

	<article class="cCaixa">
		<form class="cForm" action="php/Utilitarios/Email.php" method="post">
			<div class="cfInput">
				<input class="iptInfos" type="text" name="nome" placeholder="Digite seu nome" required>
			</div>

			<div class="cfInput">
				<input class="iptInfos" type="text" name="email" placeholder="Digite seu email" required>
			</div>

			<div class="cfInput">
				<input class="iptInfos" type="text" name="telefone" placeholder="Digite seu telefone/celular" required>
			</div>

			<div class="cfInput">
				<textarea class="iptInfos" name="mensagem" placeholder="Digite sua mensagem..." required></textarea>
			</div>

			<div class="cxButton">
				<button class="cfButton">
					<span>
						Submit
						<i class="fa fa-long-arrow-right m-l-7" aria-hidden="true"></i>
					</span>
				</button>
			</div>
		</form>
	</article>
</section>