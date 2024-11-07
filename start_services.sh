#!/bin/bash

# Load environment variables from .env file
source db.env
# start container services in detached mode
sudo docker-compose --env-file db.env up -d
# wait for DB to start
echo "Waiting for PostgreSQL backend to start ...."
until sudo docker exec -it db_service_postgres pg_isready -U $DB_USER; 
do 
    sleep 1
done 

