# DivergentWarehouseTest
Full Stack Developer Warehouse Test

Here is my solution for the warehouse test. This project uses Entity Framework Core version 7 as the primary data access technology.

## Technology Stack
- Entity Framework Core v7: My primary data access technology.
- .NET Core: This is what I use to build and run the project.
- C#: This is my primary programming language along with Javascript (primarily Jquery) in the Razor Views. 
- Visual Studio: I used this IDE. 
- Microsoft SQL Server: This is the database management system I used.

## Getting Started
To run my project, you will need to have the following software installed on your system:

.NET Core SDK
Visual Studio

Once you have the necessary software installed, you can follow these steps to run the project:

1. Clone the repository to your local machine.
2. Open the project in Visual Studio.
3. Build the project to restore the NuGet packages and build the solution.
4. Open the appsettings.json file and update the connection string to point to your local instance of SQL Server.
5. Open the Package Manager Console and run the following command to create the database and apply the migrations:
6. Copy code
  ```
  Update-Database
  ```
7. Start the application by pressing F5 or by clicking the Start button in Visual Studio.
8. To view, go to Chrome and paste this url: https://localhost:7201/Warehouses

## Code Structure 
I am using Razor controllers and views for my User Interface. The WarehouseController contains a submit action that creates a new warehouse, 12 zones and the corresponding shelves (based on how many names are created). Each zone is only allowed 10 shelves and the way I account for this is disabling the Add Shelf button once 10 input fields are created per zone. I currently am sending all the data to the controller in a JSON string and checking if any zones have duplicate shelves. If so, a message will alert failure on the frontend. If I had more time, I would create frontend validation so that the controller is only called if necessary. I have 3 tables: warehouse, zone and shelf. The warehouse table is simply an id. The zone table has a foriegn key to warehouse and a primary key for the current zone. The shelf table has a forieng key to zone, a primary key of id and a unique shelf name. My UI is very simple. There are 12 zones and you can add up to 10 shelves per zone. I am currently creating 12 zones per warehouse no matter if they have shelves or not and if more time, I would refine this. In addition, if more time, I would create a cleaner UI that maybe has an index page that allows the user to input a number of shelves per zone and then on submit, go to a new page with a tab strip view where each tab has input fields for the inputted number of shelves created for that zone. Just something to let the user focus on one zone at a time. 

## Unit Tests
I did not have time to create unit tests. 
