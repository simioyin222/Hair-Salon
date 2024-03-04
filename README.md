# Eau Claire's Salon Web Application

## Developed By Simi Oyin

### Technologies Used
- C#
- HTML
- CSS
- Bootstrap
- .NET 6
- ASP.NET Core MVC
- Razor View Engine
- MySQL Workbench
- MySQL Community Server
- Entity Framework Core

### Description
Eau Claire's Salon is a C# web application designed to help Claire, the salon owner, manage her stylists and their clients effectively. Upon landing on the splash page, users are greeted with "Welcome to Eau Claire's Salon!" and can navigate through the application to view anything, but must be registred and logged in to perform any CRUD functionalities(create, read, update, and delete) with  stylists and clients. Note that clients can only be added after a stylist has been added, as they must be associated with an existing stylist. The application leverages technologies such as ASP.NET Core MVC for web functionality, Entity Framework Core for database operations, and Bootstrap for styling. Utilizes a many-to-many relationship between the two classes -- stylists and clients. Data annotations and conditionals are in place to validate user input. User authentication and autherization are in place for personalized features. 

### Setup/Installation Requirements

#### Prerequisites
- MySQL and MySQL Workbench installed on your machine. Installation guides:
  - MySQL: https://dev.mysql.com/doc/mysql-installation-excerpt/5.7/en/
  - MySQL Workbench: https://dev.mysql.com/doc/workbench/en/

#### Project Setup
1. Open your terminal and navigate to the directory where you want to clone the repository.
2. Clone the project using:
   git clone https://github.com/simioyin222/HAIRSALON.git
3. Navigate to the `HairSalon` project directory.
4. Create a `appsettings.json` file in the root directory with the following content, replacing placeholders with your MySQL username and password:
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=localhost;Port=3306;database=cemy_oyin;uid=[YOUR-USERNAME-HERE];pwd=[YOUR-PASSWORD-HERE];"
     }
   }

#### Database Setup
1. Open MySQL Workbench and navigate to Navigator > Administration window > Data Import/Restore.
2. Choose 'Import from Self-Contained File' and select the `cemy_oyin.sql` file located in the project's root directory.
3. In 'Default Schema to be Imported To', click the 'New' button and specify the database name as `cemy_oyin` (or another name, adjusting `appsettings.json` accordingly).
4. Go to the 'Import Progress' tab and start the import by clicking 'Start Import'.

#### Running the Application
- In the terminal, navigate to the `HairSalon` directory and run the application:
  dotnet watch run
  or use `dotnet run` to start the application without the watch feature.

### Known Bugs
Please report any bugs to simi.oyinkolade@gmail.com.

### Contributing
Contributions to improve the application are welcome. Fork the repository, make your changes, and submit a pull request.

### License
MIT License

Copyright (c) 2023 Simi Oyin

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions: