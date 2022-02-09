# TOC

- [Virtual Machines](#virtual-machines)
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

## [Networking (Load Balancer)](https://docs.microsoft.com/en-us/azure/load-balancer/)

# Storage

## [Azure Blob Storage](https://docs.microsoft.com/en-us/azure/storage/blobs/storage-blobs-introduction)

## [Azure Files](https://docs.microsoft.com/en-us/azure/storage/files/storage-files-introduction)

## [Storage Access](https://docs.microsoft.com/en-us/azure/storage/common/storage-account-manage)

## [Azure Storage Explorer](https://azure.microsoft.com/en-us/features/storage-explorer/)
