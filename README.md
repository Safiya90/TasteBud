# 🍲 Recipe Platform

Recipe Platform is a multi-layered ASP.NET Core MVC web application that allows users to create, manage, and explore cooking recipes. The system supports user registration, recipe submission, categorization, ingredient/instruction management, and admin dashboard control.

## 🏗️ Architecture

The project follows the **N-Tier architecture**, which separates concerns into distinct layers for maintainability and scalability:

- **Presentation Layer (PL):** Handles UI and user interaction (ASP.NET Core MVC).
- **Business Logic Layer (BLL):** Contains the core logic and services.
- **Data Access Layer (DAL):** Manages database interactions using Entity Framework Core.
- **Models Layer:** Defines entities and data structures used across layers.

Each layer communicates with the adjacent layers only, promoting loose coupling and testability.

## 📦 Features

- User registration, login, and role-based authorization (Admin/User).
- Add, update, delete, and list recipes with full details.
- Add multiple ingredients and instructions per recipe.
- Categorize recipes for easier browsing.
- Display detailed recipe views with images, ingredients, instructions, and ratings.
- Clean, responsive UI using Bootstrap.

## 🧩 Entities

- `Recipe`: Linked to Ingredients and Instructions.
- `Ingredient`: Saved with each recipe.
- `Instruction`: Step-by-step guide for preparing the recipe.
- `Category`: Classification of recipes.
- `ApplicationUser`: Identity user.
- `Rating`: User ratings for recipes.

## 💾 Database

- Using **Entity Framework Core**.
- Fluent API or Data Annotations are used to configure relationships.
- On cascade delete, related `Ingredients` and `Instructions` are removed with their `Recipe`.

## 🧪 Technologies

- ASP.NET Core MVC
- Entity Framework Core
- Microsoft Identity for authentication
- SQL Server (or your preferred relational database)
- Bootstrap 5 for responsive design
- C#
- Visual Studio 2022

## 🔄 Future Enhancements

- Image upload for recipes.
- Search and filter recipes.
- Pagination and user profiles.
- API version for mobile app.

## 📁 Project Structure

```
RecipePlatform/
│
├── BLL/                  # Business logic layer (services, interfaces)
├── DAL/                  # Data access layer (DbContext, repositories)
├── Models/               # Entity and view model definitions
├── PL/                   # Presentation layer (Controllers, Views)
│   └── MVC/
│       └── Views/
│       └── Controllers/
│
└── README.md
```
