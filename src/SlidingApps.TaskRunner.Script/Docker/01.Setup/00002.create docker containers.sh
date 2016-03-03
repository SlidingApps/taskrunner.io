
docker run -d --name sa-rabbitmq --hostname sa-rabbitmq -p 15672:15672 -p 5672:5672 -v /docker/var/lib/rabbitmq:/var/lib/rabbitmq rabbitmq:3-management
docker run -d --name sa-mysql -p 3306:3306 -v /docker/var/lib/mysql:/var/lib/mysql -e MYSQL_ROOT_PASSWORD=superman mysql/mysql-server:latest
docker run -d --name sa-nginx -p 8080:80 -v /docker/usr/share/nginx/html:/usr/share/nginx/html:ro nginx