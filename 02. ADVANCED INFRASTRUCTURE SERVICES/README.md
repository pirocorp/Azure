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
- [Demos](#demos)
  - [Two VMs in an Availability Set + Cloud Init + Load Balancer + Security Group (Azure Portal)](#two-vms-in-an-availability-set--cloud-init--load-balancer--security-group-azure-portal)
  - [Two VMs in an Availability Set + Cloud Init + Load Balancer + Security Group (Azure CLI)](#two-vms-in-an-availability-set--cloud-init--load-balancer--security-group-azure-cli)
  - [Two VMs in an Availability Set + Cloud Init + Load Balancer + Security Group (Azure PS)](#two-vms-in-an-availability-set--cloud-init--load-balancer--security-group-azure-ps)
  - [Virtual Machine Scale Set (Azure Portal)](#virtual-machine-scale-set-azure-portal)
  - [Virtual Machine Scale Set (Azure CLI)](#virtual-machine-scale-set-azure-cli)
  - [Virtual Machine Scale Set (Azure PS)](#virtual-machine-scale-set-azure-ps)
  - [Blob + Files (Azure Portal)](#blob--files-azure-portal)

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


# Demos

## Two VMs in an Availability Set + Cloud Init + Load Balancer + Security Group (Azure Portal)

Go to [Azure Portal](https://portal.azure.com)


### Resource group

Go to Resource groups. And create a new resource group ```RG-Demo-P1-1``` in the ```West Europe``` region.

![image](https://user-images.githubusercontent.com/34960418/153183982-59348949-01b7-4c09-bab1-1507c426c8b9.png)


### Virtual network

Enter the resource group and click on the **+ Create** button to add new resources. In the search field enter **Virtual Network** and hit **Enter**. Then click on the **Create** button. 

![image](https://user-images.githubusercontent.com/34960418/153184378-7498d8f0-f8c9-4923-84e2-d23b86f027e3.png)


For name enter ```p11vnet```. Ensure that the **Region** is set to **West Europe**. Click the **Next: IP Addresses** button.

![image](https://user-images.githubusercontent.com/34960418/153184958-c53215a1-b68d-4053-8771-3d0b2d0e108c.png)


Leave the address space as it is. Make sure that it is **10.0.0.0/16**, and for the default subnet, it must be **10.0.0.0/24**. Click on the **Review + create** button.

![image](https://user-images.githubusercontent.com/34960418/153185856-20df7c37-b747-4192-9442-590172a6034a.png)


Finally, click on the **Create** button

![image](https://user-images.githubusercontent.com/34960418/153186036-ae9bc590-2e3c-4512-ad0b-58843c11f34b.png)


### Network security group

Return to the resource group and click on the **+ Create** button to add new resources. In the search field enter **Network security group** and hit **Enter**. Then click on the **Create** button.

![image](https://user-images.githubusercontent.com/34960418/153186369-f30690d9-066c-4571-82b2-ecefaf87f7c1.png)


For **name** enter ```p11sg```. Ensure that the **Region** is set to ```West Europe```. Accept the proposed values for all other parameters (subscription and resource group). Click on the **Review + create** button and then on **Create**.

![image](https://user-images.githubusercontent.com/34960418/153186861-173f2562-2291-424f-add7-9b46bc93d1c4.png)


Once the deployment is done click on the **Go to resource** button. In the **Settings** section click on **Subnets** to associate the group with a network. Click on the **+ Associate** button. In **Virtual network** drop-down select **p11vnet** and then in the **Subnet** drop-down select **default**. Click on **OK**.

![image](https://user-images.githubusercontent.com/34960418/153189803-d34e1d79-c6eb-45cd-94a7-2efb54cfc44f.png)



### Security rules

In the **Settings** section click on the **Inbound security rules** to add two rules. Click on the **+ Add** button. Change **Destination port ranges** to **22**. Change **Protocol** to **TCP**. In the **Name** field enter **Port_22**. Click on the **Add** button. Repeat the procedure once again but change **22** to **80**.

![image](https://user-images.githubusercontent.com/34960418/153190888-82d84d83-7e3c-4a07-b361-4348e4778aab.png)



### Virtual machines

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



### Load balancer

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


## Two VMs in an Availability Set + Cloud Init + Load Balancer + Security Group (Azure CLI)

If using the tool on-premise, if using the **Azure Cloud Shell**, this is not necessary.

```bash
az login
```

### Resource group

Creating a resource group is done with

```bash
az group create --name RG-Demo-P1-1 --location westeurope --output table
```

![image](https://user-images.githubusercontent.com/34960418/153212484-e4aadbba-789f-4850-9358-76ec470af6d2.png)


### Network security group

Create the network security group

```bash
az network nsg create --name p11sg --resource-group RG-Demo-P1-1 --output table
```


### Security rules

Then, add both inbound rules

```bash
az network nsg rule create --name Port_22 --nsg-name p11sg --resource-group RG-Demo-P1-1 --access Allow --protocol tcp --direction inbound --priority 100 --destination-port-range 22 --output table
az network nsg rule create --name Port_80 --nsg-name p11sg --resource-group RG-Demo-P1-1 --access Allow --protocol tcp --direction inbound --priority 110 --destination-port-range 80 --output table
```

![image](https://user-images.githubusercontent.com/34960418/153213020-cf19fe82-2eef-4610-9eec-86bb009653c3.png)



### Virtual network

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


### Virtual machines

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


### Load balancer

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


### Clean Up

```bash
az group delete --name RG-Demo-P1-1 --yes --no-wait
```



## Two VMs in an Availability Set + Cloud Init + Load Balancer + Security Group (Azure PS)


If using the tool on-premise. If using the **Azure Cloud Shell**, this is not necessary.

```powershell
Connect-AzAccount
```

![image](https://user-images.githubusercontent.com/34960418/153220487-cc7e3478-60f4-4281-a43c-9674e47a78c9.png)


### Resource group

Creating a resource group is done with

```poweshell
$LO = "westeurope"
$RG = "RG-Demo-P1-1"
New-AzResourceGroup -Name $RG -Location $LO
```

![image](https://user-images.githubusercontent.com/34960418/153220961-88414397-c52f-4955-97ff-931bb7e2afa2.png)


### Network security group

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


### Virtual network

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


### Virtual machines

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


### Load balancer

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


### Clean UP

```powershell
Get-AzResourceGroup RG-Demo-P1-1 | Remove-AzResourceGroup -Force
```


## Virtual Machine Scale Set (Azure Portal)

Navigate to [Azure Portal](https://portal.azure.com).


### Resource group

Go to **Resource groups**. Create new resource group **RG-Demo-P1-2** in the **West Europe** region.

![image](https://user-images.githubusercontent.com/34960418/153229201-3f01ed5e-dd20-4790-8874-cd695a162549.png)


### Virtual machines scale set

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




## Virtual Machine Scale Set (Azure CLI)

If using the tool on-premise. Not necessary with Azure Cloud Shell.

```bash
az login
```

### Resource group

First create a resource group

```bash
az group create --name RG-Demo-P1-2 --location westeurope
```

### Virtual machine scale set

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


### Clean Up

```bash
az group delete --name RG-Demo-P1-2 --yes --no-wait
```



## Virtual Machine Scale Set (Azure PS)


If using the tool on-premise. Not necessary with Azure Cloud Shell.

```powershell
Connect-AzAccount
```


### Resource group

Create variables for the resource group and location

```powershell
$RG = 'RG-Demo-P1-2'
$LO = 'westeurope'
New-AzResourceGroup -ResourceGroupName $RG -Location $LO
```

![image](https://user-images.githubusercontent.com/34960418/153244735-4626a250-4fd7-4883-a595-c20531540406.png)


### Network security group

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

### Virtual network

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


### Load balancer

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

### Virtual machine scale set

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


### Clean up

```powershell
Get-AzResourceGroup RG-Demo-P1-2 | Remove-AzResourceGroup -Force
```

## BLOB + Files (Azure Portal)

### Resource group

Go to **Resource groups**. Create new resource group **RG-Demo-P1-3** in the **West Europe** region. 

![image](https://user-images.githubusercontent.com/34960418/153252343-ab62df59-a0a4-47ea-a0c0-70092721735f.png)


### Storage account 


Enter the resource group and click on the **+ Create** button to add new resources. In the search field enter **Storage account** and hit **Enter**. Then click on the **Create** button.

![image](https://user-images.githubusercontent.com/34960418/153252583-c62e6195-80b3-43e7-81bc-bc17690b9b18.png)


For name enter something unique, for example **sadvzaze**. Set the Location to **West Europe**. Leave all other values as they are and click on the **Review + create** button. Then click on the **Create** button. 

![image](https://user-images.githubusercontent.com/34960418/153253086-e0fc06f6-8e33-411f-8e6f-77d74c9cce90.png)


### BLOB

Enter (navigate to) the account you just created. Click on the **Containers** section. Click on the **+ Container** button to create new one. 

![image](https://user-images.githubusercontent.com/34960418/153253837-1aebcf88-61db-4d6b-bf7d-7a96e5efde6f.png)


For **Name** enter **blobs** and click on **Create**.

![image](https://user-images.githubusercontent.com/34960418/153254033-b2c13fe0-3646-4674-9ea0-56122cfd9740.png)


Click on the newly created container

![image](https://user-images.githubusercontent.com/34960418/153254314-1a1ae132-9520-469e-87b1-912b5d5649c7.png)


Now, we can upload one or more files to it. Click on the **Upload** button. Click on the **Browse** button and select one or more files, then click on **Open**. Finally, click on **Upload**.

![image](https://user-images.githubusercontent.com/34960418/153254830-6fccecc8-cec0-42a9-8f6b-ac960ed304bf.png)


### Files

Return to the storage account. Click on the **File shares** option. Click on the **+ File share** button to create one.

![image](https://user-images.githubusercontent.com/34960418/153255411-013eb646-237c-4ff7-872f-966bcb3d902f.png)


For **Name** enter **share**. Click on **Create**.

![image](https://user-images.githubusercontent.com/34960418/153255735-14c83500-b457-4dce-a13c-68293151ad83.png)


Click on the **share**

![image](https://user-images.githubusercontent.com/34960418/153255961-4f05472b-e8c7-405a-ae91-bd01a405e476.png)


Then click on the Upload button to upload a file.

![image](https://user-images.githubusercontent.com/34960418/153256120-e1c9862e-ae66-4499-bd18-50258a1e1045.png)
![image](https://user-images.githubusercontent.com/34960418/153256181-6a483d0e-9b13-4564-8dd6-0c4d095ef1d4.png)


### Storage Explorer
