
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01//EN" "http://www.w3.org/TR/html4/strict.dtd">
<html lang="en"><head><title>SIDAK - Kota Probolinggo</title>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
<link rel="stylesheet" href="../WEB-INF/css/gaya-anjungan.css" type="text/css">
<meta content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no" name="viewport">



<!-- PAGE LOADING EFFECT -->
<!--<link rel="stylesheet" type="text/css" href="../WEB-INF/lib/PageLoadingEffects/css/normalize.css" />
<link rel="stylesheet" type="text/css" href="../WEB-INF/lib/PageLoadingEffects/css/demo.css" />-->
<link rel="stylesheet" type="text/css" href="../WEB-INF/lib/PageLoadingEffects/css/component.css" />
<script src="../WEB-INF/lib/PageLoadingEffects/js/snap.svg-min.js"></script>



<script src="../WEB-INF/lib/checkTree/jquery-1.2.6.min.js" type="text/javascript"></script>


</head>
<body <?php /*?>onLoad="goforit()"<?php */?> style="overflow:hidden;">
<div id="header">
	
    
    <div id="pagewrap" class="pagewrap">
        <div class="container show" id="page-1">
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
                  </ul>
                </nav>
                
            </section>
        </div>
        <!-- /container -->

        <!-- The new page dummy; this would be dynamically loaded content -->
        <div class="container" id="page-2">
            <section>
                &nbsp;
            </section>
        </div>
        <!-- /container -->

        <div id="loader" class="pageload-overlay" data-opening="M 0,0 c 0,0 63.5,-16.5 80,0 16.5,16.5 0,60 0,60 L 0,60 Z">
            <svg xmlns="http://www.w3.org/2000/svg" width="100%" height="100%" viewBox="0 0 80 60" preserveAspectRatio="none">
                <path d="M 0,0 c 0,0 -16.5,43.5 0,60 16.5,16.5 80,0 80,0 L 0,60 Z"/>
            </svg>
        </div>
        <!-- /pageload-overlay -->
        
    </div><!-- /pagewrap -->
    
    
	
</div>

<!-- PAGE LOADING EFFECT -->
<script src="../WEB-INF/lib/PageLoadingEffects/js/classie.js"></script>
<script src="../WEB-INF/lib/PageLoadingEffects/js/svgLoader.js"></script>
<script>
	(function() {
		var pageWrap = document.getElementById( 'pagewrap' ),
			pages = [].slice.call( pageWrap.querySelectorAll( 'div.container' ) ),
			currentPage = 0,
			triggerLoading = [].slice.call( pageWrap.querySelectorAll( 'a.pageload-link' ) ),
			loader = new SVGLoader( document.getElementById( 'loader' ), { speedIn : 400, easingIn : mina.easeinout } );

		function init() {
			triggerLoading.forEach( function( trigger ) {
				
				trigger.addEventListener( 'click', function( ev ) {
					$("#currentMenu").val($(this).attr("title"));
					ev.preventDefault();
					loader.show();
					// after some time hide loader
					setTimeout( function() {
						loader.hide();

						classie.removeClass( pages[ currentPage ], 'show' );
						// update..
						currentPage = currentPage ? 0 : 1;
						classie.addClass( pages[ currentPage ], 'show' );
						var currentMenu = $("#currentMenu").val();
						
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

        

</body>
</html>