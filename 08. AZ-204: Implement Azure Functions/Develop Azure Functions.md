- [Create an Azure Function by using Visual Studio Code](#exercise-create-an-azure-function-by-using-visual-studio-code)
  - [Prerequisites](#prerequisites)
  - [Create your local project](#create-your-local-project)
  - [Run the function locally](#run-the-function-locally)
  - [Sign in to Azure](#sign-in-to-azure)
  - [Publish the project to Azure](#publish-the-project-to-azure)
  - [Run the function in Azure](#run-the-function-in-azure)
  - [Clean up resources](#clean-up-resources)



# Develop Azure Functions

A function contains two important pieces - your code, which can be written in a variety of languages, and some config, the function.json file. For compiled languages, this config file is generated automatically from annotations in your code. For scripting languages, you must provide the config file yourself.

The function.json file defines the function's trigger, bindings, and other configuration settings. Every function has one and only one trigger. The runtime uses this config file to determine the events to monitor and how to pass data into and return data from a function execution. The following is an example function.json file.

```json
{
    "disabled":false,
    "bindings":[
        // ... bindings here
        {
            "type": "bindingType",
            "direction": "in",
            "name": "myParamName",
            // ... more depending on binding
        }
    ]
}
```

The bindings property is where you configure both triggers and bindings. Each binding shares a few common settings and some settings which are specific to a particular type of binding. Every binding requires the following settings:

| Property  	| Types  	| Comments                                                                                                                         	|
|-----------	|--------	|----------------------------------------------------------------------------------------------------------------------------------	|
| type      	| string 	| Name of binding. For example, queueTrigger.                                                                                      	|
| direction 	| string 	| Indicates whether the binding is for receiving data into the function or sending data from the function. For example, in or out. 	|
| name      	| string 	| The name that is used for the bound data in the function. For example, myQueue.                                                  	|


# Function app

A function app provides an execution context in Azure in which your functions run. As such, it is the unit of deployment and management for your functions. A function app is comprised of one or more individual functions that are managed, deployed, and scaled together. All of the functions in a function app share the same pricing plan, deployment method, and runtime version. Think of a function app as a way to organize and collectively manage your functions.

**Note**

In Functions 2.x all functions in a function app must be authored in the same language. In previous versions of the Azure Functions runtime, this wasn't required.


# Folder structure

The code for all the functions in a specific function app is located in a root project folder that contains a host configuration file. The [host.json](https://docs.microsoft.com/en-us/azure/azure-functions/functions-host-json) file contains runtime-specific configurations and is in the root folder of the function app. A bin folder contains packages and other library files that the function app requires. Specific folder structures required by the function app depend on language:

- [C# compiled (.csproj)](https://docs.microsoft.com/en-us/azure/azure-functions/functions-dotnet-class-library#functions-class-library-project)
- [C# script (.csx)](https://docs.microsoft.com/en-us/azure/azure-functions/functions-reference-csharp#folder-structure)
- [F# script](https://docs.microsoft.com/en-us/azure/azure-functions/functions-reference-fsharp#folder-structure)
- [Java](https://docs.microsoft.com/en-us/azure/azure-functions/functions-reference-java#folder-structure)
- [JavaScript](https://docs.microsoft.com/en-us/azure/azure-functions/functions-reference-node#folder-structure)
- [Python](https://docs.microsoft.com/en-us/azure/azure-functions/functions-reference-python#folder-structure)


# Local development environments

Functions makes it easy to use your favorite code editor and development tools to create and test functions on your local computer. Your local functions can connect to live Azure services, and you can debug them on your local computer using the full Functions runtime.

The way in which you develop functions on your local computer depends on your language and tooling preferences. See [Code and test Azure Functions locally](https://docs.microsoft.com/en-us/azure/azure-functions/functions-develop-local) for more information.


**Warning**

Do not mix local development with portal development in the same function app. When you create and publish functions from a local project, you should not try to maintain or modify project code in the portal.


# Create triggers and bindings

Triggers are what cause a function to run. A trigger defines how a function is invoked and a function must have exactly one trigger. Triggers have associated data, which is often provided as the payload of the function.

Binding to a function is a way of declaratively connecting another resource to the function; bindings may be connected as input bindings, output bindings, or both. Data from bindings is provided to the function as parameters.

You can mix and match different bindings to suit your needs. Bindings are optional and a function might have one or multiple input and/or output bindings.

Triggers and bindings let you avoid hardcoding access to other services. Your function receives data (for example, the content of a queue message) in function parameters. You send data (for example, to create a queue message) by using the return value of the function.


# Trigger and binding definitions

Triggers and bindings are defined differently depending on the development language.

| Language                                	| Triggers and bindings are configured by...              	|
|-----------------------------------------	|---------------------------------------------------------	|
| C# class library                        	| decorating methods and parameters with C# attributes    	|
| Java                                    	| decorating methods and parameters with Java annotations 	|
| JavaScript/PowerShell/Python/TypeScript 	| updating function.json schema                           	|

For languages that rely on function.json, the portal provides a UI for adding bindings in the Integration tab. You can also edit the file directly in the portal in the Code + test tab of your function.

In .NET and Java, the parameter type defines the data type for input data. For instance, use string to bind to the text of a queue trigger, a byte array to read as binary, and a custom type to de-serialize to an object. Since .NET class library functions and Java functions don't rely on function.json for binding definitions, they can't be created and edited in the portal. C# portal editing is based on C# script, which uses function.json instead of attributes.

For languages that are dynamically typed such as JavaScript, use the dataType property in the function.json file. For example, to read the content of an HTTP request in binary format, set dataType to binary:

```json
{
    "dataType": "binary",
    "type": "httpTrigger",
    "name": "req",
    "direction": "in"
}
```

Other options for dataType are stream and string.


# Binding direction

All triggers and bindings have a direction property in the function.json file:

- For triggers, the direction is always in
- Input and output bindings use in and out
- Some bindings support a special direction inout. If you use inout, only the Advanced editor is available via the Integrate tab in the portal.

When you use attributes in a class library to configure triggers and bindings, the direction is provided in an attribute constructor or inferred from the parameter type.


# Azure Functions trigger and binding example

Suppose you want to write a new row to Azure Table storage whenever a new message appears in Azure Queue storage. This scenario can be implemented using an Azure Queue storage trigger and an Azure Table storage output binding.

Here's a function.json file for this scenario.

```json
{
  "bindings": [
    {
      "type": "queueTrigger",
      "direction": "in",
      "name": "order",
      "queueName": "myqueue-items",
      "connection": "MY_STORAGE_ACCT_APP_SETTING"
    },
    {
      "type": "table",
      "direction": "out",
      "name": "$return",
      "tableName": "outTable",
      "connection": "MY_TABLE_STORAGE_ACCT_APP_SETTING"
    }
  ]
}
```

The first element in the bindings array is the Queue storage trigger. The type and direction properties identify the trigger. The name property identifies the function parameter that receives the queue message content. The name of the queue to monitor is in queueName, and the connection string is in the app setting identified by connection.

The second element in the bindings array is the Azure Table Storage output binding. The type and direction properties identify the binding. The name property specifies how the function provides the new table row, in this case by using the function return value. The name of the table is in tableName, and the connection string is in the app setting identified by connection.


# C# script example

Here's C# script code that works with this trigger and binding. Notice that the name of the parameter that provides the queue message content is order; this name is required because the name property value in function.json is order.

```csharp
#r "Newtonsoft.Json"

using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;

// From an incoming queue message that is a JSON object, add fields and write to Table storage
// The method return value creates a new row in Table Storage
public static Person Run(JObject order, ILogger log)
{
    return new Person() { 
            PartitionKey = "Orders", 
            RowKey = Guid.NewGuid().ToString(),  
            Name = order["Name"].ToString(),
            MobileNumber = order["MobileNumber"].ToString() };  
}

public class Person
{
    public string PartitionKey { get; set; }
    public string RowKey { get; set; }
    public string Name { get; set; }
    public string MobileNumber { get; set; }
}
```

# JavaScript example

The same function.json file can be used with a JavaScript function:

```js
// From an incoming queue message that is a JSON object, add fields and write to Table Storage
// The second parameter to context.done is used as the value for the new row
module.exports = function (context, order) {
    order.PartitionKey = "Orders";
    order.RowKey = generateRandomId(); 

    context.done(null, order);
};

function generateRandomId() {
    return Math.random().toString(36).substring(2, 15) +
        Math.random().toString(36).substring(2, 15);
}
```


# Class library example

In a class library, the same trigger and binding information — queue and table names, storage accounts, function parameters for input and output — is provided by attributes instead of a function.json file. Here's an example:

```csharp
public static class QueueTriggerTableOutput
{
    [FunctionName("QueueTriggerTableOutput")]
    [return: Table("outTable", Connection = "MY_TABLE_STORAGE_ACCT_APP_SETTING")]
    public static Person Run(
        [QueueTrigger("myqueue-items", Connection = "MY_STORAGE_ACCT_APP_SETTING")]JObject order,
        ILogger log)
    {
        return new Person() {
                PartitionKey = "Orders",
                RowKey = Guid.NewGuid().ToString(),
                Name = order["Name"].ToString(),
                MobileNumber = order["MobileNumber"].ToString() };
    }
}

public class Person
{
    public string PartitionKey { get; set; }
    public string RowKey { get; set; }
    public string Name { get; set; }
    public string MobileNumber { get; set; }
}
```

# Additional Trigger and Binding resource

For more detailed examples of triggers and bindings please visit:

- [Azure Blob storage bindings for Azure Functions](https://docs.microsoft.com/en-us/azure/azure-functions/functions-bindings-storage-blob)
- [Azure Cosmos DB bindings for Azure Functions 2.x](https://docs.microsoft.com/en-us/azure/azure-functions/functions-bindings-cosmosdb-v2)
- [Timer trigger for Azure Functions](https://docs.microsoft.com/en-us/azure/azure-functions/functions-bindings-timer)
- [Azure Functions HTTP triggers and bindings](https://docs.microsoft.com/en-us/azure/azure-functions/functions-bindings-http-webhook)


# Connect functions to Azure services

Your function project references connection information by name from its configuration provider. It does not directly accept the connection details, allowing them to be changed across environments. For example, a trigger definition might include a connection property. This might refer to a connection string, but you cannot set the connection string directly in a function.json. Instead, you would set connection to the name of an environment variable that contains the connection string.

The default configuration provider uses environment variables. These might be set by [Application Settings](https://docs.microsoft.com/en-us/azure/azure-functions/functions-how-to-use-azure-function-app-settings?tabs=portal#settings) when running in the Azure Functions service, or from the [local settings file](https://docs.microsoft.com/en-us/azure/azure-functions/functions-develop-local#local-settings-file) when developing locally.


# Connection values

When the connection name resolves to a single exact value, the runtime identifies the value as a connection string, which typically includes a secret. The details of a connection string are defined by the service to which you wish to connect.

However, a connection name can also refer to a collection of multiple configuration items. Environment variables can be treated as a collection by using a shared prefix that ends in double underscores ```__```. The group can then be referenced by setting the connection name to this prefix.

For example, the connection property for a Azure Blob trigger definition might be Storage1. As long as there is no single string value configured with Storage1 as its name, Storage1__serviceUri would be used for the serviceUri property of the connection. The connection properties are different for each service.


# Configure an identity-based connection

Some connections in Azure Functions are configured to use an identity instead of a secret. Support depends on the extension using the connection. In some cases, a connection string may still be required in Functions even though the service to which you are connecting supports identity-based connections.

**Note**

Identity-based connections are not supported with Durable Functions.

When hosted in the Azure Functions service, identity-based connections use a [managed identity](https://docs.microsoft.com/en-us/azure/app-service/overview-managed-identity?toc=/azure/azure-functions/toc.json). The system-assigned identity is used by default, although a user-assigned identity can be specified with the credential and clientID properties. When run in other contexts, such as local development, your developer identity is used instead, although this can be customized using alternative connection parameters.


# Grant permission to the identity

Whatever identity is being used must have permissions to perform the intended actions. This is typically done by assigning a role in Azure RBAC or specifying the identity in an access policy, depending on the service to which you are connecting.

**Important**

Some permissions might be exposed by the target service that are not necessary for all contexts. Where possible, adhere to the principle of least privilege, granting the identity only required privileges.


# Exercise: Create an Azure Function by using Visual Studio Code

## Prerequisites

Before you begin make sure you have the following requirements in place:

- An Azure account with an active subscription. If you don't already have one, you can sign up for a free trial at https://azure.com/free.
- The [Azure Functions Core Tools](https://docs.microsoft.com/en-us/azure/azure-functions/functions-run-local#install-the-azure-functions-core-tools) version 3.x.
- [Visual Studio Code](https://code.visualstudio.com/) on one of the [supported platforms](https://code.visualstudio.com/docs/supporting/requirements#_platforms).
- [.NET Core 3.1](https://dotnet.microsoft.com/download/dotnet/3.1) is the target framework for the steps below.
- The [C# extension](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp) for Visual Studio Code.
- The [Azure Functions extension](https://marketplace.visualstudio.com/items?itemName=ms-azuretools.vscode-azurefunctions) for Visual Studio Code.



## Create your local project

In this section, you use Visual Studio Code to create a local Azure Functions project in C#. Later in this exercise, you'll publish your function code to Azure.

Choose the Azure icon in the Activity bar, then in the Azure: Functions area, select Create new project....

![image](https://user-images.githubusercontent.com/34960418/163142363-167366b2-9b23-44b9-b8c0-a07d32c9e6eb.png)


Choose a directory location for your project workspace and choose **Select**.

![image](https://user-images.githubusercontent.com/34960418/163142568-a9c172d4-523f-49b8-a44f-d82479b227da.png)

**Note**

Be sure to select a project folder that is outside of a workspace.


Provide the following information at the prompts:

- Select a language: Choose C#.
- Select a .NET runtime: Choose .NET Core 3.1
- Select a template for your project's first function: Choose HTTP trigger.
- Provide a function name: Type HttpExample.
- Provide a namespace: Type My.Functions.
- Authorization level: Choose Anonymous, which enables anyone to call your function endpoint.
- Select how you would like to open your project: Choose Add to workspace.

![image](https://user-images.githubusercontent.com/34960418/163142856-54bf3361-ecf6-4d9c-bf44-a4a84094d7cb.png)


The current version of the Azure Functions extension (version 4) only shows .NET 6 in the runtime list. You can change the Azure Functions version by selecting **Change Azure Functions version**.

![image](https://user-images.githubusercontent.com/34960418/163143160-9d694051-0741-4889-9146-2368fd010ba5.png)


In the runtime list, and then selecting **Azure Functions v3**

![image](https://user-images.githubusercontent.com/34960418/163143396-531b05d5-dd14-4ae0-ada9-2d5ef94fbfa8.png)


Select .Net Core 3 LTS

![image](https://user-images.githubusercontent.com/34960418/163143657-68629dd8-7cfc-4c59-a715-25c9fdbcfe5f.png)


Select a template for your project's first function: Choose **HTTP trigger**.

![image](https://user-images.githubusercontent.com/34960418/163143874-22aa342a-c232-4fe0-a8da-b608f6169094.png)


Provide a function name: Type **HttpExample**.

![image](https://user-images.githubusercontent.com/34960418/163143994-5603905f-59d7-4134-b89f-45a61527917e.png)


Provide a namespace: Type **My.Functions**.

![image](https://user-images.githubusercontent.com/34960418/163144120-2946b39d-5cdd-4a48-9be9-47509f2e913d.png)


Authorization level: Choose **Anonymous**, which enables anyone to call your function endpoint.

![image](https://user-images.githubusercontent.com/34960418/163144322-3292392f-7386-4d1b-b04d-b82d227e83e8.png)


Select how you would like to open your project: Choose **Add to workspace**.

Using this information, Visual Studio Code generates an Azure Functions project with an HTTP trigger.


## Run the function locally

Visual Studio Code integrates with Azure Functions Core tools to let you run this project on your local development computer before you publish to Azure.

To call your function, press **F5** to start the function app project. Output from Core Tools is displayed in the **Terminal** panel. Your app starts in the **Terminal** panel. You can see the URL endpoint of your HTTP-triggered function running locally.

![image](https://user-images.githubusercontent.com/34960418/163145303-cc8cd583-c539-4fce-b663-eba54c93e54c.png)


Execute the function by browser

![image](https://user-images.githubusercontent.com/34960418/163145601-71c286d8-5bbe-465d-9b5f-58d2e8e03648.png)

![image](https://user-images.githubusercontent.com/34960418/163145682-b746bfda-e801-4774-9a46-c93944949a1b.png)


With Core Tools running, go to the **Azure: Functions area**. Under **Functions**, expand **Local Project** > **Functions**. Right-click the **HttpExample** function and choose **Execute Function Now....**

![image](https://user-images.githubusercontent.com/34960418/163146326-c4e6624d-63e6-44a0-9a42-6f2a009ea465.png)


In **Enter request body** type the request message body value of { "name": "Azure" }. Press **Enter** to send this request message to your function. 

![image](https://user-images.githubusercontent.com/34960418/163146636-634e24c4-0d23-40b7-b28a-c99538588142.png)


When the function executes locally and returns a response, a notification is raised in Visual Studio Code. Information about the function execution is shown in **Terminal** panel.

![image](https://user-images.githubusercontent.com/34960418/163146779-77f13b92-fa20-4aa4-952c-291456ce75f2.png)


Press **Ctrl + C** to stop Core Tools and disconnect the debugger.

![image](https://user-images.githubusercontent.com/34960418/163147116-22da755b-03b2-4e73-9ce4-9567755fa07f.png)


After you've verified that the function runs correctly on your local computer, it's time to use Visual Studio Code to publish the project directly to Azure.


## Sign in to Azure

Before you can publish your app, you must sign in to Azure. If you're already signed in, go to the next section.

If you aren't already signed in, choose the Azure icon in the Activity bar, then in the Azure: Functions area, choose **Sign in to Azure...**

![image](https://user-images.githubusercontent.com/34960418/163147434-f276c564-69fa-455f-9f59-0ff395ddf340.png)


When prompted in the browser, choose your Azure account and sign in using your Azure account credentials. After you've successfully signed in, you can close the new browser window. The subscriptions that belong to your Azure account are displayed in the Side bar.

![image](https://user-images.githubusercontent.com/34960418/163147697-9b4dd19f-94b0-4f28-aa58-43a030b48311.png)


## Publish the project to Azure

In this section, you create a function app and related resources in your Azure subscription and then deploy your code.

**Important**

Publishing to an existing function app overwrites the content of that app in Azure.


Choose the Azure icon in the Activity bar, then in the Azure: Functions area, choose the **Deploy to Function app...** button.

![image](https://user-images.githubusercontent.com/34960418/163155870-bec27c84-396c-48a8-a408-b15741d60532.png)


Provide the following information at the prompts:

- Select Function App in Azure: Choose + Create new Function App. (Don't choose the Advanced option, which isn't covered in this article.)
- Enter a globally unique name for the function app: Type a name that is valid in a URL path. The name you type is validated to make sure that it's unique in Azure Functions.
- Select a runtime stack: Use the same choice you made in the Create your local project section above.
- Select a location for new resources: For better performance, choose a region near you.
- Select subscription: Choose the subscription to use. You won't see this if you only have one subscription.


Select Function App in Azure: **Choose + Create new Function App**. (Don't choose the Advanced option, which isn't covered in this article.)

![image](https://user-images.githubusercontent.com/34960418/163156249-7cf58a0d-054a-48a5-9d50-6a2f070e2372.png)


**Enter a globally unique name for the function app**: Type a name that is valid in a URL path. The name you type is validated to make sure that it's unique in Azure Functions.

![image](https://user-images.githubusercontent.com/34960418/163156405-5f2a7af4-9bbd-482f-8dd5-730af4725785.png)


**Select a runtime stack**: Use the same choice you made in the Create your local project section above.

![image](https://user-images.githubusercontent.com/34960418/163156608-aab4f82e-d1ab-4269-96a7-45659a757e9e.png)


**Select a location for new resources**: For better performance, choose a region near you.

![image](https://user-images.githubusercontent.com/34960418/163156756-1fbcc1e7-7867-478b-a437-a7700cdc7c9f.png)


The extension shows the status of individual resources as they are being created in Azure in the notification area.

![image](https://user-images.githubusercontent.com/34960418/163156957-a768f480-87ab-4d29-88e9-029b0f2aa4cd.png)


When completed, the following Azure resources are created in your subscription, using names based on your function app name:

- A resource group, which is a logical container for related resources.
- A standard Azure Storage account, which maintains state and other information about your projects.
- A consumption plan, which defines the underlying host for your serverless function app.
- A function app, which provides the environment for executing your function code. A function app lets you group functions as a logical unit for easier management, deployment, and sharing of resources within the same hosting plan.
- An Application Insights instance connected to the function app, which tracks usage of your serverless function.
- A notification is displayed after your function app is created and the deployment package is applied.

![image](https://user-images.githubusercontent.com/34960418/163157291-49d544e3-e67c-4567-bd00-a7bdf87a586d.png)

![image](https://user-images.githubusercontent.com/34960418/163157264-3edc26dd-b8f2-4dbc-95e2-a5c5a501380c.png)


## Run the function in Azure

Back in the **Azure: Functions** area in the side bar, expand your subscription, your new function app, and **Functions**. **Right-click** the **HttpExample** function and choose **Execute Function Now**....

![image](https://user-images.githubusercontent.com/34960418/163157849-a738711c-fa57-44fc-9ed0-84ff4522cd88.png)


In Enter request body you see the request message body value of { "name": "Azure" }. Press Enter to send this request message to your function.

![image](https://user-images.githubusercontent.com/34960418/163158171-77aacfd6-b3e9-4303-bf16-c336ec5841e3.png)


When the function executes in Azure and returns a response, a notification is raised in Visual Studio Code.

![image](https://user-images.githubusercontent.com/34960418/163158213-0830da82-c2ee-45c6-97f5-17e7f6fc701c.png)


## Clean up resources

Use the following steps to delete the function app and its related resources to avoid incurring any further costs.

In Visual Studio Code, press **F1** to open the command palette. In the command palette, search for and select Azure Functions: Open in portal.

![image](https://user-images.githubusercontent.com/34960418/163158535-7ee739a9-e98c-4092-a698-0e95c1629785.png)


Choose your function app from the list, and press Enter. The function app page opens in the Azure portal.

![image](https://user-images.githubusercontent.com/34960418/163158665-3df78bf1-2e22-4f88-8dbf-d0cfb8822fd0.png)


In the **Overview** tab, select the named link next to **Resource group**.

![image](https://user-images.githubusercontent.com/34960418/163158899-6c1b1cf5-8fac-40e0-ab7b-319710ee8b79.png)


In the **Resource group** page, review the list of included resources, and verify that they are the ones you want to delete.

![image](https://user-images.githubusercontent.com/34960418/163159032-6d707021-bf97-4bd2-bfdf-c594edf51f0a.png)


Select **Delete resource group**, and follow the instructions.

![image](https://user-images.githubusercontent.com/34960418/163159177-86644cb5-b235-46fc-9f29-376a26d023b3.png)


Deletion may take a couple of minutes. When it's done, a notification appears for a few seconds. You can also select the bell icon at the top of the page to view the notification.


