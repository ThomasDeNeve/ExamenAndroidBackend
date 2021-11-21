# delete existing myapp 
if docker ps | grep -q myapp
then 
    docker stop myapp
    docker rm myapp
else    
    if docker ps -a | grep -q myapp
    	then docker rm myapp
    fi       	
fi
