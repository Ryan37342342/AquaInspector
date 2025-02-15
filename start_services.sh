#!/bin/bash
set -e

# Load environment variables from .env file
export $(grep -v '^#' db.env | xargs)
# build and start container services in detached mode
docker-compose --env-file db.env up -d --build
# wait for DB to start
echo "Waiting for PostgreSQL backend to start ...."
until sudo docker exec  db_service_postgres pg_isready -U $DB_USER -d $DB_NAME; 
do 
    sleep 1
done 

