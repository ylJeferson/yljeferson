<?php 
	include_once('php/Database/Database.php');
	include_once('php/Database/Select.php');
?>

<!DOCTYPE html>
<html lang="pt-br">
	<head>

		<title>Jeferson Hugo</title>

		<meta charset="UTF-8">
		<meta name="author" content="Jeferson Hugo">
		<meta name="description" content="Aprendendo HTML5, CSS3">
		<meta name="keywords" content="sites, web, código, html, css">
		<meta http-equiv="content-language" content="pt-br">
		<meta http-equiv="Cache-Control" content="no-store">
		<meta name="viewport" content="width=device-width">
		<!-- <meta http-equiv="refresh" content=" 0 ;url=http://www.google.com/"> -->
		
		<script async src="//pagead2.googlesyndication.com/pagead/js/adsbygoogle.js"></script>
		<script>
		  (adsbygoogle = window.adsbygoogle || []).push({
		    google_ad_client: "ca-pub-3709503415543066",
		    enable_page_level_ads: true
		  });
		</script>

		<?php include_once('php/Utilitarios/Links.php'); ?>
	</head>

	<body>
	
		<?php include_once('php/Nav/Linha.php') ?>
		<!-- <?php include_once('php/Nav/Circular.php') ?> -->
		<?php include_once('php/Header/Apresentacao.php') ?>
		<?php include_once('php/Section/Competencias.php') ?>
		<?php include_once('php/Section/Portfolio.php') ?>
		<?php include_once('php/Section/Sobre.php') ?>
		<?php include_once('php/Section/Contato.php') ?>
		
		<?php include_once('php/Utilitarios/Scripts.php'); ?>
	</body>
</html>