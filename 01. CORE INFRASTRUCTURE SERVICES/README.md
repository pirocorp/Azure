# Cloud Building Blocks

- **Infrastructure** - Physical resources in the data center of the cloud service provider (CSP) – servers, storage, network equipment, software
- **Resource Sharing** - A combination of hardware and software, responsible for isolation and resource sharing, usually delivers services via virtualization.
- **Development Platforms** - Provides functional support (API) for cloud applications. APIs include cloud storage access, user authentication, etc.
- **Application Software** - System components used by the end-users.

![image](https://user-images.githubusercontent.com/34960418/151962531-8090c758-95f1-4ebb-82af-4810594d49ae.png)

# Types of Cloud Computing

Based on who operates (owns) the cloud, who has access to the cloud services.

- **Public** - The Cloud provider is the owner of the cloud infrastructure. Services are accessible to the public over the Internet. Users can consume services without purchasing and setting up hardware and software. Charging for services usage by the users is typically done for the duration of use.

- **Sovereign clouds** - These public clouds are physically isolated from other public clouds. Only specific organizations have access to sovereign clouds like governments or countries (US, Germany, China, etc.).

- **Private** - An organization owns a cloud infrastructure. The cloud environment is procured, set up, operated, and maintained by the organization. Infrastructure is accessible to specific users via the intranet. End users are sharing resources. The organization defines security and terms of use. 

- **Hybrid** - Infrastructure includes an owned private cloud and a leased public cloud. The organization uses its private cloud most of the time. Only when needed, offload tasks and data to the public cloud. This process is known as cloud bursting. For dealing with regulatory requirements can be used cloud bursting.

# Types of Cloud Services

![image](https://user-images.githubusercontent.com/34960418/151966995-26e0dd04-35c8-4693-819c-c2c87566cfff.png)

## **Infrastructure as a Service (IaaS)**
  
Cloud providers make computing resources available to clients, usually in the form of virtual machines. Computing resources are available to users as a service. Users can scale deployed resources. Multiple users share the same physical resources. Cloud providers make resource offerings at different costs and follow a utility pricing model (typically calculated by the hour).


## Platform as a Service (PaaS)

Provides a software platform without the complexity of purchasing, installing, and maintaining the underlying hardware and software. It can be a database server, web server, etc. A web-based user interfaces for using and configuring the platform. Multitenant architecture in which multiple concurrent users utilize the same tools. Built-in mechanisms enable the platform to scale dynamically to meet demand. Pricing is based on usage(for example, execution time).


## Software as a Service (SaaS)

The cloud provider manages the infrastructure, the platform, and the software itself. Software service is consumed through a web-based client. Software is tended from a central location by the cloud provider. The software delivering model is a one-to-many model. The cloud provider handles software upgrades and patches. Pricing is based on a monthly or annual subscription fee.


# Azure Architecture

![image](https://user-images.githubusercontent.com/34960418/151972193-c25b0531-818e-4ace-938b-d256245bfca8.png)

## [Building Blocks](https://docs.microsoft.com/en-us/azure/availability-zones/az-overview)

**Geographies** - A discrete market, typically containing **two or more regions**, preserves data residency and compliance boundaries.

**Regions** - **Set of datacenters** deployed within a latency-defined perimeter and connected through a dedicated regional **low-latency network**.

**Availability Zones** - Physically **separate locations** within an Azure region. Each Availability Zone is made up of **one or more data centers** equipped with independent power, cooling, and networking.

![image](https://user-images.githubusercontent.com/34960418/151972315-20af874e-ad2f-4885-8eae-59d82843552a.png)


## Azure Administration Levels

- **Account** - An account is needed to use Microsoft services. A single account can be in multiple tenants.
- **Tenant** - Tenant is created when you create your first Azure subscription. New Azure Active Directory is created with the new tenant. 
- **Subscription** - Can have multiple subscriptions under the same tenant.
- **Resource Groups** - Resource groups are used for separating resources in terms of logical or billing level.
- **Resources** - Resources are manageable items available through Azure.


![image](https://user-images.githubusercontent.com/34960418/151974223-780a11e1-4f66-4d91-9941-5597566195e3.png)




