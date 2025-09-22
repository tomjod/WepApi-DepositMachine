# DepositMachine API

## Overview

**DepositMachine API** is a backend service built with .NET 8, designed to simulate the business logic for a network of cash deposit machines. This project serves as a portfolio piece to showcase the implementation of **Clean Architecture** and **Domain-Driven Design (DDD)** principles to build a robust, scalable, and maintainable system.

The goal of this repository is to demonstrate a modern approach to API development, focusing on separation of concerns, explicit domain logic, and decoupled infrastructure.

---

## Architecture and Design Patterns

The project is structured following the principles of Clean Architecture, dividing responsibilities into four primary layers:

* **Domain:** Contains the core business logic and domain rules. It includes Entities, Value Objects, Aggregates, and domain events, with no dependencies on any other layer.
* **Application:** Orchestrates the application's use cases. It employs the **CQRS (Command Query Responsibility Segregation)** pattern using the `MediatR` library to decouple write operations (Commands) from read operations (Queries).
* **Infrastructure:** Implements data access and external services. It contains the repository implementations using **Entity Framework Core**, the **Unit of Work** pattern, and the database configuration (PostgreSQL).
* **API (Presentation):** Exposes the application's use cases via a RESTful API. It is the entry point to the system and handles HTTP requests, serialization, and routing.

### Key Implemented Patterns:
* **Domain-Driven Design (DDD):** The system's core is modeled with rich entities and Value Objects to ensure the validity and consistency of the state.
* **CQRS with MediatR:** Clearly separates commands that modify state from queries that read it.
* **Repository and Unit of Work Pattern:** Abstracts data persistence logic, allowing the application layer to remain agnostic of the database technology.
* **Result Pattern:** Functional and explicit error handling instead of relying on exceptions for control flow.
* **FluentValidation:** Incoming requests are validated through a MediatR pipeline before reaching the command handlers.

---

## Tech Stack

* **Framework:** .NET 8
* **Language:** C# 12
* **Database:** PostgreSQL
* **ORM:** Entity Framework Core 8
* **Architectural Patterns:** Clean Architecture, DDD, CQRS
* **Key Libraries:**
    * `MediatR`: For implementing the mediator and CQRS patterns.
    * `FluentValidation`: For request validation.
    * `Serilog`: For structured logging.
    * `Swashbuckle`: For API documentation generation (Swagger/OpenAPI).

---

## Getting Started

### Prerequisites

* [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
* [Docker](https://www.docker.com/products/docker-desktop) (for the PostgreSQL database)
* An API client tool like [Postman](https://www.postman.com/) or the [REST Client](https://marketplace.visualstudio.com/items?itemName=humao.rest-client) extension for VS Code.

### Installation Steps

1.  **Clone the repository:**
    ```bash
    git clone [https://github.com/tomjod/WepApi-DepositMachine.git](https://github.com/tomjod/WepApi-DepositMachine.git)
    cd WepApi-DepositMachine
    ```

2.  **Start the database with Docker Compose:**
    This command will spin up a PostgreSQL container with the pre-configured connection details.
    ```bash
    docker-compose up -d
    ```

3.  **Apply database migrations:**
    Navigate to the API project and run the following command to create the database schema.
    ```bash
    cd src/Wep.API
    dotnet ef database update
    ```

4.  **Run the API:**
    ```bash
    dotnet run
    ```

The API will be available at `https://localhost:5001`. You can access the Swagger UI at `https://localhost:5001/swagger`.

---

## API Endpoints

The API provides several endpoints to manage the system's entities. Here are a few examples:

### Create a User

* **POST** `/api/Users/Register`
* **Body:**
    ```json
    {
      "email": "test.user@example.com",
      "firstName": "John",
      "lastName": "Doe",
      "password": "SecurePassword123!"
    }
    ```

### Create a Branch

* **POST** `/api/Branches`
* **Body:**
    ```json
    {
      "name": "Main Branch",
      "address": {
        "street": "123 Main St",
        "city": "Santiago",
        "state": "RM",
        "zipCode": "1234567"
      },
      "clientId": "..."
    }
    ```

### Create a Deposit

* **POST** `/api/Deposits`
* **Body:**
    ```json
    {
      "userId": "...",
      "depositMachineId": "...",
      "amount": 50000,
      "lineItems": [
        { "denomination": 1000, "quantity": 10 },
        { "denomination": 20000, "quantity": 2 }
      ]
    }
    ```
