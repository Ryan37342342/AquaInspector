-- create the temp reading table if it doesnt exist
CREATE TABLE IF NOT EXISTS temperature_readings (
    entry_key SERIAL PRIMARY KEY,
    tank_number INT NOT NULL,
    temp DOUBLE PRECISION NOT NULL,
    time_stamp TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP
);

-- create the temp reading table if it doesnt exist
CREATE TABLE IF NOT EXISTS logging_messages (
    entry_key SERIAL PRIMARY KEY,
    tank_number INT NOT NULL,
    message TEXT NOT NULL,
    message_type TEXT NOT NULL,
    time_stamp TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP
);