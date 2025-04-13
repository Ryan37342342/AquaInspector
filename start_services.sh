#!/bin/bash
set -e

# Load environment variables from .env file
export $(grep -v '^#' db.env | xargs)

# start rest of the services 
docker-compose --env-file db.env up  -d --build

echo "PostgreSQL is ready!"