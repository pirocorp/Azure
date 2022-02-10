# TOC

- [Virtual Machines](#virtual-machines)
  - [Cloud Init](#cloud-init)
  - [Virtual Machine Scale Sets](#virtual-machine-scale-sets)  
- [Networking](#networking)
  - [Networking (Security Groups)](#networking-security-groups)
  - [Networking (Load Balancer)](#networking-load-balancer)
- [Storage](#storage)
  - [Azure Blob Storage](#azure-blob-storage)
  - [Azure Files](#azure-files)
  - [Storage Access](#storage-access)
  - [Azure Storage Explorer](#azure-storage-explorer)
- [Security](#security)
  - [Users and Groups](#users-and-groups)
  - [Policies](#policies)
  - [Role-based Access Control (RBAC)](#role-based-access-control-rbac)
  - [Resource Locks](#resource-locks)
  - [Azure Key Vault](#azure-key-vault)
- [Monitoring and Control](#monitoring-and-control)
  - [Subscription Limits](#subscription-limits)
  - [Azure Monitor](#azure-monitor)
  - [Boot Diagnostics](#boot-diagnostics)
  - [Serial Console](#serial-console)
  - [Cost Management and Billing](#cost-management-and-billing)
  - [Budgets](#budgets)
  - [Azure Advisor](#azure-advisor)
  - [Pricing Calculator](#pricing-calculator)
  - [Total Cost of Ownership Calculator](#total-cost-of-ownership-calculator)
  - [Tags](#tags)


# Jump to practical guides

- Two VMs in an Availability Set + Cloud Init + Load Balancer + Security Group
  - [Two VMs (Azure Portal)](#two-vms-in-an-availability-set--cloud-init--load-balancer--security-group-azure-portal)
  - [Two VMs (Azure CLI)](#two-vms-in-an-availability-set--cloud-init--load-balancer--security-group-azure-cli)
  - [Two VMs (Azure PS)](#two-vms-in-an-availability-set--cloud-init--load-balancer--security-group-azure-ps)
- Virtual Machine Scale Set
  - [Virtual Machine Scale Set (Azure Portal)](#virtual-machine-scale-set-azure-portal)
  - [Virtual Machine Scale Set (Azure CLI)](#virtual-machine-scale-set-azure-cli)
  - [Virtual Machine Scale Set (Azure PS)](#virtual-machine-scale-set-azure-ps)
- [Blob + Files (Azure Portal)](#blob--files-azure-portal)
- [Security](#security-1)
  - [Create New User](#create-new-user)
  - [RBAC](#rbac)
  - [Policies](#policies-1)
  - [Locks](#locks)

# Virtual Machines

## [Cloud Init](https://docs.microsoft.com/en-us/azure/virtual-machines/linux/using-cloud-init)

Configure a virtual machine or virtual machine scale sets at provisioning time. Scripts run on first boot once the resources have been provisioned. It is a widely used approach to customize Linux VMs. Installs packages and writes files, or configures users and security. Uses YAML.

Example: 

```yaml
#cloud-config
package_upgrade: true
packages:
  - httpd
```

## [Virtual Machine Scale Sets](https://docs.microsoft.com/en-us/azure/virtual-machine-scale-sets/)

Create and manage a group of identical, load-balanced, and autoscaled VMs. Easy to create and manage multiple VMs. Provides high availability and application resiliency. Applications can automatically scale as resource demand changes. Works at large-scale.


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

# Security


## [Users and Groups](https://docs.microsoft.com/en-us/azure/active-directory/)

Azure AD is used to give users access to Azure resources. Each user has an **identity**. User ID, a password, and other properties form the identity. Users also have one or more directory roles assigned. Groups are used to manage larger groups of users. External (**guest users**) can be added via an invitation email.


## [Policies](https://docs.microsoft.com/en-us/azure/governance/policy/)

**Azure Policy** evaluates resources in Azure by comparing the properties of those resources to business rules. Enforcement of every **policy definition** depends on conditions. A **policy assignment** is a policy definition set to take place within a specific scope. 

An **initiative definition** is a collection of policy definitions. An **initiative assignment** is an initiative definition given to a particular scope. 

Both policies and initiative definitions have **parameters**.


## [Role-based Access Control (RBAC)](https://docs.microsoft.com/en-us/azure/role-based-access-control/)

Azure role-based access control (Azure **RBAC**) is a system that provides fine-grained access management of Azure resources. Using Azure **RBAC**, you can segregate duties within your team and grant only the amount of access to users that they need to perform their jobs. 

RBAC consists of four main elements: 

- The **security principle** represents an identity (user, group, app).
- A **role** defines how the security principal can interact with a resource.
- The **scope** defines the level at which the role is applied.
- **Role assignments** – role assigned to a principal at a scope.

Some of the **built-in** roles are **Owner**, **Contributor**, and **Reader**. Role assignments are **additive**.


## [Resource Locks](https://docs.microsoft.com/en-us/azure/azure-resource-manager/resource-group-lock-resources)

They are used to prevent accidental deletion or modification of a resource. Can set lock level either to **CanNotDelete** or **ReadOnly**. Its children inherit locks applied to a parent. The most restrictive lock in the inheritance takes precedence.


## [Azure Key Vault](https://docs.microsoft.com/en-us/azure/key-vault/)

Centralize application secrets. Securely store secrets and keys. Monitor access and use. Simplified administration of application secrets. Integratable with other Azure services. Two pricing tiers – **Standard** and **Premium**.


# Monitoring and Control

## [Subscription Limits](https://docs.microsoft.com/en-us/azure/azure-subscription-service-limits)

Microsoft Azure **limits** are also called **quotas**. **The raise of a limitation** or quota above the defaults is via **support request**. **Free Trial** subscriptions **aren't eligible** for limit or quota increases. You **can't raise limits** above the **maximum limit** value. Limits can be on subscription or region level.



## [Azure Monitor](https://docs.microsoft.com/en-us/azure/azure-monitor/)

**Metrics** are numerical values that describe some aspect of a system at a particular time. **Logs** contain different kinds of data organized into records. Log queries use **Kusto** language.

![image](https://user-images.githubusercontent.com/34960418/153408216-afd20b69-01f4-4421-9c4f-4cdd2ce4edc6.png)



## [Boot Diagnostics](https://docs.microsoft.com/en-us/azure/virtual-machines/troubleshooting/boot-diagnostics)

For both Windows and Linux virtual machines, **screenshots** are available. For Linux virtual machines, the output of the **console log** is available. A storage account in which to place the diagnostic files is needed. The Boot diagnostics feature does not support a premium storage account.



## [Serial Console](https://docs.microsoft.com/en-us/azure/virtual-machines/troubleshooting/serial-console-overview)

Serial Console provides a **text-based console** for virtual machines (VMs) and virtual machine scale set instances. Available both for Linux and Windows instances. Serial Console connects to the **ttyS0** or **COM1** serial port. Serial Console can only be accessed using the Azure portal, allowed only for users with an access role of **Contributor or higher**. **Must enable boot diagnostics** for the VM.



## [Cost Management and Billing](https://docs.microsoft.com/en-us/azure/billing/)

Shows organizational cost and usage patterns with advanced analytics. Cost management reports show the usage-based costs consumed by Azure services and third-party Marketplace offerings. Uses management groups, budgets, and recommendations to show how expenses are organized and reduce costs. Offers **cost analysis**, **budgets**, **recommendations**, and **exporting cost management data**.



## [Budgets](https://docs.microsoft.com/en-us/azure/cost-management/tutorial-acm-create-budgets)

Plan for and drive organizational accountability. Account for services consumption during a specific period. Monitor how spending progresses over time. When the budget thresholds are exceeded, only notifications are triggered. Budgets reset automatically at the end of a period. Resources are not affected, and consumption isn't stopped.



## [Azure Advisor](https://docs.microsoft.com/en-us/azure/advisor/)

**Azure Advisor** is a **best practices analyzer** for Azure resources. Azure Advisor analyzes your **resource configuration** and **usage telemetry**. **Recommends solutions** to **improve the cost-effectiveness, performance, reliability**, and **security of resources**.

Categories of recommendations: **Cost**, **Security**, **Reliability** (formerly called **High Availability**), **Operational Excellence**, **Performance**.



## [Pricing Calculator](https://azure.microsoft.com/en-us/pricing/calculator/)

**Pricing Calculator** is a free online tool provided by Microsoft. Configure and estimate the costs for Azure products. It supports complex environment scenarios. And it provides example scenarios. Offers to save and export the estimations.



## [Total Cost of Ownership Calculator](https://azure.microsoft.com/en-us/pricing/tco/calculator/)

Total Cost of Ownership Calculator is a free online tool provided by Microsoft. Estimate the cost savings if migrating our workloads to Azure. The emphasis is on the four core services. Expenses are accounted for software licenses, electricity, and labor.



## [Tags](https://docs.microsoft.com/en-us/azure/azure-resource-manager/resource-group-using-tags)

Can logically organize Azure resources by using tags. Each tag consists of a name and a value pair. Each resource can have a maximum of 50 tag name/value pairs. Not all resource types support tags. The length of the tag name is limited to 512 (128 for storage accounts) characters. A tag value is limited to 256 characters. Tags applied to the resource group are not inherited by the resources.



### [Azure Resource Manager](https://docs.microsoft.com/en-us/azure/azure-resource-manager/)

The deployment and management service for Azure. 

![image](https://user-images.githubusercontent.com/34960418/153414316-92cf63ec-292d-4aaf-92b9-d0aa41ae63f1.png)


#### [Azure Resource Manager Templates](https://docs.microsoft.com/en-us/azure/azure-resource-manager/template-deployment-overview)

Azure Resource Manager Templates is a **JSON file** that defines resources to deploy to a resource group or subscription. Can use it to deploy the resources consistently and repeatedly. The template is deployed only after passing validation. It can be broken into smaller, reusable components and linked together at deployment time. Nesting is also supported. Sections of a template are **parameters**, **variables**, **user-defined functions**, **resources**, and **outputs**.


### [ARMVIZ](http://armviz.io/)

ARMVIZ is a free tool for visualizing, editing and saving Azure Resource Manager Templates. Hosted online and developed and supported by 3rd party.



---

# Two VMs in an Availability Set + Cloud Init + Load Balancer + Security Group (Azure Portal)

Go to [Azure Portal](https://portal.azure.com)


## Resource group

Go to Resource groups. And create a new resource group ```RG-Demo-P1-1``` in the ```West Europe``` region.

![image](https://user-images.githubusercontent.com/34960418/153183982-59348949-01b7-4c09-bab1-1507c426c8b9.png)


## Virtual network

Enter the resource group and click on the **+ Create** button to add new resources. In the search field enter **Virtual Network** and hit **Enter**. Then click on the **Create** button. 

![image](https://user-images.githubusercontent.com/34960418/153184378-7498d8f0-f8c9-4923-84e2-d23b86f027e3.png)


For name enter ```p11vnet```. Ensure that the **Region** is set to **West Europe**. Click the **Next: IP Addresses** button.

![image](https://user-images.githubusercontent.com/34960418/153184958-c53215a1-b68d-4053-8771-3d0b2d0e108c.png)


Leave the address space as it is. Make sure that it is **10.0.0.0/16**, and for the default subnet, it must be **10.0.0.0/24**. Click on the **Review + create** button.

![image](https://user-images.githubusercontent.com/34960418/153185856-20df7c37-b747-4192-9442-590172a6034a.png)


Finally, click on the **Create** button

![image](https://user-images.githubusercontent.com/34960418/153186036-ae9bc590-2e3c-4512-ad0b-58843c11f34b.png)


## Network security group

Return to the resource group and click on the **+ Create** button to add new resources. In the search field enter **Network security group** and hit **Enter**. Then click on the **Create** button.

![image](https://user-images.githubusercontent.com/34960418/153186369-f30690d9-066c-4571-82b2-ecefaf87f7c1.png)


For **name** enter ```p11sg```. Ensure that the **Region** is set to ```West Europe```. Accept the proposed values for all other parameters (subscription and resource group). Click on the **Review + create** button and then on **Create**.

![image](https://user-images.githubusercontent.com/34960418/153186861-173f2562-2291-424f-add7-9b46bc93d1c4.png)


Once the deployment is done click on the **Go to resource** button. In the **Settings** section click on **Subnets** to associate the group with a network. Click on the **+ Associate** button. In **Virtual network** drop-down select **p11vnet** and then in the **Subnet** drop-down select **default**. Click on **OK**.

![image](https://user-images.githubusercontent.com/34960418/153189803-d34e1d79-c6eb-45cd-94a7-2efb54cfc44f.png)



## Security rules

In the **Settings** section click on the **Inbound security rules** to add two rules. Click on the **+ Add** button. Change **Destination port ranges** to **22**. Change **Protocol** to **TCP**. In the **Name** field enter **Port_22**. Click on the **Add** button. Repeat the procedure once again but change **22** to **80**.

![image](https://user-images.githubusercontent.com/34960418/153190888-82d84d83-7e3c-4a07-b361-4348e4778aab.png)



## Virtual machines

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



## Load balancer

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

![image](https://user-images.githubusercontent.com/34960418/153209891-110830a6-4c13-459f-b0bc-a3d97449904d.png)

Return to the **Overview** of the load balancer. Copy the **Public IP address** and paste in a browser tab.


# Two VMs in an Availability Set + Cloud Init + Load Balancer + Security Group (Azure CLI)

If using the tool on-premise, if using the **Azure Cloud Shell**, this is not necessary.

```bash
az login
```

## Resource group

Creating a resource group is done with

```bash
az group create --name RG-Demo-P1-1 --location westeurope --output table
```

![image](https://user-images.githubusercontent.com/34960418/153212484-e4aadbba-789f-4850-9358-76ec470af6d2.png)


## Network security group

Create the network security group

```bash
az network nsg create --name p11sg --resource-group RG-Demo-P1-1 --output table
```


## Security rules

Then, add both inbound rules

```bash
az network nsg rule create --name Port_22 --nsg-name p11sg --resource-group RG-Demo-P1-1 --access Allow --protocol tcp --direction inbound --priority 100 --destination-port-range 22 --output table
az network nsg rule create --name Port_80 --nsg-name p11sg --resource-group RG-Demo-P1-1 --access Allow --protocol tcp --direction inbound --priority 110 --destination-port-range 80 --output table
```

![image](https://user-images.githubusercontent.com/34960418/153213020-cf19fe82-2eef-4610-9eec-86bb009653c3.png)



## Virtual network

Create the virtual network

```bash
az network vnet create --name p11vnet --resource-group RG-Demo-P1-1 --output table
```

And the subnet

```bash
az network vnet subnet create --name default --vnet-name p11vnet --resource-group RG-Demo-P1-1 --address-prefix 10.0.0.0/24 --network-security-group p11sg  --output table
```

![image](https://user-images.githubusercontent.com/34960418/153213634-ddcf353c-c149-44fb-9b90-543f1ee59a6d.png)

Create both virtual network adapters:

```bash
az network nic create --name p11nic1 --resource-group RG-Demo-P1-1 --vnet-name p11vnet --subnet default --output table
az network nic create --name p11nic2 --resource-group RG-Demo-P1-1 --vnet-name p11vnet --subnet default --output table
```


## Virtual machines

Create the availability set

```bash
az vm availability-set create --name p11as --resource-group RG-Demo-P1-1 --platform-fault-domain-count 2 --platform-update-domain-count 2 --output table
```

![image](https://user-images.githubusercontent.com/34960418/153214421-34e30b6d-0990-4543-87f9-d739991824c2.png)


Prepare the **cloud init** file. Using an editor, open an empty file and store the code in a file named **cloud-init.yaml**

![image](https://user-images.githubusercontent.com/34960418/153214891-febcd51f-6600-4086-8d81-8b0e97ded9c4.png)


Create the first machine

```bash
az vm create --name p11vm1 --resource-group RG-Demo-P1-1 --image UbuntuLTS --size Standard_B1s --authentication-type password --admin-username demouser --admin-password DemoPassword-2022 --custom-data cloud-init.yaml --nics p11nic1 --availability-set p11as --verbose
```

And, then the second one

```bash
az vm create --name p11vm2 --resource-group RG-Demo-P1-1 --image UbuntuLTS --size Standard_B1s --authentication-type password --admin-username demouser --admin-password DemoPassword-2022 --custom-data cloud-init.yaml --nics p11nic2 --availability-set p11as --verbose --output table
```

![image](https://user-images.githubusercontent.com/34960418/153216692-573cdff7-bfca-4bbb-96a5-a11b3b2b9c10.png)


## Load balancer

Create a public IP address for our load balancer

```bash
az network public-ip create --name p11lb-ip --resource-group RG-Demo-P1-1 --allocation-method dynamic --output table
```

Then, the load balancer itself

```bash
az network lb create --name p11lb --resource-group RG-Demo-P1-1 --frontend-ip-name p11lb-fe --backend-pool-name p11lb-be --public-ip-address p11lb-ip --output table
```

Next step is to create a health probe

```bash
az network lb probe create --name p11lb-hp --lb-name p11lb --resource-group RG-Demo-P1-1 --protocol tcp --port 80 --output table
```

![image](https://user-images.githubusercontent.com/34960418/153217476-574103d0-3843-4f4a-b361-7eadd68d0564.png)


Create balancing rule as well

```bash
az network lb rule create --name p11lb-rule --lb-name p11lb --resource-group RG-Demo-P1-1 --protocol tcp --frontend-port 80 --backend-port 80 --frontend-ip-name p11lb-fe --backend-pool-name p11lb-be --probe-name p11lb-hp --output table
```

![image](https://user-images.githubusercontent.com/34960418/153217916-8480e5a2-fbda-4287-a9c9-c4e21d6ecaf9.png)


Update IP configurations of both virtual network adapters. The first or default IP configuration is named **ipconfig1** for both adapters.


```bash
az network nic ip-config update --name ipconfig1 --resource-group RG-Demo-P1-1 --nic-name p11nic1 --lb-name p11lb --lb-address-pools p11lb-be --output table
az network nic ip-config update --name ipconfig1 --resource-group RG-Demo-P1-1 --nic-name p11nic2 --lb-name p11lb --lb-address-pools p11lb-be --output table
```

![image](https://user-images.githubusercontent.com/34960418/153218444-bda06385-bfad-4f6b-8f2a-564790558fe2.png)

Get the public IP address of the load balancer

```bash
az network public-ip show --name p11lb-ip --resource-group RG-Demo-P1-1 --query [ipAddress] --output tsv
```

![image](https://user-images.githubusercontent.com/34960418/153218646-b1c445eb-b9aa-477d-83cb-c1e7c2663716.png)


![image](https://user-images.githubusercontent.com/34960418/153218756-b217f58b-551c-467a-8ca1-9c4242751566.png)


## Clean Up

```bash
az group delete --name RG-Demo-P1-1 --yes --no-wait
```



# Two VMs in an Availability Set + Cloud Init + Load Balancer + Security Group (Azure PS)


If using the tool on-premise. If using the **Azure Cloud Shell**, this is not necessary.

```powershell
Connect-AzAccount
```

![image](https://user-images.githubusercontent.com/34960418/153220487-cc7e3478-60f4-4281-a43c-9674e47a78c9.png)


## Resource group

Creating a resource group is done with

```poweshell
$LO = "westeurope"
$RG = "RG-Demo-P1-1"
New-AzResourceGroup -Name $RG -Location $LO
```

![image](https://user-images.githubusercontent.com/34960418/153220961-88414397-c52f-4955-97ff-931bb7e2afa2.png)


## Network security group

First, create the network security group rules

```powershell
$rule1 = New-AzNetworkSecurityRuleConfig -Name Port_22 -Access Allow -Protocol Tcp `
-Direction Inbound -Priority 100 -SourceAddressPrefix * -SourcePortRange * `
-DestinationAddressPrefix * -DestinationPortRange 22

$rule2 = New-AzNetworkSecurityRuleConfig -Name Port_80 -Access Allow -Protocol Tcp `
-Direction Inbound -Priority 110 -SourceAddressPrefix * -SourcePortRange * `
-DestinationAddressPrefix * -DestinationPortRange 80
```

And then the security group

```powershell
$nsg = New-AzNetworkSecurityGroup -Name "p11sg" -ResourceGroupName $RG -Location $LO `
-SecurityRules $rule1,$rule2
```

![image](https://user-images.githubusercontent.com/34960418/153221706-e9980039-d0b1-4797-8f59-b9e81fbee6ee.png)


## Virtual network

First, define the subnet

```powershell
$S1 = New-AzVirtualNetworkSubnetConfig -Name 'default' -AddressPrefix '10.0.0.0/24' `
-NetworkSecurityGroup $nsg
```

Then, the network itself

```powershell
$VN = New-AzVirtualNetwork -Name 'p11vnet' -ResourceGroupName $RG `
-AddressPrefix '10.0.0.0/16' -Location $LO -Subnet $S1
```

Now, it is time to define the two network interface cards

```powershell
$N1 = New-AzNetworkInterface -Name 'p11nic1' -ResourceGroupName $RG -Location $LO `
-Subnet $VN.Subnets[0]

$N2 = New-AzNetworkInterface -Name 'p11nic2' -ResourceGroupName $RG -Location $LO `
-Subnet $VN.Subnets[0]
```

![image](https://user-images.githubusercontent.com/34960418/153222475-fcbf09d4-7c58-46c9-af8e-53036a927b23.png)


## Virtual machines

Create the availability set

```powershell
$AS = New-AzAvailabilitySet -Name "p11as" -ResourceGroupName $RG -Location $LO -Sku Aligned `
-PlatformFaultDomainCount 2 -PlatformUpdateDomainCount 2
```

Store the credentials for the two virtual machines, for example **demouser** / **DemoPassword-2022**

```powershell
$CR = Get-Credential
```

![image](https://user-images.githubusercontent.com/34960418/153223207-fe84b130-093a-4e71-9e6b-6d7164c46c75.png)


Store the contents of the provision file in a variable

```powershell
$CD = Get-Content -Raw cloud-init.yaml
```

Create virtual machine configuration for the first machine

```powershell
$VC = New-AzVMConfig -VMName 'p11vm1' -VMSize 'Standard_B1s' -AvailabilitySetId $AS.Id | `
Set-AzVMOperatingSystem -Linux -ComputerName 'p11vm1' -Credential $CR `
-CustomData $CD | Set-AzVMSourceImage -PublisherName 'Canonical' `
-Offer 'UbuntuServer' -Skus '18.04-LTS' -Version latest | Add-AzVMNetworkInterface -Id $N1.Id
```

Then, the machine itself

```powershell
New-AzVM -ResourceGroupName $RG -Location $LO -VM $VC
```

![image](https://user-images.githubusercontent.com/34960418/153223981-6ded203d-fdf4-42d8-97e4-82e73448e73d.png)


Same procedure for the second one – configuration

```powershell
$VC = New-AzVMConfig -VMName 'p11vm2' -VMSize 'Standard_B1s' -AvailabilitySetId $AS.Id | `
Set-AzVMOperatingSystem -Linux -ComputerName 'p11vm2' -Credential $CR `
-CustomData $CD | Set-AzVMSourceImage -PublisherName 'Canonical' `
-Offer 'UbuntuServer' -Skus '18.04-LTS' -Version latest | Add-AzVMNetworkInterface -Id $N2.Id
```

And then the machine

```powershell
New-AzVM -ResourceGroupName $RG -Location $LO -VM $VC
```

![image](https://user-images.githubusercontent.com/34960418/153224582-916d88a5-80e4-4c62-baa0-db8d804f3f17.png)


## Load balancer

Define the public IP address

```powershell
$LBIP = New-AzPublicIpAddress -Name 'p11lb-ip' -ResourceGroupName $RG `
-Location $LO -AllocationMethod Dynamic -Sku Basic
```


Then, the front-end part of the load balancer

```powershell
$LBFE = New-AzLoadBalancerFrontendIpConfig -Name 'p11lb-fe' -PublicIpAddress $LBIP
```


Define the back-end pool

```powershell
$LBBE = New-AzLoadBalancerBackendAddressPoolConfig -Name 'p11lb-be'
```


The health probe as well

```powershell
$LBHP = New-AzLoadBalancerProbeConfig -Name 'p11lb-hp' -Protocol tcp -Port 80 `
-IntervalInSeconds 5 -ProbeCount 2
```


The rule can be created with this command

```powershell
$LBRL = New-AzLoadBalancerRuleConfig -Name 'p11lb-rule' -FrontendIpConfiguration $LBFE `
-BackendAddressPool $LBBE -Protocol Tcp -FrontendPort 80 -BackendPort 80 -Probe $LBHP
```


And finally, the load balancer

```powershell
$LB = New-AzLoadBalancer -Name 'p11lb' -ResourceGroupName $RG -Location $LO `
-FrontendIpConfiguration $LBFE -BackendAddressPool $LBBE -Probe $LBHP -LoadBalancingRule $LBRL
```


One last step remains, we must assign the network adapters to the back-end pool

```powershell
$N1.IpConfigurations[0].LoadBalancerBackendAddressPools = $LBBE
$N1 | Set-AzNetworkInterface
$N2.IpConfigurations[0].LoadBalancerBackendAddressPools = $LBBE
$N2 | Set-AzNetworkInterface
```


Get the public IP address of the load balancer

```powershell
Get-AzPublicIPAddress -Name 'p11lb-ip' -ResourceGroupName $RG | Select IpAddress
```

![image](https://user-images.githubusercontent.com/34960418/153226264-fd52ca89-3df5-4957-9bf2-96ec1e6f03e6.png)

![image](https://user-images.githubusercontent.com/34960418/153226365-e4e5493d-da28-49b5-99b5-c2d80276ea30.png)


## Clean UP

```powershell
Get-AzResourceGroup RG-Demo-P1-1 | Remove-AzResourceGroup -Force
```


# Virtual Machine Scale Set (Azure Portal)

Navigate to [Azure Portal](https://portal.azure.com).


## Resource group

Go to **Resource groups**. Create new resource group **RG-Demo-P1-2** in the **West Europe** region.

![image](https://user-images.githubusercontent.com/34960418/153229201-3f01ed5e-dd20-4790-8874-cd695a162549.png)


## Virtual machines scale set

Enter the resource group and click on the **+ Create** button to add new resources. In the search field enter **Virtual machine scale set** and press **Enter**. Then click on the **Create** button.

![image](https://user-images.githubusercontent.com/34960418/153231307-4150c7e0-78c9-48c7-a8ee-352eb73c0baa.png)


For the **Virtual machine scale set name** enter **vss**. Make sure that Make sure that West Europe is selected in the Region field is selected in the **Region** field. From the list of Operating system disk **images** choose **Ubuntu Server 18.04 LTS**. Set instance **size** to **Standard B1s**. For **Authentication type** select **Password**. In the **Username** field enter **demouser**. For password use **DemoPassword-2022**. Click on the **Next: Disks button**. Click again on the **Next: Networking** button.

![image](https://user-images.githubusercontent.com/34960418/153232871-f3da206e-867a-4d2d-9035-9c4b3809ce7f.png)


Edit the proposed network / nic settings by clicking the **pencil** icon.

![image](https://user-images.githubusercontent.com/34960418/153233789-18abd80f-7e97-4bba-922e-d72459f86c75.png)


Change the** Public inbound ports** to **Allow selected ports**. Select port** HTTP (80)** and **SSH (22)** in the **Select inbound ports** drop-down list. Confirm with the **OK** button. 

![image](https://user-images.githubusercontent.com/34960418/153234239-edddd8ba-809f-4987-93ff-c777803d9afe.png)


Set the **Use a load balancer** option to **Yes**. Accept the default settings for the load balancer. Click on the **Next: Scaling** button

![image](https://user-images.githubusercontent.com/34960418/153234829-b7dbf389-dd41-4652-8a02-c23fc6a0afe1.png)


Leave **Instance count** to **2**. Accept the other scaling options defaults and click on the **Next: Management** button. Accept the default values and click on the **Next: Health** button. Click on the **Next: Advanced** button.

![image](https://user-images.githubusercontent.com/34960418/153235407-a2239b61-1cbf-4843-936c-12d7329cc108.png)


In the Custom data field paste:

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

Click on the **Review + create** button. Finally, click the **Create** button.

![image](https://user-images.githubusercontent.com/34960418/153236142-b8958e68-e6bc-4860-ae28-7f36191c7ced.png)


Once the deployment is done, click on the **Go to resource** button. Get the public IP address and paste it into a browser window, a web site should be seen.

![image](https://user-images.githubusercontent.com/34960418/153236947-2d983e10-838e-475f-a418-f92cabd57ce5.png)




# Virtual Machine Scale Set (Azure CLI)

If using the tool on-premise. Not necessary with Azure Cloud Shell.

```bash
az login
```

## Resource group

First create a resource group

```bash
az group create --name RG-Demo-P1-2 --location westeurope
```

## Virtual machine scale set

Create a virtual machine scale set

```bash
az vmss create --resource-group RG-Demo-P1-2 --name vss --image UbuntuLTS --vm-sku Standard_B1s --instance-count 2 --upgrade-policy-mode automatic --custom-data cloud-init.yaml --authentication-type password --admin-username demouser --admin-password DemoPassword-2022 --output table
```

Create a load balancer rule

```bash
az network lb rule create --resource-group RG-Demo-P1-2 --name vss-lb-rule --lb-name vssLB --backend-pool-name vssLBBEPool --backend-port 80 --frontend-ip-name loadBalancerFrontEnd   --frontend-port 80 --protocol tcp --output table
```

![image](https://user-images.githubusercontent.com/34960418/153239506-e40cbaec-d301-4166-ab55-9c9434e653fe.png)


Get the public IP address of the load balancer

```bash
az network public-ip show --resource-group RG-Demo-P1-2 --name vssLBPublicIP --query [ipAddress] --output tsv
```

![image](https://user-images.githubusercontent.com/34960418/153239721-4bdd6220-b4f6-476c-9657-8b8c346ab327.png)


And paste it into a browser window

![image](https://user-images.githubusercontent.com/34960418/153239890-f885da3a-935a-42fc-af6c-0c98031e5004.png)


## Clean Up

```bash
az group delete --name RG-Demo-P1-2 --yes --no-wait
```



# Virtual Machine Scale Set (Azure PS)


If using the tool on-premise. Not necessary with Azure Cloud Shell.

```powershell
Connect-AzAccount
```


## Resource group

Create variables for the resource group and location

```powershell
$RG = 'RG-Demo-P1-2'
$LO = 'westeurope'
New-AzResourceGroup -ResourceGroupName $RG -Location $LO
```

![image](https://user-images.githubusercontent.com/34960418/153244735-4626a250-4fd7-4883-a595-c20531540406.png)


## Network security group

Prepare the rules and the network security group

```powershell
$rule1 = New-AzNetworkSecurityRuleConfig -Name Port_22 -Access Allow -Protocol Tcp `
-Direction Inbound -Priority 100 -SourceAddressPrefix * -SourcePortRange * `
-DestinationAddressPrefix * -DestinationPortRange 22
$rule2 = New-AzNetworkSecurityRuleConfig -Name Port_80 -Access Allow -Protocol Tcp `
-Direction Inbound -Priority 110 -SourceAddressPrefix * -SourcePortRange * `
-DestinationAddressPrefix * -DestinationPortRange 80
$NSG = New-AzNetworkSecurityGroup -Name "NSG" -ResourceGroupName $RG `
-Location $LO -SecurityRules $rule1,$rule2
```

## Virtual network

Create the subnet

```powershell
$S1 = New-AzVirtualNetworkSubnetConfig -Name VNET1-S1 `
-AddressPrefix 10.0.0.0/24 -NetworkSecurityGroup $NSG
```

create the network itself

```powershell
$NET = New-AzVirtualNetwork -ResourceGroupName $RG -Location $LO -Name VNET1 `
-AddressPrefix 10.0.0.0/16 -Subnet $S1
```


## Load balancer

First, the IP address

```powershell
$LBIP = New-AzPublicIpAddress -ResourceGroupName $RG -Location $LO `
-Name 'LB-IP' -AllocationMethod Dynamic
```

Then, the front-end configuration

```powershell
$LBFE = New-AzLoadBalancerFrontendIpConfig -Name 'LB-FE' -PublicIpAddress $LBIP
```

Next, the back-end configuration

```powershell
$LBBE = New-AzLoadBalancerBackendAddressPoolConfig -Name 'LB-BE'
```

The health probe

```powershell
$LBHP = New-AzLoadBalancerProbeConfig -Name 'LB-HP' -Protocol tcp -Port 80 `
-IntervalInSeconds 5 -ProbeCount 2
```

The load balancing rule

```powershell
$LBRL = New-AzLoadBalancerRuleConfig -Name 'LB-RULE' -FrontendIpConfiguration $LBFE `
-BackendAddressPool $LBBE -Protocol Tcp -FrontendPort 80 -BackendPort 80 -Probe $LBHP
```

And the load balancer itself

```powershell
$LB = New-AzLoadBalancer -Name 'LB' -ResourceGroupName $RG -Location $LO `
-FrontendIpConfiguration $LBFE -BackendAddressPool $LBBE -Probe $LBHP -LoadBalancingRule $LBRL
```

## Virtual machine scale set

IP configuration

```powershell
$VSSIPC = New-AzVmssIpConfig -Name 'VSSIPCONF' -Primary $true -SubnetId $NET.Subnets[0].Id `
-LoadBalancerBackendAddressPoolsId $LBBE.Id
```

Scale set configuration

```powershell
$VSSCONF = New-AzVmssConfig -Location $LO -SkuCapacity 2 -SkuName Standard_B1s `
-UpgradePolicyMode Automatic
```

Storage profile

```powershell
Set-AzVmssStorageProfile $VSSCONF -ImageReferencePublisher Canonical `
-ImageReferenceOffer UbuntuServer -ImageReferenceSku '18.04-LTS' `
-ImageReferenceVersion latest -OsDiskCreateOption FromImage
```

![image](https://user-images.githubusercontent.com/34960418/153247211-01e634fe-c4e9-48be-924e-530f9c2716d9.png)


OS profile 

```powershell
Set-AzVmssOsProfile $VSSCONF -AdminUsername 'demouser' -AdminPassword 'DemoPassword-2021' `
-ComputerNamePrefix 'VM'
```

![image](https://user-images.githubusercontent.com/34960418/153247433-45c4643f-b4b9-4cb7-93fa-b81606e1646e.png)


Networking configuration

```powershell
Add-AzVmssNetworkInterfaceConfiguration -VirtualMachineScaleSet $VSSCONF -Name 'VSSNETCONF' `
-Primary $true -IPConfiguration $VSSIPC
```

And finally, we initiate the scale set creation

```powershell
$vmss = New-AzVmss -ResourceGroupName $RG -Name 'VSS' -VirtualMachineScaleSet $VSSCONF
```


Continue with the provision process. For this to happen, prepare a custom configuration. Upload somewhere the script

```powershell
$customConfig = @{
  "fileUris" = (,"http://tuionui.com/custom-script.sh");
  "commandToExecute" = "bash custom-script.sh"
}
```

Script content

![image](https://user-images.githubusercontent.com/34960418/153248285-709851ba-796d-4d92-aaec-66083f825b67.png)


And then, install an extension that will push the configuration

```powershell
$vmss = Add-AzVmssExtension -VirtualMachineScaleSet $vmss -Name "customScript" `
-Publisher "Microsoft.Azure.Extensions" -Type "CustomScript" `
-TypeHandlerVersion 2.0 -Setting $customConfig
```

In order to initiate the installation process,  update the scale set

```powershell
Update-AzVmss -ResourceGroupName $RG -Name "VSS" -VirtualMachineScaleSet $vmss
```

Once updated, get the public IP address with

```powershell
Get-AzPublicIPAddress -Name 'LB-IP' -ResourceGroupName $RG | Select IpAddress
```

And navigate in a browser tab to this URL ```http://<public ip>/index.php```

![image](https://user-images.githubusercontent.com/34960418/153249409-43aaa4c5-ca3b-42ca-989d-40a97ca5f4ef.png)


## Clean up

```powershell
Get-AzResourceGroup RG-Demo-P1-2 | Remove-AzResourceGroup -Force
```


# BLOB + Files (Azure Portal)

## Resource group

Go to **Resource groups**. Create new resource group **RG-Demo-P1-3** in the **West Europe** region. 

![image](https://user-images.githubusercontent.com/34960418/153252343-ab62df59-a0a4-47ea-a0c0-70092721735f.png)


## Storage account 


Enter the resource group and click on the **+ Create** button to add new resources. In the search field enter **Storage account** and hit **Enter**. Then click on the **Create** button.

![image](https://user-images.githubusercontent.com/34960418/153252583-c62e6195-80b3-43e7-81bc-bc17690b9b18.png)


For name enter something unique, for example **sadvzaze**. Set the Location to **West Europe**. Leave all other values as they are and click on the **Review + create** button. Then click on the **Create** button. 

![image](https://user-images.githubusercontent.com/34960418/153253086-e0fc06f6-8e33-411f-8e6f-77d74c9cce90.png)


## BLOB

Enter (navigate to) the account you just created. Click on the **Containers** section. Click on the **+ Container** button to create new one. 

![image](https://user-images.githubusercontent.com/34960418/153253837-1aebcf88-61db-4d6b-bf7d-7a96e5efde6f.png)


For **Name** enter **blobs** and click on **Create**.

![image](https://user-images.githubusercontent.com/34960418/153254033-b2c13fe0-3646-4674-9ea0-56122cfd9740.png)


Click on the newly created container

![image](https://user-images.githubusercontent.com/34960418/153254314-1a1ae132-9520-469e-87b1-912b5d5649c7.png)


Now, we can upload one or more files to it. Click on the **Upload** button. Click on the **Browse** button and select one or more files, then click on **Open**. Finally, click on **Upload**.

![image](https://user-images.githubusercontent.com/34960418/153254830-6fccecc8-cec0-42a9-8f6b-ac960ed304bf.png)


## Files

Return to the storage account. Click on the **File shares** option. Click on the **+ File share** button to create one.

![image](https://user-images.githubusercontent.com/34960418/153255411-013eb646-237c-4ff7-872f-966bcb3d902f.png)


For **Name** enter **share**. Click on **Create**.

![image](https://user-images.githubusercontent.com/34960418/153255735-14c83500-b457-4dce-a13c-68293151ad83.png)


Click on the **share**

![image](https://user-images.githubusercontent.com/34960418/153255961-4f05472b-e8c7-405a-ae91-bd01a405e476.png)


Then click on the Upload button to upload a file.

![image](https://user-images.githubusercontent.com/34960418/153256120-e1c9862e-ae66-4499-bd18-50258a1e1045.png)
![image](https://user-images.githubusercontent.com/34960418/153256181-6a483d0e-9b13-4564-8dd6-0c4d095ef1d4.png)


## Storage Explorer

Download the Storage Explorer application from [here](https://azure.microsoft.com/en-us/features/storage-explorer/). Install it and run it. Connect it to your subscription.
Navigate to the storage account and explore its contents.


# Security

## Create New User

Enter **Users** in the search field, then hit the **Enter** key. Click on the **+ New user** button

![image](https://user-images.githubusercontent.com/34960418/153392477-7348d4f6-a6cd-4d67-af59-356fb6be755e.png)


In the **User name** field enter something, for example **azeuser**. For **Name** enter **AzE User**. Select the Let me create the password option. Then for **Initial password** enter something (up to 16 symbols), for example **Password-2022**. Click on **Create**.

![image](https://user-images.githubusercontent.com/34960418/153392971-ffcba912-1d27-48a4-b94a-766e1b78e3bc.png)


Now, the new account which will be ```azeuser@<domain>.onmicrosoft.com``` can be used for login. 

![image](https://user-images.githubusercontent.com/34960418/153393456-dfccdc13-3b61-432d-b224-f2251116713e.png)


Open new browser window in private mode and navigate to [portal.azure.com](https://portal.azure.com). Enter the account name. Next you will be asked to change the password. Once you are in the portal, you will notice that the new user is not assigned to a subscription.

![image](https://user-images.githubusercontent.com/34960418/153394290-ddfef215-d852-489c-b448-45277e0ba367.png)



## RBAC

Return to the session with your main user. In the search field enter **Subscription** and hit **Enter**. Go to **Access control (IAM)**. Switch to **Role assignments**. Click on the **+ Add** button. 

![image](https://user-images.githubusercontent.com/34960418/153395202-f5851378-605b-46bd-a46c-8de1a1faa8ef.png)


Select **Add role assignment**.

![image](https://user-images.githubusercontent.com/34960418/153395569-4022b5ae-63fa-4d92-a563-5b6ed88d11db.png)


In the search filed enter **Virtual Machine Contributor**. Select the Virtual Machine Contributor role. And click on **Next** button.

![image](https://user-images.githubusercontent.com/34960418/153396790-739379dd-5cc1-4aeb-bd3d-cd0c5bcc92fa.png)


Click on **Select members**.

![image](https://user-images.githubusercontent.com/34960418/153396256-5d603d87-ee38-4af1-b3bf-6b073555a550.png)


Choose newly created user AzE User. And click on button **Select**.

![image](https://user-images.githubusercontent.com/34960418/153396557-92ebd09a-d4c8-4c16-853a-44ab9c191d41.png)


Click on **Review + assign** button.

![image](https://user-images.githubusercontent.com/34960418/153397081-e00c4aab-a6fc-40b1-acbe-44e0accd5c7f.png)


Repeat procedure for **Virtual Machine User Login** role. Return to AzE User's Azure portal.

![image](https://user-images.githubusercontent.com/34960418/153398034-bcd9e0cb-870b-413c-a40b-fa04540a7fd1.png)


Check for subscriptions. 

![image](https://user-images.githubusercontent.com/34960418/153398582-056628ae-46a2-432b-b85b-179a3872e574.png)



## Policies

Go to Home view with regular user. In the search bar enter **Policy** and hit **Enter**. Go to **Definitions**. Filter the **Category** to **Compute** only. Click on the **Allowed virtual machine SKUs**. 

![image](https://user-images.githubusercontent.com/34960418/153402798-daf5c09c-788d-41d1-bcda-6fc37fd72f8c.png)


Click on the **Assign** button. 

![image](https://user-images.githubusercontent.com/34960418/153402910-edd7ea41-27f8-4298-9270-9d5ca826deb5.png)


In **scope** choose both **subscription** and **resource group**. Click **Select**.

![image](https://user-images.githubusercontent.com/34960418/153403412-ac4e3ca2-4057-45fd-8a82-657ac7c2f065.png)


In the **Assignment name** append **only B1S**. Click on **Next**.

![image](https://user-images.githubusercontent.com/34960418/153403935-c2f88676-6138-4834-bd44-7936a90827fa.png)


In the **Allowed SKUs** select **Standard_B1s** and **Standard_B1ls**. Click **Review + create**. Finally, click on **Create**.

![image](https://user-images.githubusercontent.com/34960418/153404346-a28aeb7a-d289-4777-bf80-4d8db7a668e6.png)


Return to **Assignments** in the **Policies**. New policy assignment should be there.

![image](https://user-images.githubusercontent.com/34960418/153404698-0be79fdb-4f40-468b-9ceb-f2c25ccece23.png)


Go to the resource group and create a VM of different size. Click on **See all sizes**.

![image](https://user-images.githubusercontent.com/34960418/153405028-781a1307-69c1-4887-9b3b-93eb74d1c141.png)


Only sizes allowed by policy are displayed.

![image](https://user-images.githubusercontent.com/34960418/153405257-5f27e7f3-61dd-4fd8-bceb-1b951705f412.png)


## Locks

Locks are an effective prevention mechanism against deleting resources by a mistake.

Let’s navigate to Resource group **RG-Demo-P1-1**. Scroll down to the **Settings** section. There is the **Locks** command, click on it. Click on the **+ Add** button.

![image](https://user-images.githubusercontent.com/34960418/153406610-5bcf12c9-296c-474a-8402-d68705cbe9d0.png)


For Lock name enter **rg-lock**. Set the **Lock type** to **Delete**. In the **Notes** field enter **Do not delete this RG**. Click on the **OK** button.

![image](https://user-images.githubusercontent.com/34960418/153407003-1e0bf3ee-c58f-4e62-bad9-b9914cd914f9.png)


Try to delete the RG. In order to delete the resource, first delete the lock.

![image](https://user-images.githubusercontent.com/34960418/153407158-53dc28fc-98e2-482c-8136-425de7475a1a.png)




