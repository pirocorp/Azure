# Azure virtual machines

Azure virtual machines (VM) is one of several types of on-demand, scalable computing resources that Azure offers. Typically, you choose a VM when you need more control over the computing environment than the other choices offer.

An Azure virtual machine gives you the flexibility of virtualization without having to buy and maintain the physical hardware that runs it. However, you still need to maintain the VM by performing tasks, such as configuring, patching, and installing the software that runs on it. This unit gives you information about what you should consider before you create a VM, how you create it, and how you manage it.

Azure virtual machines can be used in various ways. Some examples are:

- Development and test – Azure VMs offer a quick and easy way to create a computer with specific configurations required to code and test an application.
- Applications in the cloud – Because demand for your application can fluctuate, it might make economic sense to run it on a VM in Azure. You pay for extra VMs when you need them and shut them down when you don’t.
- Extended datacenter – Virtual machines in an Azure virtual network can easily be connected to your organization’s network.


# Design considerations for virtual machine creation

There are always a multitude of design considerations when you build out an application infrastructure in Azure. These aspects of a VM are important to think about before you start:

- Availability: Azure supports a single instance virtual machine Service Level Agreement of 99.9% provided you deploy the VM with premium storage for all disks.
- VM size: The size of the VM that you use is determined by the workload that you want to run. The size that you choose then determines factors such as processing power, memory, and storage capacity.
- VM limits: Your subscription has default quota limits in place that could impact the deployment of many VMs for your project. The current limit on a per subscription basis is 20 VMs per region. Limits can be raised by filing a [support ticket requesting an increase](https://docs.microsoft.com/en-us/azure/azure-portal/supportability/regional-quota-requests).
- VM image: You can either use your own image, or you can use one of the images in the Azure Marketplace. You can get a list of images in the marketplace by using the ```az vm image list``` command. See [list popular images](https://docs.microsoft.com/en-us/azure/virtual-machines/linux/cli-ps-findimage#list-popular-images) for more information on using the command.
- VM disks: There are two components that make up this area. The type of disks which determines the performance level and the storage account type that contains the disks. Azure provides two types of disks:
  - Standard disks: Backed by HDDs, and delivers cost-effective storage while still being performant. Standard disks are ideal for a cost effective dev and test workload.
  - Premium disks: Backed by SSD-based, high-performance, low-latency disk. Perfect for VMs running production workload.

And, there are two options for the disk storage:

- Managed disks: Managed disks are the newer and recommended disk storage model and they are managed by Azure. You specify the size of the disk, which can be up to 4 terabytes (TB), and Azure creates and manages both the disk and the storage. You don't have to worry about storage account limits, which makes managed disks easier to scale out than unmanaged discs.
- Unmanaged disks: With unmanaged disks, you’re responsible for the storage accounts that hold the virtual hard disks (VHDs) that correspond to your VM disks. You pay the storage account rates for the amount of space you use. A single storage account has a fixed-rate limit of 20,000 input/output (I/O) operations per second. This means that a storage account is capable of supporting 40 standard VHDs at full utilization. If you need to scale out with more disks, then you'll need more storage accounts, which can get complicated.


# Virtual machine extensions

Windows VMs have extensions which give your VM additional capabilities through post deployment configuration and automated tasks. These common tasks can be accomplished using extensions:

- Run custom scripts: The Custom Script Extension helps you configure workloads on the VM by running your script when the VM is provisioned.
- Deploy and manage configurations: The PowerShell Desired State Configuration (DSC) Extension helps you set up DSC on a VM to manage configurations and environments.
- Collect diagnostics data: The Azure Diagnostics Extension helps you configure the VM to collect diagnostics data that can be used to monitor the health of your application.

For Linux VMs, Azure supports [cloud-init](https://cloud-init.io/) across most Linux distributions that support it and works with all the major automation tooling like Ansible, Chef, SaltStack, and Puppet.


# Compare virtual machine availability options

Azure offers several options for ensuring the availability of the virtual machines, and applications, you have deployed.


## Availability zones

[Availability zones](https://docs.microsoft.com/en-us/azure/availability-zones/az-overview?context=/azure/virtual-machines/context/context) expands the level of control you have to maintain the availability of the applications and data on your VMs. An Availability Zone is a physically separate zone, within an Azure region. There are three Availability Zones per supported Azure region.

An Availability Zone in an Azure region is a combination of a fault domain and an update domain. For example, if you create three or more VMs across three zones in an Azure region, your VMs are effectively distributed across three fault domains and three update domains. The Azure platform recognizes this distribution across update domains to make sure that VMs in different zones are not scheduled to be updated at the same time.

Build high-availability into your application architecture by co-locating your compute, storage, networking, and data resources within a zone and replicating in other zones. Azure services that support Availability Zones fall into two categories:

- **Zonal services**: Where a resource is pinned to a specific zone (for example, virtual machines, managed disks, Standard IP addresses), or
- **Zone-redundant services**: When the Azure platform replicates automatically across zones (for example, zone-redundant storage, SQL Database).


## Availability sets

An [availability set](https://docs.microsoft.com/en-us/azure/virtual-machines/availability-set-overview) is a logical grouping of VMs that allows Azure to understand how your application is built to provide for redundancy and availability. An availability set is composed of two additional groupings that protect against hardware failures and allow updates to safely be applied - fault domains (FDs) and update domains (UDs).


### Fault domains

A fault domain is a logical group of underlying hardware that share a common power source and network switch, similar to a rack within an on-premises datacenter. As you create VMs within an availability set, the Azure platform automatically distributes your VMs across these fault domains. This approach limits the impact of potential physical hardware failures, network outages, or power interruptions.

![image](https://user-images.githubusercontent.com/34960418/163979683-5d11e3c6-bc8d-4287-82b6-6ae27cf56a34.png)


### Update domains

An update domain is a logical group of underlying hardware that can undergo maintenance or be rebooted at the same time. As you create VMs within an availability set, the Azure platform automatically distributes your VMs across these update domains. This approach ensures that at least one instance of your application always remains running as the Azure platform undergoes periodic maintenance. The order of update domains being rebooted may not proceed sequentially during planned maintenance, but only one update domain is rebooted at a time.

![image](https://user-images.githubusercontent.com/34960418/163979770-1340945f-80ae-4b3b-9e2a-7a73e223cacc.png)


### Virtual machine scale sets

[Azure virtual machine scale sets](https://docs.microsoft.com/en-us/azure/virtual-machine-scale-sets/overview?context=/azure/virtual-machines/context/context) let you create and manage a group of load balanced VMs. The number of VM instances can automatically increase or decrease in response to demand or a defined schedule.


### Load balancer

Combine the [Azure Load Balancer](https://docs.microsoft.com/en-us/azure/load-balancer/load-balancer-overview) with an availability zone or availability set to get the most application resiliency. An Azure load balancer is a Layer-4 (TCP, UDP) load balancer that provides high availability by distributing incoming traffic among healthy VMs. A load balancer health probe monitors a given port on each VM and only distributes traffic to an operational VM.

You define a front-end IP configuration that contains one or more public IP addresses. This front-end IP configuration allows your load balancer and applications to be accessible over the Internet.

Virtual machines connect to a load balancer using their virtual network interface card (NIC). To distribute traffic to the VMs, a back-end address pool contains the IP addresses of the virtual (NICs) connected to the load balancer.

To control the flow of traffic, you define load balancer rules for specific ports and protocols that map to your VMs.


# Determine appropriate virtual machine size

The best way to determine the appropriate VM size is to consider the type of workload your VM needs to run. Based on the workload, you're able to choose from a subset of available VM sizes. Workload options are classified as follows on Azure:

| VM Type                  	| Description                                                                                                                                                                                     	|
|--------------------------	|-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------	|
| General Purpose          	| Balanced CPU-to-memory ratio. Ideal for testing and development, small to medium databases, and low to medium traffic web servers.                                                              	|
| Compute Optimized        	| High CPU-to-memory ratio. Good for medium traffic web servers, network appliances, batch processes, and application servers.                                                                    	|
| Memory Optimized         	| High memory-to-CPU ratio. Great for relational database servers, medium to large caches, and in-memory analytics.                                                                               	|
| Storage Optimized        	| High disk throughput and IO ideal for Big Data, SQL, NoSQL databases, data warehousing and large transactional databases.                                                                       	|
| GPU                      	| Specialized virtual machines targeted for heavy graphic rendering and video editing, as well as model training and inferencing (ND) with deep learning. Available with single or multiple GPUs. 	|
| High Performance Compute 	| Our fastest and most powerful CPU virtual machines with optional high-throughput network interfaces (RDMA).                                                                                     	|

What if my size needs change?

Azure allows you to change the VM size when the existing size no longer meets your needs. You can resize the VM - as long as your current hardware configuration is allowed in the new size. This provides a fully agile and elastic approach to VM management.

If you stop and deallocate the VM, you can then select any size available in your region since this removes your VM from the cluster it was running on.


## Additional resources

- For information about pricing of the various sizes, see the pricing pages for [Linux](https://azure.microsoft.com/pricing/details/virtual-machines/#Linux) or [Windows](https://azure.microsoft.com/pricing/details/virtual-machines/Windows/#Windows).
- For availability of VM sizes in Azure regions, see [Products available by region](https://azure.microsoft.com/regions/services/).


# Create a virtual machine by using the Azure CLI

## Login to Azure

```bash
az login
```

![image](https://user-images.githubusercontent.com/34960418/163986410-d687aa2c-b717-4008-9e23-194cb12d0d1f.png)


## Create a resource group and virtual machine

Create a resource group with the ```az group create``` command. The command below creates a resource group named ```az204-vm-rg```. Replace ```<myLocation>``` with a region near you.

```bash
az group create --name az204-vm-rg --location <myLocation>
```

![image](https://user-images.githubusercontent.com/34960418/163986656-b9598a7b-a936-48d3-bd5e-eee5ea71b995.png)


Create a VM with the ```az vm create``` command. The command below creates a Linux VM named **az204vm** with an admin user named **azureuser**. After executing the command you will need to supply a password that meets the password requirements.

```bash
az vm create \
    --resource-group az204-vm-rg \
    --name az204vm \
    --image UbuntuLTS \
    --generate-ssh-keys \
    --admin-username azureuser
```

It will take a few minutes for the operation to complete. When it is finished note the **publicIpAddress** in the output, you'll use it in the next step.

![image](https://user-images.githubusercontent.com/34960418/163987826-dabe6bb1-7c6a-42a2-b9b3-7bf062654fdb.png)

**Note**

When creating VMs with the Azure CLI passwords need to be between 12-123 characters, have both uppercase and lowercase characters, a digit, and have a special character (@, !, etc.). Be sure to remember the password.
