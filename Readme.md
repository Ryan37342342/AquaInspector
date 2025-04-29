# AquaInspector

AquaInspector is a personal project aimed at monitoring the variables in multiple fish tanks simultaneously. By using IoT boards and sensors, the project collects data from each fish tank and stores it in a database for further analysis. This will help me to breed fish more effectively 

## Project Goals
The main goal is to ensure the health and well-being of fish by monitoring key variables such as temperature, pH levels, and water quality in real time. I also want to collect data that will assist me in the future 

## Technology Stack
- **C#**: Used for developing the central hub and APIs.
- **Rust**: Selected for programming the microcontrollers to leverage performance and safety.
- **Docker**: Used to containerize the APIs and database, ensuring consistent environments.

## Deployment Strategy
By using Docker and Kubernetes, the project achieves scalability and ease of management for the microservices architecture, allowing for easier updates and maintenance.

## Current Progress 
- Completed intial boiler plate for C# API and DB backend 
- Containerized above step
- C# API now saves data in the DB Backend for temp
- Micro Controller has been programmed with a Temp sensor (See MicroController Repo)
- Can visualise data in the Grafana dashboard on local machine

## Next Steps:
- Investigate other sensors
- look at hosting options 
- explore k8s setup to see if it would provide value when using multiple sensors