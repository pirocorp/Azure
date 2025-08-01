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

First of all, don't allocate more resources than you need. That seems obvious. And it doesn't just apply to the number of resources. It also applies to the level of resources. Ensure that you fully utilize the resources you allocate. Don't let resources sit unused, because that means you're paying for something you aren't getting any benefit from.




