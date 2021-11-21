# delete existing myapp 
if docker ps | grep -q HIER_website
then 
    docker stop HIER_website
    docker rm HIER_website
else    
    if docker ps -a | grep -q HIER_website
    	then docker rm HIER_website
    fi       	
fi
