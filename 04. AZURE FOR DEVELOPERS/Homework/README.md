Create a function application with one HTTP triggered function that conforms to the following rules:

- Accepts a parameter name. If no parameter is submitted, an informational message is returned
- If a name is submitted, then
  - Inserts a row in table Names in an Azure SQL database. The row should have the following attributes:
    - Unique identifier (it may be a simple integer)
    - Timestamp when the record is created
    - The submitted name
  - Returns a text showing when was the first record for a name inserted and how many records with the same name exists in the table
