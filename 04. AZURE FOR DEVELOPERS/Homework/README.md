Create a function application with one HTTP triggered function that conforms to the following rules:

- Accepts a parameter name. If no parameter is submitted, an informational message is returned
- If a name is submitted, then
  - Inserts a row in table Names in an Azure SQL database. The row should have the following attributes:
    - Unique identifier (it may be a simple integer)
    - Timestamp when the record is created
    - The submitted name
  - Returns a text showing when was the first record for a name inserted and how many records with the same name exists in the table


# Create the Resource group

![image](https://user-images.githubusercontent.com/34960418/157232062-f1b97481-f869-4333-b9ff-1a0fea7ab030.png)


# Create a Function App

![image](https://user-images.githubusercontent.com/34960418/157232364-fbc1c9a2-0a60-4c22-8834-ab7b524bf737.png)

![image](https://user-images.githubusercontent.com/34960418/157232503-a2f5a227-e477-46e2-bdb2-1160123f9880.png)


# Create a HTTP triggered function

![image](https://user-images.githubusercontent.com/34960418/157232855-75013237-7496-4a9f-921e-bf3f81bf7670.png)

![image](https://user-images.githubusercontent.com/34960418/157233924-7735f559-e22d-4488-b701-760dc53cccde.png)


# Create SQL server and database

![image](https://user-images.githubusercontent.com/34960418/157234381-7c535420-6ddc-42b3-b8e0-4fbd012e5c73.png)

![image](https://user-images.githubusercontent.com/34960418/157236843-0d8b4abf-5b1b-4805-ae46-c596eff59f82.png)
