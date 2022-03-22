# TOC

- [Azure Kubernetes Service](#azure-kubernetes-service)
  - [Container Orchestration](#container-orchestration)
  - [What Kubernetes Does?](#what-kubernetes-does)
  - [Architecture Overview](#architecture-overview)
  - [Masters](#masters)
  - [(Worker) Nodes](#worker-nodes)
  - [Pods](#pods)
  - [Replication Controllers](#replication-controllers)
  - [Deployments](#deployments)
  - [Services](#services)
  - [Services in Action](#services-in-action)
- [DevOps](#devops)
  - [What is DevOps?](#what-is-devops)
  - [The Road to DevOps](#the-road-to-devops)
  - [How to Achieve DevOps?](#how-to-achieve-devops)
  - [Continuous (Something)](#continuous-something)
  - [CD vs CD](#cd-vs-cd)
- [Azure DevOps](#azure-devops)
- [Azure DevOps Services](#azure-devops-services)
  - [Azure DevOps Pricing](#azure-devops-pricing)
  - [Azure Boards](#azure-boards)
  - [Azure Boards Tools](#azure-boards-tools)
  - [Azure Pipelines](#azure-pipelines)
  - [Azure Repos](#azure-repos)
- [Azure DevOps Projects](#azure-devops-projects)
  - [Integration with Azure DevOps](#integration-with-azure-devops)


# Jump to practical guides

- [Azure Kubernetes Service (Portal)](#azure-kubernetes-service-portal)
  - [Resource group](#resource-group)
  - [Container registry](#container-registry)
  - [Kubernetes cluster](#kubernetes-cluster)
  - [Explore the cluster](#explore-the-cluster)
  - [Scale the cluster](#scale-the-cluster)
- [Azure Kubernetes Service (CLI)](#azure-kubernetes-service-cli)
  - [Create a resource group](#create-a-resource-group)
  - [Create a container registry](#create-a-container-registry)
  - [Create the cluster](#create-the-cluster)
  - [Explore the cluster](#explore-the-cluster-1)
  - [Run an application](#run-an-application)
  - [Delete the application](#delete-the-application)
  - [Scale an application](#scale-an-application)
  - [Scale the cluster](#scale-the-cluster-1)
  - [Update and redeploy the application](#update-and-redeploy-the-application)


# [Azure Kubernetes Service](https://azure.microsoft.com/en-us/services/kubernetes-service/)

- Accelerate containerized application development
- Manage Kubernetes with ease
- Build on an enterprise-grade, more secure foundation
- Run any workload in the cloud, at the edge, or as a hybrid

## Container Orchestration

- Workload deployment and distribution
- Resource governance
- Scalability and availability
- Automatization and management
- Internal and external communication


## What Kubernetes Does?

- **Run a cluster** of hosts.
- **Schedule containers** to run on different hosts.
- Facilitate the **communication between** the **containers**.
- Provide and control access to/from **outside world**.
- Track and optimize the **resource usage**.


## Architecture Overview

![image](https://user-images.githubusercontent.com/34960418/159252034-da006e4a-9599-4749-a898-59d5dfbcd660.png)


## Masters

- Responsible for **managing** the cluster.
- Typically, **more than one** is installed.
- In HA mode one Master node is the **Leader**.
- It is **work-free**.
- Components running on master are also known as **Control Plane**.
- Can be reached via **CLI (kubectl)**, **APIs**, or **Dashboard**.

![image](https://user-images.githubusercontent.com/34960418/159252789-fc7cdbc8-480c-4c13-bddd-3dc20b1efd5d.png)


## (Worker) Nodes

- Initially called **Minions**
- **Container runtime**
    - containerd, rkt, lxd
- **Kubelet**
    - Communicates with master
    - Uses CRI shims
- **kube-proxy** 
    - Network proxy

![image](https://user-images.githubusercontent.com/34960418/159253096-2d448ccf-dc57-4501-b88f-80341c0b5fc1.png)


## Pods

- Smallest **unit of scheduling**.
- **One** or **more** containers.
- Containers **share** the pod **environment**.
- **Scheduled** on nodes.
- It is **atomic** – **deployed as one** and on **one node**.
- Created via **manifest files**.

![image](https://user-images.githubusercontent.com/34960418/159253400-925dc582-ae77-4967-9033-2b7287853072.png)

- Each pod has **unique IP** address.
- **Inter-pod** communication is via a **pod network**.
- **Intra-pod** communication is via **localhost** and **port**.

![image](https://user-images.githubusercontent.com/34960418/159253613-29f22d1f-b64d-432c-bec0-5079c029e139.png)


## Replication Controllers

- **Higher** level workload.
- Looks after **pod** or **set of pods**.
- **Scale** up/down **pods**.
- Sets **Desired State**.

![image](https://user-images.githubusercontent.com/34960418/159253974-1340c5cf-e9b2-49fe-8c8e-8063a5b4ff18.png)


## Deployments

- **Even higher** level workload.
- Simplifies **updates** and **rollbacks**.
- **Declarative** and **imperative** approach.
- Self **documenting**.
- Suitable for **versioning**.

![image](https://user-images.githubusercontent.com/34960418/159254292-b00f0bc2-9140-454f-9a33-2687e82dc995.png)


## Services

- Provide reliable network endpoint
  - **IP address**
  - **DNS name**
  - **Port**
- Expose Pods to the outside world
  - **NodePort** (cluster-wide port)
  - **LoadBalancer** (cloud-based)
- Use End Point object to track Pods

![image](https://user-images.githubusercontent.com/34960418/159254588-3bd11196-13cf-4a29-888a-125c59dbc627.png)


## Services in Action

![image](https://user-images.githubusercontent.com/34960418/159254828-615adde8-cdeb-4ca1-9232-7e5ccd7e3374.png)

![image](https://user-images.githubusercontent.com/34960418/159254922-49f6eb91-2084-4189-8896-69ee5a835517.png)

![image](https://user-images.githubusercontent.com/34960418/159254997-5c8ba0ad-b781-46ce-97a9-a9754997818e.png)

![image](https://user-images.githubusercontent.com/34960418/159255099-a9301524-8d39-42f9-ae88-be1c2a7dbe4f.png)


# DevOps

## [What is DevOps?](https://docs.microsoft.com/en-us/azure/devops/learn/what-is-devops)

![image](https://user-images.githubusercontent.com/34960418/159258140-761462a3-918d-43c3-a277-47b69b5a2810.png)


## The Road to DevOps

- **Understand your Cycle Time** - Observe, Orient, Decide, Act.
- **Become Data-Informed** - Use data to inform what to do in your next cycle.
- **Strive for Validated Learning** - Feedback gathered with each cycle should be real, actionable data.
- **Shorten your Cycle Time** - Smaller batches, more automation, improved telemetry, frequent deployments.
- **Optimize Validated Learning** - The sum of improvements that you achieve and the failures that you avoid.


## How to Achieve DevOps?

![image](https://user-images.githubusercontent.com/34960418/159258994-9f6e0189-f7fb-46d1-80ec-4d4a92d8e0a2.png)


## Continuous (Something)

**Continuous Integration** - Series of steps that are automatically performed to integrate code from multiple sources, create a build and test.
**Continuous Delivery** - Helps you build a refined version of the software by continuously implementing fixes and feedback until finally, you decide to push it out to production.
**Continuous Deployment** - Every change goes through an automated pipeline and a working version of the application is automatically pushed to production.


## CD vs CD

![image](https://user-images.githubusercontent.com/34960418/159259699-063b38c4-25b8-46f6-bd7e-cb3fbe014f64.png)


# [Azure DevOps](https://azure.microsoft.com/en-us/pricing/details/devops/server/)

![image](https://user-images.githubusercontent.com/34960418/159260563-ced4fcff-79c0-4a07-b5b4-4b25fb81b439.png)


# [Azure DevOps Services](https://azure.microsoft.com/en-us/services/devops/)

- **Azure Boards** (Agile planning tools)
- **Azure Pipelines** (CI/CD for any platform and language)
- **Azure Repos** (Unlimited free private repos)
- **Azure Test Plans** (Manual and exploratory testing)
- **Azure Artifacts** (Universal package repository)
- **Extensions Marketplace** (Over 1000 extensions)


## [Azure DevOps Pricing](https://azure.microsoft.com/en-us/pricing/details/devops/azure-devops-services/)

- Individual Services
  - Azure Pipelines
  - Azure Artifacts
- User Licenses
  - Basic Plan (w/o Test Plans)
  - Basic + Test Plans
- Azure DevOps for Open Source
  - Azure Pipelines
  - Azure DevOps (all five products)
- Included with Visual Studio Subscriptions

## [Azure Boards](https://docs.microsoft.com/en-us/azure/devops/boards/get-started/what-is-azure-boards)

- Provides a rich set of capabilities for managing software projects.
- The process defines the building blocks of a work-tracking system.
- Supports **Basic**, **Agile**, **Scrum**, and **CMMI** processes.
- Work item types for Basic process are:
  - **Epics** are used to track significant features or requirements.
  - **Issues** are used to track user stories, bugs, or other smaller items of work.
  - **Tasks** are for even smaller amounts of work, measured in hours or days.
- Basic process uses the **To Do**, **Doing**, and **Done** states to track workflow status.
- Track work on interactive **backlogs** and **boards**.
- Collaborate with others through the **Discussion** section.
- Work in sprints, plan and forecast.
- Work effectively by using hierarchies, queries, templates, etc.
- Link issues and tasks to GitHub commits and pull requests.
- Support independent and autonomous teams.
- Can track work across several projects.


## Azure Boards Tools

- **Work items** - Quickly find work items that are assigned to you.
- **Boards** - Present work items as cards and support drag-and-drop status updates.
- **Backlogs** - Present work items as lists. Represents your project plan. It is a sort of repository.
- **Sprints** - Sprint backlogs and taskboards provide a view of work items by iteration or sprint.
- **Queries** - Filtered lists of work items based on criteria defined by us. 


## [Azure Pipelines](https://docs.microsoft.com/en-us/azure/devops/pipelines/get-started/what-is-azure-pipelines)

- Automatically build and test your code project.
- Combines **continuous integration** (CI) & **continuous delivery** (CD).
- Supports **Python**, **Java**, **JavaScript**, **PHP**, **Ruby**, **C#**, **C++**, and **Go**.
- Integrates with **GitHub**, **GitHub Enterprise**, **Azure Repos Git** & **TFVC**, **Bitbucket Cloud**, and **Subversion**.
- Supports application types, such as **Java**, **JavaScript**, **Node.js**, **Python**, **.NET**, **C++**, **Go**, **PHP**, and **Xcode**.
- Multiple targets and package formats.


## [Azure Repos](https://docs.microsoft.com/en-us/azure/devops/repos/get-started/what-is-repos)

- A set of version control tools that you can use to manage your code
- Supports **distributed** (Git) and **centralized** (TFVC) version control
- Git in Azure Repos is standard Git
  - Connect your favorite development environment
  - Review code with pull requests
  - Protect branches with policies
  - Extend pull request workflows with pull request status
  - Isolate code with forks


# [Azure DevOps Projects](https://azure.microsoft.com/en-us/features/devops-projects/)

- Built-in support for popular application frameworks - **.NET**, **Java**, **PHP**, **Node**, **Python**, **Go** and other languages and frameworks.
- Deploy to the platform of your choice - **Azure Web App**, **Virtual Machine**, **Service Fabric** or choose **AKS**.
- Cloud-powered CI/CD - Auto-generated and fully integrated Azure Pipelines.
- Application Insights integration - Rich performance monitoring, powerful alerting, and dashboards.
- Quickly deploy your application to Azure
- Automate the setup of a CI/CD pipeline
- View and understand how to properly set up a CI/CD pipeline
- Further customize the release pipelines based on your specific scenarios


## [Integration with Azure DevOps](https://docs.microsoft.com/en-us/azure/devops-project/overview)

- DevOps Projects is powered by Azure DevOps.
- DevOps Projects automates all the work that's needed in Azure Pipelines to set up a CI/CD pipeline.
- Creates a Git repository in a new or existing Azure DevOps organization.
- Commits a sample application or your existing code to a new Git repository.
- Establishes a CI trigger for the build so that every new code commit initiates a build.
- Creates a CD trigger and deploys every new successful build to the Azure service of your choice.
- The build and release pipelines can be customized further.



# Azure Kubernetes Service (Portal)

## Resource group

Search for **Resource groups** in the main search bar and hit **Enter**. Click on **+ Add**. Check the **Subscription**. For Resource group enter **RG-Kubernetes**. Select **West Europe** for **Region**. Click on **Review + create** and then on **Create**.

![image](https://user-images.githubusercontent.com/34960418/159470302-9c8cd9c4-1849-4c65-aa74-21240337bbec.png)


## Container registry

Search for **Container registries** in the main search bar and hit **Enter**. Click on **+ Create**.

![image](https://user-images.githubusercontent.com/34960418/159470666-7f2c0b5a-96aa-4670-82ca-2e456fc293ce.png)


For **Registry name** enter **azesu**. Check the **Subscription**. For **Resource group** select **RG-Kubernetes** created earlier. Adjust the **Location**. Change **SKU** to **Basic**. Click **Review + create**. Click **Create**.

![image](https://user-images.githubusercontent.com/34960418/159471047-8f9e45b8-aa63-4d12-96d9-256c3b02c6c3.png)


## Kubernetes cluster

Search for **Kubernetes services** in the main search bar and hit **Enter**. Click on **+ Create** and select **Create a Kubernetes cluster**.

![image](https://user-images.githubusercontent.com/34960418/159471668-d21245fc-bd5f-48fe-8f50-40916613368a.png)


Check that the correct **Subscription** is selected. For the **Resource group** select the **RG-Kubernetes** created earlier. In the **Kubernetes cluster name** field enter **aze-kubernetes**. Change **Region** to **West Europe**. Change **Node size** to **Standard B2s**. Set **Node count** to **1**. Click on **Next: Node pools**. Click on **Next: Access**. Click on **Next: Networking**. Click on **Next: Integrations**.

![image](https://user-images.githubusercontent.com/34960418/159472777-7685daa1-289b-4c1a-9fc5-bd433273e05b.png)


Select the registry created earlier in the **Container registry** drop-down list. Click on **Create new** under the **Log Analytics workspace**. 

![image](https://user-images.githubusercontent.com/34960418/159473459-d7c13651-ecbf-4f3c-a482-f26b07cd8c93.png)


Leave the **Region** to **West Europe**. For **Log Analytics workspace** enter **LA-Kubernetes**. Click **Create**.

![image](https://user-images.githubusercontent.com/34960418/159473590-d7b94ad4-9a9e-4199-a457-c384477acb2c.png)


Click **Review + create** and then **Create**.

![image](https://user-images.githubusercontent.com/34960418/159473826-88bc531b-ab64-4d0b-8e05-df6456fe047c.png)


## Explore the cluster

Your first stop is the **Overview**.

![image](https://user-images.githubusercontent.com/34960418/159481299-a34211df-6d21-4919-bb9c-30d311dedeb7.png)


Then, you can visit the **Node pools**.

![image](https://user-images.githubusercontent.com/34960418/159481405-7ee39527-b769-459e-902b-42ae43f5cb2c.png)


Next stop is the **Insights**, **Metrics**, and **Logs** sections.

![image](https://user-images.githubusercontent.com/34960418/159481538-7e4726c2-b125-4e24-b5e8-dee1b8c92c8c.png)


## Scale the cluster

Go to **Node pools** under **Settings**. Select the pool.

![image](https://user-images.githubusercontent.com/34960418/159490541-0ebec128-2858-43f0-8a09-0c62d2722d02.png)


Click on **Scale node pool**.

![image](https://user-images.githubusercontent.com/34960418/159490706-34a6a5c1-9beb-4b85-ac47-1c9f20af72fd.png)


Change **Node count** to **2**. Click **Apply**.

![image](https://user-images.githubusercontent.com/34960418/159491011-86579b02-f1f9-411a-b786-00d163683e23.png)


After a while you will notice that the number of nodes has changed to two.

![image](https://user-images.githubusercontent.com/34960418/159492598-660f559e-db30-424a-9e48-d208f0deb913.png)


If we scale now to 5 replicas:

```bash
kubectl scale --replicas=5 deployment.apps/phpapp-deployment
```

We will notice that some of the pods are on the first node, and others on the second:

```bash
kubectl get pods -o wide
```

![image](https://user-images.githubusercontent.com/34960418/159493097-7da77faf-1e34-4c9c-82fd-b5b8b5edc021.png)




# Azure Kubernetes Service (CLI)

## Login

```bash
az login
```

## Create a resource group

```bash
az group create -n RG-K8S -l westeurope
```

![image](https://user-images.githubusercontent.com/34960418/159477855-c024c33e-e044-47c7-aee4-ba7385a547ed.png)


## Create a container registry

```bash
az acr create -g RG-K8S -n azesucli --sku Basic
```

![image](https://user-images.githubusercontent.com/34960418/159478160-e4e9ab5b-288c-4ed4-a574-b0376d4e763f.png)


## Create the cluster

```bash
az aks create -g RG-K8S -n k8s-demo --node-count 1 --node-vm-size Standard_B2s --enable-addons monitoring --generate-ssh-keys --attach-acr azesucli
```

![image](https://user-images.githubusercontent.com/34960418/159479531-fb5527c5-ab9d-4778-afde-99a971f0be84.png)


## Explore the cluster

In order to get and store the credentials needed for communication with the cluster, you must execute:

```bash
az aks get-credentials --resource-group RG-Kubernetes --name aze-kubernetes
```

![image](https://user-images.githubusercontent.com/34960418/159479888-e2356089-933a-4a05-b4f1-1152afd9bf96.png)


Check versions. Plus minus one minor version is ok. Download **kubectl** from [here](https://kubernetes.io/docs/tasks/tools/).

```bash
kubectl version
```

![image](https://user-images.githubusercontent.com/34960418/159480159-5c4b0608-d84a-4497-b847-4062de7f46c9.png)


Get information about the cluster and nodes:

```bash
kubectl cluster-info
kubectl get nodes
```

![image](https://user-images.githubusercontent.com/34960418/159480590-273f7ca9-9f71-4a99-9685-5818f84b3984.png)
![image](https://user-images.githubusercontent.com/34960418/159480697-b0e32b0e-38cf-493a-9da3-beae87912745.png)


List all namespaces and all pods in every namespace:

```bash
kubectl get namespaces
kubectl get pods --all-namespaces
```

![image](https://user-images.githubusercontent.com/34960418/159480938-99fb24a3-11fa-470c-bd62-1440eb381be8.png)


## Run an application

Extract the file **web-app-php.zip**. Build the image:

```bash
docker build . -t aze-web-app-php
```


Test the app locally:

```bash
docker run -d --name webapp -p 8000:80 aze-web-app-php
```

![image](https://user-images.githubusercontent.com/34960418/159483604-9d32c010-bbb3-42b6-b3c0-fe3e14ef68e1.png)


After we are sure that everything is working as expected, we can continue further. Login to the ACR (Azure Container Registry).

```bash
az acr login --name azesu
```

![image](https://user-images.githubusercontent.com/34960418/159484125-58691092-636e-4997-ad5f-7ba3a7705d65.png)


Check the login server:

```bash
az acr list --resource-group RG-Kubernetes --query "[].{acrLoginServer:loginServer}" --output table
```

![image](https://user-images.githubusercontent.com/34960418/159484297-e32fed0d-58a2-4f38-b6bd-22f081cb6acb.png)


Tag the image:

```bash
docker tag aze-web-app-php azesu.azurecr.io/aze-web-app-php:v1
```


Push the image to our ACR:

```bash
docker push azesu.azurecr.io/aze-web-app-php:v1
```

![image](https://user-images.githubusercontent.com/34960418/159484850-f04094df-6571-4f4b-b3bd-9089c0c4aad9.png)


Check the list of images available on our ACR:

```bash
az acr repository list --name azesu --output table
```

![image](https://user-images.githubusercontent.com/34960418/159485038-beba7e5b-090b-4dce-b10e-29ff66394882.png)


And all tags for an image:

```bash
az acr repository show-tags --name azesu --repository aze-web-app-php --output table
```

![image](https://user-images.githubusercontent.com/34960418/159485218-f62e34fb-7538-47ac-bad4-9be82fcded3d.png)


Integrate our existing ACR with our existing AKS cluster (if not done):

```bash
az aks update -n aze-kubernetes -g RG-Kubernetes --attach-acr azesu
```


Enter the **manifests** folder. Deploy both the service and application simultaneously:

```bash
kubectl apply -f service.yaml -f deployment.yaml
```

```bash
kubectl get svc,pod
```

![image](https://user-images.githubusercontent.com/34960418/159487778-8d7dcff0-b8fa-430f-a51f-96e9e74e6cae.png)


Get the load balancer IP address and paste it into a new browser window to check if the application is working

![image](https://user-images.githubusercontent.com/34960418/159487913-b2367055-a889-45c1-9ffc-b19aafd6c402.png)



## Delete the application

```bash
kubectl delete -f service.yaml -f deployment.yaml
```


## Scale an application

Let’s first check what do we have:

```bash
kubectl get pods
```

![image](https://user-images.githubusercontent.com/34960418/159488453-f1385202-2066-420f-b8fc-14df0e67646f.png)


Get detailed information about the deployment:

```bash
kubectl describe deployment phpapp-deployment
```

![image](https://user-images.githubusercontent.com/34960418/159488638-fedac254-9519-4b70-af6c-135bb1b9c23b.png)


Scale up to 5 replicas:

```bash
kubectl scale --replicas=5 deployment.apps/phpapp-deployment
```


Check what is going on with the pods:

```bash
kubectl get pods
```

![image](https://user-images.githubusercontent.com/34960418/159488903-4b7c3abd-b8e4-412b-b841-eb0017e2692f.png)


Scale once again, this time to 10 replicas:

```bash
kubectl scale --replicas=10 deployment.apps/phpapp-deployment
```

Check that the new pods are created:

```bash
kubectl get pods
```

![image](https://user-images.githubusercontent.com/34960418/159489181-6e8e5492-07a8-4b6f-88b8-c28b7681c711.png)


Now, we can go to the app opened in the browser and refresh a few times to see that it is served by different pods.

![image](https://user-images.githubusercontent.com/34960418/159489389-83a34eaf-6726-4d03-abe3-e8541dd1084a.png)
![image](https://user-images.githubusercontent.com/34960418/159489428-4eb573df-8089-4373-8598-5b0eeb1b0f7d.png)


Let’s scale down a bit:

```bash
kubectl scale --replicas=2 deployment.apps/phpapp-deployment
```


And check what is going on with the pods:

```bash
kubectl get pods
```

![image](https://user-images.githubusercontent.com/34960418/159489755-4d53a625-e18e-4fb2-84b2-6a69bcb1ad6d.png)


## Scale the cluster

```bash
az aks scale --resource-group RG-Kubernetes --name aze-kubernetes --node-count 3 --nodepool-name agentpool
```


After a while, a new nodes will appear:

```bash
kubectl get nodes -o wide
```

![image](https://user-images.githubusercontent.com/34960418/159494785-a59e5e3c-f72e-4052-a472-957cfdd323ce.png)


## Update and redeploy the application

Let’s modify our application. Remember to stop it first if it is still running. This can be done with.

```bash
docker container rm webapp --force
```

Change the title to **Top 10 cities in Bulgaria**, change the **H3** tag to **H2**, and add a border to the table. Save the file. Build the new image:

```bash
docker build . -t aze-web-app-php
```

![image](https://user-images.githubusercontent.com/34960418/159495680-808645ff-9706-481f-b588-e9aa2decee78.png)


Test the app locally:

```bash
docker run -d --name webapp -p 8000:80 aze-web-app-php
```

![image](https://user-images.githubusercontent.com/34960418/159496130-6719d089-9256-4d26-ad12-03629601b59a.png)


After we are sure that everything is working as expected, we can continue further. Tag the image:

```bash
docker tag aze-web-app-php azesu.azurecr.io/aze-web-app-php:v2
```


Push the image to our ACR:

```bash
docker push azesu.azurecr.io/aze-web-app-php:v2
```

![image](https://user-images.githubusercontent.com/34960418/159496519-1fad6513-bc78-48cf-9871-b237c0445d72.png)


Check the list of images available on our ACR:

```bash
az acr repository list --name azesu --output table
```

![image](https://user-images.githubusercontent.com/34960418/159496722-4b08b5b3-ec98-4be0-ab4e-b73be0023638.png)


And all tags for an image:

```bash
az acr repository show-tags --name azesu --repository aze-web-app-php --output table
```

![image](https://user-images.githubusercontent.com/34960418/159496916-55d1f647-5f8c-4521-93fc-6270eee726d8.png)


Change the image version in the **deployment.yaml** file as well

![image](https://user-images.githubusercontent.com/34960418/159497283-237f3bb8-f01d-4c00-9047-f0623caf2981.png)


Deploy both the service and application simultaneously:

```bash
kubectl apply -f service.yaml -f deployment.yaml
```

![image](https://user-images.githubusercontent.com/34960418/159497519-fe510445-3841-463f-b096-a6039b394dc8.png)


We can check periodically how it is going:

```bash
kubectl get svc,pod
```

![image](https://user-images.githubusercontent.com/34960418/159497738-a9f96e73-b702-4672-9646-969a182032dc.png)


We can go to the browser and check the result

![image](https://user-images.githubusercontent.com/34960418/159497922-e33b241f-ce9d-4f0f-bc45-8381f808bce5.png)


# Azure DevOps Boards


