# TestAutomation

# Lesson 1 (Selenium Web Driver for C#)
Hometask:  
- Open https://www.selenium.dev ;
- Navigate to the documentation page;
- Check that samples for each supported language is present on a page (Java, Python, C#, Ruby, JavaScript, Kotlin);
- Check supported languages and area with code a little bit down the page;
- Please, use Page Object pattern in your project.

# Lesson 2 (Locators(XPath/CSS))
Hometask:  
Implement several auto tests (positive, negative) according to this scenario:​  
1. Go to https://allo.ua/ru/ ;​  
2. Switch header theme to light/ city/ language and verify that it has been worked;​  
3. Enter 2 appropriated letters in the search bar, for example, “lg” and select the first item of the popup list;​  
4. Verify that items list for first page contains elements with appropriate title;​  
5. Filter items (price, manufacturer, discount);​  
6. Click on first element and verify headers and description;​  
7. Choose the color of device and verify that it has been changed;​  
8. Click on button ‘Buy’ and verify that popup is displayed and contains all appropriated fields;​  
9. Return to the items search and choose another product;​  
10. Click on button ‘Buy’ and verify that popup is displayed and contains all appropriated fields;​  
11. Close popup and verify that your bucket contains two products.​  

# Lesson 3 (WebElement. Explicit & Implicit Waits​)
Hometask:  
As you are already familiar with waits, try to use different types of waits and mix them to investigate test behavior.  
Also, try to be using different expected conditions for the explicit waits.  

# Lesson 7 (DB and ORM)
Hometask:  
SQL Server:  
Part 1:​  
- Install SQL Server locally and connect to it with SSMS​  
- Populate ‘Master’ DB with Tables and Data (provided in next slides)​  

Part 2:​  
Use Dapper to create 3 Automation Tests (NUnit or XUnit):​  
- Validate that there are Persons who bought Cars NOT in their home City​  
- Validate that All Persons who bought cars are older than their BuyersInfo year​  
- Validate that All Persons bought Cars (Should Fail)​  

Part 3:​  
- Import Entity Framework Models for Master DB​  
- Create Same tests for Entity Framework as you did for Dapper​  

​(Optional) MongoDB​:  
Part 1:​  
- Install MongoDB Locally and connect with Compass​  
- Create 2 collections with provided files​  

Part 2:​  
Use MongoDB library to create 3 Automation Tests (NUnit or XUnit):​  
- Validate that user ‘Harris’ has alignment ‘Evil’​  
- Validate that All Alignments have at least one user that uses them​  
- Validate that there are ‘Neutral’ Alignments born after 1900 (Should Fail)​  

# Lesson 8 (Test runners)
Hometask:  
1. Go to https://xunit.net/;​  
2. In first test check that xUnit logo is present;​  
3. In second test check that Table of Context section contains Documentation;​  
4. Think what to include to Setup and Teardown;​  
5. Create both tests using each runner (separetly): NUnit, xUnit and MSTest.​  

# Lesson 9 (Testing approaches)
Hometask:  
Go to https://www.demoblaze.com/index.html .​  
Create test that will check that sign up is successful for next users:​  
- user that has only special characters in login;​  
- user that has login in both upper and lower case;​  
- user that has only 1 letter in password;​  
- user that has only numbers in password.​  
Create test that will check that users above can be logged in.​  
Create test that will check that user can purchase products from different products categories (Phones/Laptops/Monitors).​  
Use 1 of BDD-frameworks, think where you can use tables.​  


​

​
