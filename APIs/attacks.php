<?php
        $cmd = $_POST['target'];
        if(strpos($cmd , ";")){ echo "Command Is not Allowed.";}
        elseif(strpos($cmd , "&")){ echo "Command Is not Allowed.";}
        else{
            system("ps auxw|grep -i screen|grep -v grep | grep ".$cmd." | wc -l;");
        }
