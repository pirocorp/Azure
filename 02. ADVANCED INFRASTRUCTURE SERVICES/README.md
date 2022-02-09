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

Enter the resource group and click on the **+ Create** button to add new resources. In the search field enter **Virtual Network** and hit **Enter**. Then click on the **Create** button. 

![image](https://user-images.githubusercontent.com/34960418/153184378-7498d8f0-f8c9-4923-84e2-d23b86f027e3.png)


For name enter ```p11vnet```. Ensure that the **Region** is set to **West Europe**. Click the **Next: IP Addresses** button.

![image](https://user-images.githubusercontent.com/34960418/153184958-c53215a1-b68d-4053-8771-3d0b2d0e108c.png)


Leave the address space as it is. Make sure that it is **10.0.0.0/16**, and for the default subnet, it must be **10.0.0.0/24**. Click on the **Review + create** button.

![image](https://user-images.githubusercontent.com/34960418/153185856-20df7c37-b747-4192-9442-590172a6034a.png)


Finally, click on the **Create** button

![image](https://user-images.githubusercontent.com/34960418/153186036-ae9bc590-2e3c-4512-ad0b-58843c11f34b.png)


Return to the resource group and click on the **+ Create** button to add new resources. In the search field enter **Network security group** and hit **Enter**. Then click on the **Create** button.

![image](https://user-images.githubusercontent.com/34960418/153186369-f30690d9-066c-4571-82b2-ecefaf87f7c1.png)


For **name** enter ```p11sg```. Ensure that the **Region** is set to ```West Europe```. Accept the proposed values for all other parameters (subscription and resource group). Click on the **Review + create** button and then on **Create**.

![image](https://user-images.githubusercontent.com/34960418/153186861-173f2562-2291-424f-add7-9b46bc93d1c4.png)


Once the deployment is done click on the **Go to resource** button. In the **Settings** section click on **Subnets** to associate the group with a network. Click on the **+ Associate** button. In **Virtual network** drop-down select **p11vnet** and then in the **Subnet** drop-down select **default**. Click on **OK**.

![image](https://user-images.githubusercontent.com/34960418/153189803-d34e1d79-c6eb-45cd-94a7-2efb54cfc44f.png)


In the **Settings** section click on the **Inbound security rules** to add two rules. Click on the **+ Add** button. Change **Destination port ranges** to **22**. Change **Protocol** to **TCP**. In the **Name** field enter **Port_22**. Click on the **Add** button. Repeat the procedure once again but change **22** to **80**.

![image](https://user-images.githubusercontent.com/34960418/153190888-82d84d83-7e3c-4a07-b361-4348e4778aab.png)

Return to the resource group and click on the **+ Add** button to add new resources. Select **Ubuntu Server 18.04 LTS** from the list of popular resources. Leave **Subscription** and **Resource group** as they are. In the **Virtual machine name** enter **p11vm1**. Set the **Region** to **West Europe**. For **Availability options** set **Availability set**. Click on the **Create new** under the **Availability set**. Change the **Size** to **Standard B1S**. Select **Password** as **Authentication type**. Enter ```demouser``` as **Username**. For **Password** set for example ```DemoPassword-2022```. In the **Public inbound ports** section select **None**. Click on the **Next: Disks button**. 

![image](https://user-images.githubusercontent.com/34960418/153192960-5836309c-72b3-4cc7-90e1-8b991e47975c.png)


Accept all default values and click on the **Next: Networking button**. 

![image](https://user-images.githubusercontent.com/34960418/153194055-26e93f28-d41a-493a-bf9d-f75ee4ad7147.png)


Do not change proposed values in the **Virtual network**, **subnet**, and **Public IP** fields. In the **NIC network security group** select **Advanced**. Select **p11sg** from the **Configure network security group** drop-down. Click on the **Next: Management button** and then on the **Next: Advanced button**.

![image](https://user-images.githubusercontent.com/34960418/153194960-3d372482-2971-4f0f-a5bf-c8bf37fcb323.png)

In the **Cloud init** section paste (be sure the keep the formatting incl. empty spaces) the following yaml:

```yaml
#cloud-config
package_upgrade: true 
packages:
  - apache2
  - php
write_files:
  - path: /var/www/html/index.php
    content: |
      Hello from <b><?php echo gethostname(); ?></b>
runcmd:
  - systemctl restart apache2
```

**Cloud init** run on first boot once the resources have been provisioned. ```package_upgrade``` -  will execute ```apt-get update``` and ```apt-get upgrade```. ```packages``` clause specifies packages to be installed (```apt install apache2``` and ```apt install php```). ```write_files``` will create files in path with given content. ```runcmd``` will execute given commands in given order (```systemctl restart apache2```).

Click on the **Review + create** button. And then on **Create** button. Once the deployment is done, repeat the procedure but enter **p11vm2** for VM name.

![image](https://user-images.githubusercontent.com/34960418/153197650-fccb4390-9657-4016-af56-80cf7cb82009.png)

Both VMs must be accessible from their public IPs.

![image](https://user-images.githubusercontent.com/34960418/153199465-16989bc3-ddac-4a3b-9bcc-16d67c50138a.png)


![image](https://user-images.githubusercontent.com/34960418/153199441-0174f918-2978-4d4f-8c44-d8404a9ed01c.png)





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
