# TOC

- [Virtual Machines](#virtual-machines)
  - [Two VMs in an Availability Set (Azure Portal)](#two-vms-in-an-availability-set--cloud-init--load-balancer--security-group-azure-portal)
  - [Virtual Machine Scale Sets](#virtual-machine-scale-sets)
  - [Cloud Init](#cloud-init)
- [Networking](#networking)
  - [Networking (Security Groups)](#networking-security-groups)
  - [Networking (Load Balancer)](#networking-load-balancer)
- [Storage](#storage)
  - [Azure Blob Storage](#azure-blob-storage)
  - [Azure Files](#azure-files)
  - [Storage Access](#storage-access)
  - [Azure Storage Explorer](#azure-storage-explorer)

# Virtual Machines

## Two VMs in an Availability Set + Cloud Init + Load Balancer + Security Group (Azure Portal)

Go to [Azure Portal](https://portal.azure.com)

Go to Resource groups. And create a new resource group ```RG-Demo-P1-1``` in the ```West Europe``` region.

![image](https://user-images.githubusercontent.com/34960418/153183982-59348949-01b7-4c09-bab1-1507c426c8b9.png)




## [Virtual Machine Scale Sets](https://docs.microsoft.com/en-us/azure/virtual-machine-scale-sets/)

Create and manage a group of identical, load-balanced, and autoscaled VMs. Easy to create and manage multiple VMs. Provides high availability and application resiliency. Applications can automatically scale as resource demand changes. Works at large-scale.

## [Cloud Init](https://docs.microsoft.com/en-us/azure/virtual-machines/linux/using-cloud-init)

Configure a virtual machine or virtual machine scale sets at provisioning time. Scripts run on first boot once the resources have been provisioned. It is a widely used approach to customize Linux VMs. Installs packages and writes files, or configures users and security. Uses YAML.

Example: 

```yaml
#cloud-config
package_upgrade: true
packages:
  - httpd
```

# Networking

## [Networking (Security Groups)](https://docs.microsoft.com/en-us/azure/virtual-network/security-overview)

Filter network traffic to and from Azure resources. Contain rules that allow or deny inbound or outbound traffic. Rules can have source and destination, port, and protocol. Rules are evaluated by priority using the 5-tuple information. And they can be applied to individual subnets within a VNet, NICs attached to a VNet, or both. Azure creates a set of default rules in every security group.

## [Networking (Load Balancer)](https://docs.microsoft.com/en-us/azure/load-balancer/)

Allows the creation of highly available services. Have four components: a rule, front end, a health probe, a back-end pool definition. The load balancer can be public or internal. Available in two pricing tiers - Basic and Standard.

# Storage

## [Azure Blob Storage](https://docs.microsoft.com/en-us/azure/storage/blobs/storage-blobs-introduction)

Designed for storing **unstructured data**. Used to store **text files**, **images**, **videos**, **documents**, etc. 

Types of blob storage: 

- **Block blobs** are used to store files used by applications
- **Append blobs** are like block blobs but are optimized for appending
- **Page blobs** are optimized to store virtual hard drives (VHD)

**Storage containers** are used to organize blobs.

Blob **URI**

```
https://<storage-acc>.blob.core.windows.net/<container>/<blob>
```

## [Azure Files](https://docs.microsoft.com/en-us/azure/storage/files/storage-files-introduction)

Fully managed file shares in the cloud accessible via **SMB**. Can be mounted concurrently by cloud or on-premise deployments. Azure Files can be cached on Windows Servers with **Azure File Sync**.

Azure File **URI**

```
https://<storage-acc>.file.core.windows.net/<share>/<dir>/<file>
```

## [Storage Access](https://docs.microsoft.com/en-us/azure/storage/common/storage-account-manage)

**Access Keys**

Two 512-bit storage account access keys are automatically created. They are used for authorized access to a storage account via SAS. They can be rotated and regenerated without interruption to applications. The storage account key is like the root password for a storage account. Avoid distributing, hard-coding, or saving it anywhere in plaintext.

**Shared Access Signature (SAS)**

Used for granting granular access to resources.

## [Azure Storage Explorer](https://azure.microsoft.com/en-us/features/storage-explorer/)

Free tool to easily manage Azure cloud storage resources. Available for Windows, Linux, and macOS. Accessible, intuitive, feature-rich graphical user interface. Can work also disconnected from the cloud or offline with local emulators.
