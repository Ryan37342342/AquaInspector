#!/bin/bash
set -e
docker-compose down -v
# Load environment variables from .env file
export $(grep -v '^#' db.env | xargs)

# start rest of the services 
docker-compose --env-file db.env up  -d --build

echo "PostgreSQL is ready!"

docker-compose logs -f