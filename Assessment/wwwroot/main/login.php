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
			header("location:../asesor/index.php");
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

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>Aplikasi Pelaporan Hasil Assessment</title>

<!-- BOOTSTRAP -->
<meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1">
<link href="../WEB-INF/lib/bootstrap/bootstrap.css" rel="stylesheet">
<link rel="stylesheet" href="../WEB-INF/css/gaya-main.css" type="text/css">
<link rel="stylesheet" href="../WEB-INF/lib/font-awesome/4.5.0/css/font-awesome.css">
    
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
                	<span class="judul-app" style="color:black;"><img src="../WEB-INF/images/logo_login.png" width="200px" > &nbsp Aplikasi Pelaporan Hasil Assessment</span>
                </div>
            </div>
        </div>
        
        <div class="row" style="height:calc(100% - 20px);">
        	<div class="col-md-12" style="height:100%;">
        		<div class="row" style="height:100%;">
		        	<div class="col-md-6" style="height:100%;">
                		<div class="row">
                            <div class="col-xs-12 col-sm-8 col-md-6 col-sm-offset-2 col-md-offset-3 area-login">
                            
                                <form role="form" method="post" action="">
                                    <fieldset>
                                        <!--<h2>Please Sign In</h2>
                                        <hr class="colorgraph">-->
                                        <div class="form-group">
                                            <input type="text" name="reqUser" id="reqUser" class="form-control input-lg" placeholder="Username">
                                        </div>
                                        <div class="form-group">
                                            <input type="password" name="reqPasswd" id="reqPasswd" class="form-control input-lg" placeholder="Password">
                                        </div>
                                        <!--<span class="button-checkbox">
                                            <button type="button" class="btn" data-color="info">Remember Me</button>
                                            <input type="checkbox" name="remember_me" id="remember_me" checked="checked" class="hidden">
                                            <a href="" class="btn btn-link pull-right">Forgot Password?</a>
                                        </span>-->
                                        <!--<hr class="colorgraph">-->
                                        <div class="row">
                                            <div class="col-xs-6 col-sm-6 col-md-6">
                                                <input name="slogin_POST_send" type="submit" class="btn btn-lg btn-success btn-block" value="Login" alt="DO LOGIN!" >
                                                <input type="hidden" name="reqMode" value="submitLogin">
                                            </div>
                                            <div class="col-xs-6 col-sm-6 col-md-6">
                                            	<input type="reset" class="btn btn-lg btn-warning btn-block" value="Reset">
                                                <!--<a href="" class="btn btn-lg btn-primary btn-block">Register</a>-->
                                            </div>
                                        </div>
                                    </fieldset>
                                </form>
                            </div>
                        </div>
                        
                    </div>
                    <div class="col-md-6">
                		<div class="row">
                            <div class="col-md-12 area-logo-login">
                            	<img src="../WEB-INF/images/logo_login.png" width="550px" >
                            </div>
						</div>
                    </div>
                </div>
            </div>
		</div>
        
        
        
    </div>
</div>
<footer class="footer" style="color:black;">
	 © 2019 PT Pelabuhan Indonesia III. All Rights Reserved.
</footer>
    
<script type='text/javascript' src="../WEB-INF/lib/bootstrap/bootstrap.js"></script> 
<script type='text/javascript' src="../WEB-INF/lib/bootstrap/angular.js"></script> 
    
</body>
</html>
