<?
include_once("../WEB-INF/page_config.php");
include_once("../WEB-INF/functions/default.func.php");
include_once("../WEB-INF/classes/utils/UserLogin.php");

// LOGIN CHECK 
if ($userLogin->checkUserLogin()) 
{ 
	$userLogin->retrieveUserInfo();  
}

$pg = httpFilterRequest("pg");
$menu = httpFilterRequest("menu");
?>

<!doctype html>
<html>
<head>
<meta charset="utf-8">
<title>Aplikasi Pelaporan Hasil Assessment</title>

<link rel="stylesheet" type="text/css" href="../WEB-INF/css/gaya.css">
<link rel="shortcut icon" type="image/x-icon" href="../WEB-INF/images/favicon.ico">

<script type="text/javascript" src="droptiles/js/Combined.js?v=14"></script>
  
<!-- DROPTILES -->
<!--<link rel="stylesheet" type="text/css" href="droptiles/css/bootstrap.min.css">-->
<link rel="stylesheet" type="text/css" href="droptiles/css/droptiles.css?v=14">
<style>
.app-nama{ color:#77726f; font-size:16px; margin-bottom:10px;}
.app-last-login-icon{ float:left; margin-right:10px; padding-top:7px;}
.app-keterangan{ float:right; color:#aba7a5; }
</style>

<link rel="stylesheet" href="../WEB-INF/css/gaya.css" type="text/css">

<!-- LIVE DATE -->
<script>

/*
Live Date Script- 
© Dynamic Drive (www.dynamicdrive.com)
For full source code, installation instructions, 100's more DHTML scripts, and Terms Of Use,
visit http://www.dynamicdrive.com
*/

var dayarray = new Array("Minggu", "Senin", "Selasa", "Rabu", "Kamis", "Jumat", "Sabtu")
var montharray = new Array("Januari", "Februari", "Maret", "April", "Mei", "Juni", "Juli", "Agustus", "September", "Oktober", "November", "Desember")

function getthedate() {
    var mydate = new Date()
    var year = mydate.getYear()
    if (year < 1000)
        year += 1900
    var day = mydate.getDay()
    var month = mydate.getMonth()
    var daym = mydate.getDate()
    if (daym < 10)
        daym = "0" + daym
    var hours = mydate.getHours()
    var minutes = mydate.getMinutes()
    var seconds = mydate.getSeconds()
    var dn = "AM"
    if (hours >= 12)
        dn = "PM"
    if (hours > 12) {
        hours = hours - 12
    }
    if (hours == 0)
        hours = 12
    if (minutes <= 9)
        minutes = "0" + minutes
    if (seconds <= 9)
        seconds = "0" + seconds
    
	    //change font size here
    var cdate = "<small><font color='000000' face='Arial'><b>" + dayarray[day] + ", " + montharray[month] + " " + daym + ", " + year + " " + hours + ":" + minutes + ":" + seconds + " " + dn + "</b></font></small>"
	var cjam = hours + ":" + minutes
	var chari = dayarray[day] + ", " + daym + " " + montharray[month] + " " + year
	
    if (document.all)
        //document.all.clock.innerHTML = cdate,
		document.all.jam.innerHTML = cjam,
		document.all.hari.innerHTML = chari
    else if (document.getElementById)
        //document.getElementById("clock").innerHTML = cdate,
		document.getElementById("jam").innerHTML = cjam,
		document.getElementById("hari").innerHTML = chari
    else
        //document.write(cdate),
		document.write(cjam),
		document.write(chari)
}
if (!document.all && !document.getElementById)
    getthedate()

function goforit() {
    if (document.all || document.getElementById)
        setInterval("getthedate()", 1000)
}

</script>

</head>

<body style="overflow:hidden;" onLoad="goforit()" >

<?
include_once "../global_page/header.php";
?>
<div id="main-kontainer">
	<div id="login-area">
    	<!--<div class="judul">LOGIN AREA</div>-->
        <div class="judul"><img src="../WEB-INF/images/foto2.png"></div>
    	<div class="akun">
        <strong><?=$userLogin->nama?></strong><br>
        <?=$userLogin->userGroupNama?><br>
        <a href="#">Ganti Password</a> | <a href="login.php?reqMode=submitLogout">Logout</a>
        </div>
        
        <div class="alamat">
        
        <strong>PUSAT DATA, STATISTIK, DAN INFORMASI</strong><br><br>
        
        <strong>Sekretariat Jenderal - Kementerian Kelautan dan Perikanan</strong><br>
        
        Jl. Medan Merdeka Timur No. 16 Lt. 3A<br>
        Jakarta Pusat<br><br>
        
        Telp. (021) 3519070 EXT. 7440<br>
        Fax. (021) 3519133<br><br>
        
        Email: pusdatin@kkp.go.id<br>
        Homepage: www.kkp.go.id
        </div>
	</div>
    
    <div id="logo-login-area" style="height:100%">
    	<div id="judul-main" style="margin-top:-50px;"><span> Informasi</span> Pegawai&nbsp;</div>
        <div style="clear: both ;"></div>
        <?
		$reqId=1;
        ?>
        
        <div id="content" style="display: block; height: 100%; width: 100%; margin:0; background-color:#0F0">
            <table width="100%" border="0" cellpadding="0" cellspacing="0" align="center" height="100%" bgcolor="#F0F0F0" style="overflow:hidden">
            <tr> 
                <td height="100%" valign="top" class="menu" width="1"> 
                    <table width="242" border="0" cellpadding="0" cellspacing="0" height="100%" id="menuFrame">
                        <tr> 
                            <td height="100%"></td>
                            <td valign="top">
                            <!-- MENU -->
                            <iframe src="../silat/pegawai_menu_edit.php?reqPegawaiId=<?=$reqId?>&reqIdOrganisasi=<?=$reqIdOrganisasi?>" name="menuFrame" width="100%" height="100%" scrolling="auto" frameborder="0"></iframe>		  
                            </td>
                        </tr>
                    </table>
                </td>
                <td width="3" background="../WEB-INF/images/bg_menu_right.gif" align="right">
                    <a href="javascript:displayElement('menuFrame')"><img src="../WEB-INF/images/btn_display_element.gif" title="Buka/Tutup Menu" border="0"></a>
                </td>
                <td valign="top" height="100%" width="100%">
                    <div id="kontainer-atas" class="kontainer-atasFull">
                        <iframe class="mainframe" id="idMainFrame" name="mainFrame" src="../silat/identitas_edit.php?reqPegawaiId=<?=$reqId?>&reqIdOrganisasi=<?=$reqIdOrganisasi?>&reqConfirm=<?=$reqConfirm?>" style="width:100%; height:calc(100% - 5px); border:none;"></iframe>
                    </div>
                    
                    <div id="trdetil" style="overflow:hidden; display:none">
                        <button id="atasbawah">Show/Hide</button>
                        <iframe class="mainframe" id="idMainFrame" name="mainFrameDetil" src="" style="width:100%; height: 100%;  border:none;"></iframe>
                    </div>
                </td>
            </tr>
            </table>
        
        </div>
    </div>
    
</div>
<div id="main-footer">
	&copy; 2015 Kementerian Kelautan dan Perikanan. All Rights Reserved.
</div>
</body>


<script type="text/javascript">
    // Bootstrap initialization
    $(document).ready(function () {
        $('.dropdown-toggle').dropdown();
    });
</script>

<script type="text/javascript">
    window.currentUser = new User({
        firstName: "None",
        lastName: "Anonymous",
        photo: "img/User No-Frame.png",
        isAnonymous: true
    });
</script>

<script type="text/javascript" src="droptiles/js/CombinedDashboard.js?v=14"></script>
</html>
