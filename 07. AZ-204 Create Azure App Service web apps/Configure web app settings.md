# Configure web app service

## Configure application settings

In App Service, app settings are variables passed as environment variables to the application code. For Linux apps and custom containers, App Service passes app settings to the container using the --env flag to set the environment variable in the container.

Application settings can be accessed by navigating to your app's management page and selecting Configuration > Application Settings.

![image](https://user-images.githubusercontent.com/34960418/162739298-502d79f3-a43c-46b2-afc0-ab303db3015e.png)


For ASP.NET and ASP.NET Core developers, setting app settings in App Service are like setting them in ```<appSettings>``` in Web.config or appsettings.json, but the values in App Service override the ones in Web.config or appsettings.json. You can keep development settings (for example, local MySQL password) in Web.config or appsettings.json, but production secrets (for example, Azure MySQL database password) safe in App Service. The same code uses your development settings when you debug locally, and it uses your production secrets when deployed to Azure.

App settings are always encrypted when stored (encrypted-at-rest).
  

## Adding and editing settings
  
To add a new app setting, click **New application setting**. If you are using deployment slots you can specify if your setting is swappable or not. In the dialog, you can stick the setting to the current slot.
  
![image](https://user-images.githubusercontent.com/34960418/162739479-f9ed42b1-c7da-4a85-a76e-76a8ab4a5aa5.png)
  
  
To edit a setting, click the **Edit** button on the right side.

![image](https://user-images.githubusercontent.com/34960418/162739664-e8e97f4a-1814-4797-ba8a-66c7057274f3.png)


When finished, click **OK**. Don't forget to click **Save** back in the Configuration page.

![image](https://user-images.githubusercontent.com/34960418/162739870-38858e8f-37b9-4ace-a9a3-53afebea27f3.png)


**Note**

In a default, or custom, Linux container any nested JSON key structure in the app setting name like ApplicationInsights:InstrumentationKey needs to be configured in App Service as ApplicationInsights__InstrumentationKey for the key name. In other words, any : should be replaced by __ (double underscore).


## Editing application settings in bulk

To add or edit app settings in bulk, click the **Advanced** edit button.

![image](https://user-images.githubusercontent.com/34960418/162740247-21fd155e-c40b-4ae5-ba26-13ec0e7dba87.png)


When finished, click **OK**. App settings have the following JSON formatting:

![image](https://user-images.githubusercontent.com/34960418/162740418-884d0b20-c9d3-426c-8089-23054f0ca1a0.png)


## Configure connection strings

For ASP.NET and ASP.NET Core developers the values you set in App Service override the ones in Web.config. For other language stacks, it's better to use app settings instead, because connection strings require special formatting in the variable keys in order to access the values. Connection strings are always encrypted when stored (encrypted-at-rest).

**Tip**

There is one case where you may want to use connection strings instead of app settings for non-.NET languages: certain Azure database types are backed up along with the app only if you configure a connection string for the database in your App Service app.

Adding and editing connection strings follow the same principles as other app settings and they can also be tied to deployment slots. Below is an example of connection strings in JSON formatting that you would use for bulk adding or editing.

```json
[
  {
    "name": "name-1",
    "value": "conn-string-1",
    "type": "SQLServer",
    "slotSetting": false
  },
  {
    "name": "name-2",
    "value": "conn-string-2",
    "type": "PostgreSQL",
    "slotSetting": false
  },
  ...
]
```


# Configure general settings

In the **Configuration > General settings** section you can configure some common settings for your app. Some settings require you to scale up to higher pricing tiers.

![image](https://user-images.githubusercontent.com/34960418/162741176-89a44603-030b-420b-bd22-c393d11fc60f.png)

Below is a list of the currently available settings:

- Stack settings: The software stack to run the app, including the language and SDK versions. For Linux apps and custom container apps, you can also set an optional start-up command or file.

![image](https://user-images.githubusercontent.com/34960418/162741381-2aa2baa0-3213-43b8-adb5-350f0962fb5f.png)

- Platform settings: Lets you configure settings for the hosting platform, including:
  - Bitness: 32-bit or 64-bit.
  - WebSocket protocol: For ASP.NET SignalR or socket.io, for example.
  - Always On: Keep the app loaded even when there's no traffic. By default, Always On is not enabled and the app is unloaded after 20 minutes without any incoming requests. It's required for continuous WebJobs or for WebJobs that are triggered using a CRON expression.
  - Managed pipeline version: The IIS pipeline mode. Set it to Classic if you have a legacy app that requires an older version of IIS.
  - HTTP version: Set to 2.0 to enable support for HTTPS/2 protocol.
  - ARR affinity: In a multi-instance deployment, ensure that the client is routed to the same instance for the life of the session. You can set this option to Off for stateless applications.
- Debugging: Enable remote debugging for ASP.NET, ASP.NET Core, or Node.js apps. This option turns off automatically after 48 hours.
- Incoming client certificates: require client certificates in mutual authentication. TLS mutual authentication is used to restrict access to your app by enabling different types of authentication for it.


# Configure path mappings

In the **Configuration > Path mappings** section you can configure handler mappings, and virtual application and directory mappings. The Path mappings page will display different options based on the OS type.

## Windows apps (uncontainerized)

![image](https://user-images.githubusercontent.com/34960418/162741721-ef801565-5429-4e27-b004-58a34cedf4cf.png)

For Windows apps, you can customize the IIS handler mappings and virtual applications and directories.

Handler mappings let you add custom script processors to handle requests for specific file extensions. To add a custom handler, select New handler. Configure the handler as follows:

- **Extension**: The file extension you want to handle, such as *.php or handler.fcgi.
- **Script processor**: The absolute path of the script processor. Requests to files that match the file extension are processed by the script processor. Use the path ```D:\home\site\wwwroot``` to refer to your app's root directory.
- **Arguments**: Optional command-line arguments for the script processor.

Each app has the default root path (```/```) mapped to ```D:\home\site\wwwroot```, where your code is deployed by default. If your app root is in a different folder, or if your repository has more than one application, you can edit or add virtual applications and directories.

You can configure virtual applications and directories by specifying each virtual directory and its corresponding physical path relative to the website root (```D:\home```). To mark a virtual directory as a web application, clear the **Directory** check box.


## Linux and containerized apps

You can add custom storage for your containerized app. Containerized apps include all Linux apps and also the Windows and Linux custom containers running on App Service. Click New Azure Storage Mount and configure your custom storage as follows:

- Name: The display name.
- Configuration options: Basic or Advanced.
- Storage accounts: The storage account with the container you want.
- Storage type: Azure Blobs or Azure Files. Windows container apps only support Azure Files.
- Storage container: For basic configuration, the container you want.
- Share name: For advanced configuration, the file share name.
- Access key: For advanced configuration, the access key.
- Mount path: The absolute path in your container to mount the custom storage.


# Enable diagnostic logging

There are built-in diagnostics to assist with debugging an App Service app. In this lesson, you will learn how to enable diagnostic logging and add instrumentation to your application, as well as how to access the information logged by Azure.

The table below shows the types of logging, the platforms supported, and where the logs can be stored and located for accessing the information.

| Type                   	| Platform       	| Location                                           	| Description                                                                                                                                                                                                                                                                                                              	|
|------------------------	|----------------	|----------------------------------------------------	|--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------	|
| Application logging    	| Windows, Linux 	| App Service file system and/or Azure Storage blobs 	| Logs messages generated by your application code. The messages can be generated by the web framework you choose, or from your application code directly using the standard logging pattern of your language. Each message is assigned one of the following categories: Critical, Error, Warning, Info, Debug, and Trace. 	|
| Web server logging     	| Windows        	| App Service file system or Azure Storage blobs     	| Raw HTTP request data in the W3C extended log file format. Each log message includes data like the HTTP method, resource URI, client IP, client port, user agent, response code, and so on.                                                                                                                              	|
| Detailed error logging 	| Windows        	| App Service file system                            	| Copies of the .htm error pages that would have been sent to the client browser. For security reasons, detailed error pages shouldn't be sent to clients in production, but App Service can save the error page each time an application error occurs that has HTTP code 400 or greater.                                  	|
| Failed request tracing 	| Windows        	| App Service file system                            	| Detailed tracing information on failed requests, including a trace of the IIS components used to process the request and the time taken in each component. One folder is generated for each failed request, which contains the XML log file, and the XSL stylesheet to view the log file with.                           	|
| Deployment logging     	| Windows, Linux 	| App Service file system                            	| Helps determine why a deployment failed. Deployment logging happens automatically and there are no configurable settings for deployment logging.                                                                                                                                                                         	|

## Enable application logging (Windows)

To enable application logging for Windows apps in the Azure portal, navigate to your app and select **App Service logs**. Select **On** for either **Application Logging (Filesystem)** or **Application Logging (Blob)**, or both. The Filesystem option is for temporary debugging purposes, and turns itself off in 12 hours. The Blob option is for long-term logging, and needs a blob storage container to write logs to. You can also set the Level of details included in the log as shown in the table below.

| Level       	| Included categories                                           	|
|-------------	|---------------------------------------------------------------	|
| Disabled    	| None                                                          	|
| Error       	| Error, Critical                                               	|
| Warning     	| Warning, Error, Critical                                      	|
| Information 	| Info, Warning, Error, Critical                                	|
| Verbose     	| Trace, Debug, Info, Warning, Error, Critical (all categories) 	|


When finished, select **Save**.

![image](https://user-images.githubusercontent.com/34960418/162743874-5f4e54e7-5a51-48b3-aa07-dcd8835ed8c7.png)


## Enable application logging (Linux/Container)

In **App Service logs** set the **Application logging** option to **File System**. In **Quota (MB)**, specify the disk quota for the application logs. In **Retention Period (Days)**, set the number of days the logs should be retained. When finished, select **Save**.


## Enable web server logging

For **Web server logging**, select **Storage** to store logs on blob storage, or **File System** to store logs on the App Service file system. In **Retention Period (Days)**, set the number of days the logs should be retained. When finished, select **Save**.

![image](https://user-images.githubusercontent.com/34960418/162744494-2294ba92-bace-4eb9-a6e1-948a7ef92fad.png)


## Add log messages in code

In your application code, you use the usual logging facilities to send log messages to the application logs. For example:

ASP.NET applications can use the System.Diagnostics.Trace class to log information to the application diagnostics log. For example:

```csharp
System.Diagnostics.Trace.TraceError("If you're seeing this, something bad happened");
```

By default, ASP.NET Core uses the Microsoft.Extensions.Logging.AzureAppServices logging provider.


## Stream logs

Before you stream logs in real time, enable the log type that you want. Any information written to files ending in .txt, .log, or .htm that are stored in the /LogFiles directory (d:/home/logfiles) is streamed by App Service.

**Note**

Some types of logging buffer write to the log file, which can result in out of order events in the stream. For example, an application log entry that occurs when a user visits a page may be displayed in the stream before the corresponding HTTP log entry for the page request.


Azure portal - To stream logs in the Azure portal, navigate to your app and select Log stream. 

![image](https://user-images.githubusercontent.com/34960418/162746245-b523bd29-7c43-4a3e-995c-38754be71acd.png)


Azure CLI - To stream logs live in Cloud Shell, use the following command:

```bash
az webapp log tail --name appname --resource-group myResourceGroup
```

![image](https://user-images.githubusercontent.com/34960418/162746551-383b9b50-f7da-4264-8811-56dc717fdab9.png)
