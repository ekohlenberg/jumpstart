# Jumpstart

[![License](https://img.shields.io/badge/license-MIT-blue.svg)](LICENSE)
[![.NET](https://img.shields.io/badge/.NET-9.0-blue.svg)](https://dotnet.microsoft.com/)
[![PostgreSQL](https://img.shields.io/badge/PostgreSQL-15+-blue.svg)](https://www.postgresql.org/)
[![SQL Server](https://img.shields.io/badge/SQL%20Server-2022-blue.svg)](https://www.microsoft.com/en-us/sql-server/sql-server-2022)

> **Jumpstart** is an enterprise-grade code generation framework that creates full-stack applications from metadata specifications. It generates production-ready scaffolds for machine learning applications, business systems, and data-driven applications.

## 🚀 Overview

Jumpstart transforms tabular metadata into complete, production-ready applications including:

- **Database Layer**: PostgreSQL DDL scripts with audit trails, sequences, and real-world keys
- **Backend API**: .NET 9 REST API with authentication, authorization, and business logic
- **Frontend**: Blazor WebAssembly with modern UI components
- **Testing**: Generated test suites for both API and persist layers
- **Infrastructure**: Logging and monitoring capabilities

## ✨ Key Features

### 🔧 **Metadata-Driven Generation**
- Accepts CSV-based metadata specifications
- Generates complete application stacks from data models
- Supports complex relationships, constraints, and business rules

### 🏗️ **Full-Stack Architecture**
- **Database**: PostgreSQL and MS SQL Server support with audit trails and sequences
- **Backend**: .NET 9 REST API with dependency injection
- **Frontend**: Blazor WebAssembly with responsive design
- **Testing**: Dual test suites (API and persist layer testing)

### 🔐 **Enterprise Security**
- Role-based access control (RBAC)
- Object-level permissions (RWX authorization) (future)
- OAuth authentication support (future)
- Audit logging and compliance features

### 🚀 **Developer Experience**
- Hot reload during development
- Comprehensive logging and debugging
- Automated testing and CI/CD ready

## 🛠️ Technology Stack

| Component | Technology |
|-----------|------------|
| **Backend** | .NET 9, ASP.NET Core |
| **Database** | PostgreSQL 15+, MS SQL Server 2022+ |
| **Frontend** | Blazor WebAssembly |
| **Testing** | Generated Persist and HTTP Client |
| **Templating** | RazorLight |

## 📋 Prerequisites

- **.NET 9 SDK** - [Download](https://dotnet.microsoft.com/download)
- **PostgreSQL 15+** - [Download](https://www.postgresql.org/download/)
- **Git** - [Download](https://git-scm.com/downloads)

## 🚀 Quick Start

### 1. Clone the Repository

```bash
git clone https://github.com/your-org/jumpstart.git
cd jumpstart
```

### 2. Build the Project

```bash
cd jumpstart/src
dotnet build

```

### 3. Generate an Application

```bash
# Generate from a metadata CSV file
dotnet run --project src/jumpstart.csproj -- model.csv

# Or use the executable directly
./jumpstart model.csv
```

### 4. Run the Generated Application

```bash
cd generated-app
dotnet run --project server/api/api.csproj
```

## 📖 Usage

### Metadata Specification

Jumpstart uses CSV files to define your application's data model. Here's a basic example:

```csv
SCHEMA_NAME,OBJECT_NAME,ATTRIBUTE_NAME,DATA_TYPE,IS_NULLABLE,IS_PRIMARY_KEY,IS_FOREIGN_KEY,REFERENCED_TABLE
app,User,id,BIGINT,false,true,false,
app,User,username,VARCHAR(50),false,false,false,
app,User,email,VARCHAR(100),false,false,false,
app,User,created_date,TIMESTAMP,false,false,false,
```

### Command Line Options

```bash
# Generate application from metadata
jumpstart model.csv

# Generate with custom output directory
jumpstart model.csv --output ./my-app

# Generate with specific template set
jumpstart model.csv --template-set enterprise
```

## 🏗️ Generated Application Structure

```
generated-app/
├── database/
│   ├── ddl/           # Database schema scripts
│   └── data/          # Seed data scripts
├── server/
│   ├── api/           # REST API (.NET 9)
│   ├── logic/         # Business logic layer
│   ├── persist/       # Data access layer
│   ├── test-api/      # API integration tests
│   └── test-persist/  # Persist layer tests
├── shared/
│   ├── common/        # Shared utilities
│   └── domain/        # Domain models
└── web/
    └── blazor/        # Blazor WebAssembly frontend
```

## 🔧 Configuration

### Database Connection

Jumpstart reads database connection parrameters from a file in your home directory:

```bash
# Model configuration file location
~/.jumpstart-model
```

The appsettings.json file contains your application's runtime configuration in the *appsettings* section.

### Application Settings

Update `appsettings.json` in your generated application:

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
        "appsettings": {
                "logwriters": "<your-model-name>.LogFileWriter,<your-model-name>.LogTableWriter,<your-model-name>.LogConsoleWriter",
                "loglevel": "debug" ,
                "db.type": "mssql"
        }
}
```




## 🧪 Testing

Jumpstart generates comprehensive test suites:

### API Testing
```bash
cd server/test-api
dotnet test
```

### Persist Layer Testing
```bash
cd server/test-persist
dotnet test
```

## 📚 Sample Applications

Jumpstart can generate various application types:

- **📊 Accounting System** - Double-entry bookkeeping with GL accounts
- **👥 CRM System** - Customer relationship management
- **🐛 Project Management** - Bug tracking and task management
- **📈 Analytics Dashboard** - Data visualization and reporting
- **🔐 Identity Management** - User and role management

## 🤝 Contributing

We welcome contributions! Please see our [Contributing Guidelines](CONTRIBUTING.md) for details.

### Development Setup

1. **Fork the repository**
2. **Create a feature branch**
   ```bash
   git checkout -b feature/amazing-feature
   ```
3. **Make your changes**
4. **Run tests**
   ```bash
   dotnet test
   ```
5. **Submit a pull request**

## 📋 Roadmap

### 🎯 Upcoming Features

- **🤖 AI-Powered Generation**
  - GenAI integration for metadata creation
  - AI-assisted business logic implementation
  - Natural language to code generation

- **🔧 Enhanced Templates**
  - Dynamic pivoting capabilities
  - Advanced scripting (triggers, stored procedures)
  - Multi-database support (SQL Server, SQLite)

- **🚀 Performance & Scalability**
  - Microservices architecture support
  - Horizontal scaling capabilities
  - Advanced caching strategies

- **🔐 Security Enhancements**
  - Multi-factor authentication
  - Advanced encryption options
  - Compliance frameworks (SOC2, GDPR)

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 🙏 Acknowledgments

- **RazorLight** - For the powerful templating engine
- **CsvHelper** - For robust CSV parsing
- **PostgreSQL** - For the excellent database support
- **Blazor** - For the modern web framework

## 📞 Support

- **📧 Email**: support@jumpstart.dev
- **💬 Discord**: [Join our community](https://discord.gg/jumpstart)
- **🐛 Issues**: [GitHub Issues](https://github.com/your-org/jumpstart/issues)
- **📖 Documentation**: [Wiki](https://github.com/your-org/jumpstart/wiki)

---

**Made with ❤️ by the Jumpstart Team**
