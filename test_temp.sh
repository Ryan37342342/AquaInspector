curl -X POST http://localhost:8080/api/tank/tempcurl -X POST http://localhost:8080 \
     -H "Content-Type: application/json" \
     -d '{
           "tank_number": 1,
           "temp": 25.5,
           "time_stamp": "2025-04-03T12:00:00Z"
         }'

docker exec -it db_service_postgres psql -U ryan -d aquarium_db
psql -U ryan -d aquarium_db
SELECT * FROM "temperature_reading";
# select all from last 24 hours 
SELECT * 
FROM temperature_readings
WHERE time_stamp >= NOW() - INTERVAL '1 day';

curl -X POST http://192.168.50.23:8080/api/tank/log \
  -H "Content-Type: application/json" \
  -d '{
        "tank_number": 1,
        "message_type": "INFO",
        "message": "This is a test log entry from curl",
        "time_stamp": "2025-04-25T12:00:00Z"
      }'