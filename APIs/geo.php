<?php

include 'class.IPInfoDB.php';

// Load the class
$ipinfodb = new IPInfoDB('68d7d82992e30a0fcbe28ad7e54bef917ec2e60fe36a0ccc1db9cb92db3c907a');

$results = $ipinfodb->getCity($_GET['target']);

// Getting the result
echo "Result
\n";
if (!empty($results) && is_array($results)) {
	foreach ($results as $key => $value) {
		echo $key . ' : ' . $value . "
\n";
	}
}
