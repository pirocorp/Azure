## Data Centres Overview

- Data Centres Overview: 
	- **Current Data Centers**: The current data centre locations are Paris and Brussels. The Brussels data centre would be replaced with two new data centres.
	- **Storage and Compute**: The storage and compute services available in the data centres, including virtual machines, containers, and databases. The use of VMware and Nutanix for managing these services.
 	- **Networking Components**: The networking components involved in the data centres, including the DMZ, firewalls, and connections for customers to access the environment.

<img width="869" height="589" alt="image" src="https://github.com/user-attachments/assets/8878c17d-2d00-4ea6-9049-23fe55db094d" />

- Azure Overview
	- **Regions** - Azure regions are locations where data centers are coupled. Regions consist of multiple data centers.
	- **Availability Zones** - Groups of data centers within a region that provide redundancy and connectivity. Most regions have at least three availability zones to ensure high availability.
	- **Redundancy and Connectivity** - Importance of availability zones for redundancy and connectivity, ensuring that services remain available even if one data center fails.
   
<img width="719" height="542" alt="image" src="https://github.com/user-attachments/assets/f82aaf84-f088-45f0-b536-32514657f2f3" />

- **Infrastructure as Code**: Infrastructure as code (IaaS) in Azure includes virtual machines, storage, and networking components. These services are managed as code, allowing for automation and scalability.
- **Platform as a Service**: Platform as a service (PaaS) offerings, which are built on top of the IaaS layer. Services like databases and web applications simplify management and reduce the need for manual updates.
	- **Service Integration**: PaaS services are often built on top of IaaS components, providing a higher level of abstraction and ease of use for developers — examples like Azure Kubernetes Service (AKS) and SQL databases.
- **Software as a Service**: Software as a service (SaaS) examples like Office 365 and Power Platform. Emphasized the ease of use and scalability of SaaS offerings, which require minimal configuration and management.
	-  **Software as a service (SaaS)** involves providing fully managed applications that require minimal configuration and management. He highlighted the ease of use and scalability of SaaS offerings.

<img width="826" height="576" alt="image" src="https://github.com/user-attachments/assets/9c560881-51d6-40ec-87bb-f262ed6b62bc" />

- **Azure Governance**: The importance of governance in managing these services. He mentioned the role of subscriptions, resource providers, and the Azure Resource Manager (ARM) in managing and securing the environment.
	- **Governance**: Role of subscriptions, resource providers, and the Azure Resource Manager (ARM) in ensuring security and compliance.
	- **Resource Management**:  Azure Resource Manager (ARM) is used to manage resources in Azure. It provides a unified interface for managing services and ensures that policies and permissions are enforced.
- **Networking and Connectivity**: Importance of secure and reliable connections between data centers and regions.
	- **Microsoft Global Network (backbone)**: Microsoft Global Network consists of Microsoft's cables and leased lines, providing connectivity between regions and data centres. Emphasized the reliability and security of this network.
	- **Edge Locations**: Edge locations are points where users can connect to the Microsoft Global Network. These locations provide access to Azure services and ensure low latency and high performance.
	- **Private Connections**: Private connections can be established through providers like Equinex. These connections offer secure and dedicated access to Azure services, ensuring data privacy and reliability.

   <img width="748" height="525" alt="image" src="https://github.com/user-attachments/assets/2d34e6ee-6dcf-4081-8c32-aa9884bd5ea6" />

From On-Prem to Azure (Result of private line):

<img width="862" height="121" alt="image" src="https://github.com/user-attachments/assets/1015179a-36bb-45d9-aa8a-33b1a57680e0" />

- **Management and Governance Tools**: Management and governance tools available in Azure, such as role-based access control (RBAC), policies, and monitoring tools like Azure Defender and Sentinel. Emphasized the importance of these tools in maintaining security and compliance.
	- **RBAC**: Tim explained role-based access control (RBAC) as a tool for managing permissions in Azure. RBAC allows administrators to define roles and assign permissions to users, ensuring that only authorized individuals can access resources.
	- **Policies**: Use of policies in Azure to enforce compliance and security standards. Policies can be used to restrict actions, enforce configurations, and ensure that resources are managed according to organizational guidelines.
	- **Monitoring Tools**: Monitoring tools like Azure Defender and Sentinel, which provide security and monitoring capabilities. These tools help detect and respond to threats, ensuring the security of Azure environments.
   
 <img width="802" height="670" alt="image" src="https://github.com/user-attachments/assets/cb79c6b9-d4e1-4811-9d0d-2212cd2f59f6" />

- **Azure Landing Zones**: A Structured approach to building and managing environments in Azure. These zones provide a framework for setting up resources, ensuring consistency and compliance.
	- **Governance and Security**: These zones include predefined policies and configurations to ensure that resources are managed securely and in compliance with organizational standards.
	- **Architecture**: Architectural considerations for Azure Landing Zones, including network design, resource organization, and integration with existing systems. Highlighted the need for a well-defined architecture to ensure scalability and reliability.
 

- **Entra ID** - Previously known as Azure AD (Active Directory) - Identity system of Azure. You can connect your on-prem domain through Entra Connect. And here is where all the users live. (User Access Control)
- **Tenant** - To do anything in the cloud, you need to have a tenant (something like a domain on-prem). Example Euroclear's tenant is Euroclear.com, and it has registered for it in Entra ID
- **Management Group** - Allows grouping multiple subscriptions
- **Subscription** - Where you put your credit card. Way to group things, grant rights, access, etc.
- **Resource Groups** - All resources can be put in Resource groups. It is a way to organize resources, rights, and other relevant elements.
- **User-Subscription Access-Control levels** - Owner, Contributor, Reader -> Subscription level rights translate to the same right underneath (e.g., resource groups, resources under that subscription).

<img width="1051" height="678" alt="image" src="https://github.com/user-attachments/assets/1623cba3-dd0c-4e0c-bf56-3eab28452f1c" />



## Cloud Concepts

### Cloud computing 

Basic requirements include computers connected to a network, but many other components make up cloud computing.

### Shared responsibility model

This is a key concept in cloud computing, meaning that you and the cloud provider share the responsibility for the apps that you run in the cloud. 

Now, how much of that responsibility relies on you versus the cloud provider? Depends on the choices you make when you deploy to the cloud. But it's important to note that the cloud provider rarely takes responsibility for everything. At least part of the responsibility for your app performing the way you want it to will be yours. And there's another critical point here. 

Cloud providers will only take responsibility for things that are within their control. So, for example, if you deploy a website to the cloud and it has software bugs that impact the app negatively, the cloud provider will never take responsibility for that, because it's not entirely within their control. As I said earlier, there are decisions you can make that impact the amount of responsibility that you have in the cloud.



## Cloud models 

Three different cloud models are available to you, and each one of them has its unique benefits and drawbacks.

### Public Cloud 

Shared infrastructure, things like networks, computers, and so forth, that a cloud provider provides. The public cloud is often referred to as a multi-tenant environment because multiple companies and people share the same underlying infrastructure.

#### Benefits:

- **Agility** -  you can easily add resources when you need them, and reduce the number of resources when you don't. The public cloud often provides features that make agility an automatic thing, so you don't even have to think about it.
- **Quick deployment**
- **Easy management of cloud applications** - how easy management is differs depending on which type of service you use. But cloud providers in the public cloud are always going to offer some features to make management of your cloud services as easy as possible.
- **Costs Control** - You usually only pay for what you use in the cloud. And the cloud provider gives you powerful tools that enable you to track costs and prevent unwanted charges.

#### Drawbacks:

- **Loss of Control** - You don't have visibility into the entire infrastructure. So you have to rely on the cloud provider for many things that might otherwise be within your control.
- **Security and regulatory requirements** - You might find some challenges in the public cloud. Cloud providers recognize that security and regulatory requirements are essential, and they take steps to address these requirements. But depending on how strict your requirements are, the public cloud may not be your best choice.
- **Loss of flexibility**  - Cloud providers give you cloud offerings that are configured a certain way, and you're often locked into choosing one of those pre-configured choices rather than choosing everything yourself
- **Shared infrastructure** - depending on your requirements, that might be a drawback for you, especially if you have security and privacy needs that require your data not to be on shared systems.


### Private Cloud

A private cloud is dedicated to a single company, and for that reason, it's sometimes referred to as a single-tenant cloud.

#### Benefits:

- **Agility** - Just like the public cloud, the private cloud provides agility with all the same benefits that we discussed when we were going over the public cloud model. The private cloud can also be used without access to the Internet.
- **Can be used without access to the Internet** - can operate in a disconnected way and then sync systems with the infrastructure that exists across that private cloud when they get back online.
- **Costs Control** - you own everything and don't have to pay any fees or costs that are incurred in the public cloud. However, in the private cloud, costs can be a double-edged sword.
- **Private network** - a network that's dedicated to your company, and that means you don't share any network infrastructure with anyone else. That can be important for many companies that rely on privacy.

#### Drawbacks:

- **Owned Infrastructure** -  You can utilize the private cloud by paying a private cloud provider to supply the infrastructure to you. Now, that infrastructure is still dedicated only to you, but a third-party provider owns it, and they incur the cost of IT staff, power, and other operational expenses. However, you can also buy the infrastructure yourself, and if you go that route, costs can be high because you have to pay for the infrastructure up front, and you need IT staff to manage it and all of those things.
- **May not be able to effectively control access to data if you pay a third-party provider** - Even though the infrastructure is dedicated to you, the third-party provider will own and manage the systems on which the data lives. And that could be a concern for you. Now, to alleviate that, you'd need to own the infrastructure yourself, thereby increasing your costs and your management efforts.


### Hybrid Cloud

The hybrid cloud is a mix of public and private cloud models. One of the benefits of the hybrid cloud model is that you keep some systems on-premises.

#### Benefits:

- **Keep some systems on-premises** - For example, if you have a secure database system, let's say that your cloud application needs to use it, you can keep that database system on-premises, and then use networking features of the cloud to connect it to your cloud resources.
- **Support for legacy systems** - You might have some older systems on-premises that aren't compatible with modern systems in the cloud, and by using the hybrid cloud, you can continue to use those legacy systems with your cloud applications.
- **Maintaining control over your data and infrastructure** - when needed.
 

#### Drawbacks:

- **Technically complex to connect systems** - not only to set up in the first place, but also to troubleshoot if something goes wrong.
- **Compatibility of Data** - Example:  an older database technology on-premises
- **IT expertise within your company** - to manage the on-premises resources and those connectivity requirements to your cloud applications.

Choosing the right cloud model can be a challenge. The best approach is to list your requirements related to ease of management, privacy, security, and so on, and once you do that, you'll be in a better position to weigh the pros and cons of each model and settle on your best choice.

 
### Consumption-based model

What that means is that you pay only for those resources that are allocated to you. Now, the use of the word "allocated" is vital because you can have a cloud resource that's allocated to you even though you aren't using that resource. In the cloud, if something is assigned to you, you're consuming it even if you aren't actively using it.

- First of all, don't allocate more resources than you need. That seems obvious. And it doesn't just apply to the number of resources. It also applies to the level of resources.
- Ensure that you fully utilize the resources you allocate. Don't let resources sit unused, because that means you're paying for something you aren't getting any benefit from.


## Benefits of using cloud Services

### High availability and scalability

- **High Availability**: This means that applications and systems are accessible by users most of the time. The cloud offers high availability, typically 99% or higher, by accounting for various factors that might impact availability, such as network outages, application failures, and power outages.
- **Scalability**: The cloud provides two types of scalability:
- **Vertical Scaling (Scaling Up/Down)**: Moving to a more powerful machine or service (scaling up) or to a less powerful one (scaling down) based on needs.
- **Horizontal Scaling (Scaling Out/In)**: Adding more instances of a resource like virtual machines (scaling out) or reducing the number of instances that are no longer needed (scaling in).
- **Elasticity**: The ability to easily scale resources up and down or out and in, making the cloud highly adaptable to changing needs.
 
These concepts are crucial for ensuring that your applications remain available and can handle varying loads efficiently.


### Reliability and Predictability

- **Fault Tolerance**: The ability to maintain availability even when a fault occurs, such as a networking problem, power outage, or hardware failure. The cloud offers features that provide fault tolerance.
- **Disaster Recovery**: Planning for large-scale events like natural disasters (e.g., hurricanes, forest fires, floods) that can impact availability. This involves creating a Business Continuity & Disaster Recovery (BCDR) plan, with tools and information provided by cloud providers to help develop a robust strategy.

These concepts are essential for ensuring that your systems remain reliable and predictable, even in the face of faults or disasters.

 

### Security and governance

- **Security**: Refers to restricting access to your resources to only those people you allow. Cloud providers offer documentation and services to help configure security properly.
- **Governance**: Involves the level of access someone has once they gain access, including what they can do and how they can do it. Governance helps comply with regulations and company policies, and can save money by optimizing resource usage.
- **Cloud Provider Assistance**: Azure provides features and services to identify and correct security and governance concerns easily, often before they impact you.

These concepts are crucial for managing access and ensuring compliance with regulations and company policies.


### Manageability in the cloud

- **Ongoing Management**: Deploying to the cloud requires continuous monitoring and management to ensure everything runs smoothly and costs are controlled.
- **Monitoring Tools**: The cloud provides tools to monitor resources, including performance and cost management, easily.
- **Scaling Resources**: Tools are available to scale resources as needed, including automatic scaling based on configurable rules.
- **Budgeting**: Cloud tools help you budget and manage spending, alerting you proactively if you are about to exceed your budget.

These points highlight the importance of active management and the tools available to simplify this process in the cloud. 


#### **Cloud Service Types**: There are three different cloud service types, each with its benefits and drawbacks. 

- **Infrastructure as a Service (IaaS)**: Provides flexibility in managing and controlling computing resources.
- **Platform as a Service (PaaS)**: Simplifies adding powerful functionality to applications.
- **Software as a Service (SaaS)**: The easiest way to take advantage of the cloud, offering ready-to-use applications.


#### Infrastructure as a service (IaaS)

- **Infrastructure Provided by Cloud Provider**: IaaS involves the cloud provider supplying the infrastructure, such as computers, networking components, and storage.
- **Consumption-Based Costs**: Costs in IaaS are typically based on consumption, meaning you pay for what you use.
- **High Responsibility and Control**: IaaS gives you the most significant level of responsibility for managing the infrastructure but also provides the highest level of control over it.

Azure Virtual Machines are a good example of an IaaS service in Microsoft Azure. 

These points highlight the flexibility and control offered by IaaS, along with the responsibility it entails.


#### Platform as a service (PaaS) 

- **Definition**: PaaS provides not just the infrastructure but also the operating system and middleware components needed for the service.
- **Ease of Use**: PaaS services offer many easy-to-use, turnkey features that require minimal configuration.
- **Management Burden**: PaaS reduces the management burden compared to IaaS, offering a balance between responsibility and control.

Example: Azure App Service is an example of a PaaS offering in Microsoft Azure.

These points highlight how PaaS simplifies application development and management by providing essential components and reducing the need for extensive configuration.


#### Software as a service (SaaS)

**Comprehensive Service**: SaaS includes the infrastructure, operating system, and the software itself, all provided by the cloud provider.
**Ease of Access**: SaaS services are typically accessed via web browsers or apps on various devices, and they often operate on a pay-as-you-go or free basis.
**Minimal Responsibility**: Users have the least responsibility in managing the service compared to other cloud models, but also have limited control over the service.

Common Usage: SaaS is widely used, often without users realizing it, for services like web-based email (e.g., Outlook.com) and online storage (e.g., OneDrive).

These points highlight the convenience and widespread use of SaaS, along with its minimal user management requirements.
 

#### Thought experiment: Analyzing cloud types 

- **Public Cloud**: Offers easy management, fault tolerance, and agility but uses shared infrastructure, which may not meet strict privacy requirements.
- **Hybrid Cloud**: Provides more control over data by keeping some resources on-premises, but can involve complex networking issues.
- **Private Cloud**: Ensures data privacy and compliance by using dedicated infrastructure, managed by a private cloud provider, though it may be more costly.

These points help in understanding the trade-offs between different cloud deployment models based on specific requirements.

 
## Core Architectural Components of Azure


### Azure Regions, Region Pairs, and Sovereign Regions

- **Azure Geographies**: Azure is divided into geographies, which are boundaries defined for compliance with regulations. These can be based on countries, continents, or other criteria.
- **Azure Regions and Region Pairs**: A region is a physical location within a geography that contains data centers. Each region is paired with another for disaster recovery, ensuring high availability and minimal impact during updates.
- **Sovereign Regions**: There are three special regions called sovereign regions: Azure Government (for US government and affiliated entities), Azure Germany (for compliance with EU regulations), and Azure China (for compliance with Chinese regulations).

### Availability zones

- **Availability Zones**: These are unique physical locations within an Azure region, each containing one or more data centers. They are designed to protect applications from data center failures.
- **Zonal vs. Zone Redundant Services**: Zonal services, like Azure virtual machines, require manual deployment across multiple zones. Zone redundant services, like Azure storage, automatically replicate data across zones.
- **Fault Tolerance**: Availability Zones provide fault tolerance within a region but are not suitable for disaster recovery, as a disaster could affect all zones within a region.

### Azure datacenters

- **Physical Infrastructure**: Azure datacenters are physical buildings within an Azure region, containing hardware like network switches, server racks, and servers.
- **Isolation and Independence**: Each datacenter has its own climate control, dedicated network infrastructure, isolated power supply, and power generators to ensure fault tolerance.
- **Data Flow**: All data flowing into and out of a datacenter uses cables owned or leased exclusively by Microsoft, enhancing reliability and predictability.


### Azure Resources and Resource Groups

- **Azure Resources**: Any entity created within Azure, such as web apps, virtual machines, databases, and storage.
- **Resource Groups**: Logical containers designed to help with resource management, cost control, and organization.
- **Benefits of Resource Groups**: Simplify deletion of multiple resources, improve billing experiences with tags, and facilitate redeployment using ARM Templates.


### Management Groups

- **Purpose of Management Groups**: Management groups are used to organize multiple Azure subscriptions, providing a way to manage them collectively.
- **Hierarchy**: You can only place Azure subscriptions or other management groups within a management group, creating a hierarchical structure.
- **Example Structure**: A company might have top-level management groups for different departments (e.g., Sales, IT, Training), with each containing relevant subscriptions. This helps in organizing and managing resources effectively.


## Azure Compute and Networking services

### Compute Definition: 

Compute refers to cloud services that consume resources like CPU and memory.

### Containers: 

Containers are isolated virtual environments for applications, created using images that include everything the application needs.

### Azure Compute Types:

- **Azure Virtual Machines (VMs)**: Allow creation of VMs with pre-installed operating systems, requiring configuration and deployment by the user.
- **Azure Container Instances (ACI)**: Run containers directly without needing a VM, paying only for the memory and CPU used.
- **Azure Functions**: Designed for microservices that perform quick operations, running in a consumption-based model where you pay only for the compute resources used.

### VM options

- **Azure Virtual Machines (VMs)**: VMs are available for both Windows and Linux, and you are only billed when they are running.
- **Availability Sets**: These consist of fault domains and update domains to ensure high availability and fault tolerance.
- **Virtual Machine Scale Sets (VMSS)**: VMSS allows you to scale VMs automatically, using identical VMs for fault tolerance.
- **Azure Virtual Desktop**: This service provides desktop virtualization, allowing applications to run in a virtualized environment without being installed on the user's device.

### Resources required for virtual machines

- **Resource Group**: When creating a virtual machine, a resource group is created to organize and manage related resources.
- **Essential Resources**: Creating a virtual machine automatically generates several resources, including a virtual network, public IP address, network security group, virtual network interface, and an operating system disk.
- **SSH Key**: If using a Linux operating system with SSH for remote access, an SSH key is also generated.

### Application hosting options

- **Azure App Service**: A PaaS service used to create and host web apps in the cloud. It offers various tiers for hosting, with higher tiers providing more features and power. It supports easy scaling and includes built-in features like authentication providers.
- **Azure Kubernetes Service (AKS)**: A powerful container orchestration service for managing and scaling containers. It simplifies the adoption of Kubernetes by managing the infrastructure for you.
- **Virtual Machines (VMs)**: The most flexible hosting option, allowing full control over the environment. However, it requires more responsibility for installation, configuration, and security.

### Virtual networking

- **Azure Virtual Networks**: These enable you to configure your networking in Azure similarly to on-premises setups, without the need for physical hardware.
- **Subnet Configuration**: You can create multiple subnets within a virtual network, each serving different purposes (e.g., web tier, middle tier, data tier).
- **Virtual Network Peering**: This allows you to connect two Azure virtual networks, with traffic traveling over Microsoft's private backbone network.
- **Azure DNS**: Facilitates easy management of DNS records in Azure, with public zones for internet-facing domains and private zones for internal use.
- **Azure VPN Gateway**: Provides secure connections between Azure virtual networks and other networks, with different types of VPN gateways for various connection needs.
- **Azure Express Route**: Offers high-speed, dedicated connections between Azure resources and on-premises resources, bypassing the internet for enhanced performance and security.

### Public and Private endpoints

- **Public Endpoint**: A resource with an IP address that is reachable over the internet.
- **Private Endpoint**: A resource with an IP address that is only reachable over a private network.
- **Dual Endpoints**: A resource can have both a public and a private endpoint, providing flexibility in access.


## Azure Storage Services

- **Azure Blob Storage**: Designed for storing unstructured files like pictures, audio files, videos, and documents. It includes block blobs, append blobs, and page blobs.
- **Azure Disks**: Used for storing disks in virtual machines, available as either spinning platter disks or solid-state drives.
- **Azure Files**: An SMB-based service providing disk space in the cloud, accessible via a mapped drive or network share. Azure File Sync can be used to synchronize files locally for faster access.

### Storage tiers

- **Hot Tier**: For data accessed frequently. Highest storage cost but lowest access costs.
- **Cool Tier**: For data stored for longer periods. Lower storage cost than the hot tier but higher access costs. Data must be stored for at least 30 days.
- **Archive Tier**: For long-term storage. Lowest storage cost but highest access costs. Data must be stored for at least 180 days and requires hydration to access.

### Redundancy options

- **Locally-Redundant Storage (LRS)**: Creates three copies of your data within the same data center. Least expensive but also the least durable.
- **Zone-Redundant Storage (ZRS)**: Creates three copies of your data across different availability zones within the same region, providing higher durability.
- **Geo-Redundant Storage (GRS)**: Combines LRS in the primary region with three additional copies in a secondary region, offering protection from regional disasters.
- **Geo-Zone-Redundant Storage (GZRS)**: Combines ZRS in the primary region with three additional copies in a secondary region, providing the highest level of durability and disaster recovery.

### Storage account options

- **General-Purpose v2 Storage Account**: Recommended for most purposes, supporting blob storage, Azure files, queue storage, and table storage with all redundancy options.
- **Premium Storage Accounts**:
	- **Premium Block Blobs**: For block blobs and append blobs, with LRS and ZRS redundancy options.
	- **Premium File Shares**: For file shares in Azure files, supporting LRS and ZRS redundancy.
	- **Premium Page Blobs**: For storage of page blobs, supporting LRS redundancy.

Performance: Premium storage accounts use solid-state drives (SSDs) for maximum performance.




