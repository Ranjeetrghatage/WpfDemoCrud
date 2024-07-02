# Employee Management System

## Introduction

Welcome to the Employee Management System! This project is designed to manage employee records in a database using MSSQL Server. Follow the steps below to set up and run the project on your local machine.

## Clone the Project

- Clone the project, follow the steps below to set it up.

## Prerequisites
- MSSQL Server
- MSSQL Server Management Studio (SSMS)
- .NET framework (for running the project)
- Your preferred IDE (Visual Studio)

## Setup Instructions

### Step 1: Create the Database

1. Open MSSQL Server Management Studio (SSMS).
2. Tap on `New Query`.
3. Type the following command to create the database and execute it:
   
    - CREATE DATABASE Employee_management_System;
    
### Step 2: Create the Table and Insert Data

1. Ensure you are using the correct database by executing:
    
    - USE Employee_management_System;
      
2. Create the `EmployeeTb` table and insert sample data by executing the following commands:
   
    CREATE TABLE EmployeeTb (
        Emp_id INT NOT NULL PRIMARY KEY,
        Emp_name VARCHAR(255) NOT NULL,
        Emp_pno VARCHAR(255) NOT NULL,
        Emp_salary DECIMAL(18, 2),
        Emp_gender VARCHAR(50),
        Emp_age INT,
        Emp_department VARCHAR(255),
        Emp_designation VARCHAR(255)
    );

    INSERT INTO EmployeeTb (Emp_id, Emp_name, Emp_pno, Emp_salary, Emp_gender, Emp_age, Emp_department, Emp_designation)
    VALUES 
    (1, 'Alice Johnson', '555-1234', 75000.00, 'Female', 29, 'HR', 'Manager'),
    (2, 'Bob Smith', '555-5678', 65000.00, 'Male', 34, 'IT', 'Developer'),
    (3, 'Charlie Brown', '555-8765', 60000.00, 'Male', 28, 'Finance', 'Analyst'),
    (4, 'Diana Prince', '555-4321', 85000.00, 'Female', 32, 'IT', 'Team Lead'),
    (5, 'Evan Williams', '555-6789', 72000.00, 'Male', 30, 'Marketing', 'Coordinator'),
    (6, 'Fiona Gallagher', '555-9876', 20000.00, 'Female', 25, 'Customer Service', 'Representative'),
    (7, 'George Martin', '555-5432', 68000.00, 'Male', 40, 'HR', 'Recruiter'),
    (8, 'Helen White', '555-6543', 79000.00, 'Female', 35, 'Finance', 'Manager'),
    (9, 'Ian Black', '555-3210', 71000.00, 'Male', 29, 'IT', 'Developer'),
    (10, 'Julia Roberts', '555-2109', 90000.00, 'Female', 38, 'Marketing', 'Director');

    SELECT * FROM EmployeeTb;

### Step 3: Configure the Project

1. Navigate to `Projects/DemoSubPrj/Models/SubPrjService` class.
2. Change the `connectionString` to match your local SQL Server instance. For example:

   - connectionString = "Data Source=YOUR_SERVER_NAME;Initial Catalog=Employee_management_System;Integrated Security=True;Encrypt=false";
   
   Replace `YOUR_SERVER_NAME` with your actual SQL Server name. In the example connection string provided:
   
### Step 4: Run the Project

1. Load the project.
2. Build and run the project.

## Conclusion

By following the above steps, you should be able to set up and run on your local machine.
