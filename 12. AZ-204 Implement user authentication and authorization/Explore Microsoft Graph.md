# Microsoft Graph

Microsoft Graph is the gateway to data and intelligence in Microsoft 365. It provides a unified programmability model that you can use to access the tremendous amount of data in Microsoft 365, Windows 10, and Enterprise Mobility + Security.

![image](https://user-images.githubusercontent.com/34960418/164709921-4b822f26-9175-45ce-8f3f-090a755cf2bb.png)

In the Microsoft 365 platform, three main components facilitate the access and flow of data:

- The Microsoft Graph API offers a single endpoint, https://graph.microsoft.com. You can use REST APIs or SDKs to access the endpoint. Microsoft Graph also includes a powerful set of services that manage user and device identity, access, compliance, security, and help protect organizations from data leakage or loss.
- Microsoft Graph connectors work in the incoming direction, delivering data external to the Microsoft cloud into Microsoft Graph services and applications, to enhance Microsoft 365 experiences such as Microsoft Search. Connectors exist for many commonly used data sources such as Box, Google Drive, Jira, and Salesforce.
- Microsoft Graph Data Connect provides a set of tools to streamline secure and scalable delivery of Microsoft Graph data to popular Azure data stores. The cached data serves as data sources for Azure development tools that you can use to build intelligent applications.


# Query Microsoft Graph by using REST

Microsoft Graph is a RESTful web API that enables you to access Microsoft Cloud service resources. After you register your app and get authentication tokens for a user or service, you can make requests to the Microsoft Graph API.

The Microsoft Graph API defines most of its resources, methods, and enumerations in the OData namespace, microsoft.graph, in the [Microsoft Graph metadata](https://docs.microsoft.com/en-us/graph/traverse-the-graph). A small number of API sets are defined in their sub-namespaces, such as the [call records API](https://docs.microsoft.com/en-us/graph/api/resources/callrecords-api-overview) which defines resources like [callRecord](https://docs.microsoft.com/en-us/graph/api/resources/callrecords-callrecord) in microsoft.graph.callRecords.

Unless explicitly specified in the corresponding topic, assume types, methods, and enumerations are part of the microsoft.graph namespace.


# Call a REST API method

To read from or write to a resource such as a user or an email message, you construct a request that looks like the following:

```http
{HTTP method} https://graph.microsoft.com/{version}/{resource}?{query-parameters}
```

The components of a request include:

- {HTTP method} - The HTTP method used on the request to Microsoft Graph.
- {version} - The version of the Microsoft Graph API your application is using.
- {resource} - The resource in Microsoft Graph that you're referencing.
- {query-parameters} - Optional OData query options or REST method parameters that customize the response.

After you make a request, a response is returned that includes:

- Status code - An HTTP status code that indicates success or failure.
- Response message - The data that you requested or the result of the operation. The response message can be empty for some operations.
- nextLink - If your request returns a lot of data, you need to page through it by using the URL returned in @odata.nextLink.


# HTTP methods

Microsoft Graph uses the HTTP method on your request to determine what your request is doing. The API supports the following methods.

| Method 	| Description                                  	|
|--------	|----------------------------------------------	|
| GET    	| Read data from a resource.                   	|
| POST   	| Create a new resource, or perform an action. 	|
| PATCH  	| Update a resource with new values.           	|
| PUT    	| Replace a resource with a new one.           	|
| DELETE 	| Remove a resource.                           	|

- For the CRUD methods GET and DELETE, no request body is required.
- The POST, PATCH, and PUT methods require a request body, usually specified in JSON format, that contains additional information, such as the values for properties of the resource.


# Version

Microsoft Graph currently supports two versions: v1.0 and beta.

- v1.0 includes generally available APIs. Use the v1.0 version for all production apps.
- beta includes APIs that are currently in preview. Because we might introduce breaking changes to our beta APIs, we recommend that you use the beta version only to test apps that are in development; do not use beta APIs in your production apps.


# Resource

A resource can be an entity or complex type, commonly defined with properties. Entities differ from complex types by always including an id property.

Your URL will include the resource you are interacting with in the request, such as me, user, group, drive, and site. Often, top-level resources also include relationships, which you can use to access additional resources, like me/messages or me/drive. You can also interact with resources using methods; for example, to send an email, use me/sendMail.

Each resource might require different permissions to access it. You will often need a higher level of permissions to create or update a resource than to read it. For details about required permissions, see the method reference topic.


# Query parameters

Query parameters can be OData system query options, or other strings that a method accepts to customize its response.

You can use optional OData system query options to include more or fewer properties than the default response, filter the response for items that match a custom query, or provide additional parameters for a method.

For example, adding the following filter parameter restricts the messages returned to only those with the emailAddress property of jon@contoso.com.

```http
GET https://graph.microsoft.com/v1.0/me/messages?filter=emailAddress eq 'jon@contoso.com'
```

# Additional resources

Below are links to some tools you can use to build and test requests using Microsoft Graph APIs.

- [Graph Explorer](https://developer.microsoft.com/graph/graph-explorer)
- [Postman](https://www.getpostman.com/)

