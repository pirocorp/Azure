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

![image](https://user-images.githubusercontent.com/34960418/157239374-3cbf348a-1ff5-407f-b53b-96c686a51aa6.png)


# Http Function Code

```csharp
#r "Newtonsoft.Json"

using System.Net;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;

public static async Task<IActionResult> Run(HttpRequest req, ILogger log)
{
    log.LogInformation("C# HTTP trigger function processed a request.");

    string name = req.Query["name"];

    string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
    dynamic data = JsonConvert.DeserializeObject(requestBody);
    name = name ?? data?.name;

    string responseMessage = string.Empty;

    if(string.IsNullOrEmpty(name))
    {
        responseMessage = "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response.";

        return new OkObjectResult(responseMessage);
    }

    var str = "Server=tcp:funcsqlsrv.database.windows.net,1433;Initial Catalog=funcappdb;Persist Security Info=False;User ID=demosa;Password=DemoPassword-2022;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
    
    using (SqlConnection conn = new SqlConnection(str))
    {
        conn.Open();

        var timestamp = DateTime.Now.Ticks;        

        var insertQuery = $"INSERT INTO Names VALUES ({timestamp}, '{name}')";

        using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
        {
            using (SqlDataReader reader = cmd.ExecuteReader());
        }

        var countQuery = $"SELECT COUNT(*) FROM Names WHERE Name='{name}'";

        int count = 0;

        using (SqlCommand cmd = new SqlCommand(countQuery, conn))
        {
            using (SqlDataReader reader = cmd.ExecuteReader()) 
            {
                if (reader.HasRows)
                {
                    reader.Read();
                    count = int.Parse(reader[0].ToString());
                };
            }
        }

        var firstTimestampQuery = $"SELECT TOP(1) Timestamp FROM Names WHERE Name='{name}'";

        long firstTimestamp = 0;

        using(SqlCommand cmd = new SqlCommand(firstTimestampQuery, conn))
        {
            using (var reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    reader.Read();

                    firstTimestamp = long.Parse(reader[0].ToString());
                } 
            }           
        }

        responseMessage = $"{firstTimestamp}: {name} - {count}";
    }

    return new OkObjectResult(responseMessage);
}
```
