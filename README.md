## Table of contents
* [General info](#general-info)
* [Technologies and tools](#technologies)
* [Setup](#setup)

## General info
Newsletter mail tests created as a part of recruitment process.
	
## Technologies and tools
Project is created with:
* .NET Core 3.1
* Selenium 4.1.0
* NUnit 3.12.0
* Restsharp 106.15.0
* VS 2019
* Postman 9.7.1
	
## Setup
**To run tests locally in VS:**


* Clone git repository git clone https://github.com/KatarzynaKluszczynskaGit/TSHNewsletterHomework.git
* Open solution in VS
* Restore nuget packages <br/>
![image](https://user-images.githubusercontent.com/80790156/148475495-c7eb9048-1ef4-4831-9cdb-78b6ae97c606.png)
* Rebuild solution <br/>
![image](https://user-images.githubusercontent.com/80790156/148474915-55e252b3-d174-40f6-a25b-fb29cde42b0e.png)
* Run tests in Test Explorer <br/>
![image](https://user-images.githubusercontent.com/80790156/148475059-06107921-ff89-4235-83dc-5074730b6b4a.png)

**To run api tests in postman:**

* Import postman collection and environment from mailsac_postman_collection folder <br>
![image](https://user-images.githubusercontent.com/80790156/148476808-444d6d46-e402-4a27-9bf3-383b801b7847.png)

* Run postman collection
![image](https://user-images.githubusercontent.com/80790156/148476911-a99df904-4cdc-40f7-b3c3-92709d83c479.png) 
<br>
Ensure at least 1 mail is sent to tshnewsletteremail@mailsac.com inbox (in other case all tests will fail)
