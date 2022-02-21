# TOC

- [Azure Container Instances (ACI)](#azure-container-instances-aci)
- [Azure Container Registry (ACR)](#azure-container-registry-acr)
- [Azure Kubernetes Service (AKS)](#azure-kubernetes-service-aks)
- [App Service](#app-service)
- [App Service Plans](#app-service-plans)
- [Azure Functions](#azure-functions)
- [Durable Functions](#durable-functions)
- [Azure Logic Apps](#azure-logic-apps)
- [Right Integration and Automation Services](#right-integration-and-automation-services)

# Jump to practical guides





# [Azure Container Instances (ACI)](https://docs.microsoft.com/en-us/azure/container-instances/container-instances-overview)

Containers are becoming the preferred way to package, deploy, and manage cloud applications. Azure Container Instances offers the fastest and simplest way to run a container in Azure, without having to manage any virtual machines and without having to adopt a higher-level service.

Azure Container Instances is a great solution for any scenario that can operate in isolated containers, including simple applications, task automation, and build jobs.

- **Fast startup times** compared to virtual machines
- **Public IP and DNS name** (container.azureregion.azurecontainer.io)
- **Hypervisor-level security** as it would be in a VM
- **Custom sizes** allow adjusting of CPU cores and memory
- For compute intensive jobs containers can use NVIDIA  Tesla GPUs
- **Persistent storage** via direct mounting of Azure File shared
- Both **Windows and Linux containers** can be scheduled
- Supports scheduling of **multi-container groups** that share a host machine, local network, storage, and lifecycle

# [Azure Container Registry (ACR)](https://docs.microsoft.com/en-us/azure/container-registry/container-registry-intro)

- It is a managed, private **Docker registry service**
- Based on the open-source **Docker Registry 2.0**
- Used to store and manage private Docker container images
- Available in three SKUs: **Basic**, **Standard**, and **Premium**
- Offers support for both Windows and Linux images
- Supports **Docker container images**, **Helm charts**, and **OCI images**
- Building, testing, publishing and deploying images with **ACR Tasks**

# [Azure Kubernetes Service (AKS)](https://docs.microsoft.com/en-us/azure/aks/intro-kubernetes)

- Simplifies deployment of a managed Kubernetes cluster in Azure
- Offloads management complexity and operational overhead
- Kubernetes masters are managed by Azure
- We are responsible only for the nodes and pay only for them
- AKS nodes run on Azure virtual machines
- AKS supports the creation of GPU enabled node pools


# [App Service](https://docs.microsoft.com/en-us/azure/app-service/overview)

Azure App Service is a fully managed platform as a service (PaaS). Azure App Service is an HTTP-based service for hosting web applications, REST APIs, and mobile back ends. You can develop in your favorite language, be it .NET, .NET Core, Java, Ruby, Node.js, PHP, or Python. Applications run and scale with ease on both Windows and Linux-based environments. 

App Service not only adds the power of Microsoft Azure to your application, such as security, load balancing, autoscaling, and automated management. You can also take advantage of its DevOps capabilities, such as continuous deployment from Azure DevOps, GitHub, Docker Hub, and other sources, package management, staging environments, custom domain, and TLS/SSL certificates.

- **Multiple languages and frameworks** - App Service has first-class support for ASP.NET, ASP.NET Core, Java, Ruby, Node.js, PHP, or Python. You can also run PowerShell and other scripts or executables as background services.
- **Managed production environment** - App Service automatically patches and maintains the OS and language frameworks for you. Spend time writing great apps and let Azure worry about the platform.
- **Containerization and Docker** - Dockerize your app and host a custom Windows or Linux container in App Service. Run multi-container apps with Docker Compose. Migrate your Docker skills directly to App Service.
- **DevOps optimization** - Set up continuous integration and deployment with Azure DevOps, GitHub, BitBucket, Docker Hub, or Azure Container Registry. Promote updates through test and staging environments. Manage your apps in App Service by using Azure PowerShell or the cross-platform command-line interface (CLI).
- **Global scale with high availability** - Scale up or out manually or automatically. Host your apps anywhere in Microsoft's global datacenter infrastructure, and the App Service SLA promises high availability.
- **Connections to SaaS platforms and on-premises data** - Choose from more than 50 connectors for enterprise systems (such as SAP), SaaS services (such as Salesforce), and internet services (such as Facebook). Access on-premises data using Hybrid Connections and Azure Virtual Networks.
- **Security and compliance** - App Service is ISO, SOC, and PCI compliant. Authenticate users with Azure Active Directory, Google, Facebook, Twitter, or Microsoft account. Create IP address restrictions and manage service identities.
- **Application templates** - Choose from an extensive list of application templates in the Azure Marketplace, such as WordPress, Joomla, and Drupal.
- **Visual Studio and Visual Studio Code integration** - Dedicated tools in Visual Studio and Visual Studio Code streamline the work of creating, deploying, and debugging.
- **API and mobile features** - App Service provides turn-key CORS support for RESTful API scenarios, and simplifies mobile app scenarios by enabling authentication, offline data sync, push notifications, and more.
- **Serverless code** - Run a code snippet or script on-demand without having to explicitly provision or manage infrastructure, and pay only for the compute time your code actually uses (see Azure Functions).


# [App Service Plans](https://docs.microsoft.com/en-us/azure/app-service/overview-hosting-plans)

In App Service (Web Apps, API Apps, or Mobile Apps), an app always runs in an App Service plan. In addition, Azure Functions also has the option of running in an App Service plan. An App Service plan defines a set of compute resources for a web app to run. These compute resources are analogous to the server farm in conventional web hosting. One or more apps can be configured to run on the same computing resources (or in the same App Service plan).

When you create an App Service plan in a certain region (for example, West Europe), a set of compute resources is created for that plan in that region. Whatever apps you put into this App Service plan run on these compute resources as defined by your App Service plan. Each App Service plan defines:

- **Operating System** (Windows, Linux)
- **Region** (West US, East US, etc.)
- **Number of VM instances**
- **Size of VM instances** (Small, Medium, Large)
- **Pricing tier** (Free, Shared, Basic, Standard, Premium, PremiumV2, PremiumV3, Isolated, IsolatedV2)

The pricing tier of an App Service plan determines what App Service features you get and how much you pay for the plan. The pricing tiers available to your App Service plan depend on the operating system selected at creation time. There are a few categories of pricing tiers:

- **Shared compute**: Free and Shared, the two base tiers, runs an app on the same Azure VM as other App Service apps, including apps of other customers. These tiers allocate CPU quotas to each app that runs on the shared resources, and the resources cannot scale out.
- **Dedicated compute**: The Basic, Standard, Premium, PremiumV2, and PremiumV3 tiers run apps on dedicated Azure VMs. Only apps in the same App Service plan share the same compute resources. The higher the tier, the more VM instances are available to you for scale-out.
- **Isolated**: This Isolated and IsolatedV2 tiers run dedicated Azure VMs on dedicated Azure Virtual Networks. It provides network isolation on top of compute isolation to your apps. It provides the maximum scale-out capabilities.


# [Azure Functions](https://docs.microsoft.com/en-us/azure/azure-functions/functions-overview)

Azure Functions is a serverless solution that allows you to write less code, maintain less infrastructure, and save on costs. Instead of worrying about deploying and maintaining servers, the cloud infrastructure provides all the up-to-date resources needed to keep your applications running.

We often build systems to react to a series of critical events. Whether you're building a web API, responding to database changes, processing IoT data streams, or even managing message queues - every application needs a way to run some code as these events occur.

To meet this need, Azure Functions provides "compute on-demand" in two significant ways.

First, Azure Functions allows you to implement your system's logic into readily available blocks of code. These code blocks are called "functions". Different functions can run anytime you need to respond to critical events.

Second, as requests increase, Azure Functions meets the demand with as many resources and function instances as necessary - but only while needed. As requests fall, any extra resources and application instances drop off automatically.

[Payment](https://docs.microsoft.com/en-us/azure/azure-functions/functions-scale)

- Consumption plan
  - Azure provides all the necessary computational resources as needed
  - Pay only for the time your code runs
- Premium plan
  - A number of pre-warmed instances that are always online and ready
  - On-demand additional computational resources may be provided
  - Pay for both set of resources
- App Service plan
  - Run your functions just like your web apps
  - Use the same plan at no additional costs

# [Durable Functions](https://docs.microsoft.com/en-us/azure/azure-functions/durable/durable-functions-overview)

Durable Functions is an extension of Azure Functions that lets you write stateful functions in a serverless compute environment. The extension lets you define stateful workflows by writing orchestrator functions and stateful entities by writing entity functions using the Azure Functions programming model. Behind the scenes, the extension manages state, checkpoints, and restarts for you, allowing you to focus on your business logic.

## Durable Functions Application Patterns

- **Function chaining** - A sequence of function executes in a specific order
- **Fan-out/-in** - Multiple functions are executed in parallel
- **Async HTTP APIs** - Addresses the problem of coordinating the state of long-running operations with external clients
- **Monitoring** - Flexible, recurring process in a workflow. An example is polling until specific conditions are met
- **Human interaction** - An automated process might allow for this interaction by using timeouts and compensation logic
- **Aggregator** - Aggregating event data over a period of time into a single, addressable entity


# [Azure Logic Apps](https://docs.microsoft.com/en-us/azure/logic-apps/logic-apps-overview)

Azure Logic Apps is a cloud-based platform for creating and running automated workflows that integrate your apps, data, services, and systems. With this platform, you can quickly develop highly scalable integration solutions for your enterprise and business-to-business (B2B) scenarios. As a member of Azure Integration Services, Azure Logic Apps simplifies the way that you connect legacy, modern, and cutting-edge systems across cloud, on premises, and hybrid environments.


**Workflow** - Visualize, design, build, automate, and deploy business processes as series of steps
**Managed connectors** - Connectors are designed to connect, access, and work with your data
**Triggers** - Fire when events or new data meet specified conditions. Each time new logic app instance is created that runs the workflow
**Actions** - All steps that happen after the trigger
**Enterprise Integration Pack**


# [Right Integration and Automation Services](https://docs.microsoft.com/en-us/azure/azure-functions/functions-compare-logic-apps-ms-flow-webjobs)

- **Microsoft Flow** vs **Azure Logic Apps**
  - Designer-first integration services that can create workflows
  - Both services integrate with various SaaS and enterprise applications
- **Azure Functions** vs **Azure Logic Apps**
  - Azure services that enable serverless workloads
  - Azure Functions is a serverless compute service, whereas Azure Logic Apps provides serverless workflows
  - Both can create complex orchestrations. An orchestration is a collection of functions or steps
- **Azure Functions** vs **WebJobs** (with **WebJobs SDK**)
  - Code-first integration services that are designed for developers
  - Both are built on Azure App Service and support features such as source control integration, authentication, and monitoring with Application Insights integration
