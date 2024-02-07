<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>Untitled Document</title>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" lang="en" xml:lang="en">

<link rel="stylesheet" type="text/css" href="ddsmoothmenu.css" />
<link rel="stylesheet" type="text/css" href="ddsmoothmenu-v.css" />

<script type="text/javascript" src="js/jquery.min.js"></script>
<script type="text/javascript" src="ddsmoothmenu.js">

/***********************************************
* Smooth Navigational Menu- (c) Dynamic Drive DHTML code library (www.dynamicdrive.com)
* This notice MUST stay intact for legal use
* Visit Dynamic Drive at http://www.dynamicdrive.com/ for full source code
***********************************************/

</script>

<script type="text/javascript">

ddsmoothmenu.init({
	mainmenuid: "smoothmenu1", //menu DIV id
	orientation: 'h', //Horizontal or vertical menu: Set to "h" or "v"
	classname: 'ddsmoothmenu', //class added to menu's outer DIV
	//customtheme: ["#1c5a80", "#18374a"],
	contentsource: "markup" //"markup" or ["container_id", "path_to_menu_file"]
})

ddsmoothmenu.init({
	mainmenuid: "smoothmenu2", //Menu DIV id
	orientation: 'v', //Horizontal or vertical menu: Set to "h" or "v"
	classname: 'ddsmoothmenu-v', //class added to menu's outer DIV
	//customtheme: ["#804000", "#482400"],
	contentsource: "markup" //"markup" or ["container_id", "path_to_menu_file"]
})

</script>
</head>

<body>
<h2>Example 1</h2>

<div id="smoothmenu1" class="ddsmoothmenu">
<ul>
<li><a href="http://www.dynamicdrive.com">Item 1</a></li>
<li><a href="#">Folder 0</a>
  <ul>
  <li><a href="#">Sub Item 1.1</a></li>
  <li><a href="#">Sub Item 1.2</a></li>
  <li><a href="#">Sub Item 1.3</a></li>
  <li><a href="#">Sub Item 1.4</a></li>
  <li><a href="#">Sub Item 1.2</a></li>
  <li><a href="#">Sub Item 1.3</a></li>
  <li><a href="#">Sub Item 1.4</a></li>
  </ul>
</li>
<li><a href="#">Folder 1</a>
  <ul>
  <li><a href="#">Sub Item 1.1</a></li>
  <li><a href="#">Sub Item 1.2</a></li>
  <li><a href="#">Sub Item 1.3</a></li>
  <li><a href="#">Sub Item 1.4</a></li>
  <li><a href="#">Sub Item 1.2</a></li>
  <li><a href="#">Sub Item 1.3</a></li>
  <li><a href="#">Sub Item 1.4</a></li>
  </ul>
</li>
<li><a href="#">Item 3</a></li>
<li><a href="#">Folder 2</a>
  <ul>
  <li><a href="#">Sub Item 2.1</a></li>
  <li><a href="#">Folder 2.1</a>
    <ul>
    <li><a href="#">Sub Item 2.1.1</a></li>
    <li><a href="#">Sub Item 2.1.2</a></li>
    <li><a href="#">Folder 3.1.1</a>
		<ul>
    		<li><a href="#">Sub Item 3.1.1.1</a></li>
    		<li><a href="#">Sub Item 3.1.1.2</a></li>
    		<li><a href="#">Sub Item 3.1.1.3</a></li>
    		<li><a href="#">Sub Item 3.1.1.4</a></li>
    		<li><a href="#">Sub Item 3.1.1.5</a></li>
		</ul>
    </li>
    <li><a href="#">Sub Item 2.1.4</a></li>
    </ul>
  </li>
  </ul>
</li>
<li><a href="http://www.dynamicdrive.com/style/">Item 4</a></li>
</ul>
<br style="clear: left" />
</div>


<h2 style="margin-top:200px">Example 2</h2>

<div id="smoothmenu2" class="ddsmoothmenu-v">
<ul>
<li><a href="http://www.dynamicdrive.com">Item 1</a></li>
<li><a href="#">Folder 0</a>
  <ul>
  <li><a href="#">Sub Item 1.1</a></li>
  <li><a href="#">Sub Item 1.2</a></li>
  <li><a href="#">Sub Item 1.3</a></li>
  <li><a href="#">Sub Item 1.4</a></li>
  <li><a href="#">Sub Item 1.2</a></li>
  <li><a href="#">Sub Item 1.3</a></li>
  <li><a href="#">Sub Item 1.4</a></li>
  </ul>
</li>
<li><a href="#">Folder 1</a>
  <ul>
  <li><a href="#">Sub Item 1.1</a></li>
  <li><a href="#">Sub Item 1.2</a></li>
  <li><a href="#">Sub Item 1.3</a></li>
  <li><a href="#">Sub Item 1.4</a></li>
  <li><a href="#">Sub Item 1.2</a></li>
  <li><a href="#">Sub Item 1.3</a></li>
  <li><a href="#">Sub Item 1.4</a></li>
  </ul>
</li>
<li><a href="#">Item 3</a></li>
<li><a href="#">Folder 2</a>
  <ul>
  <li><a href="#">Sub Item 2.1</a></li>
  <li><a href="#">Folder 2.1</a>
    <ul>
    <li><a href="#">Sub Item 2.1.1</a></li>
    <li><a href="#">Sub Item 2.1.2</a></li>
    <li><a href="#">Folder 3.1.1</a>
		<ul>
    		<li><a href="#">Sub Item 3.1.1.1</a></li>
    		<li><a href="#">Sub Item 3.1.1.2</a></li>
    		<li><a href="#">Sub Item 3.1.1.3</a></li>
    		<li><a href="#">Sub Item 3.1.1.4</a></li>
    		<li><a href="#">Sub Item 3.1.1.5</a></li>
		</ul>
    </li>
    <li><a href="#">Sub Item 2.1.4</a></li>
    </ul>
  </li>
  </ul>
</li>
<li><a href="http://www.dynamicdrive.com/style/">Item 4</a></li>
</ul>
<br style="clear: left" />
</div>
</body>
</html>