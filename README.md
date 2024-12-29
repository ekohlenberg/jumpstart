#**Project Jumpstart**
   - Project Jumpstart


2. **Purpose**  
   - This project generates a full stack application from metadata input.

3. **Problem Solved**  
   - The Jumpstart project builds application scaffolding based on a domain model specification.

4. **Target Audience**  
   - The Jumpstart project is an aide to software developers.

5. **Key Features**  
   - Accepts tabular metadata as input
   - Uses Razor light templates to generate output.
   - Output includes Postgres DDL scripts, dotnet REST API server, and React front-end.
   - Future common modules will include:
     - OAuth authentication
     - Logging
     - Role-based function authorization
     - Object rwx authorization
     - Distributed custom script processing (e.g. Powershell or Python)

## Technical Details
6. **Languages and Frameworks**  
   - Jumpstart is written in C# and RazorLight

7. **Database Support**  
   - Currently only supports Postgres, but MS SQL and SQLite should follow soon.

8. **Architectural Overview**  
   - Database
     - Table design
       - Primary Keys
       - Foreign keys
     - Global columns
     - Audit tables
     - Sequence identities
     - Real-world keys
   - Domain
   - Persist
   - Logic
   - API
   - Web
   

9. **Dependencies**  
   - CsvHelper
   - RazorLight

10. **Technology Stack**  
    - What is the technology stack (e.g., PostgreSQL, .NET Core, React)?

## Setup and Installation
11. **Cloning or Downloading**  
    - TBD clone or download the project

12. **System Requirements**  
    - TBD - system requirements to run the project

13. **Development Environment Setup**  
    - TBD - steps to set up the development environment

14. **Running the Project Locally**  
    - TBD - How to run the project locally

## Usage
15. **Command Line**  
    - Usage

16. **Example Inputs or Configurations**  
``` bash
    jumpstart .\model.csv
```

17. **Sample Applications**  
    - Basic double-entry accounting
    - Application Management and Performance Monitoring
    - Bug Tracking / Project Management
    - Customer Relationship Management

## Contributing and Maintenance
18. **Getting Involved**  
     - TBD

19. **Contributing Guidelines**  
     - TBD

20. **Future Plans**  
    - Use GenAI to produce metadata files
    - Use GenAI for the logic implementation layer
    - More extensive scripting (e.g. trigger scripts)
    - Dynamic pivoting
