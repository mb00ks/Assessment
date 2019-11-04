<!DOCTYPE html>
<html lang="en">
  <head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <!-- The above 3 meta tags *must* come first in the head; any other head content must come *after* these tags -->
    <meta name="description" content="">
    <meta name="author" content="">
    <link rel="icon" href="../WEB-INF/lib/bootstrap-3.3.7/docs/favicon.ico">

    <title>Starter Template for Bootstrap</title>

    <!-- Bootstrap core CSS -->
    <link href="../WEB-INF/lib/bootstrap-3.3.7/docs/dist/css/bootstrap.css" rel="stylesheet">

    <!-- IE10 viewport hack for Surface/desktop Windows 8 bug -->
    <link href="../WEB-INF/lib/bootstrap-3.3.7/docs/assets/css/ie10-viewport-bug-workaround.css" rel="stylesheet">

    <!-- Custom styles for this template -->
    <link href="../WEB-INF/lib/bootstrap-3.3.7/docs/examples/starter-template/starter-template.css" rel="stylesheet">

    <!-- Just for debugging purposes. Don't actually copy these 2 lines! -->
    <!--[if lt IE 9]><script src="../../assets/js/ie8-responsive-file-warning.js"></script><![endif]-->
    <script src="../WEB-INF/lib/bootstrap-3.3.7/docs/assets/js/ie-emulation-modes-warning.js"></script>

    <!-- HTML5 shim and Respond.js for IE8 support of HTML5 elements and media queries -->
    <!--[if lt IE 9]>
      <script src="https://oss.maxcdn.com/html5shiv/3.7.3/html5shiv.min.js"></script>
      <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
    <![endif]-->
    
    <link href="../WEB-INF/css/gaya.css" rel="stylesheet">
    
  </head>

  <body class="detil">

    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <h3 class="judul-halaman"><img src="../WEB-INF/images/icon-main-menu.png"> Main Menu</h3>
                
                <div class="area-menu-launcher">
                    <div class="row">
                        <div class="col-md-5ths col-xs-6">
                            <div class="item">
                                    <a href="../ikk/index.php" target="mainFrameUtama">
                                    <div class="ikon"><img src="../WEB-INF/images/icon-penilaian-kompetensi.png"></div>
                                    <div class="teks">Penilaian Kompetensi</div>
                                </a>
                            </div>
                        </div>
                        <div class="col-md-5ths col-xs-6">
                            <div class="item">
                                    <a href="../silat/index.php" target="mainFrameUtama">
                                    <div class="ikon"><img src="../WEB-INF/images/icon-pengembangan-sdm.png"></div>
                                    <div class="teks">Rencana Diklat</div>
                                </a>
                            </div>
                        </div>
                        <!-- <div class="col-md-5ths col-xs-6">
                            <div class="item">
                                    <a href="../suksesi/index.php" target="mainFrameUtama">
                                    <div class="ikon"><img src="../WEB-INF/images/icon-rencana-suksesi.png"></div>
                                    <div class="teks">Rencana Suksesi</div>
                                </a>
                            </div>
                        </div>
                        <div class="col-md-5ths col-xs-6">
                            <div class="item">
                                    <a href="../pengaturan/index_absen.php" target="mainFrameUtama">
                                    <div class="ikon"><img src="../WEB-INF/images/icon-absen.png"></div>
                                    <div class="teks">Absen</div>
                                </a>
                            </div>
                        </div>
                        <div class="col-md-5ths col-xs-6">
                            <div class="item">
                                    <a href="../pengaturan/index_hasil_cat.php" target="mainFrameUtama">
                                    <div class="ikon"><img src="../WEB-INF/images/icon-hasil.png"></div>
                                    <div class="teks">Hasil</div>
                                </a>
                            </div>
                        </div> -->
                        <div class="col-md-5ths col-xs-6">
                            <div class="item">
                                    <a href="../pengaturan/index.php" target="mainFrameUtama">
                                    <div class="ikon"><img src="../WEB-INF/images/icon-pengaturan.png"></div>
                                    <div class="teks">Pengaturan</div>
                                </a>
                            </div>
                        </div>
                    </div>
                </div>
                
            </div>
        </div>
        
        <div class="row">
            <div class="col-md-7">
                <div class="area-menu-bawah-launcher">
                    <div class="item">
                        <a href="#">
                            <img src="../WEB-INF/images/icon-panduan-singkat.png"> Panduan singkat
                        </a>
                    </div>
                    <div class="item">
                        <a href="#">
                            <img src="../WEB-INF/images/icon-syarat-ketentuan.png"> Syarat &amp; ketentuan
                        </a>
                    </div>
                    <div class="item">
                        <a href="#">
                            <img src="../WEB-INF/images/icon-notifikasi.png"> Notifikasi
                        </a>
                    </div>
                </div>
            </div>
            <div class="col-md-5">
                <div class="area-live-date">
                    <div class="ikon"><img src="../WEB-INF/images/icon-live-clock.png"></div>
                    <div class='time-frame'>
                        <div id='time-part'></div>
                        <div id='date-part'></div>
                    </div>
                </div>
            </div>
        </div>
        
      <?php /*?><div class="info-home text-center">
        <div class="inner">
            <div class="logo"><img src="../WEB-INF/images/logo.png"></div>
            <!--<p class="lead">MAJU MELANGKAH, AYO BERBENAH.</p>-->
        </div>
        
      </div><?php */?>

    </div><!-- /.container -->


    <!-- Bootstrap core JavaScript
    ================================================== -->
    <!-- Placed at the end of the document so the pages load faster -->
    <!--<script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>-->
    <script src="../WEB-INF/lib/bootstrap-3.3.7/js/jquery.min.js"></script>
    <script>window.jQuery || document.write('<script src="../../assets/js/vendor/jquery.min.js"><\/script>')</script>
    <script src="../WEB-INF/lib/bootstrap-3.3.7/docs/dist/js/bootstrap.min.js"></script>
    <!-- IE10 viewport hack for Surface/desktop Windows 8 bug -->
    <script src="../WEB-INF/lib/bootstrap-3.3.7/docs/assets/js/ie10-viewport-bug-workaround.js"></script>
    
    <script type="text/javascript" src="../WEB-INF/js/moment.js"></script>
    <script>
    $(document).ready(function() {
        var interval = setInterval(function() {
            var momentNow = moment();
            $('#date-part').html(momentNow.format('YYYY MMMM DD') + ' '
                                + momentNow.format('dddd')
                                 .substring(0,3).toUpperCase());
            $('#time-part').html(momentNow.format('hh:mm:ss A'));
        }, 100);
        
        $('#stop-interval').on('click', function() {
            clearInterval(interval);
        });
    });
    </script>
    
  </body>
</html>
