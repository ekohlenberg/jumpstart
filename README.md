##Project Jumpstart


1. **Purpose**  
    - Jumpstart is meant to help enterprise application developers create realistic prototypes that can be used as the foundation for real applications.

2. **Problem Solved** 
   - This project generates a full stack application from metadata input.
   - The metadata input is a tabular data model specification.

3. **Target Audience**  
   - The Jumpstart project is an aide to software developers.

4. **Key Features**  
   - Accepts tabular metadata as input
   - Uses RazorLight templates to generate output.
   - Output includes Postgres DDL scripts, dotnet REST API server, and React front-end.
   - Future common modules will include:
     - OAuth authentication
     - Logging
     - Role-based function authorization
     - Object rwx authorization
     - Distributed custom script processing (e.g. Powershell or Python)

## Technical Details
1. **Jumpstart Architecture**  
   - Jumpstart is written in C# and RazorLight
   - Metadata application definition
   - MetaModel Representation
     - MetaModel
     - MetaSchema
     - MetaObject
     - MetaAttribute
     - MetaBuild
   - Type Mapping and Conversion
   - Template types
     - Application
     - Schema
     - Object
     - Build

2. **Database Support**  
   - Jumpstart itself does not use a database.  Generated applications currently only support Postgres, but MS SQL and SQLite should follow soon.

3. **Generated Application Architectural Overview**  
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
   

4. **Dependencies**  
   - CsvHelper
   - RazorLight

5. **Technology Stack**  
    - What is the technology stack (e.g., PostgreSQL, .NET Core, React)?

## Setup and Installation
1. **Cloning or Downloading**  
    - TBD clone or download the project

2. **System Requirements**  
    - TBD - system requirements to run the project

3. **Development Environment Setup**  
    - TBD - steps to set up the development environment

4. **Running the Project Locally**  
    - TBD - How to run the project locally

## Usage
1. **Command Line**  
    - Usage

2. **Example Inputs or Configurations**  
``` bash
    jumpstart .\model.csv
```

3. **Sample Applications**  
    - Basic double-entry accounting
    - Application Management and Performance Monitoring
    - Bug Tracking / Project Management
    - Customer Relationship Management

## Contributing and Maintenance
1. **Getting Involved**  
     - TBD

2. **Contributing Guidelines**  
     - TBD

3. **Future Plans**  
    - Use GenAI to produce metadata files
    - Use GenAI for the logic implementation layer
    - More extensive scripting (e.g. trigger scripts)
    - Dynamic pivoting
