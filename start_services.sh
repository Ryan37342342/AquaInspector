#!/bin/bash
 # start container services in detached mode
 sudo docker-compose --env-file db.env up -d
 echo "AquaInspector Ready and Waiting ... "