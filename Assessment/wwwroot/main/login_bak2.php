<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>Aplikasi Pelaporan Hasil Assesment</title>

<!-- BOOTSTRAP -->
<meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1">
<link href="../WEB-INF/lib/bootstrap/bootstrap.css" rel="stylesheet">
<link rel="stylesheet" href="../WEB-INF/css/gaya-main.css" type="text/css">
<link rel="stylesheet" href="../WEB-INF/lib/font-awesome/4.5.0/css/font-awesome.css">
    
<!--<script type='text/javascript' src="../WEB-INF/lib/bootstrap/jquery.js"></script> -->

    <style>
	.col-md-12{
		padding-left:0px;
		padding-right:0px;
	}
	</style>
    
    <script src="../WEB-INF/lib/emodal/eModal.js"></script>
    <script>
	function openPopup() {
		//document.getElementById("demo").innerHTML = "Hello World";
		//alert('hhh');
		//Display a ajax modal, with a title
		eModal.ajax('konten.html', 'Judul Popup')
		//.then(ajaxOnLoadCallback);
	}
	
	</script>
    

</head>

<body class="pjbs-map-dashboard">
    
    <div class="container-fluid">
    	
        <div class="row">
        	<div class="col-md-12">
            	<div class="area-header">
                	<span class="judul-app">Aplikasi Pelaporan Hasil Assessment</span>
                </div>
            </div>
        </div>
        
        <div class="row">
        	<div class="col-md-12 area-main">
        		<div class="row">
		        	<div class="col-md-6">
                		<div class="row">
                            <div class="col-xs-12 col-sm-8 col-md-6 col-sm-offset-2 col-md-offset-3">
                                <form role="form">
                                    <fieldset>
                                        <h2>Please Sign In</h2>
                                        <hr class="colorgraph">
                                        <div class="form-group">
                                            <input type="email" name="email" id="email" class="form-control input-lg" placeholder="Email Address">
                                        </div>
                                        <div class="form-group">
                                            <input type="password" name="password" id="password" class="form-control input-lg" placeholder="Password">
                                        </div>
                                        <span class="button-checkbox">
                                            <button type="button" class="btn" data-color="info">Remember Me</button>
                                            <input type="checkbox" name="remember_me" id="remember_me" checked="checked" class="hidden">
                                            <a href="" class="btn btn-link pull-right">Forgot Password?</a>
                                        </span>
                                        <hr class="colorgraph">
                                        <div class="row">
                                            <div class="col-xs-6 col-sm-6 col-md-6">
                                                <input type="submit" class="btn btn-lg btn-success btn-block" value="Sign In">
                                            </div>
                                            <div class="col-xs-6 col-sm-6 col-md-6">
                                                <a href="" class="btn btn-lg btn-primary btn-block">Register</a>
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
                            	<img src="../WEB-INF/images/logo-kemendagri-login.png">
                            </div>
						</div>
                    </div>
                </div>
            </div>
		</div>
        
        <div class="row">
        	<div class="col-md-12">
            	<div class="area-footer">
        		© 2016 Kementerian Dalam Negeri. All Rights Reserved. 
                </div>
            </div>
        </div>
        
    </div>
    <!-- /.container --> 
    
    <script type='text/javascript' src="../WEB-INF/lib/bootstrap/bootstrap.js"></script> 
    <script type='text/javascript' src="../WEB-INF/lib/bootstrap/angular.js"></script> 
	
    
</body>
</html>
