# AquaInspector

AquaInspector is a personal project aimed at monitoring the variables in multiple fish tanks simultaneously. By using IoT boards and sensors, the project collects data from each fish tank and stores it in a database for further analysis. This will help me to breed fish more effectively 

## Project Goals
The main goal is to ensure the health and well-being of fish by monitoring key variables such as temperature, pH levels, and water quality in real time.

## Technology Stack
- **C#**: Used for developing the central hub and APIs.
- **TypeScript**: Utilized for creating a dynamic and responsive dashboard.
- **Rust**: Selected for programming the microcontrollers to leverage performance and safety.
- **Docker**: Used to containerize the APIs and database, ensuring consistent environments.
- **Kubernetes**: Employed to manage and orchestrate the deployment of containers.

## Deployment Strategy
By using Docker and Kubernetes, the project achieves scalability and ease of management for the microservices architecture, allowing for easier updates and maintenance.

## Current Progress 
- Completed intial boiler plate for C# API and DB backend 
- Containerized above step
- C# API now saves data in the DB Backend for temp

## Next Steps:
 - Program Micro controller
 - Implement Temperature montioring (I have the board and sensor just need to connect and program)
 - Implement Dashboard