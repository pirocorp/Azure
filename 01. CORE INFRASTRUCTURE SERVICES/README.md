# Jump to practical guides

- [Create a Linux (Ubuntu-based) VM (Azure Portal)](#create-a-linux-ubuntu-based-vm-azure-portal)
  - [Connect to the VM (Linux)](#connect-to-the-vm)
  - [Install a web server (Linux)](#install-a-web-server)
  - [Adjust the security (Linux)](#adjust-the-security)
  - [Add additional disk (Linux)](#add-additional-disk)
- [Create a Windwos VM](#create-a-windows-vm)
  - [Connect to the VM (Windows)](#connect-to-the-vm-windows)
  - [Install a web server (Windows)](#install-a-web-server-windows)
  - [Adjust the security (Windows)](#adjust-the-security-windows)
  - [Add additional disk (Windows)](#add-additional-disk-windows)
 - [Azure the Console Way](#azure-the-console-way)
   - [Create а Simple Solution with Azure CLI](#create-%D0%B0-simple-solution-with-azure-cli)


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
- Suitable for the execution of single non-repetitive tasks
- Accessible from anywhere and on any connected device
- Most modern browsers are supported (Microsoft Edge, Safari, Chrome, Firefox, and Internet Explorer 11)
- Available via [portal.azure.com](https://portal.azure.com/)


## [Azure Cloud Shell](https://docs.microsoft.com/en-us/azure/cloud-shell/overview)

- An interactive, authenticated, browser-accessible shell for managing Azure resources
- Supports both **Bash** or **PowerShell** modes
- Can be started from the Azure Portal or via [shell.azure.com](https://shell.azure.com)
- Integrated **code editor** and many other tools
- Requires **Azure Files**(Regular costs apply) share to persist the home folder


## [Azure CLI](https://docs.microsoft.com/en-us/cli/azure)

Free command-line utility, installed additionally. Supported **Windows** (**+WSL**), **Linux**, **macOS**, and **Docker**. Actions are triggered via **commands (nouns)**, **sub-commands (verbs)**, and **properties**.

```bash
az noun verb --properties [...]
```

For example, to create a **resource group**

```bash
az group create --name RG-Demo --location westeurope
```

Most properties have long (**--name**) and short (**-n**) form


## [Azure PowerShell Module](https://docs.microsoft.com/en-us/powershell/azure)

Free command-line utility, installed additionally. Requires **PowerShell** (**5.1+**) or **PowerShell Core** (**6.x+**). Supported on **Windows**, **Linux**, and **macOS**. Actions on resources are available through separate commands.

```powershell
Action-AzTargetResource
```

For example, to create a resource group:

```powershell
New-AzResourceGroup -Name RG-Demo -Location WestEurope
```

## [Azure (Unified) SDKs](https://aka.ms/azurecom-sdk-dl-net)

Collections of libraries for programming languages. Used to build applications that manage and interact with Azure services. Unified SDKs focus on consistency, familiarity, and language idiomaticity. Unified SDKs support .NET, Java, JavaScript, and Python. For new projects, Unified SDKs are the recommended way.


## [Azure Mobile App](https://azure.microsoft.com/en-us/features/azure-portal/mobile-app/)

Available both on **App Store** and **Google Play**. Monitor the health and status of Azure resources. Quickly diagnose and fix issues. Run commands to manage Azure resources.


# Consoles Crash Course

## CMD

- This is the classic command-line interface of Windows
- Usually, no Tab completion of commands and arguments
- Environment variables are declared and used like:

```cmd
set LOCATION=westeurope
set RESOURCE_GROUP=RG-Demo-CMD
az group create --name %RESOURCE_GROUP% --location %LOCATION% 
```

Individual lines in a multi-line command are separated with ```^```

```cmd
C:\> az group create --name %RESOURCE_GROUP% ^
More? --location %LOCATION%
```

## Bash

- Case sensitive shell available in most Unix-like OSes 
- Usually, tab completion is available
- Environment variables are declared and used like:

```bash
LOCATION=westeurope
RESOURCE_GROUP=RG-Demo-Bash
az group create --name $RESOURCE_GROUP --location $LOCATION 
```

Individual lines in a multi-line command are separated with ```\```

```bash
$ az group create --name $RESOURCE_GROUP \
>> --location $LOCATION
```

## PowerShell (Core)

- Case in-sensitive shell available in Windows, Linux, and macOS
- Usually, tab completion is available
- Environment variables are declared and used like:

```powershell
$LOCATION="westeurope"
$RESOURCE_GROUP="RG-Demo-PS"
New-AzResourceGroup -Name $RESOURCE_GROUP -Location $LOCATION
```
Individual lines in a multi-line command are separated with ``` ` ```

```powershell
PS C:\> New-AzResourceGroup -Name $RESOURCE_GROUP ` 
>> -Location $LOCATION
```


# Create a Linux (Ubuntu-based) VM (Azure Portal)

Let’s create an **Ubuntu 20.04** machine with all settings by default.

Go to the home view if you are not there. In the search box, start typing virtual machines. When you see the Virtual machines option, click on it.

![image](https://user-images.githubusercontent.com/34960418/152121856-b152f7b7-586e-4b3d-a807-cdd48c6ec891.png)

Click on the **+ Create** button and select **Virtual machine** in the drop-down list.

![image](https://user-images.githubusercontent.com/34960418/152122077-ac35b768-98a2-4ce5-b58c-efb216dfd825.png)

Select your **subscription** if not selected. In the **resource group** section, click on **create new**. Enter a name, for example, **RG-Demo-1** and hit **OK**.

![image](https://user-images.githubusercontent.com/34960418/152122518-d070aeb4-9f52-47ea-90d1-f3af944648d3.png)

For **virtual machine name** enter **VM-Demo-Ubuntu-1**. It must be unique for the resource group. In the **region** drop-down, select something closer to your location, for example, **(Europe) West Europe**. In the **image** drop-down select **Ubuntu Server 20.04 LTS - Gen 2**.

![image](https://user-images.githubusercontent.com/34960418/152123162-39cdf162-2015-45e1-9565-effdc677fe21.png)

Click on the **size** option. Explore the available VM sizes. Select something smaller, for example, **B1s**. Then click on the **select** button.

![image](https://user-images.githubusercontent.com/34960418/152123508-6f4364e7-78ed-429f-a2f6-dcf6b896b894.png)

![image](https://user-images.githubusercontent.com/34960418/152123564-f28979c4-f60d-4fac-abe9-4560e5a0e214.png)

For **authentication type** select the **password** option. In the **username** field enter for example **demouser**. **Password** must comply with the following, a length between 12 and 72 characters, must have three of the following: one lower case, one upper case, one number, and one special character, must not include reserved words or unsupported characters. Enter for example, **DemoPassword-2022**.

![image](https://user-images.githubusercontent.com/34960418/152124144-12a72842-37c8-4874-8298-f5af63d062a4.png)

Hit the **Review + create** button to examine what we are creating.

![image](https://user-images.githubusercontent.com/34960418/152124582-abe92a04-ec10-4c63-a619-bcebd81e90a7.png)


Click on the **Create** button to initiate the creation process.

![image](https://user-images.githubusercontent.com/34960418/152125366-fc4782c1-47fe-49f7-8e82-ee63a224b8e6.png)

Now, we can sit and watch the **deployment** process. It will finish in 30 or so seconds.

![image](https://user-images.githubusercontent.com/34960418/152125625-6434100a-a742-40fa-8c0b-db7460a40319.png)

Once deployment is complete click, on the **Go to resource** button.

![image](https://user-images.githubusercontent.com/34960418/152125946-a58dcc98-f6ad-4f1c-b3e9-756eccf9313f.png)

This is the newly created virtual machine.

![image](https://user-images.githubusercontent.com/34960418/152126367-ce5397bf-d0ff-4a3d-bb4c-6269eaa23f0d.png)

Go to the **Home** screen. Click on the **Resource groups** option in the **Azure services** section.

![image](https://user-images.githubusercontent.com/34960418/152126771-ccb6d293-bab4-43ae-b141-5cd3e3bd95e2.png)

In the list of groups, click on the **RG-Demo-1** group.

![image](https://user-images.githubusercontent.com/34960418/152126951-52f5fe08-ffcd-430a-84ca-b1eb37986b20.png)


Those are all resources created together with the virtual machine.

![image](https://user-images.githubusercontent.com/34960418/152127091-1b20f1f2-a2b7-4084-bd58-1ffba781f94f.png)


## Connect to the VM

In the resource group overview, find the virtual machine **VM-Demo-Ubuntu-1** and click on it.

![image](https://user-images.githubusercontent.com/34960418/152130062-66f90e3c-7b2f-4ba0-9d13-57ae49f0756d.png)

Virtual machine **overview** has the details about its size, public, and private IP addresses, etc. Can stop, restart, and delete the machine as well. Most of the information is in the **Properties** tab. 

![image](https://user-images.githubusercontent.com/34960418/152130981-c33618e6-eea5-463f-b0e0-81c5bd676228.png)

The **monitoring** tab has a few charts that show how the machine is performing.

![image](https://user-images.githubusercontent.com/34960418/152131766-c6d56797-bd41-456e-942b-821b8f1a57da.png)

Click on the **Connect** command in the top-left part of the **Overview** screen and select the **SSH** option from the list.

![image](https://user-images.githubusercontent.com/34960418/152132449-cbf70e36-9d06-42a0-be3f-34622c820f49.png)

Examine the provided instructions. As you can see, they suppose that we are using a key pair to connect to the VM. In the current situation, we will use username and password pair instead. 

![image](https://user-images.githubusercontent.com/34960418/152132708-5a0cae39-c89a-41f8-bfce-151191038583.png)

Depending on your host operating system and the available software, you must either start an SSH client (like **PuTTY**) or open a terminal window (if running on **Linux**, **macOS**, or **Windows 10** with **OpenSSH** client installed). To connect to the VM, execute this:

```cmd
ssh demouser@<public-ip-address>
```

Here we can execute standard Linux commands ```like``` ```ps```, ```top```, ```ls```, ```free```, ```uname```, etc.

![image](https://user-images.githubusercontent.com/34960418/152133761-ac8a2fc6-6cf3-4afe-aecb-cc2fe4a04906.png)


# Install a web server

Because this is a **standard Ubuntu** installation, we can add software as if we are working on a “regular” VM. 

Refresh the repositories information, upgrade installed packages, and install the **nginx** web server with these commands. Use the **sudo** in front of every command above because of higher privileges needed to modify the system configuration.

```bash
sudo apt-get update
sudo apt-get upgrade
sudo apt-get install -y nginx
```

Check if the webserver is running:

```bash
systemctl status nginx
```

![image](https://user-images.githubusercontent.com/34960418/152135987-07cb2114-b073-4e90-a46e-774115681634.png)

If it is not running, we could start and enable (autostart on reboot) it with (skip it if the above showed **running**):

```bash
sudo systemctl start nginx
sudo systemctl enable nginx
```

## Adjust the security

Return to the **resource group** in the **Azure Portal**. Find the **VM-Demo-Ubuntu-1-nsg** security group created during the virtual machine deployment and click on it.

![image](https://user-images.githubusercontent.com/34960418/152137044-d767c746-67b6-4ebc-8ee3-e638185d68e1.png)

The **Overview** has two sections – **Inbound security rules** and **Outbound security rules**. They are like a summary (overview) of how the security group is configured.

![image](https://user-images.githubusercontent.com/34960418/152138119-1e7f8af8-bdc0-4bc3-9526-58880d828e01.png)

Click on the **Inbound security rules** under the **Settings** section. Click on the **Default rules** button to hide the default security rules. Only the one for **SSH** remains, created during the machine deployment. Now click on the **+ Add** button to add one more rule.

![image](https://user-images.githubusercontent.com/34960418/152138912-a00dd1e3-ca64-43cd-93df-46f8f3fc0f90.png)

Change the **Destination port ranges** value to **80**. Set the **Protocol** selector to **TCP**. In the **Name** field enter for example **HTTP-Port-80**. Click on the **Add** button to confirm.

![image](https://user-images.githubusercontent.com/34960418/152139456-83f554dd-d5ee-4ae4-a3b1-8a2b14d183ff.png)
![image](https://user-images.githubusercontent.com/34960418/152139790-900ba6a4-c462-4048-9d4f-434419221e83.png)

Now, switch back to the browser tab with the error and hit **refresh**. You should see the default **NGINX** web page.

![image](https://user-images.githubusercontent.com/34960418/152140039-d9f0d2ca-59aa-4291-a5e5-dec95bc40bf5.png)

## Add additional disk

Return to the shell session or re-establish a new one. Let’s check what disk devices are available and how they are utilized:

```bash
lsblk
```

![image](https://user-images.githubusercontent.com/34960418/152141474-0bd56bf7-fb37-4c4a-8700-a4633b46d60e.png)

We can see that there are two disk drives – sda (operating system is there) and sdb (temp disk). Let’s return to the portal. Go to the **VM-Demo-Ubuntu-1** virtual machine. Click on the **Disks** command in the **Settings** section. Click on **+ Create and attach a new disk** button under the **Data disks** section. For Disk name enter: **VM-Demo-Ubuntu-1_disk2**. You can change **Storage type** and **Size**. Select **Standard SSD** for storage type and **16 GiB** for size. Confirm with the **Save** button (top left).

![image](https://user-images.githubusercontent.com/34960418/152144099-66e61bfa-aa95-4ad9-9ff9-3bc9474a6df7.png)


After a while saving process will finish. Return to the resource group and hit **Refresh** button to see the new resource.

![image](https://user-images.githubusercontent.com/34960418/152144810-88a547e5-6d1e-4156-afba-e630d0054639.png)

Return to the console session or if you closed it, establish a new one. Check again what disks are available with:

```bash
lsblk
```

![image](https://user-images.githubusercontent.com/34960418/152145117-6d6a7cdc-7394-466b-8af8-ab7a3625d3d2.png)


You should see now that there is a new device – **sdc**. Now, let’s issue set of commands to make the disk usable. Start the disk **partitioning** program:

```bash
sudo fdisk /dev/sdc
```
![image](https://user-images.githubusercontent.com/34960418/152145640-fa545145-937f-4dc4-9e33-3c91ac57db53.png)


Create a new partition. When in the program, hit the following sequence of keys: 
- **n** – to create a new partition
- **p** – to create a primary partition
- **1** – to set partition number to 1
- **Enter** key – to confirm the first sector
- **Enter** key again – to confirm the last sector
- **w** – to write the changes and exit

![image](https://user-images.githubusercontent.com/34960418/152156099-a3bf269e-dc52-4222-85d3-83f9987d0d03.png)


Check again the situation with the disks:

```bash
lsblk
```

![image](https://user-images.githubusercontent.com/34960418/152156708-fd0f285f-55a8-4ceb-9e9e-72893f611bc6.png)


We can see that we have a partition. Let’s create a file system there:

```bash
sudo mkfs.ext4 /dev/sdc1
```

Our new disk is ready to be mounted and used. First, we will create a folder, and then we will mount it:

```bash
sudo mkdir /disk
sudo mount /dev/sdc1 /disk
```

If we ask again for information about the block devices, we will see that our disk (partition) is mounted:

```bash
lsblk
```

![image](https://user-images.githubusercontent.com/34960418/152157358-9b2e2b6c-7d58-4da5-96f1-549b0ebecf53.png)


For the disk to be auto mounted after a reboot, must change the **/etc/fstab** file. Be very careful with this file if it gets corrupted, the system won’t boot. To modify the **/etc/fstab** file we can invoke the nano text editor:

```bash
sudo nano /etc/fstab
```

Use the arrow keys to go to the last (empty) line. Enter the following text:

```
/dev/sdc1    /disk   ext4   defaults   0  0
```

Hit **Ctr+O** and then the **Enter** key to confirm. Exit with **Ctrl+X**. A way to test if everything with the **/etc/fstab** file is okay is to issue the following command:

```bash
sudo mount -a
```

It will try to mount all filesystems that exist in the /etc/fstab file. If you do not see any error, then you are good to go.


# Create a Windows VM

Will create the **resource group** first, and then the VM. 

Select **Resource groups** from the **Azure services** section and hit the **+ Create** button.

![image](https://user-images.githubusercontent.com/34960418/152160587-ee03f79f-7f0d-4488-938c-aff601b9586f.png)


Select the appropriate **Subscription** if you have more than one. For **Resource group** name enter **RG-Demo-2** In the **Region** drop-down select **(Europe) West Europe**. Click on the **Review + create** button.

![image](https://user-images.githubusercontent.com/34960418/152161052-9ed257ca-12e3-41c6-ade6-989acaaf75e0.png)


If all looks good, proceed by clicking the **Create** button.

![image](https://user-images.githubusercontent.com/34960418/152161284-8dfc753e-68c6-4280-9aaf-b68c2ea75c42.png)


After Resource group creation, in the **Search** box (top of the screen), type **Marketplace** and hit the Enter key. Then click on **Compute** item in **Categories**. Find **Windows Server** and click on it. In the **Select a plan** drop-down select, **[smalldisk] Windows Server 2012 R2 Datacenter**. Click on **Create**.

![image](https://user-images.githubusercontent.com/34960418/152162931-b3c0cff5-b97f-40c8-a942-615c6593e15a.png)


Select the appropriate **Subscription**. In the **Resource group** drop-down select **RG-Demo-2**. For **Virtual machine name** enter **VM-Windows-2012**. Click on **Select size**. Select the **B1s** size (**B1ms** or **B2** will be better, but will incur more expenses) and click on the **Select** button. In the **Username** field enter **DemoUser**. For a password use for example **DemoPassword-2022**. Click on the **Review + create** button.

![image](https://user-images.githubusercontent.com/34960418/152163843-c89326e9-0070-43ee-8869-f5db5273a509.png)


Click on the **Create** button.

![image](https://user-images.githubusercontent.com/34960418/152163941-a11fd173-d98f-4747-be51-7c3bc5844603.png)

Sit back and watch the deployment process. After a while, between one and two minutes, the machine will be ready

![image](https://user-images.githubusercontent.com/34960418/152164143-f8fdcb8f-9dcc-4d60-9951-9c86312930c8.png)

In the list of groups, click on the **RG-Demo-2** group. List resources created together with our virtual machine.

![image](https://user-images.githubusercontent.com/34960418/152164823-d0c66cdd-eedc-49ef-86ce-4381674838e8.png)

## Connect to the VM (Windows)

In the **Resource group** overview, find the virtual machine VM-Windows-2012 and click on it.

![image](https://user-images.githubusercontent.com/34960418/152170677-3416f4d2-832e-413f-8082-31a126fd051e.png)

Click on the **Connect** command in the top-left of the **Overview** screen and select **RDP** from the list.

![image](https://user-images.githubusercontent.com/34960418/152171033-e7445dc9-bea1-4c0d-acd1-736435c06f5a.png)

Click on the **Download RDP File** button to download the connection information and initiate a connection.

![image](https://user-images.githubusercontent.com/34960418/152171120-aabdfc23-e08a-4185-a018-f294ab8f6814.png)

A warning will appear saying that there is an issue with the certificate of the remote machine. Confirm with **Connect**.

![image](https://user-images.githubusercontent.com/34960418/152171426-d37ada99-d479-4253-91c9-60c127f63ebf.png)

Enter the credentials used during the creation process and confirm with **OK**.

![image](https://user-images.githubusercontent.com/34960418/152171803-a7af1df9-7164-461a-b11b-ed2d58173ac7.png)

Another certificate related warning will appear, confirm with **Yes**

![image](https://user-images.githubusercontent.com/34960418/152171899-f97032f9-9071-4ed5-bd7d-daa21e327e2c.png)

## Install a web server (Windows)

Let’s install the **IIS** web server. Start a **PowerShell** session with the **Run as administration** option. Execute the following command (**-Restart** at the end can be skipped in this situation):

```powershell
Add-WindowsFeature -Name Web-Server -IncludeManagementTools -Restart
```

![image](https://user-images.githubusercontent.com/34960418/152173296-9cc6661f-a7c5-4f74-bf3e-c0d171c6396e.png)

There are other ways to achieve the same. For example, using the **Server Manager** and **Add Roles and Features** option. 

Open the **Internet Explorer** browser and navigate to ```http://localhost```. The default site should appear. If you return to your host machine and try to reach the site from the outside, an error will be returned.

![image](https://user-images.githubusercontent.com/34960418/152173688-1df79ff8-49eb-4635-af3f-e9e82396fe80.png)

## Adjust the security (Windows)
Return to the **resource group** in the **Azure Portal**. Find the **VM-Windows-2012-nsg** security group created during the virtual machine deployment and click on it. In the **Overview**, there are two sections – **Inbound security rules** and **Outbound security rules**. They are like a summary (overview) of how the security group is configured. Click on the **Inbound security rules** under the **Settings** section. Click on the** Default rules** button to hide the default security rules. Only the one for **RDP** remains. It was created during the machine deployment. Now click on the **+ Add** button to add one more rule. 

![image](https://user-images.githubusercontent.com/34960418/152175501-6389d8b4-54b2-4c08-9d5e-33ed79b1a557.png)

Change the **Destination port ranges** value to **80**. Set the **Protocol** selector to **TCP**. In the **Name**, field enters **HTTP-Port-80**. Click on the **Add** button to confirm.

![image](https://user-images.githubusercontent.com/34960418/152176013-f541747d-c2b8-46e2-b741-8f262e924cad.png)

Now, switch back to the browser tab with the error and hit refresh. You should see the default IIS web page.

![image](https://user-images.githubusercontent.com/34960418/152176321-0195e7c0-312b-4320-9d47-dfa87947d26f.png)


# Add additional disk (Windows)

Return to the RDP session or re-establish a new one. Let’s check-in **Disk Management** what disk devices are available and how they are utilized. We can see that there are two disk drives – **Disk 0** (C: - the operating system is installed there) and **Disk 1** (D: - temp disk).

![image](https://user-images.githubusercontent.com/34960418/152177981-3816d356-890c-4a8c-927a-cf20074fab9d.png)


Return to the **Azure portal**. Go to the **VM-Windows-2012** virtual machine. Click on the **Disks** command in the **Settings** section. Click on **+ Create and attach a new disk** button under the **Data disks** section. For **Disk name** enter **VM-Windows-2012_DataDisk**. You can change **Storage type** and **Size**. Select for example **Standard SSD** for storage type and **16 GiB** for size. Confirm with the **Save** button (top left).

![image](https://user-images.githubusercontent.com/34960418/152179119-3bad56ba-3495-4035-a175-de626bd56000.png)

After a while saving process will finish. Return to the resource group and hit **Refresh** button to see the new resource. 

![image](https://user-images.githubusercontent.com/34960418/152179374-5c5fbf27-1cb2-41a3-8b4c-9f1588cc0c31.png)

Return to the RDP session or if you closed it, establish a new one. Start the **Disk Management** tool if not started. There you will see the new disk. It will appear as **Disk 2**. Click on it and choose **Initialize Disk** from the context menu. Confirm with the **OK** button. 

![image](https://user-images.githubusercontent.com/34960418/152180058-5eb4ca00-c293-4d02-8959-891ab634e4fa.png)

Start the **New Simple Volume Wizard** and follow the instructions. After a while, a new **NTFS** drive with the letter **F:** will appear.

![image](https://user-images.githubusercontent.com/34960418/152180208-9629bdd1-7685-41e7-89bc-350c74a9f73d.png)


# Azure the Console Way

## Create а Simple Solution with Azure CLI

Before we can do anything with our **Azure** subscription from **Azure CLI**, we must login first:

```powershell
az login
```

![image](https://user-images.githubusercontent.com/34960418/152181844-91b5e4c0-a250-4a52-8481-8eaee4b979b2.png)


Let’s create a simple but complete set of resources from the **Azure CLI**. Creating a resource group and a Linux-based VM, installing a web server, and opening a port. First, we need to get familiar with some of the commands provided by the **Azure CLI**. To ask for help for the **group** command, we must execute:

```powershell
az group --help
```

![image](https://user-images.githubusercontent.com/34960418/152182813-b1246104-926f-41fb-9c17-b45caa0b67f3.png)


