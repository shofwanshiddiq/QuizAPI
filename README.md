# ASP.NET Core Web API for Quiz Trivia Web Application

This is a RESTful API built using ASP.NET Core Web API for Harry Potter quizzes trivia web application. Features login and user registration, generate random 5 questions, submit answer and save result. Integrated with SQL Server database using Microsoft Entity Frameworks and deployed using Swagger.

### Features
* User registration & login
* Generate random 5 questions & answers from all questions available in the database
* Perform score calculation based on users choice and answers
* Calculate time taken by user for taking the test
* Submit score and save the result to database

### Technologies
![.NET Web API](https://img.shields.io/badge/.NET_Web_API-%230078D4.svg?style=for-the-badge&logo=.net&logoColor=white)  ![REST API](https://img.shields.io/badge/REST_API-%23000000.svg?style=for-the-badge&logo=swagger&logoColor=white)  ![SQL Server](https://img.shields.io/badge/SQL_Server-%23007A92.svg?style=for-the-badge&logo=microsoft-sql-server&logoColor=white)  ![Swagger](https://img.shields.io/badge/Swagger-%2385EA2D.svg?style=for-the-badge&logo=swagger&logoColor=black)   

### Version
* .NET 8
* Entity Frameworks 6
* Entity Framework Core Tools 9.0.3
* Visual Studio 2022
* Microsoft SQL Server 2019

## API Endpoints Documentation

| Method     | API Endpoint               | Description                                      |
|------------|----------------------------|--------------------------------------------------|
| **POST**   | `/api/Participant`            | Create a new participant                              |
| **GET**   | `/api/Participant`            | Get all participant data                              |
| **GET**   | `/api/Participant/{id}`            | Get participant data by ID                            |
| **PUT**   | `/api/Participant/{id}`            | Update participant data by ID                            |
| **DELETE**   | `/api/Participant/{id}`            | Delete participant data by ID                            |
| **POST**   | `/api/Question/GetAnswers`            | Get questions answer by question id                |
| **GET**   | `/api/Question`            | Get all questions                      |
| **GET**   | `/api/Question/{id}`            | Get question by ID                      |
| **PUT**   | `/api/Question/{id}`            | Update question data by ID                      |
| **DELETE**   | `/api/Question/{id}`            | Delete question data by ID                      |

# Getting Started

Follow these steps to set up the project:

### 1. Download Repositories
* Navigate to Directory
```bash
cd /path/to/your/directory
```
* Clone Repositories
```bash
git clone https://github.com/shofwanshiddiq/QuizAPI
```

### 2. Open the Project in Visual Studio
* Select NetWebApi.sln > Open

### 3. Set Up Connection
* Go to file Web.config > Find tag <connectionString> > change all the data-source in every item to your local server

### 4. Run the Project
* Click on NewWebApi in Solution Explorer > Rebuild
* Start the Project on IIS Express(Google Chrome)


# Gallery

<img src="https://github.com/user-attachments/assets/386a04c6-980f-4828-a6e9-df6cc33e0b26" alt="Image 1" style="width: 400px;">
