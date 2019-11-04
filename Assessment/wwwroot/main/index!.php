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

<body style="overflow-x:hidden;" onLoad="goforit()" >

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
    	<?
        $includePage = $page_to_load->loadPage();
		include_once($includePage);
		?>
    </div>
    

    	
        
	<div id="footer-waktu" style="margin-left:200px !important">
        <!--<div id="footer-waktu-icon"><img src="../WEB-INF/images/icon-jam.png"></div>-->
        <div id="footer-waktu-jam"><span id="jam"></span></div>
        <div id="footer-waktu-tgl"><span id="hari"></span></div>
    </div>
        
</div>
<div id="main-footer">
	&copy; 2016 Kementerian Dalam Negeri. All Rights Reserved.
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

<!--Menu Aplikasi-->
<script type="text/javascript">
// The default tile setup offered to new users.
window.DefaultTiles = [
    {
        name :"Section1",
        tiles: [
			<?
			if($userLogin->userPegawaiId=="")
			{
			?>
			 <?
				if(	findWord($tempListInfo, "Pegawai IKK") == 1 ||
					findWord($tempListInfo, "Assesment") == 1 ||
					//Indeks Kompetensi dan Integritas 
					findWord($tempListInfo, "Potensi") == 1 || findWord($tempListInfo, "Kompetensi") == 1 ||  findWord($tempListInfo, "General IKK") == 1 ||
					//TalentPool
					findWord($tempListInfo, "Grafik Nine Box Talent") == 1 || findWord($tempListInfo, "Tabel Nine Box Talent") == 1 || $tempListInfo == "")
				{
			?>
			{ id: "ikk", name: "ikk" },
			<?
				}
			?>
			 <?
				if(findWord($tempListInfo, "Atribut") == 1 || 
					findWord($tempListInfo, "Pegawai SDM") == 1 || 
					findWord($tempListInfo, "Analisa Diklat") == 1 ||
					findWord($tempListInfo, "Training") == 1 ||  $tempListInfo == "")
				{
			?>
			{ id: "silat", name: "silat" },
			 <?
				}
			?>
			 <?
				if(findWord($tempListInfo, "Pegawai Pola Karir") == 1 || $tempListInfo == "")
				{
			?>
			{ id: "polakarir", name: "polakarir" }, 
			<?
				}
			?>
			 <?
				if(findWord($tempListInfo, "Periode Penilaian") == 1 || findWord($tempListInfo, "Kategori") == 1
					|| findWord($tempListInfo, "Pertanyaan") == 1 || findWord($tempListInfo, "Pegawai Penilai") == 1 
					|| findWord($tempListInfo, "Kinerjaku dan SKP") == 1 || findWord($tempListInfo, "Formulir SKP") == 1
					|| findWord($tempListInfo, "Pencapaian SKP") == 1 || findWord($tempListInfo, "Validasi Formulir SKP") == 1
					|| findWord($tempListInfo, "Validasi Pencapaian SKP") == 1 || findWord($tempListInfo, "Penilaian SKP") == 1 
					|| findWord($tempListInfo, "SKP dan Perilaku Kerja") == 1  
					||$tempListInfo == "")
				{
			?>
			{ id: "kinerja", name: "kinerja" }, 
			<?
				}
			?>
			<?
				if(findWord($tempListInfo, "Hukuman") == 1 || findWord($tempListInfo, "Tugas Belajar") == 1 || $tempListInfo == "")
				{
			?>
			{ id: "tugasbelajar", name: "tugasbelajar" },
			<?
				}
			?>
			<?
				if($userLogin->userMasterProses=="0"){}
				else
				{
			?>
			{ id: "pengaturan", name: "pengaturan" },
			<?
				}
			?>
			<?
				if(findWord($tempListInfo, "Rencana Suksesi") == 1 || $tempListInfo == "")
				{
			?>
			{ id: "suksesi", name: "suksesi" }, 
			<?
				}
			?>
			<?
			}
			else
			{
			?>
			{ id: "pegawai", name: "pegawai" }
			<?
			}
			?>
			/*,{ id: "skp", name: "skp" }*/
		   
        ]
    },
    {
        name: "Section2",
        tiles: [
           { id: "video1", name: "video" },
           { id: "wikipedia1", name: "wikipedia" },           
           //{ id: "email1", name: "email" },
           //{ id: "maps1", name: "maps" },
           { id: "facebook1", name: "facebook" },
           { id: "ie1", name: "ie" },
           { id: "dynamicTile1", name: "dynamicTile" },
           { id: "buy1", name: "buy" }]
    },
    {
        name: "Section3", tiles: [
            
           //{ id: "youtube1", name: "youtube" },
           //{ id: "ie1", name: "ie" }
           { id: "howto1", name: "howto" }           
        ]
    }
];

// Definition of the tiles, their default values.
window.TileBuilders = {
    
	ikk: function (uniqueId) {
        return {
            uniqueId: uniqueId,
            name: "ikk",
            color: "bg-color-white",
            //label: "<div class='app-last-login-icon' ><img src='../WEB-INF/images/app-master-data.jpg'></div>",
            iconSrc: '../WEB-INF/images/app-ikk.png',
            //appUrl: 'gaji/index.php'
			appUrl: "javascript:top.document.location.href='../ikk/index.php'"
        };
    },
	
	silat: function (uniqueId) {
        return {
            uniqueId: uniqueId,
            name: "silat",
            color: "bg-color-white",
            //label: "<div class='app-last-login-icon' ><img src='../WEB-INF/images/app-master-data.jpg'></div>",
            iconSrc: '../WEB-INF/images/app-silat.png',
            //appUrl: 'gaji/index.php'
			appUrl: "javascript:top.document.location.href='../silat/index.php'"
        };
    },
	
	polakarir: function (uniqueId) {
        return {
            uniqueId: uniqueId,
            name: "polakarir",
            color: "bg-color-white",
            //label: "<div class='app-last-login-icon' ><img src='../WEB-INF/images/app-master-data.jpg'></div>",
            iconSrc: '../WEB-INF/images/app-polakarir.png',
            //appUrl: 'gaji/index.php'
			appUrl: "javascript:top.document.location.href='../polakarir/index.php'"
        };
    },
	
 
 
	
	

	
	suksesi: function (uniqueId) {
        return {
            uniqueId: uniqueId,
            name: "suksesi",
            color: "bg-color-white",
            //label: "<div class='app-last-login-icon' ><img src='../WEB-INF/images/app-master-data.jpg'></div>",
            iconSrc: '../WEB-INF/images/app-rencanasuksesi.png',
            //appUrl: 'gaji/index.php'
			appUrl: "javascript:top.document.location.href='../suksesi/index.php'"
        };
    },
	
		pengaturan: function (uniqueId) {
        return {
            uniqueId: uniqueId,
            name: "pengaturan",
            color: "bg-color-white",
            //label: "<div class='app-last-login-icon' ><img src='../WEB-INF/images/app-master-data.jpg'></div>",
            iconSrc: '../WEB-INF/images/app-pengaturan.png',
            //appUrl: 'gaji/index.php'
			appUrl: "javascript:top.document.location.href='../pengaturan/index.php'"
        };
    },
	
	pegawai: function (uniqueId) {
        return {
            uniqueId: uniqueId,
            name: "pegawai",
            color: "bg-color-white",
            //label: "<div class='app-last-login-icon' ><img src='../WEB-INF/images/app-master-data.jpg'></div>",
            iconSrc: '../WEB-INF/images/app-pegawai.png',
            //appUrl: 'gaji/index.php'
			appUrl: "javascript:top.document.location.href='../pegawai/pegawai.php'"
        };
    },
	
	
	skp: function (uniqueId) {
        return {
            uniqueId: uniqueId,
            name: "skp",
            color: "bg-color-white",
            //label: "<div class='app-last-login-icon' ><img src='../WEB-INF/images/app-master-data.jpg'></div>",
            iconSrc: '../WEB-INF/images/app-skp.png',
            //appUrl: 'gaji/index.php'
			appUrl: "javascript:top.document.location.href='../skp/index.php'"
        };
    },
        
};
</script>
<script type="text/javascript" src="droptiles/js/CombinedDashboard.js?v=14"></script>
</html>
