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

### Azure Subscriptions

Azure Subscription is the **billing unit**. They are used to separate Azure environments by financial and administrative logic.

**Management groups** manage multiple subscriptions.

Three different types of Azure Subscriptions
  - Sponsored Subscriptions
    - [Azure Free Account](https://azure.microsoft.com/en-us/free)
    - [Azure for Students](https://azure.microsoft.com/en-us/free/students)
  - Pay-As-You-Go
  - Enterprise Agreement

### Resource Groups and Resources

Resource groups are within a particular location (region) when created. All the resources in a group should share the same lifecycle. They are deployed, updated, and deleted together. Each resource can only exist in one resource group. An Azure resource can be added or removed to a resource group at any time or moved from one resource group to another. A resource group can contain resources in different regions, can scope access control for administrative actions. A resource can interact with resources in other resource groups.

# Azure Services

- **Compute** - Virtual Machines, Virtual Machine Scale Sets, App Services, etc.
- **Networking** - Virtual Networks, Load Balancers, VPN Gateways, etc.
- **Storage** - Storage Accounts, Recovery Services, etc.
- **Database** - Azure CosmosDB, Azure SQL, Azure Synapse Analytics (SQL Data Warehouses), etc.

# [Azure Solutions](https://azure.microsoft.com/en-us/solutions/)

Combinations of Azure services and related products.

- **Internet of Things** - Azure IoT Central, Azure IoT Hub, Azure IoT Edge, etc.
- **Big Data and Analytics** - HDInsight, Azure Data Lake Analytics, Azure Databricks, etc.
- **Artificial Intelligence** - Azure Machine Learning, Azure Cognitive Search, etc.

# Azure Marketplace 

Azure Marketplace is the central place that offers tested and approved appliances. Solutions range from open-source container platforms to threat detection to the blockchain. Provision end-to-end solutions quickly and reliably.

# [Always Free Products and Services](https://azure.microsoft.com/en-us/free/)

- Resource Groups
- Virtual Networks (up to 50)
- Load Balancers (Basic)
- Azure Active Directory (Basic)
- Network Security Groups
- Free-tier Web Apps (up to 10)


# Core Services

## [Virtual Machines](https://docs.microsoft.com/en-us/azure/virtual-machines/)

- Offer various predefined configurations of CPU, RAM, HDD, etc.
- Every configuration exposes some limits as well
- Both Windows and Linux are supported
- Can be created from publicly available image or our own image
- License fees **may apply** based on the chosen OS
- Azure charges an hourly price based on the VM’s size and operating system
- For partial hours, Azure charges only for the minutes used
- Storage is priced and charged separately

### Resources Created with Virtual Machines

- Virtual Machine
- One or More Disk(s)
- Network Interface
- Virtual Network
- Network Security Group
- Public IP Address*
- Storage Account*


### [Virtual Machines Series](https://azure.microsoft.com/en-us/pricing/details/virtual-machines/series/)

- A-Series - Entry-level VMs for dev/test. Suitable for entry level workloads like development and test
- Bs-Series - Economical burstable VMs. Development and test servers.
- D-Series - General purpose compute. Suitable for most production workloads.
- E-Series - Optimized for in-memory hyper-threaded applications. Optimized for heavy in-memory applications such as SAP HANA.
- F-Series - Compute optimized virtual machines. Optimized for compute intensive workloads.
- G-Series - Memory and storage optimized virtual machines. Suitable for large databases (relational or NoSQL) and data warehousing solutions.
- H-Series - High Performance Computing virtual machines. Optimized for HPC applications driven by memory bandwidth (HB) or intensive computation (HC)
- Ls-Series - Storage optimized virtual machines. Low latency, directly mapped local NVMe storage.
- M-Series - Memory optimized virtual machines. Memory optimized and are ideal for heavy in-memory workloads such as SAP HANA. 
- Mv2-Series - Largest memory optimized virtual machines. 
- N-Series - GPU enabled virtual machines. Compute and graphics-intensive workloads, deep learning, and predictive analytics. 


## [Virtual Networks (VNet)](https://docs.microsoft.com/en-us/azure/virtual-network/virtual-networks-overview)

**Virtual Network** (**VNet**) is a fundamental building block for a private network in Azure. Enables many Azure resources to communicate with each other, the internet, and on-premise networks. During creation, we must specify a custom IP **address space**. **Subnets** enable us to segment a virtual network. VNet scope is to a single **region**/location and **subscription**. Network traffic can be filtered via **network security groups**. There is **no charge** for using Azure VNet.


## [Storage](https://docs.microsoft.com/en-us/azure/storage/common/storage-introduction)

Azure Storage is a managed service providing cloud storage. It is **highly available**, **secure**, **durable**, **scalable**, and **redundant**.

- **Azure Blobs**: A massively scalable object store for text and binary data. Also includes support for big data analytics.
- **Azure Files**: Managed file shares for cloud or on-premises deployments.
- **Azure Queues**: A messaging store for reliable messaging between application components.
- **Azure Tables**: A NoSQL store for schemaless storage of structured data.
- **Azure Disks**: Block-level storage volumes for Azure VMs.

Each service is accessed through a storage account


## [Storage Accounts](https://docs.microsoft.com/en-us/azure/storage/common/storage-account-overview)

- Names must be between **3 and 24 characters** in length and may contain **numbers** and **lowercase** letters only. Must be **globally unique**.
- Multiple types, but **General-purpose v2** is recommended.
- **Standard** and **premium** performance tiers are offered.
- **Hot**, **cool**, and **archive** access tiers are available.
- Replication options vary, but include **Locally-redundant storage (LRS)**,** Geo-redundant storage (GRS)**, etc.
- All data in the storage account is encrypted on the service side.

## [Azure Managed Disks](https://docs.microsoft.com/en-us/azure/virtual-machines/windows/managed-disks-overview)

- The main advantage over the unmanaged disks is that there is no need to create separate storage accounts to hold the VHDs.
- The azure-managed disk is a virtual hard disk (VHD).
- Stored as page blobs (random IO storage object in Azure).
- Available types are **Ultra disk**, **Premium solid-state drive (SSD)**, **Standard SSD**, and **Standard hard disk drive (HDD)**.
- Disk roles include **OS Disk**, **Temporary Disk**, and **Data Disk**.


### OS Disk

Every virtual machine has one attached operating system disk. That OS disk has a pre-installed OS selected during VM creation. This disk contains the boot volume. It has a maximum capacity of 4,095 GiB.


### Temporary Disk

Every VM contains a temporary, **not a managed disk**. The temporary disk is for storing data such as pages or swap files. Data on the temp disk may be lost during a maintenance event. On Azure Linux VMs, the temporary disk is **/dev/sdb** by default. On Windows VMs, the temporary disk is **D:** by default. During a successful standard reboot of the VM, the data on the temporary disk will persist.


### [Data Disks](https://docs.microsoft.com/en-us/azure/virtual-machines/disks-types)

Data disks are managed disks. They store application data or other data we need to keep. They are registered as SCSI drives and labeled with a letter of our choice. Each data disk has a maximum capacity of **32,767 GiB** (**Standard HDD**, **Standard SSD**, and **Premium SSD**) or **65,536 GiB** (**Ultra SSD**). 

The size of the virtual machine determines. How many data disks can be attached to it. And the type of storage that hosts the disks.


# Management Tools

## [Azure Portal](https://docs.microsoft.com/en-us/azure/azure-portal/)

- Nice-looking and responsive web UI
- Offers full control over all services
- Suitable for execution of single non-repetitive tasks
- Accessible from anywhere and on any connected device
- Most modern browsers are supported (Microsoft Edge, Safari, Chrome, Firefox, and Internet Explorer 11)
- Available via [portal.azure.com](https://portal.azure.com/)
