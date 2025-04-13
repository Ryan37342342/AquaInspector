curl -X POST http://localhost:8080/api/tank/tempcurl -X POST http://localhost:8080/api/tank/temperature-reading \
     -H "Content-Type: application/json" \
     -d '{
           "tankNumber": 1,
           "temp": 25.5,
           "timeStamp": "2025-04-03T12:00:00Z"
         }'

docker exec -it db_service_postgres psql -U ryan -d aquarium_db
psql -U ryan -d aquarium_db
SELECT * FROM "TemperatureReading";