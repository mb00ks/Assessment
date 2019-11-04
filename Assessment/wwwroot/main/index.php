
<?
include_once("../WEB-INF/classes/utils/UserLogin.php");
include_once("../WEB-INF/page_config.php");
include_once("../WEB-INF/functions/default.func.php");
include_once("../WEB-INF/functions/string.func.php");

// LOGIN CHECK 
if ($userLogin->checkUserLogin()) 
{ 
    $userLogin->retrieveUserInfo();  
}

$pg = httpFilterRequest("pg");
$menu = httpFilterRequest("menu");

$tempListInfo= $userLogin->userTempList;
?>

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

    <title>Aplikasi Pelaporan Hasil Assesment</title>

    <!-- Bootstrap core CSS -->
    <link href="../WEB-INF/lib/bootstrap-3.3.7/docs/dist/css/bootstrap.css" rel="stylesheet">

    <!-- IE10 viewport hack for Surface/desktop Windows 8 bug -->
    <link href="../WEB-INF/lib/bootstrap-3.3.7/docs/assets/css/ie10-viewport-bug-workaround.css" rel="stylesheet">

    <!-- Custom styles for this template -->
    <link href="../WEB-INF/lib/bootstrap-3.3.7/docs/examples/dashboard/dashboard.css" rel="stylesheet">

    <!-- Just for debugging purposes. Don't actually copy these 2 lines! -->
    <!--[if lt IE 9]><script src="../../assets/js/ie8-responsive-file-warning.js"></script><![endif]-->
    <script src="../WEB-INF/lib/bootstrap-3.3.7/docs/assets/js/ie-emulation-modes-warning.js"></script>

    <!-- HTML5 shim and Respond.js for IE8 support of HTML5 elements and media queries -->
    <!--[if lt IE 9]>
      <script src="https://oss.maxcdn.com/html5shiv/3.7.3/html5shiv.min.js"></script>
      <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
    <![endif]-->
    
    <link href="../WEB-INF/css/gaya.css" rel="stylesheet">
    
<!--     <script src="//cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
 -->
    <script src="../WEB-INF/lib/js/jquery/3.2.1/jquery.min.js"></script>
<!-- 
     <script src="//cdn.rawgit.com/saribe/eModal/1.2.67/dist/eModal.min.js"></script>
    <script type="application/javascript" >
    function openPopup(page) {
        //alert("hhhhh");
        //eModal.alert('You shall not pass!');
        //eModal.iframe();
        // eModal.iframe('pegawai_edit.php', 'SIMPEG KOTA MOJOKERTO')
        eModal.iframe(page, 'Tes')
    }
    </script> -->
    
    
  </head>

  <body class="index">

    <nav class="navbar navbar-inverse navbar-fixed-top">
      <div class="container-fluid">
        <div class="navbar-header">
          <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#navbar" aria-expanded="false" aria-controls="navbar">
            <span class="sr-only">Toggle navigation</span>
            <span class="icon-bar"></span>
            <span class="icon-bar"></span>
            <span class="icon-bar"></span>
          </button>
          <a class="navbar-brand" href="index.php"><img src="../WEB-INF/images/logo.png"></a>
        </div>
        <div id="navbar" class="navbar-collapse collapse">
            <ul class="nav navbar-nav navbar-right">
                
              
                
                <li class="dropdown" style="display: none;">
                    <a href="#"><i class="glyphicon glyphicon-envelope"></i> <span class="badge">3</span></a>
                    <ul class="dropdown-menu dropdown-pesan">
                        <li><a href="#"><span class="label label-primary">20/06/2019</span> Lorem ipsum dolor sit amet</a></li>
                        <li><a href="#"><span class="label label-primary">18/06/2019</span> Sed do eiusmod tempor incididunt ut labore</a></li>
                        <li><a href="#"><span class="label label-primary">17/06/2019</span> Quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat</a></li>
                        <li><a href="#"><span class="label label-warning"><i class="glyphicon glyphicon-alert"></i></span> Tidak ada pesan</a></li>
                    </ul>
                </li>  
                <li class="dropdown" style="display: none;">
                    <a href="#"><i class="glyphicon glyphicon-bell"></i> <span class="badge">42</span></a>
                    <ul class="dropdown-menu dropdown-pesan">
                        <li><a href="#"><span class="label label-primary">20/06/2019</span> Lorem ipsum dolor sit amet</a></li>
                        <li><a href="#"><span class="label label-primary">18/06/2019</span> Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua</a></li>
                        <li><a href="#"><span class="label label-primary">17/06/2019</span> quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat</a></li>
                        <li><a href="#"><span class="label label-warning"><i class="glyphicon glyphicon-alert"></i></span> Tidak ada notifikasi</a></li>
                    </ul>
                </li>
                <li class="dropdown">
                    <a href="#" class="dropdown-toggle" data-toggle="dropdown"><i class="glyphicon glyphicon-user"></i>                     Selamat datang, <strong><?=$userLogin->nama?></strong> (<?=$userLogin->userGroupNama?>) - 
                     <span class="caret"></span></a>
                     <ul class="dropdown-menu">
                        <li><a href="#">Ubah Password</a></li>
                        <li><a href="login.php?reqMode=submitLogout">Logout</a></li>
                    </ul>
                </li>
            </ul>
          
        </div>
      </div>
    </nav>

    <div class="container-fluid">
      <div class="row">
        <div class="col-sm-3 col-md-2 sidebar">
            <div class="area-profil-sidebar">
                <div class="foto"><img src="../WEB-INF/images/icon-profil.png"></div>
                <div class="nama"><?=$userLogin->nama?></div>
                <div class="nik">570890 0002</div>
                <div class="jabatan">Staff Komunikasi &amp; Informasi</div>
            </div>
            
            <!--<div id="cssmenu">
                <ul>
                    <li><a href="home.php" target="mainFrame">Home</a></li>
                    <li class="has-sub"><a href="#">Pegawai</a>
                      <ul>
                         <li><a href="pegawai.php" target="mainFrame">Data Pegawai</a></li>
                         <li><a href="duk.php" target="mainFrame">DUK</a></li>
                      </ul>
                    </li>
                    <li class="has-sub"><a href="#">Coba 2</a>
                      <ul>
                         <li><a href="#" target="mainFrame">Coba 2.1</a></li>
                         <li><a href="#" target="mainFrame">Coba 2.2</a></li>
                      </ul>
                    </li>
                </ul>
            </div>   -->       
            
        </div>
        <div class="col-sm-9 col-sm-offset-3 col-md-10 col-md-offset-2 main">
            <iframe src="home.php" name="mainFrameUtama"></iframe>
        </div>
      </div>
    </div>

    <!-- Bootstrap core JavaScript
    ================================================== -->
    <!-- Placed at the end of the document so the pages load faster -->
<!--     <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
 -->        <script src="../WEB-INF/lib/js/jquery/1.12.4/jquery.min.js"></script>

    <script>window.jQuery || document.write('<script src="../../assets/js/vendor/jquery.min.js"><\/script>')</script>
    <script src="../WEB-INF/lib/bootstrap-3.3.7/docs/dist/js/bootstrap.min.js"></script>
    <!-- Just to make our placeholder images work. Don't actually copy the next line! -->
    <script src="../WEB-INF/lib/bootstrap-3.3.7/docs/assets/js/vendor/holder.min.js"></script>
    <!-- IE10 viewport hack for Surface/desktop Windows 8 bug -->
    <script src="../WEB-INF/lib/bootstrap-3.3.7/docs/assets/js/ie10-viewport-bug-workaround.js"></script>
    
    <!-- CSS MENU -->
    <link rel="stylesheet" href="../WEB-INF/lib/cssmenu/styles.css">
    <!-- <script src="http://code.jquery.com/jquery-latest.min.js" type="text/javascript"></script>-->
    <script src="../WEB-INF/lib/cssmenu/script.js"></script>
    
    <script type="text/javascript">
    //$(document).ready(function(){
//      function openPopup() {
//          alert("index");
//          //eModal.iframe(page, 'SIMPEG KOTA MOJOKERTO')
//      }   
//  });
    
    </script>
    
    <?php /*?><script src="../WEB-INF/lib/eModal-master/dist/eModal.js"></script>
    <script type="application/javascript" >
    function openPopup(page) {
            alert("index");
            eModal.iframe(page, 'SIMPEG KOTA MOJOKERTO')
        }   
    </script><?php */?>
    
<!--     <script src="//cdn.rawgit.com/saribe/eModal/1.2.67/dist/eModal.min.js"></script>
 -->
  <script src="../WEB-INF/lib/js/eModal.min.js"></script>
   
  <script type="application/javascript" >
    function openPopup(page) {
        //alert("hhhhh");
        //eModal.alert('You shall not pass!');
        //eModal.iframe();
        // eModal.iframe('pegawai_edit.php', 'SIMPEG KOTA MOJOKERTO')
        eModal.iframe(page, 'PELINDO III')
    }
    </script>
    
  </body>
</html>
