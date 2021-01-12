# _Library_

#### _DATE 01.11.2021_

#### By _** Patrick Osten & Bess Campbell**_

## Description
- This application was made as part of the Epicodus Coding bootcamp coursework.


![](ReadMeAssets/recording.gif)

## Setup/Installation Requirements

<details>

Software Requirements
* An internet browser of your choice; I prefer Chrome
* A code editor; I prefer VSCode
* .NET Core
* MySQL Workbench

Open by Downloading or Cloning
* Navigate to <>
* Download this repository to your computer by clicking the green Code button and 'Download Zip'
* Or clone the repository with `git clone `

AppSettings
* This project requires an AppSettings file. Create your `appsettings.json` file in the main `Library` directory. 
* Format your `appsettings.json` file as follows including your unique password that was created at MySqlWorkbench installation:
```
{
  "ConnectionStrings":{
      "DefaultConnection": "Server=localhost;Port=3306;database=library;uid=root;pwd=<YourPassword>;"
  }
}
```
* Update the Server, Port, and User ID as needed.

</details>

## Launching the Application
* Navigate to Library.Solution/Library and type `dotnet restore` into the terminal
* Then, in the same project folder, type `dotnet ef database update` to create the database. 
* To open in your browser type `dotnet run` 

## User Stories
<details>

| User Stories                                                                                                                                                                                                                                                               |   |
|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|---|
| As a librarian, I want to create, read, update, delete, and list books in the catalog, so that we can keep track of our inventory.                                                                                                                                            |   |
| As a librarian, I want to search for a book by author or title, so that I can find a book when there are a lot of books in the library. |   |
| As a librarian, I want to enter multiple authors for a book, so that I can include accurate information in my catalog. (Hint: make an authors table and a books table with a many-to-many relationship.)                                                                                                             |   |
| As a patron, I want to check a book out, so that I can take it home with me.                                                                                          |   |
| As a patron, I want to know how many copies of a book are on the shelf, so that I can see if any are available. (Hint: make a copies table; a book should have many copies.)                      |   |
| As a patron, I want to see a history of all the books I checked out, so that I can look up the name of that awesome sci-fi novel I read three years ago. (Hint: make a checkouts table that is a join table between patrons and copies.)                                                              |   | As a patron, I want to know when a book I checked out is due, so that I know when to return it. |   |  As a librarian, I want to see a list of overdue books, so that I can call up the patron who checked them out and tell them to bring them back - OR ELSE!
</details>
<br>

## SQL Chart
![](./ReadMeAssets/library_sql.PNG)

## Known Bugs

This application has no known bugs. 

## Support and contact details

Patrick Osten at <posten.coding@gmail.com> 
Bess Campbell at <bess.k.campbell@gmail.com>


## Technologies Used

* [Bootstrap Components](https://getbootstrap.com/docs/3.3/components/)
* C#
* Razor
* Entity Framework Core
* MySql Workbench
* .NET Core
* Coffee

### License

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

Copyright (c) 2020 **_Patrick Osten, Bess Campbell_**