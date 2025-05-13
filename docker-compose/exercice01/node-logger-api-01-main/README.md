# Node Logs API 

* Start the db container with 

```bash
docker run -d -p 3306:3306 --name mysql -v db_data:/var/lib/mysql -e MYSQL_ALLOW_EMPTY_PASSWORD=true -e MYSQL_DATABASE=db -e MYSQL_USER=admin -e MYSQL_PASSWORD=password mysql
```