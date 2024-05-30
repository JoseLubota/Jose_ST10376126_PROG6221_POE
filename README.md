# Recipe Creation Software

#  Project Description

This project focuses on the creation of a recipe app using object-oriented-programming standards including generic collections, delegates, etc.

#  How to run the project

Requirements: Microsoft Visual Studio, C#. Latest version 

The repository: https://github.com/JoseLubota/Jose_ST10376126_PROG6221_POE

Open the project solution through Visual Studio, in the folder you will something called solutuion exlporer, clisk there.
To run the software go to the following coordinates: 
Jose_ST10376126_PROG6221_POE(folder, it will have a green C# mark on its left, before its name)
    Program.cs
    Once you are with the file open open, click on run on the program toolsbar.
    It should create a window whose first question is "Enter the recipe name"

To run the unit test go to
    JoseST10376126_PROG221_POE.UnitTests
    RecipeTests.cs
    Click on the right button from your computer and select the option "Run Tests"
    The result should mention/contain 3 different tests.
    

#  References

https://www.geeksforgeeks.org/c-sharp-how-to-change-foreground-color-of-text-in-console/
https://www.w3schools.blog/c-sharp-list
https://www.w3schools.com/cs/cs_arrays_loop.php
https://web-p-ebscohost-com.ezproxy.iielearn.ac.za/ehost/ebookviewer/ebook/bmxlYmtfXzI5MTc3MDFfX0FO0?sid=f5055d80-d4b0-4010-      9877c1a2d34945af@redis&vid=0&format=EB&lpid=lp_xlv&rid=0     
https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/exceptions/exception-handling
https://learn.microsoft.com/en-us/dotnet/api/system.formatexception?view=net-8.0
https://sweetlife.org.za/how-much-to-eat-to-lose-weight/
https://learn.microsoft.com/en-us/dotnet/api/system.eventhandler?view=net-8.0
https://www.c-sharpcorner.com/article/event-handling-in-net-using-C-Sharp/
https://learn.microsoft.com/en-us/dotnet/core/testing/unit-testing-with-dotnet-test

# Changes made based on feedback 

He identified that my code had a poor implementation of error handling, especially regarding the type of data entered in the variables. To solve this, two methods were written; checkStringInput, a method used to verify if a string variable receives a string that meets some requirements such as it must not be null and must not just be a number, since the app is for recipe management the user should not only enter number in variable that represent descriptions, name, etc. The other one (checkDoubleInput) is that the number must be equal or greater; even if the user enters data different than a number, the error handling will be able to handle it.

