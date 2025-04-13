-- create the temp reading table if it doesnt exist
CREATE TABLE IF NOT EXISTS temperature_readings (
    entry_key SERIAL PRIMARY KEY,
    tank_number INT NOT NULL,
    temp DOUBLE PRECISION NOT NULL,
    time_stamp TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP
);