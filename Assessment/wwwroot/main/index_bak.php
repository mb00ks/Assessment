<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>Aplikasi Pelaporan Hasil Assesment</title>

<!-- BOOTSTRAP -->
<meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1">
<link href="../WEB-INF/lib/bootstrap/bootstrap.css" rel="stylesheet">
<link rel="stylesheet" href="../WEB-INF/css/gaya-main.css" type="text/css">
<link rel="stylesheet" href="../WEB-INF/lib/Font-Awesome-4.5.0/css/font-awesome.css">
    
<!--<script type='text/javascript' src="../WEB-INF/lib/bootstrap/jquery.js"></script> -->

    <style>
	.col-md-12{
		*padding-left:0px;
		*padding-right:0px;
	}
	</style>
    
    <script src="../WEB-INF/lib/emodal/eModal.js"></script>
    <script>
	function openPopup() {
		//document.getElementById("demo").innerHTML = "Hello World";
		//alert('hhh');
		// Display a ajax modal, with a title
		eModal.ajax('konten.html', 'Judul Popup')
		//  .then(ajaxOnLoadCallback);
	}

	

	</script>
    
    <!-- FLUSH FOOTER -->
    <style>
	html, body {
		height: 100%;
	}
	
	#wrap-utama {
		min-height: 100%;
		*min-height: calc(100% - 10px);
	}
	
	#main {
		overflow:auto;
		padding-bottom:50px; /* this needs to be bigger than footer height*/
	}
	
	.footer {
		position: relative;
		margin-top: -50px; /* negative value of footer height */
		height: 50px;
		clear:both;
		padding-top:20px;
		*background:cyan;
		
		text-align:center;
		color:#FFF;
	} 
	</style>
    
</head>

<body>

<div id="wrap-utama" style="height:100%; ">
    <div id="main" class="container-fluid clear-top" style="height:100%;">
		
        <div class="row">
        	<div class="col-md-12">
            	<div class="area-header">
                	<span class="judul-app">Aplikasi Pelaporan Hasil Assessment</span>
                </div>
            </div>
        </div>
        
        <div class="row" style="height:calc(100% - 20px);">
        	<div class="col-md-12" style="height:100%;">
            	<div class="judul-halaman">Main Menu</div>
                
                <div id="pagewrap" class="pagewrap">
		
                    <div class="container show" id="page-1">
                    	
                        <div class="row">
                            <div class="col-md-5ths col-xs-6">
                                <div class="area-main-menu">
                                    <div class="item">
                                        <a class="pageload-link" href="#page-2" title="1">
                                        <div class="icon"><i class="fa fa-pencil-square-o fa-3x"></i></div>
                                        <div class="teks">Penilaian<br>Kompetensi</div>
                                        </a>
                                        <a class="pageload-link" href="#page-2" title="2">Show Page Loader</a>
                                    </div>
                                </div>
                            </div>
						</div>
                        
                    </div><!-- /container -->
                    
                    <?php /*?><div class="container show" id="page-1">
                        <!-- Top Navigation -->
                        <section class="columns clearfix">
                            
                            <nav class="left" style="position: fixed; top: 70px;">
                              <ul>
                                <li>
                                  <a class="pageload-link"  href="#" title="1">Regulasi</a>
                                </li>
                                <li>
                                  <a class="pageload-link"  href="#" title="2">Kebijakan Pemerintah</a>
                                </li>
                                <li>
                                  <a class="pageload-link"  href="#" title="3">TKPK</a>
                                </li>
                                <li>
                                  <a class="pageload-link"  href="#" title="4">Program/Kegiatan</a>
                                </li>
                                <li>
                                  <a class="pageload-link"  href="#" title="5">Data Sasaran</a>
                                </li>
                                <li>
                                  <a class="pageload-link"  href="#" title="6">Mekanisme Permintaan Data</a>
                                </li>
                                <li>
                                  <a class="pageload-link"  href="#" title="7">Indikator Kemiskinan</a>
                                </li>
                                <li>
                                	<a class="pageload-link" href="#page-2">Show Page Loader</a>
                                </li>
                              </ul>
                            </nav>
                            
                        </section>
                        
                    </div><?php */?>
                    <!-- /container -->
        
                    <!-- The new page dummy; this would be dynamically loaded content -->
                    <div class="container-login" id="page-2">
                        <section>
                            &nbsp;
                        </section>
                    </div>
                    <!-- /container -->
                    
                    <div id="loader" class="pageload-overlay" data-opening="M20,15 50,30 50,30 30,30 Z;M0,0 80,0 50,30 20,45 Z;M0,0 80,0 60,45 0,60 Z;M0,0 80,0 80,60 0,60 Z" data-closing="M0,0 80,0 60,45 0,60 Z;M0,0 80,0 50,30 20,45 Z;M20,15 50,30 50,30 30,30 Z;M30,30 50,30 50,30 30,30 Z">
                        <svg xmlns="http://www.w3.org/2000/svg" width="100%" height="100%" viewBox="0 0 80 60" preserveAspectRatio="none">
                            <path d="M30,30 50,30 50,30 30,30 Z"/>
                        </svg>
                    </div><!-- /pageload-overlay -->
                    
                </div><!-- /pagewrap -->
				
                
                <!--------------------------------------------------------------------------------------------------------------------------------->
                                
                <?php /*?><div class="container">
                	<div class="row">
                        <div class="col-md-5ths col-xs-6">
                            <div class="area-main-menu">
                                <div class="item">
                                	<a href="#">
                                    <div class="icon"><i class="fa fa-pencil-square-o fa-3x"></i></div>
                                    <div class="teks">Penilaian<br>Kompetensi</div>
                                    </a>
                                </div>
                            </div>
                        </div>
                        
                        <div class="col-md-5ths col-xs-6">
                            <div class="area-main-menu">
                                <div class="item">
                                	<a href="#">
                                    <div class="icon"><i class="fa fa-user fa-3x"></i></div>
                                    <div class="teks">Pengembangan<br>SDM</div>
                                    </a>
                                </div>
                            </div>
                        </div>
                        
                        <div class="col-md-5ths col-xs-6">
                            <div class="area-main-menu">
                                <div class="item">
                                	<a href="#">
                                    <div class="icon"><i class="fa fa-clipboard fa-3x"></i></div>
                                    <div class="teks">Pola Karir</div>
                                    </a>
                                </div>
                            </div>
                        </div>
                        
                        <div class="col-md-5ths col-xs-6">
                            <div class="area-main-menu">
                                <div class="item">
                                	<a href="#">
                                    <div class="icon"><i class="fa fa-cog fa-3x"></i></div>
                                    <div class="teks">Pengaturan</div>
                                    </a>
                                </div>
                            </div>
                        </div>
                        
                        <div class="col-md-5ths col-xs-6">
                            <div class="area-main-menu">
                                <div class="item">
                                	<a href="#">
                                    <div class="icon"><i class="fa fa-users fa-3x"></i></div>
                                    <div class="teks">Rencana<br>Suksesi</div>
                                    </a>
                                </div>
                            </div>
                        </div>
                        
                        <div class="col-md-5ths col-xs-6">
                            <div class="area-main-menu">
                                <div class="item">
                                	<a href="#">
                                    <div class="icon"><i class="fa fa-plus fa-3x"></i></div>
                                    <div class="teks">tambah menu<br>...</div>
                                    </a>
                                </div>
                            </div>
                        </div>
                        
                        
                    </div>
                </div><?php */?>
                
            </div>
		</div>
        
        
        
    </div>
</div>
<footer class="footer">
	 © 2016 Kementerian Dalam Negeri. All Rights Reserved. 
</footer>



    
<?php /*?>    <div class="container-fluid">
	
	
	<div class="row">
		<div class="col-md-12">
			<div class="area-footer">
			© 2016 Kementerian Dalam Negeri. All Rights Reserved. 
			</div>
		</div>
	</div>
	
</div>
<!-- /.container --> <?php */?>

<?php /*?><script type='text/javascript' src="../WEB-INF/lib/bootstrap/bootstrap.js"></script> <?php */?>
<script type='text/javascript' src="../WEB-INF/lib/bootstrap/angular.js"></script> 
<script type='text/javascript' src="../WEB-INF/lib/js/jquery.min.js"></script> 

<!-- PAGE LOADING EFFECT -->
<link rel="stylesheet" type="text/css" href="../WEB-INF/lib/PageLoadingEffects/css/component.css" />
<script src="../WEB-INF/lib/PageLoadingEffects/js/snap.svg-min.js"></script>

<script src="../WEB-INF/lib/PageLoadingEffects/js/classie.js"></script>
                <script src="../WEB-INF/lib/PageLoadingEffects/js/svgLoader.js"></script>
                <script>
                    /*(function() {
                        var pageWrap = document.getElementById( 'pagewrap' ),
                            pages = [].slice.call( pageWrap.querySelectorAll( 'div.container' ) ),
                            currentPage = 0,
                            triggerLoading = [].slice.call( pageWrap.querySelectorAll( 'a.pageload-link' ) ),
                            loader = new SVGLoader( document.getElementById( 'loader' ), { speedIn : 100 } );
        
                        function init() {
                            triggerLoading.forEach( function( trigger ) {
                                trigger.addEventListener( 'click', function( ev ) {
                                    ev.preventDefault();
                                    loader.show();
                                    // after some time hide loader
                                    setTimeout( function() {
                                        loader.hide();
        
                                        classie.removeClass( pages[ currentPage ], 'show' );
                                        // update..
                                        currentPage = currentPage ? 0 : 1;
                                        classie.addClass( pages[ currentPage ], 'show' );
        
                                    }, 2000 );
                                } );
                            } );	
                        }
        
                        init();
                    })();*/
                </script>
                
                <script>
					(function() {
						var pageWrap = document.getElementById( 'pagewrap' ),
							pages = [].slice.call( pageWrap.querySelectorAll( 'div.container' ) ),
							currentPage = 0,
							triggerLoading = [].slice.call( pageWrap.querySelectorAll( 'a.pageload-link' ) ),
							loader = new SVGLoader( document.getElementById( 'loader' ), { speedIn : 100, easingIn : mina.easeinout } );
				
						function init() {
							triggerLoading.forEach( function( trigger ) {
								
								trigger.addEventListener( 'click', function( ev ) {
									//alert("hai"+$(this).attr("title"));return false;
									$("#currentMenu").val($(this).attr("title"));
									ev.preventDefault();
									loader.show();
									alert("jos1");
									// after some time hide loader
									setTimeout( function() {
										loader.hide();
										//alert("jos2");
										classie.removeClass( pages[ currentPage ], 'show' );
										// update..
										currentPage = currentPage ? 0 : 1;
										alert("jos2");
										classie.addClass( pages[ currentPage ], 'show' );
										
										
										var currentMenu = $("#currentMenu").val();
										alert("jos3");
										
										if(currentMenu == 1)
											document.location.href = "?pg=regulasi";
										else if(currentMenu == 2)
											document.location.href = "?pg=kebijakan_pemerintah";
										else if(currentMenu == 3)
											document.location.href = "?pg=tkpk";
										else if(currentMenu == 4)
											document.location.href = "?pg=program_kegiatan";
										else if(currentMenu == 5)
											document.location.href = "?pg=data_sasaran";
										else if(currentMenu == 6)
											document.location.href = "?pg=mekanisme_permintaan_data";
										else if(currentMenu == 7)
											document.location.href = "?pg=indikator_kemiskinan";
										
									}, 2000 );
								} );
							} );	
						}
				
						init();
					})();
				</script>

<input type="hidden" id="currentMenu" value="">
    
</body>
</html>
