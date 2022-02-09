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


Add a load balancer in front of the VMs. Return to the resource group and click on the **+ Create** button to add new resources. In the search field, enter Load Balancer and hit Enter. Then click on the Create button.

![image](https://user-images.githubusercontent.com/34960418/153200122-2cddbcf4-7945-42f5-a6bc-142975585fcf.png)


In the **Resource group** drop down select **RG-Demo-P1-1**. In the **Name** field enter **p11lb**. Set the **Region** to **West Europe**. Make sure that **SKU** is set to **Basic** and **Type** is set to **Public**. Click on **Next : Frontend IP configuration** button.

![image](https://user-images.githubusercontent.com/34960418/153200982-b5f790c4-7a8a-4fcc-af66-45b76451ef0b.png)


Click on **+ Add a frontend IP configuration**. In the Name field enter **p11lb-config**. For Public IP address click on **Create new** button. In the **Public IP address name** enter **p11lb-ip**. Click **OK** button. Then click **Add** button. And finaly click on **Review + Create** and then on **Create** buttons.

![image](https://user-images.githubusercontent.com/34960418/153201928-d31663a8-ad77-4f42-badd-141bf5c6a1aa.png)


Once the deployment is done click on the **Go to resource** button. In the **Settings** section click on the **Backend pools**. Then click on the **+ Add** button.

![image](https://user-images.githubusercontent.com/34960418/153202683-afd42aee-9555-4a0b-b466-8bd29126712f.png)


For **Name** enter **p11lb-back-pool**. In the **Virtual network** drop-down list select the **p11vnet** created earlier. Change **Associated to** to **Virtual machines**. In the Virtual machines section click **+ Add** button.

![image](https://user-images.githubusercontent.com/34960418/153203341-97819d3c-4a88-45e5-939e-7ab68e9e0f70.png)


Slecet both **p11vm1** and **p11vm2** VMs and click **Add** button.

![image](https://user-images.githubusercontent.com/34960418/153203647-e912562c-7c95-4d57-88f7-ed43ea96a29b.png)


Add these VMs to the backend pool. Select both VMs and click the **Add** button.

![image](https://user-images.githubusercontent.com/34960418/153205131-b977f571-6148-47c4-8710-b9d5d6ea7d66.png)


Next, go to **Health probes**. Click on the **+ Add** button.

![image](https://user-images.githubusercontent.com/34960418/153205361-0d5f3622-0bf2-4c11-8f4b-b50e119cd839.png)


For **Name** enter **p11lb-health**, accept the default values and click on **Add** button.

![image](https://user-images.githubusercontent.com/34960418/153205610-a950a322-33a0-43ac-b73d-fdaa061b7a6d.png)


Next, go to the **Load balancing rules** section in the menu. Click on the **+ Add** button. 

![image](https://user-images.githubusercontent.com/34960418/153206010-882ad6c0-f23d-49a8-a219-37af8b48fb14.png)


In the **Name** field enter **p11lb-rule**. For **Frontend IP address** select from drop-down menu **p11lb-config**. From **Backend pool** drop-down select **p11lb-back-pool**. In the **Port** field enter **80**. For **Backend port** field enter **80**. In **Health probe** drop-down select **p11lb-health**. Click **Add** button.


![image](https://user-images.githubusercontent.com/34960418/153207382-8a430515-642d-4fc9-b138-9231ff65c27d.png)


Return to the **Overview** of the load balancer. Copy the **Public IP address** and paste in a browser tab.













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