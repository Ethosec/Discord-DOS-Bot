<?php
$curl = system("curl https://psnresolver.org/resolve/$username | grep '$error' > psn.lst");
if($error = "<td>")
{
$username = $_GET['psn'];
system("curl https://psnresolver.org/resolve/$username | grep '<td>' > /tmp/resolve.txt");
system('sed -i -e "s#<td>##g" /tmp/resolve.txt;sed -i -e "s#</td>##g" /tmp/resolve.txt;cat /tmp/resolve.txt');
}
?>
