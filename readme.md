# Global E-Commerce Order Management Platform (POC)

A proof-of-concept implementation of a Global E-Commerce Order Management Platform built using **ASP.NET Core 10**, **Angular**, and **SQLite**.

This project demonstrates how a production-ready event-driven microservices architecture can be implemented as a locally executable Modular Monolith 
while preserving clean architecture principles and enabling future migration to distributed services.

## Architecture Philosophy

The original requirement targets:

- Millions of orders/day
- Event-driven Microservices
- Cloud-native deployment
- High availability

For this Proof of Concept, I intentionally implemented a **Modular Monolith**.

This keeps the project:

- Easy to clone
- Easy to run locally
- Easy to review
- Infrastructure independent

while maintaining module boundaries that can later evolve into independent microservices.

Reasons
    - Demonstrates functionality without requiring cloud infrastructure.
    - Simplifies local development and evaluation.
    - Avoids overhead of managing multiple services, databases, message brokers, and deployment pipelines.
    - Enables reviewers to clone and run the project with minimal setup.

The application is still organized into independent modules (Catalog, Orders, Payment), allowing a straightforward migration to microservices in the future.

---

# Architecture Overview

## Architecture

Frontend (Angular)
        │
        ▼
ASP.NET Core REST API
        │
        ▼
Application Layer
        │
        ▼
Infrastructure (Dapper)
        │
        ▼
SQLite


## Features

### Version 1

- Product Catalog
- Shopping Cart
- Mock Checkout
- Mock Payment Processing
- Order Creation
- Order Confirmation
- Responsive Angular Material UI
- SQLite Database
- API Versioning
- Fluent Validation
- Clean Architecture (Application, Domain, Infrastructure, API)

---

# Tech Stack

## Backend

- ASP.NET Core 10
- Dapper
- SQLite
- FluentValidation
- API Versioning

## Frontend

- Angular
- Angular Material
- Angular Signals
- Reactive Forms

---

# Prerequisites

Install the following before running the project:

- .NET 10 SDK
- Node.js (v20 or later recommended)
- Angular CLI
---

# Verify installation

run command in bash
dotnet --version
node --version
npm --version
ng version

----


# Steps for setup and running locally.
Clone Repository
    git clone https://github.com/rsrohitsingh423/GlobalECommerce.git
    cd GlobalECommerce
Backend Setup
    1.	cd backend
    2.	dotnet restore
    3.	dotnet build      
    4.	dotnet run
Swagger: https://localhost:<port>/swagger
SQLite Database
    The application uses SQLite. If no database exists it will be created automatically on first run. 
Frontend Setup
    5.	cd frontend/global-ecommerce-ui
    6.	npm install
    7.	ng serve
Application URL: http://localhost:4200

Update the API URL if required in below file.
src/environments/environment.ts


Running the Application
8.	Start the backend
9.	Start the Angular application
10.	Open http://localhost:4200
11.	Browse products → Add to Cart → Checkout → Mock Payment → Order Confirmation


