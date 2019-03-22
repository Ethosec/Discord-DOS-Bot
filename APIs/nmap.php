<?php
ini_set('max_execution_time', 0);
ini_set('memory_limit', -1);

$host = $_GET['target'];
$ports = array(21, 22, 80, 443);

if(isset($host))
{
foreach ($ports as $port)
{
    $connection = @fsockopen($host, $port, $errno, $errstr, 2);

    if (is_resource($connection))
    {
        echo $host . ':' . $port . ' ' . '(' . getservbyport($port, 'tcp') . ') is open.' . "\n";

        fclose($connection);
    }else 
    {
//        echo $host . ':' . $port . ' ' . '(' . getservbyport($port, 'tcp') . ') is Closed.' . "\n";

  //      fclose($connection);
    }
}
}
else if(empty($host)){
echo "Target is Missing";
}

