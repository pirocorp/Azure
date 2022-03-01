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


- Container Instances
  - [Container Instances (Azure Portal)](#container-instances-azure-portal)
    - [Resource group](#resource-group)
    - [Container instance](#container-instance)
    - [Interact with a container](#interact-with-a-container)
    - [Inspect a container](#inspect-a-container)
    - [Remove a container](#remove-a-container)
  - [Container Instances (Azure CLI)](#container-instances-azure-cli)
    - [Container instance](#container-instance-1)
    - [Interact with a container](#interact-with-a-container-1)
    - [Inspect a container](#inspect-a-container-1)
    - [Remove a container](#remove-a-container-1)
  - [Container Instances (Azure PowerShell)](#container-instances-azure-powershell)


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


# Container Instances (Azure Portal)

## Resource group

Search for resource groups. Click on **+ Create** to create a new resource group for **Resource group** set **RG-Containers**. Select the **region** to be **West Europe**. Click on **Review + create**. Then on **Create**. Once the deployment is done, click on the **Go to resource group** button.

![image](https://user-images.githubusercontent.com/34960418/156141727-4e4217ca-f856-47b1-8e48-70df3c870ef2.png)


## Container instance

Click on the **+ Create** button to create new resource. Type **Container instances** in the top search field and hit Enter. Click on **Create** button.

![image](https://user-images.githubusercontent.com/34960418/156142019-e4c23f6d-30e2-4123-b79c-3088a09fa3d6.png)


Ensure that the correct **Subscription** and **Resource group** are selected. Enter a unique (in the resource group) name for the** Container Name**—for example, **aze-hello**. Change the **Image source** selection to **Docker Hub or other registry**. For **Image type**, leave the default selection – **Public**. Paste the path to the image in the **image** text field. The path could be a repository in any registry to which we have access. It can be either Docker Hub or Microsoft’s container registry. For this exercise, use just **shekeriev/aze-image-1** because the container image is in Docker Hub and is publicly available. Leave the **OS type** to **Linux**. You can click on Change size if you want to lower the memory. For now, leave it as it is. Click on the **Next: Networking** button.

![image](https://user-images.githubusercontent.com/34960418/156143814-be6a82ef-3cdb-4b39-953d-59a70e9f7751.png)


In the DNS name label field enter a string that must be unique for the region. It will become part of the FQDN of the container. Enter for example **aze-hello**. Click on **Next: Advanced**. Accept all default values. Click on **Review + create** button. Click on **Create**.

![image](https://user-images.githubusercontent.com/34960418/156144233-f30a6c8f-f43b-4026-817e-9a4f33e1d5e6.png)


## Interact with a container

Once the deployment is done, click on the** Go to resource** button. Being in the Overview section, we can copy either the **IP address** or the **FQDN** and paste it into a browser window. And voila, we can see that our container is working and reachable as expected. 

![image](https://user-images.githubusercontent.com/34960418/156145163-92066f3b-66a4-4aa8-a928-a3585056ff1c.png)


## Inspect a container

Return to the **Overview** of the container instance in the portal. Click on the **Containers** option under **Settings**. Here, we can see that there is one container in running state. Bellow the container list, we can see four different sections. First one, the **Events** section, is selected by default. It shows us, what stages the container went through. 

![image](https://user-images.githubusercontent.com/34960418/156146212-5a7c21c1-fa16-41b2-a2f8-044333135e88.png)


In **Properties** we can see some more details about our container

![image](https://user-images.githubusercontent.com/34960418/156146337-c6fbb38d-bed0-4eb5-bcfb-edd5ed8515fe.png)


**Logs** are showing us the HTTP GET requests generated when we accessed the application via the browser

![image](https://user-images.githubusercontent.com/34960418/156146680-c3f26e5a-a678-4827-8d49-b62a383f6624.png)


Click on **Connect** to establish an interactive session to the container. Select **/bin/sh** and click **Connect**.

![image](https://user-images.githubusercontent.com/34960418/156146854-c29ae7d1-a86f-4808-887d-dd16bd541695.png)


Issue some commands. For example, let’s try ```ls```, ```hostname```, ```uname```, etc. Once done exploring, execute the ```exit``` command to close the connection.

![image](https://user-images.githubusercontent.com/34960418/156147465-c805ebcb-250b-4485-98c0-988fe1537700.png)


## Remove a container

Return to the **Overview** section. Click on the **Delete** button. Confirm with **Yes**.

![image](https://user-images.githubusercontent.com/34960418/156147739-c4fe7e79-8ffd-47bb-80cc-cf5bc46c4b0e.png)


# Container Instances (Azure CLI)

If using a local shell, login first by issuing:

```bash
az login
```

## Container instance

To start a container like the one created in the previous part, execute the following:

```bash
az container create --resource-group RG-Containers --name aze-hello --image shekeriev/aze-image-1 --dns-name-label aze-hello --ports 80
```


## Interact with a container

Ask for details like the public IP address, the FQDN, etc.

```bash
az container show --resource-group RG-Containers --name aze-hello
```

![image](https://user-images.githubusercontent.com/34960418/156150025-a1619d07-f707-4ae3-93ef-524fcd358f4f.png)


Narrow down the received information and change the output style with:

```bash
az container show --resource-group RG-Containers --name aze-hello --query "{FQDN:ipAddress.fqdn,IP:ipAddress.ip}" --output table
```

![image](https://user-images.githubusercontent.com/34960418/156150220-b922150c-e8ec-4fa7-84c3-801525a1e1cf.png)


Copy either the IP address or the FQDN and paste it into a browser window. And voila, container is working and reachable as expected.

![image](https://user-images.githubusercontent.com/34960418/156150483-e37df83b-3862-4c3b-803d-230eb314a8e4.png)


## Inspect a container

Get container logs

```bash
az container logs --resource-group RG-Containers --name aze-hello
```

![image](https://user-images.githubusercontent.com/34960418/156150909-3b4b52c3-f36e-46c0-a503-80105f7d9771.png)


Attach to the container’s output streams and monitor what is happening in real-time. Return to the browser window, refresh a few times, and notice that events appear immediately on the stream. Detach with **Ctrl+C**. When asked, confirm with y. 

```bash
az container attach --resource-group RG-Containers --name aze-hello
```

Execute command to see the hostname of the container

```bash
az container exec --resource-group RG-Containers --name aze-hello --exec-command hostname
```

![image](https://user-images.githubusercontent.com/34960418/156151735-5202c737-53f5-4d65-aa5e-38db93f8a2ce.png)


Start a shell and connect to it

```bash
az container exec --resource-group RG-Containers --name aze-hello --exec-command /bin/sh
```

![image](https://user-images.githubusercontent.com/34960418/156152009-7a2aa1cb-386c-4c12-9b71-33a0d9219c2c.png)


In the container issue some commands. For example, let’s try ```ls```, ```hostname```, ```uname```, etc. Execute the exit command to close the connection.

![image](https://user-images.githubusercontent.com/34960418/156152682-dfab78f6-b076-4ae9-baab-e5ec1c82e563.png)


## Remove a container

Delete the container with. Confirm with **y**.

```bash
az container delete --resource-group RG-Containers --name aze-hello
```


# Container Instances (Azure PowerShell)

If using a local shell, login first by issuing

```powershell
Connect-AzAccount
```

![image](https://user-images.githubusercontent.com/34960418/156154142-3dc150a9-d600-4f27-b1e7-f9a9be489501.png)


## Container instance

Start a container from the same image as we did in the previous part:

```powershell
$port1 = New-AzContainerInstancePortObject -Port 80 -Protocol TCP
$container = New-AzContainerInstanceObject -Name aze-hello -Image shekeriev/aze-image-1 -RequestCpu 1 -RequestMemoryInGb 1.5 -Port $port1
$containerGroup = New-AzContainerGroup -ResourceGroupName RG-Containers -Name aze-hello -Location westeurope -Container $container -OsType Linux -RestartPolicy "Never" -IpAddressType Public
```

![image](https://user-images.githubusercontent.com/34960418/156156558-4e8084ae-5caf-4bbb-99f1-c72ed8e34355.png)
