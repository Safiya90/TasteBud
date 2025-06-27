# 🍲 Recipe Platform

Recipe Platform is a multi-layered ASP.NET Core MVC web application that allows users to create, manage, and explore cooking recipes. The system supports user registration, recipe submission, categorization, ingredient/instruction management, and admin dashboard control.

## 🏗️ Architecture

The project follows a **3-Tier Architecture**:

- **Presentation Layer (PL)**: ASP.NET Core MVC with Bootstrap for UI.
- **Business Logic Layer (BLL)**: Contains services like `RecipeService`, responsible for business operations.
- **Data Access Layer (DAL)**: Manages database operations using Entity Framework Core and Generic Repositories.

## 📦 Features

- User authentication and registration via Identity.
- Role-based authorization (Admin/User).
- Add/Edit/Delete recipes with ingredients and instructions.
- Assign categories and difficulty levels.
- Admin dashboard for managing categories, users, and recipes.
- Ratings system for user feedback.

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
- SQL Server
- Bootstrap 5
- Identity Framework

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
