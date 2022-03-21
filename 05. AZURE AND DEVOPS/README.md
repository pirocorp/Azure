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


# Azure DevOps Projects
