# Azure Functions

Azure Functions are a great solution for processing data, integrating systems, working with the internet-of-things (IoT), and building simple APIs and microservices. Consider Functions for tasks like image or order processing, file maintenance, or for any tasks that you want to run on a schedule. Functions provides templates to get you started with key scenarios.

Azure Functions supports triggers, which are ways to start execution of your code, and bindings, which are ways to simplify coding for input and output data. There are other integration and automation services in Azure and they all can solve integration problems and automate business processes. They can all define input, actions, conditions, and output.


# Compare Azure Functions and Azure Logic Apps

Both Functions and Logic Apps enable serverless workloads. Azure Functions is a serverless compute service, whereas Azure Logic Apps provides serverless workflows. Both can create complex orchestrations. An orchestration is a collection of functions or steps, called actions in Logic Apps, that are executed to accomplish a complex task.

For Azure Functions, you develop orchestrations by writing code and using the Durable Functions extension. For Logic Apps, you create orchestrations by using a GUI or editing configuration files.

You can mix and match services when you build an orchestration, calling functions from logic apps and calling logic apps from functions. The following table lists some of the key differences between these:

|                   	| Azure Functions                                                       	| Logic Apps                                                                                             	|
|-------------------	|-----------------------------------------------------------------------	|--------------------------------------------------------------------------------------------------------	|
| Development       	| Code-first (imperative)                                               	| Designer-first (declarative)                                                                           	|
| Connectivity      	| About a dozen built-in binding types, write code for custom bindings  	| Large collection of connectors, Enterprise Integration Pack for B2B scenarios, build custom connectors 	|
| Actions           	| Each activity is an Azure function; write code for activity functions 	| Large collection of ready-made actions                                                                 	|
| Monitoring        	| Azure Application Insights                                            	| Azure portal, Azure Monitor logs                                                                       	|
| Management        	| REST API, Visual Studio                                               	| Azure portal, REST API, PowerShell, Visual Studio                                                      	|
| Execution context 	| Can run locally or in the cloud                                       	| Supports run-anywhere scenarios                                                                        	|

# Compare Functions and WebJobs

Like Azure Functions, Azure App Service WebJobs with the WebJobs SDK is a code-first integration service that is designed for developers. Both are built on Azure App Service and support features such as source control integration, authentication, and monitoring with Application Insights integration.

Azure Functions is built on the WebJobs SDK, so it shares many of the same event triggers and connections to other Azure services. Here are some factors to consider when you're choosing between Azure Functions and WebJobs with the WebJobs SDK:

|                                             	| Functions                                                                                                                                              	| WebJobs with WebJobs SDK                                                                                              	|
|---------------------------------------------	|--------------------------------------------------------------------------------------------------------------------------------------------------------	|-----------------------------------------------------------------------------------------------------------------------	|
| Serverless app model with automatic scaling 	| Yes                                                                                                                                                    	| No                                                                                                                    	|
| Develop and test in browser                 	| Yes                                                                                                                                                    	| No                                                                                                                    	|
| Pay-per-use pricing                         	| Yes                                                                                                                                                    	| No                                                                                                                    	|
| Integration with Logic Apps                 	| Yes                                                                                                                                                    	| No                                                                                                                    	|
| Trigger events                              	| Timer Azure Storage queues and blobs Azure Service Bus queues and topics Azure Cosmos DB Azure Event Hubs HTTP/WebHook (GitHub Slack) Azure Event Grid 	| Timer Azure Storage queues and blobs Azure Service Bus queues and topics Azure Cosmos DB Azure Event Hubs File system 	|

Azure Functions offers more developer productivity than Azure App Service WebJobs does. It also offers more options for programming languages, development environments, Azure service integration, and pricing. For most scenarios, it's the best choice.

# Compare Azure Functions hosting options

When you create a function app in Azure, you must choose a hosting plan for your app. There are three basic hosting plans available for Azure Functions: Consumption plan, Functions Premium plan, and App service (Dedicated) plan. All hosting plans are generally available (GA) on both Linux and Windows virtual machines.

The hosting plan you choose dictates the following behaviors:

- How your function app is scaled.
- The resources available to each function app instance.
- Support for advanced functionality, such as Azure Virtual Network connectivity.

The following is a summary of the benefits of the three main hosting plans for Functions:

| Plan                   	| Benefits                                                                                                                                                                                                                                    	|
|------------------------	|---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------	|
| Consumption plan       	| This is the default hosting plan. It scales automatically and you only pay for compute resources when your functions are running. Instances of the Functions host are dynamically added and removed based on the number of incoming events. 	|
| Functions Premium plan 	| Automatically scales based on demand using pre-warmed workers which run applications with no delay after being idle, runs on more powerful instances, and connects to virtual networks.                                                     	|
| App service plan       	| Run your functions within an App Service plan at regular App Service plan rates. Best for long-running scenarios where Durable Functions can't be used.                                                                                     	|

There are two other hosting options which provide the highest amount of control and isolation in which to run your function apps.

| Hosting option 	| Details                                                                                                                                                                       	|
|----------------	|-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------	|
| ASE            	| App Service Environment (ASE) is an App Service feature that provides a fully isolated and dedicated environment for securely running App Service apps at high scale.         	|
| Kubernetes     	| Kubernetes provides a fully isolated and dedicated environment running on top of the Kubernetes platform. For more information visit Azure Functions on Kubernetes with KEDA. 	|

# Always on

If you run on an App Service plan, you should enable the Always on setting so that your function app runs correctly. On an App Service plan, the functions runtime goes idle after a few minutes of inactivity, so only HTTP triggers will "wake up" your functions. Always on is available only on an App Service plan. On a Consumption plan, the platform activates function apps automatically.

# Storage account requirements

On any plan, a function app requires a general Azure Storage account, which supports Azure Blob, Queue, Files, and Table storage. This is because Functions relies on Azure Storage for operations such as managing triggers and logging function executions, but some storage accounts do not support queues and tables. These accounts, which include blob-only storage accounts (including premium storage) and general-purpose storage accounts with zone-redundant storage replication, are filtered-out from your existing Storage Account selections when you create a function app.

The same storage account used by your function app can also be used by your triggers and bindings to store your application data. However, for storage-intensive operations, you should use a separate storage account.
