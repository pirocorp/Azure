# Microsoft Authentication Library (MSAL)

The Microsoft Authentication Library (MSAL) enables developers to acquire tokens from the Microsoft identity platform in order to authenticate users and access secured web APIs.

The Microsoft Authentication Library (MSAL) can be used to provide secure access to Microsoft Graph, other Microsoft APIs, third-party web APIs, or your own web API. MSAL supports many different application architectures and platforms including .NET, JavaScript, Java, Python, Android, and iOS.

MSAL gives you many ways to get tokens, with a consistent API for a number of platforms. Using MSAL provides the following benefits:

- No need to directly use the OAuth libraries or code against the protocol in your application.
- Acquires tokens on behalf of a user or on behalf of an application (when applicable to the platform).
- Maintains a token cache and refreshes tokens for you when they are close to expire. You don't need to handle token expiration on your own.
- Helps you specify which audience you want your application to sign in.
- Helps you set up your application from configuration files.
- Helps you troubleshoot your app by exposing actionable exceptions, logging, and telemetry.


# Application types and scenarios

Using MSAL, a token can be acquired from a number of application types: web applications, web APIs, single-page apps (JavaScript), mobile and native applications, and daemons and server-side applications. MSAL currently supports the platforms and frameworks listed in the table below.

| Library                	| Supported platforms and frameworks                                                  	|
|------------------------	|-------------------------------------------------------------------------------------	|
| MSAL for Android       	| Android                                                                             	|
| MSAL Angular           	| Single-page apps with Angular and Angular.js frameworks                             	|
| MSAL for iOS and macOS 	| iOS and macOS                                                                       	|
| MSAL Go (Preview)      	| Windows, macOS, Linux                                                               	|
| MSAL Java              	| Windows, macOS, Linux                                                               	|
| MSAL.js                	| JavaScript/TypeScript frameworks such as Vue.js, Ember.js, or Durandal.js           	|
| MSAL.NET               	| .NET Framework, .NET Core, Xamarin Android, Xamarin iOS, Universal Windows Platform 	|
| MSAL Node              	| Web apps with Express, desktop apps with Electron, Cross-platform console apps      	|
| MSAL Python            	| Windows, macOS, Linux                                                               	|
| MSAL React             	| Single-page apps with React and React-based libraries (Next.js, Gatsby.js)          	|


# Authentication flows

Below are some of the different authentication flows provided by Microsoft Authentication Library (MSAL). These flows can be used in a variety of different application scenarios.

| Flow               	| Description                                                                    	|
|--------------------	|--------------------------------------------------------------------------------	|
| Authorization code 	| Native and web apps securely obtain tokens in the name of the user             	|
| Client credentials 	| Service applications run without user interaction                              	|
| On-behalf-of       	| The application calls a service/web API, which in turns calls Microsoft Graph  	|
| Implicit           	| Used in browser-based applications                                             	|
| Device code        	| Enables sign-in to a device by using another device that has a browser         	|
| Integrated Windows 	| Windows computers silently acquire an access token when they are domain joined 	|
| Interactive        	| Mobile and desktops applications call Microsoft Graph in the name of a user    	|
| Username/password  	| The application signs in a user by using their username and password           	|


# Public client, and confidential client applications

Security tokens can be acquired by multiple types of applications. These applications tend to be separated into the following two categories. Each is used with different libraries and objects.

- Public client applications: Are apps that run on devices or desktop computers or in a web browser. They're not trusted to safely keep application secrets, so they only access web APIs on behalf of the user. (They support only public client flows.) Public clients can't hold configuration-time secrets, so they don't have client secrets.
- Confidential client applications: Are apps that run on servers (web apps, web API apps, or even service/daemon apps). They're considered difficult to access, and for that reason capable of keeping an application secret. Confidential clients can hold configuration-time secrets. Each instance of the client has a distinct configuration (including client ID and client secret).


# Initialize client applications

With MSAL.NET 3.x, the recommended way to instantiate an application is by using the application builders: PublicClientApplicationBuilder and ConfidentialClientApplicationBuilder. They offer a powerful mechanism to configure the application either from the code, or from a configuration file, or even by mixing both approaches.

Before initializing an application, you first need to register it so that your app can be integrated with the Microsoft identity platform. After registration, you may need the following information (which can be found in the Azure portal):

- The client ID (a string representing a GUID)
- The identity provider URL (named the instance) and the sign-in audience for your application. These two parameters are collectively known as the authority.
- The tenant ID if you are writing a line of business application solely for your organization (also named single-tenant application).
- The application secret (client secret string) or certificate (of type X509Certificate2) if it's a confidential client app.
- For web apps, and sometimes for public client apps (in particular when your app needs to use a broker), you'll have also set the redirectUri where the identity provider will contact back your application with the security tokens.


# Initializing public and confidential client applications from code

The following code instantiates a public client application, signing-in users in the Microsoft Azure public cloud, with their work and school accounts, or their personal Microsoft accounts.

```csharp
IPublicClientApplication app = PublicClientApplicationBuilder.Create(clientId).Build();
```

In the same way, the following code instantiates a confidential application (a Web app located at https://myapp.azurewebsites.net) handling tokens from users in the Microsoft Azure public cloud, with their work and school accounts, or their personal Microsoft accounts. The application is identified with the identity provider by sharing a client secret:

```csharp
string redirectUri = "https://myapp.azurewebsites.net";
IConfidentialClientApplication app = ConfidentialClientApplicationBuilder.Create(clientId)
    .WithClientSecret(clientSecret)
    .WithRedirectUri(redirectUri )
    .Build();
```

# Builder modifiers

In the code snippets using application builders, a number of .With methods can be applied as modifiers (for example, .WithAuthority and .WithRedirectUri).

- ```.WithAuthority``` modifier: The ```.WithAuthority``` modifier sets the application default authority to an Azure Active Directory authority, with the possibility of choosing the Azure Cloud, the audience, the tenant (tenant ID or domain name), or providing directly the authority URI.

```csharp
var clientApp = PublicClientApplicationBuilder.Create(client_id)
    .WithAuthority(AzureCloudInstance.AzurePublic, tenant_id)
    .Build();
```

- ```.WithRedirectUri``` modifier: The ```.WithRedirectUri``` modifier overrides the default redirect URI. In the case of public client applications, this will be useful for scenarios which require a broker.

```csharp
var clientApp = PublicClientApplicationBuilder.Create(client_id)
    .WithAuthority(AzureCloudInstance.AzurePublic, tenant_id)
    .WithRedirectUri("http://localhost")
    .Build();
```

# Modifiers common to public and confidential client applications

The table below lists some of the modifiers you can set on a public, or client confidential client.

| Modifier                                            	| Description                                                                                                                                                                                                                    	|
|-----------------------------------------------------	|--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------	|
| .WithAuthority()                                    	| Sets the application default authority to an Azure Active Directory authority, with the possibility of choosing the Azure Cloud, the audience, the tenant (tenant ID or domain name), or providing directly the authority URI. 	|
| .WithTenantId(string tenantId)                      	| Overrides the tenant ID, or the tenant description.                                                                                                                                                                            	|
| .WithClientId(string)                               	| Overrides the client ID.                                                                                                                                                                                                       	|
| .WithRedirectUri(string redirectUri)                	| Overrides the default redirect URI. In the case of public client applications, this will be useful for scenarios requiring a broker.                                                                                           	|
| .WithComponent(string)                              	| Sets the name of the library using MSAL.NET (for telemetry reasons).                                                                                                                                                           	|
| .WithDebugLoggingCallback()                         	| If called, the application will call Debug.Write simply enabling debugging traces.                                                                                                                                             	|
| .WithLogging()                                      	| If called, the application will call a callback with debugging traces.                                                                                                                                                         	|
| .WithTelemetry(TelemetryCallback telemetryCallback) 	| Sets the delegate used to send telemetry.                                                                                                                                                                                      	|

# Modifiers specific to confidential client applications

The modifiers you can set on a confidential client application builder are:

| Modifier                                       	| Description                                                                                    	|
|------------------------------------------------	|------------------------------------------------------------------------------------------------	|
| .WithCertificate(X509Certificate2 certificate) 	| Sets the certificate identifying the application with Azure Active Directory.                  	|
| .WithClientSecret(string clientSecret)         	| Sets the client secret (app password) identifying the application with Azure Active Directory. 	|


# Implement interactive authentication by using MSAL.NET

In this exercise you'll learn how to perform the following actions:

- Register an application with the Microsoft identity platform
- Use the ```PublicClientApplicationBuilder``` class in MSAL.NET
- Acquire a token interactively in a console application


## Register a new application

Sign in to the portal: https://portal.azure.com. Search for and select **Azure Active Directory**. Under **Manage**, select **App registrations** > **New registration**.

![image](https://user-images.githubusercontent.com/34960418/164684510-415daf18-6f04-467b-a06f-b2340f006935.png)


When the Register an application page appears, enter your application's registration information:

| Field                   	| Value                                                                                              	|
|-------------------------	|----------------------------------------------------------------------------------------------------	|
| Name                    	| az204appreg                                                                                        	|
| Supported account types 	| Select Accounts in this organizational directory only                                              	|
| Redirect URI (optional) 	| Select Public client/native (mobile & desktop) and enter http://localhost in the box to the right. 	|

Select **Register**.

![image](https://user-images.githubusercontent.com/34960418/164691227-64f3984b-9dae-4d6e-9fa6-ad5f57037096.png)


Azure Active Directory assigns a unique application (client) ID to your app, and you're taken to your application's Overview page.

![image](https://user-images.githubusercontent.com/34960418/164692274-0dae4c39-5949-4e3c-aba5-196c75fd6367.png)


## Build the console app

In this section you will add the necessary packages and code to the project.

### Add packages and using statements

Add the ```Microsoft.Identity.Client``` package to the project. Open the Program.cs file and add using statements to include ```Microsoft.Identity.Client``` and to enable async operations. Change the Main method to enable async.

```csharp
namespace Msal_Demo
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.Identity.Client;

    public static class Program
    {
        public static async Task Main(string[] args)
        {
            
        }
    }
}
```
