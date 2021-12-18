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

if docker ps | grep -q HIER_API
then 
    docker stop HIER_API
    docker rm HIER_API
else    
    if docker ps -a | grep -q HIER_API
    	then docker rm HIER_API
    fi       	
fi
