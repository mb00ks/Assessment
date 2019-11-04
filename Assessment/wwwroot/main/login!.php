<?
include_once("../WEB-INF/page_config.php");
include_once("../WEB-INF/functions/default.func.php");
include_once("../WEB-INF/classes/utils/UserLogin.php");

/* PARAMETERS */
$pg = httpFilterRequest("pg");
$menu = httpFilterRequest("menu");
$reqMode = httpFilterRequest("reqMode");
$reqUser = httpFilterPost("reqUser");
$reqPasswd = httpFilterPost("reqPasswd");
/* ACTIONS BY reqMode */
if($reqMode == "submitLogin" && $reqUser != "" && $reqPasswd != "") 
{
	$userLogin->resetLogin();
	if ($userLogin->verifyUserLogin($reqUser, $reqPasswd)) 
	{	
		if($userLogin->userPegawaiId=="")
		{	
			header("location:index.php");
		}
		else
		{
			header("location:pegawai.php");
		}
		exit;			
	}
	else
	{
		echo '<script language="javascript">';
		echo 'alert("Username atau password anda masih salah.");';
		echo 'top.location.href = "login.php";';
		echo '</script>';		
		exit;		
	}
}
else if ($reqMode == "submitLogout")
{
	$userLogin->resetLogin();
	$userLogin->emptyUsrSessions();
}
?>

<!doctype html>
<html>
<head>
<meta charset="utf-8">
<title>Aplikasi Pelaporan Hasil Assessment</title>

<link rel="stylesheet" type="text/css" href="../WEB-INF/css/gaya.css">
</head>

<body style="overflow-x:hidden;">

<div id="main-header">
	<div id="main-logo"><img src="../WEB-INF/images/logo.png"></div>
    <div id="main-judul">
    	<strong>KEMENTERIAN DALAM NEGERI REPUBLIK INDONESIA</strong><br>
        The Interior Ministry of The Republic of Indonesia
    </div>
        


    
</div>
<div id="main-kontainer">
	<div id="login-area">
    	<!--<div class="judul">LOGIN AREA</div>-->
        <div class="judul"><img src="../WEB-INF/images/foto.png" height="150"></div>
    	<form method="post" action="">
            <input name="reqUser" type="text" id="reqUser" />
            <input name="reqPasswd" type="password" id="reqPasswd" />
            <input name="slogin_POST_send" type="submit" value="LOGIN" alt="DO LOGIN!" class="bg-button" />
            <input type="hidden" name="reqMode" value="submitLogin"></span>
            
        </form>
        
        <div class="alamat">
        
        <strong>KEMENTERIAN DALAM NEGERI</strong><br><br>
        
        <strong>Biro Kepegawaian</strong><br>
        <strong>Kementerian Dalam Negeri</strong><br>
        
        Jl. Medan Merdeka Utara No. 7<br>
        Jakarta Pusat 10110<br><br>
        
        Telp. (021) 3450038<br>
        Fax. (021) 3851193<br><br>
        
        Email: pusdatin@kemendagri.go.id<br>
        Homepage: www.kemendagri.go.id
        </div>
	</div>
    
    <div id="logo-login-area">
    	<img src="../WEB-INF/images/logo-login.png">
    </div>
        
</div>
<div id="main-footer">
	&copy; 2016 Kementerian Dalam Negeri. All Rights Reserved.
</div>
</body>

</html>
