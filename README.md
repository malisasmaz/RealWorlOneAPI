# RealWorlOneAPI

# Preconditions

1. Visual Studio 2019+
2. .NET Core 3.1+
3. Postman(optional)<br />
The programs in above must be installed.

# Steps to Run this Project

1. Clone the repo
```sh
git clone https://github.com/malisasmaz/RealWorlOneAPI.git
```
2. Open in Visual Studio.

# API Documentation 
I used swagger for documentation.
When you run the project it opens swagger page and also you can open via https://localhost:44375/swagger/index.html

# Decision-Making Process and TechStack

1. I used ASP.NET Core Web Api template for the project. I added Services folder for my sub proccess and Models for my entities.
2. Nuget packages and why I use them
   - Microsoft.EntityFrameworkCore.InMemory
     - The purpose of this is not to waste time creating a database for the API, instead of using memory as a database, we can quickly replace it with a permanent storage unit such as a Database later.
   - System.Drawing.Common
     - For image rotation operations.
   - Swashbuckle.AspNetCore
     - Swagger and API documentation
4. I added two different endpoints to the API:
   - Cat
     - Contains two different GET operations. 
       - Return upside-down cat image
       - Get rotation input and return cat image with rotation.
   - User
     - User CRUD operations

5. I used BasicAuthentication in all operations, except new user registration.

