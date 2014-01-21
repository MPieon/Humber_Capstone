<?php 
        $db = mysql_connect('localhost', 'Bob', 'yesd') or die('Could not connect: ' . mysql_error()); 
        mysql_select_db('CSI_Toronto') or die('Could not select database');
		
        // Strings must be escaped to prevent SQL injection attack. 
        $username = mysql_real_escape_string($_GET['username'], $db);
		$pwHash = mysql_real_escape_string($_GET['pwhash'], $db);
        
		$query = "SELECT * FROM `userdata` ORDER by `username`";
		$result = mysql_query($query) or die('Query failed: ' . mysql_error());
		$secretKey="myKey";
		
		$num_results = mysql_num_rows($result);
		
		for($i = 0; $i < $num_results; $i++)
		{
			$row = mysql_fetch_array($result);
			
			if($username == $row['username'])
			{
				$pwCheck = md5($row['password'] . $secretKey);
				//echo $pwCheck;
				if($pwHash == $pwCheck)	echo "TRUE";
				else echo "FALSE";			
			}
		}
?>
