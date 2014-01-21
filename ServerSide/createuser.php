<?php 
        $db = mysql_connect('localhost', 'Bob', 'yesd') or die('Could not connect: ' . mysql_error()); 
        mysql_select_db('CSI_Toronto') or die('Could not select database');
 
        // Strings must be escaped to prevent SQL injection attack. 
        $username = mysql_real_escape_string($_GET['username'], $db);
		$password = mysql_real_escape_string($_GET['password'], $db);
        $sex = mysql_real_escape_string($_GET['sex'], $db); 
        $hash = $_GET['hash']; 
 
        $secretKey="myKey"; //Change value for a more secure addition of username/passwords

        $real_hash = md5($username . $password . $sex . $secretKey); 
        if($real_hash == $hash) { 
            // Send variables for the MySQL database class. 
								//userdata <-- is the table name
            $query = "INSERT INTO userdata VALUES ('$username', '$password', '$sex');"; 
            $result = mysql_query($query) or die('Query failed: ' . mysql_error()); 
		}
?>
