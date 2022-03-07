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
    - [Container instance](#container-instance-2)
    - [Interact with a container](#interact-with-a-container-2)
    - [Inspect a container](#inspect-a-container-2)
    - [Remove a container](#remove-a-container-2)
  - [Container Images](#container-images)
    - [Create a container image](#create-a-container-image)
    - [Azure Portal: Create Azure Container Registry (Azure Portal)](#azure-portal-create-azure-container-registry-azure-portal)
    - [Azure CLI: Create Azure Container Registry (CLI)](#azure-cli-create-azure-container-registry-cli)
    - [Publish the image](#publish-the-image)
    - [List repositories in a registry](#list-repositories-in-a-registry)
    - [Azure Portal](#azure-portal)
    - [Azure CLI](#azure-cli)
- Azure App Services
  - [HTML web app (Azure Portal)](#html-web-app-azure-portal)
    - [Create a Web App](#create-a-web-app)
    - [Deploy the project](#deploy-the-project)
    - [Change and re-deploy a project](#change-and-re-deploy-a-project)
  - [HTML web app (Azure CLI)](#html-web-app-azure-cli)
    - [Deploy a HTML web app](#deploy-a-html-web-app)
    - [Change and re-deploy a project](#change-and-re-deploy-a-project-1)
  - [PHP + SQL web app (Azure Portal)](#php--sql-web-app-azure-portal)
    - [Create DB](#create-db)
    - [Load the data](#load-the-data)
    - [Configure the application](#configure-the-application)
    - [Create the web application](#create-the-web-application)
    - [Deploy the project](#deploy-the-project-1)
- [Azure Functions](#azure-functions-1)


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


## Interact with a container

Ask for information with

```powershell
Get-AzContainerGroup -ResourceGroupName RG-Containers -Name aze-hello | fl
```

![image](https://user-images.githubusercontent.com/34960418/156160787-08e21364-8db3-4c68-8e6b-3647b917d948.png)


Narrow-down the received information with

```powershell
Get-AzContainerGroup -ResourceGroupName RG-Containers -Name aze-hello | Select IpAddressIp, IpAddressFqdn
```

![image](https://user-images.githubusercontent.com/34960418/156161400-27dbca3e-ae56-46c5-81c9-e43fd0b2db12.png)


Copy the IP address and paste it into a browser window.

![image](https://user-images.githubusercontent.com/34960418/156161257-c638316f-3cb2-4171-976f-49d734db6b85.png)


## Inspect a container

To get the logs, execute.

```powershell
Get-AzContainerInstanceLog -ResourceGroupName RG-Containers -ContainerName aze-hello -ContainerGroupName aze-hello
```

![image](https://user-images.githubusercontent.com/34960418/156161905-17bb3306-affd-48d0-b46b-ed58b182ebb6.png)


Add the **-Tail** option to get only the last **X** lines. For example **-Tail 5** to get the **last 5 lines**

```powershell
Get-AzContainerInstanceLog -ResourceGroupName RG-Containers -ContainerName aze-hello -ContainerGroupName aze-hello -Tail 5
```

![image](https://user-images.githubusercontent.com/34960418/156162003-6fcc21c5-c41d-418c-a7f3-4d2b7c12cd7f.png)


## Remove a container

```powershell
Remove-AzContainerGroup -ResourceGroupName RG-Containers -Name aze-hello
```

![image](https://user-images.githubusercontent.com/34960418/156162259-bfd6159d-1aad-43ac-8aa7-2929564bdd34.png)


# Container Images

## Prepare the project

Download and extract the accompanying file **docker-image-2.zip**. If you examine the contents, you will see that there is one file named **Dockerfile**, a file named **file.png** and a folder **web** with one HTML file and one PNG file. Examine the **Dockerfile**. Copy or move **file.png** to the folder **web**. Go to the **web** folder and open the **index.html** file in a text editor. Create an empty row on **line 10** and paste this block of code. Save and close the file. There is no need to modify the **Dockerfile** as it will copy the whole web folder including the new file to the image.

```html
	  <br />
	  <h1>And this is a cat ;)</h1>
	  <img src="file.png" />
```


## Create a container image

Open a terminal session and make sure that you are in the folder that contains the **Dockerfile** from the previous task. Now, build the new image with:

```bash
docker build . -t aze-image-2
```

![image](https://user-images.githubusercontent.com/34960418/156172186-096ef2ce-70b1-43e0-bace-5406d112df1f.png)


List the available images

```bash
docker images
```

![image](https://user-images.githubusercontent.com/34960418/156172347-4fca119a-4dd2-4457-b07e-9869244c8e31.png)


Run the app locally. Open a browser window and navigate to http://localhost:8080 to test the app

```bash
docker run -d -p 8080:80 aze-image-2
```

![image](https://user-images.githubusercontent.com/34960418/156172647-1bcd546e-4ccb-4e4f-a902-9bc5a003ec53.png)


## Azure Portal: Create Azure Container Registry (Azure Portal)

Go to the resource group created earlier (**RG-Containers**). Click on the **+ Create** button. Search for **Container Registry** in the **Marketplace** search box. Click on **Create**.

![image](https://user-images.githubusercontent.com/34960418/156173532-fb8bd988-befa-40b0-8a50-a317142698b8.png)


For **Registry name** enter **azecr2022**. Set the **Location** to **West Europe**. Change the **SKU** to **Basic**. Click on **Review + create** and then on **Create**.

![image](https://user-images.githubusercontent.com/34960418/156174029-f13a8ced-4ccd-4c9c-90fc-0c91d1416dc8.png)


After the registry is created, navigate to its **Overview** mode. There, click on **Access keys** in the **Settings** section. Switch the **Admin user** option to **Enable**. 

![image](https://user-images.githubusercontent.com/34960418/156174469-ecff83b8-9e29-4a0f-b887-6a024ea93e5e.png)


## Azure CLI: Create Azure Container Registry (CLI)

```bash
az acr create --resource-group RG-Containers --name azecr2022 --sku Basic --admin-enabled true
```


## Publish the image

Return on the console session used earlier to build the container image. Tag the image against the new registry:

```bash
docker tag aze-image-2 azecr2022.azurecr.io/aze-image-2:v1
```


Next, log in to the registry

```bash
az acr login --name azecr2022
```

![image](https://user-images.githubusercontent.com/34960418/156175667-afe38d6b-fa89-431a-b0f7-bf3a35dec91a.png)


Then push the image to the registry

```bash
docker push azecr2022.azurecr.io/aze-image-2:v1
```

![image](https://user-images.githubusercontent.com/34960418/156175968-e61fbe0e-4e9a-4188-8961-14ab150df16a.png)


## List repositories in a registry

Now, we can list all repositories available in our registry. If you prefer the portal way of doing things, you can navigate to the **azecr2022** registry. Then click on **Repositories** under **Services**. There you will see our repository **aze-image-2**. If you click on it, you will see how many different tags (or versions) are available. 

![image](https://user-images.githubusercontent.com/34960418/156176617-ecf502d8-bdec-4127-93e8-82776b6a29ea.png)


If you prefer the command line way, you can execute:

```bash
az acr repository list --resource-group RG-Containers --name azecr2022 --output table
```

![image](https://user-images.githubusercontent.com/34960418/156176784-72762e3c-7e97-4908-8e07-bbebe876f705.png)


Besides the wanted output you will notice a deprecation warning about the resource-group. The command can be:

```bash
az acr repository list --name azecr2022 --output table
```

![image](https://user-images.githubusercontent.com/34960418/156176999-7b6372b5-bffe-4508-a671-37a4ce0606c7.png)


This should return the list of repositories. In order to see how many tags are available in a repository, execute:

```bash
az acr repository show-tags --resource-group RG-Containers --name azecr2022 --repository aze-image-2 --output table
```

![image](https://user-images.githubusercontent.com/34960418/156177230-1e2001bd-396d-4f3f-821e-bb86416807de.png)


The same applies here and the new version of the command should look like:

```bash
az acr repository show-tags --name azecr2022 --repository aze-image-2 --output table
```

![image](https://user-images.githubusercontent.com/34960418/156177358-0f08b5b4-272a-49dc-8679-e838325f67c1.png)


## Deploy the new application

Our image is in a private registry, so we must provide credentials

### Azure Portal

Here, the main difference is that during the creation process, you must select **Azure Container Registry** for **Image Source**. The rest of the steps are the same as before

![image](https://user-images.githubusercontent.com/34960418/156178012-17e00120-7c2f-449f-abd8-1902a815c5e2.png)


### Azure CLI

Extended version of the container creation command would look like:

```bash
az container create --resource-group RG-Containers --name aze-hello --image azecr2021.azurecr.io/aze-image-2:v1 --cpu 1 --memory 1 --registry-login-server azecr2021.azurecr.io --registry-username azecr2022 --registry-password "Tgjhc6KaLaTuQRErh9U/uqSq8RXMwFP0" --dns-name-label aze-hello --ports 80
```


# HTML web app (Azure Portal)

Navigate to resource groups section. Create a new resource group, for example **RG-WebApps** in the West Europe region. Enter the resource group.

![image](https://user-images.githubusercontent.com/34960418/156188843-cfaa2e86-92b0-41ed-9ddf-75768ed33909.png)

## Create a Web App

Click on the **+ Create** button to add new resource. In the search bar enter **App Services** and hit Enter. Click either on the **+ Creat**e to create a new app service.

![image](https://user-images.githubusercontent.com/34960418/156191598-9c3e20a1-1f81-4b2b-8448-7c6208857eb1.png)


Make sure that the **Subscription** and the **Resource Group** are correctly set. For **Name** of the instance enter **azewebapp**. Be sure to select **Code** in the **Publish** section. For the current task, the **Runtime stack** is of no importance. Let’s choose **PHP**. Set the **Operating System** to **Linux**. Select **West Europe** for the **Region**. Click Create new link under the drop-down list in the App Service Plan section. In the text field enter a name you like, for example Linux-WebApp-Plan. Change the Sku and size to Free F1. Click on Review + create. Click on Create.

![image](https://user-images.githubusercontent.com/34960418/156192606-5e6076e5-bda5-4fea-ac63-6c169ca060d6.png)


## Deploy the project

Extract the accompanying archive file **web-app-html.zip** to a folder of your choice. Once the web app is ready, click on the **Go to resource**. Click on the **Deployment Center** option under **Deployment**. Select **FTPS Credentials** tab. 

![image](https://user-images.githubusercontent.com/34960418/156193364-b9752a27-7734-49df-a283-5262c5b5fd2b.png)


**FileZilla** as well as any other FTP application will do the job. Copy the **FTPS Endpoint** string and paste it in the **Host** field of the FTP application.

![image](https://user-images.githubusercontent.com/34960418/156193658-8be97c68-ddce-4c1e-8f61-6a99530674a9.png)


Use the provided Username and Password

![image](https://user-images.githubusercontent.com/34960418/156193857-6d55f2ce-8382-4e76-bb02-de87074b7588.png)


Click on the Quickconnect button. Accept the certificate.

![image](https://user-images.githubusercontent.com/34960418/156193996-981d172b-9463-4dec-aee0-12e2ede9bd4b.png)

![image](https://user-images.githubusercontent.com/34960418/156194141-f23661a4-cb73-447a-9511-704c3b300b3f.png)


Navigate to the extracted files and copy them to the destination folder in the right part of the screen. Close the FTP session and application.

![image](https://user-images.githubusercontent.com/34960418/156194672-705cedb0-6951-4690-b697-4855da2bdce4.png)


Return to the **Azure Portal**. Go to the **Overview** section. Copy the value for **URL** and paste in a new browser window or click over it to open a new window. You should see a familiar web page.

![image](https://user-images.githubusercontent.com/34960418/156195037-e2ed539e-46d6-4a02-b2db-a3cf5e763f74.png)
![image](https://user-images.githubusercontent.com/34960418/156195120-cbd31e39-7513-479d-9543-a15e2557a1ef.png)


## Change and re-deploy a project

Navigate back to the folder where the files for the page are stored. Open the index.html file with a text editor and modify it. For example, add or remove text. Once you are done with the manipulation save and close the file.

```html
  <br />
  <h1>And this is a cat ;)</h1>
  <img src="file.png" />
```

![image](https://user-images.githubusercontent.com/34960418/156196095-aea4a5a2-4a93-4c94-862d-1a1b6a76d9f5.png)

![image](https://user-images.githubusercontent.com/34960418/156196237-838b06a7-2795-4d21-906b-16eb4af4c53f.png)



# HTML web app (Azure CLI)

If using a local shell, login first by issuing:

```bash
az login
```

## Deploy a HTML web app

As static HTML web apps are hosted only on Windows app service plan, we must create a new plan. Unfortunately, we must create it in a separate resource group as the two (Linux and Windows) app service plans cannot co-exist in one group.

```bash
az group create --name RG-WebApps-Win --location westeurope
```

![image](https://user-images.githubusercontent.com/34960418/156196887-bbbb0e4d-1205-4382-840d-d4167163454d.png)


Now, navigate to the folder where you extracted the accompanying archive file **web-app-html.zip**. Execute the following command to deploy the web application:

```bash
az webapp up --resource-group RG-WebApps-Win --location westeurope --name azewebapp1 --html --plan Windows-WebApp-Plan --sku F1
```

![image](https://user-images.githubusercontent.com/34960418/156197422-72f7de53-fcf9-411b-8a6e-fbd41af61329.png)


Use the following command to list all web applications with their parameters:

```bash
az webapp list --resource-group RG-WebApps-Win
```

![image](https://user-images.githubusercontent.com/34960418/156197806-121398c7-762d-40e0-adaa-d39e8ce90ecb.png)


Or to narrow down the results:

```bash
az webapp list --resource-group RG-WebApps-Win --query "[].{Name:name,URL:defaultHostName}" --output table
```

![image](https://user-images.githubusercontent.com/34960418/156197968-19fe8e1c-19bb-4e86-9952-454407ee8fe7.png)
![image](https://user-images.githubusercontent.com/34960418/156198064-ef28474d-0214-441a-8c37-39ab989387e0.png)


## Change and re-deploy a project

Change the **index.html** file. Execute the same command that you used for the initial deployment to redeploy the app:

```bash
az webapp up --resource-group RG-WebApps-Win --location westeurope --name azewebapp1 --html
```

![image](https://user-images.githubusercontent.com/34960418/156198416-c747e2af-e1de-479e-a20b-adf60b68413e.png)
![image](https://user-images.githubusercontent.com/34960418/156198471-217e5a5e-fa21-44bb-a040-f87d42f167ff.png)



# PHP + SQL web app (Azure Portal)

## Create DB

Create a new resource group. For example, the **RG-WebApps-DB** group. Enter the resource group.

![image](https://user-images.githubusercontent.com/34960418/156202985-7acdbcbc-bff8-4741-b7fe-7ecc803b5302.png)


Click on the **+ Create** button and search for **Azure SQL**. Click on **Create**

![image](https://user-images.githubusercontent.com/34960418/156203341-2dac09b8-52b4-44cc-aed3-779a632aab73.png)


Then click on Create in the SQL databases tile

![image](https://user-images.githubusercontent.com/34960418/156203519-4dc1c003-485b-4bd1-839c-b2fa67ac7ce4.png)


Ensure that the **Subscription** and the **Resource group** are filled correctly. For **Database name** enter **azedb**. Click on **Create new** in the **Server** section. In the **Server name** filed enter **azedbsrv**. Enter **demosa** for the **Server admin login**. Use a password that conforms to the rules, for example **DemoPassword-2022**. Set the location to **West Europe**. Click on **OK**. Click on **Configure database**. Select **Basic** plan and click **Apply**. Click on **Next: Networking** to configure the connectivity to the database.

![image](https://user-images.githubusercontent.com/34960418/156203866-445bd5d1-48c2-4495-88d9-c10932735b68.png)
![image](https://user-images.githubusercontent.com/34960418/156204161-405d787a-ba56-4e0b-8b2d-8ca2f774d4bf.png)
![image](https://user-images.githubusercontent.com/34960418/156204704-91297f60-b0e4-4627-a9e9-90f74b8a915b.png)


Under **Connectivity method** select **Public endpoint**. For the Allow **Azure services and resources to access this server** select **Yes**. Do the same for **Add current client IP address**. Click on **Review + create**. Click on **Create**.

![image](https://user-images.githubusercontent.com/34960418/156205134-6b027a51-7a71-4607-976a-4fefb1074a93.png)


## Load the data

Once the deployment is done, click on **Go to resource**. Click on the **Query editor (preview)**. Enter the login information and click on the **OK** button. Paste the contents of the file **cities-database.sql** in the query panel. Click on the **Run** button.

![image](https://user-images.githubusercontent.com/34960418/156206898-7e134c10-3f18-464f-82e9-d41afbc524b5.png)
![image](https://user-images.githubusercontent.com/34960418/156206954-98f0a811-9b6d-4d06-a188-0b52131a4bfe.png)


## Configure the application

Navigate to the **Connection strings** under the **Settings** section. Switch to the **PHP** tab. Copy the information related to the **SQL Server Extension**.

![image](https://user-images.githubusercontent.com/34960418/156207731-80246a5d-6527-4eaa-80d6-59e856773243.png)


Open the index.php file. Paste the copied information after the // CONNECTION INFORMATION BELLOW. Adjust the password. Save and close the file. 

![image](https://user-images.githubusercontent.com/34960418/156208067-9ecea0ee-3db1-4116-ace4-ad27530b4705.png)


## Create the web application

Go to the resource group (**RG-WebApps-DB**). Click on the **+ Create** button to add new resource. In the search bar enter **App Services** and hit Enter. Click either on the **+ Create**.

![image](https://user-images.githubusercontent.com/34960418/156208889-1c155d2f-69d3-4ffe-8f75-5b53101c8ef5.png)


Make sure that the **Subscription** and the **Resource Group** are correctly set. For **Name** of the instance enter **azewebapp2**. Be sure to select **Code** in the **Publish** section. For the current task set the **Runtime stack** to **PHP 7.4**. Set the **Operating System** to **Linux**. Select **West Europe** for the **Region**. Select 
the existing Linux plan (we can have only one free plan per region). Click on **Review + create**. Click on **Create**.

![image](https://user-images.githubusercontent.com/34960418/156209703-3000b037-bc6e-4a21-94c8-edd409c390e7.png)


## Deploy the project

Once the web app is ready, click on the Go to resource. Click on the Deployment Center option under Deployment. Switch to FTPS Credentials. 

![image](https://user-images.githubusercontent.com/34960418/156210162-c25d3456-65d5-4b09-9170-47ea2c7bc018.png)


**FileZilla** as well as any other FTP application will do the job. Copy the **FTPS Endpoint** string and paste it in the **Host** field of the FTP application. Use the provided **Username** and **Password**. Click on the **Quickconnect** button. Accept the certificate if prompted to do so. Navigate to the extracted files and copy them to the destination folder in the right part of the screen. Close the FTP session and application.

![image](https://user-images.githubusercontent.com/34960418/156210777-6339ff9f-4f9b-42e4-945e-3f2271022740.png)


Return to the **Azure Portal**. Go to the **Overview** section. Copy the value for **URL** and paste in a new browser window or click over it to open a new window.

![image](https://user-images.githubusercontent.com/34960418/156211005-93f79d69-cf7c-46b9-b852-2f43db623353.png)


You should see a web page showing information about the top 10 cities by population in Bulgaria.

![image](https://user-images.githubusercontent.com/34960418/156211490-6e79e4d3-6f7c-4264-bfdb-3218762154a8.png)



# Azure Functions


Navigate to the resource groups section. Create a new resource group, for example, RG-Functions in the West Europe region. Enter the resource group.

![image](https://user-images.githubusercontent.com/34960418/157040272-196b0f65-b8da-44b1-8e67-3a35650b596b.png)


## Create a Function App


Click on the **+ Create** button. Search for **Function App** in the main search bar and hit Enter. Click on the **Create** button.

![image](https://user-images.githubusercontent.com/34960418/157040623-c412bf0c-bd32-44bb-a7e9-2746d04e2b50.png)


Ensure that the **Subscription** and **Resource Group** are correctly filled in. Enter **azefuncapp** for **Function App name**. Make sure that **Code** is selected in the **Publish** option. Select **.NET** for **Runtime stack**. Change the **Region** to **West Europe**. Click on **Next: Hosting**. Move forward by clicking on **Next: Monitoring**. Click on **Review + create**. Click on **Create**. Once the deployment is done, click on the **Go to resource** button.


![image](https://user-images.githubusercontent.com/34960418/157041181-822ab1d9-1837-4c7a-b2e0-81ec8a8a4ce9.png)


## Create a time triggered function


Once in the **Overview** mode of the function application, click on **Functions** option in the **Functions** sectionл Click on the **+ Create** button.

![image](https://user-images.githubusercontent.com/34960418/157043302-a5b687af-d567-4dce-995e-e6b3f0849104.png)


Select **Timer trigger** template. Let’s change the schedule to ```0 */1 * * * *```. This will cause the function to be executed every minute instead of every five minutes. Click on **Create** button.

![image](https://user-images.githubusercontent.com/34960418/157044005-add6fa6d-80fe-49b2-a796-c89dd3032ae6.png)


After the function is created, you will be brought to its Overview section. Explore the options under the Developer section. Return to the function by clicking on its name. When in the Monitoring section, switch to the Logs view. After a while, you will see some log messages proving that the function is working as expected. 

![image](https://user-images.githubusercontent.com/34960418/157044956-2e043093-dd00-40a1-9de7-9cd9b5fd4790.png)


## Create a HTTP triggered function


Return in the **Overview** mode of the function app. Select Functions and click on the **+ Create** button.

![image](https://user-images.githubusercontent.com/34960418/157045332-5bcb340e-d518-42a7-9466-de27edae613e.png)


Select **HTTP trigger** and click on the **Create** button.

![image](https://user-images.githubusercontent.com/34960418/157045559-b4356e96-1eda-4362-9767-96a6474f8814.png)


Once the function is created, click on **Code + Test** to examine the code.

![image](https://user-images.githubusercontent.com/34960418/157045743-37bba8fc-67a7-44a4-a789-7d1befda0cf7.png)


Then, click on the **Get function URL** button. Click on **Copy** to copy it to the clipboard.

![image](https://user-images.githubusercontent.com/34960418/157046163-7b32e8c9-985a-4da3-8dd4-d4423be7dc6d.png)


Open a web browser, paste the URL and hit **Enter**. You will see a message that we must pass a name either via a query string value or in the request body.

![image](https://user-images.githubusercontent.com/34960418/157046337-c1f9e2ee-f50c-437b-9c3b-f10eeb52e336.png)


Let’s pass it as a query string. Add **&name=Demo** at the end of the URL. Now the result should become **Hello, Demo. This HTTP triggered function executed successfully.**

![image](https://user-images.githubusercontent.com/34960418/157046528-f7af1cd6-6435-4aea-820d-9d515aeed491.png)


## Modify the app to use a Queue


