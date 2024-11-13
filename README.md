# RentEasy

RentEasy is a web application designed for booking and renting properties. The project provides an intuitive and seamless platform for property management and rental experiences, incorporating best practices in software development and architecture to ensure scalability, modularity, and performance.

## 🚀 Technologies Used

- **Backend**: C#, .NET Core
- **Architecture**: Clean Architecture, DDD, CQRS
- **Database**: PostgreSQL, MongoDB
- **Frameworks**: Entity Framework, Dapper, MediatR
- **Messaging**: RabbitMQ
- **Testing**: xUnit, NUnit
- **Security**: OAuth, JWT Authentication

## ⚙️ Features

- **Property Management**: Users can add, edit, and view properties available for rent, ensuring efficient property management.
- **Property Booking**: Streamlined booking process for users to search for and reserve properties effortlessly.
- **User Management**: Handles user registration, authentication, and authorization with role-based access control (admin and tenant roles).
- **Notifications and Events**: Utilizes **MediatR** for handling events and notifications, providing real-time updates about booking status, availability changes, etc.
- **Authentication and Authorization**: API security is implemented with **JWT** and **OAuth** to ensure proper authentication and authorization for different user roles.

## 🛠️ Architecture Overview

- **Clean Architecture**: The application follows Clean Architecture principles, ensuring separation of concerns between layers such as API, services, and domain logic.
- **Domain-Driven Design (DDD)**: The domain layer is designed using DDD practices, which focus on modeling real-world concepts and entities such as `Apartment`, `Booking`, and `User`.
- **CQRS**: The project uses **CQRS** (Command Query Responsibility Segregation) to separate read and write operations for better scalability and performance.
- **Event-Driven**: **MediatR** is used for handling events and ensuring loose coupling between layers, improving maintainability and flexibility.

## 🧩 Cross-Cutting Concerns

- **Logging**: Utilizes logging frameworks to capture application behavior and errors for monitoring and debugging purposes.
- **Exception Handling**: Global exception handling to ensure consistency in error responses.
- **Caching**: Implements caching mechanisms to optimize performance and reduce database load.
- **Authorization & Authentication**: Uses industry-standard practices for securing APIs with **OAuth** and **JWT**.
