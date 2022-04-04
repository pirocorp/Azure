# TOC

## Assignments

- [Implement three-tier architecture to host a PHP web application with SQL server database](#implement-three-tier-architecture-to-host-a-php-web-application-with-sql-server-database)
- [Implement AKS and deploy Azure Web App and 2 Azure Functions](#implement-aks-and-deploy-azure-web-app-and-2-azure-functions)

## Solutions

- [Three-tier architecture (Portal)](#three-tier-architecture-portal)
  - [Exemplary execution plan](#exemplary-execution-plan)
  - [Resource group](#resource-group)
  - [Network security group (front-end)](#network-security-group-front-end)
  - [Network security group (back-end)](#network-security-group-back-end)
  - [Virtual Network and Subnets](#virtual-network-and-subnets)
  - [Link the subnets and security groups.](#link-the-subnets-and-security-groups)
  - [Availability set (front-end).](#availability-set-front-end)
  - [Availability set (back-end)](#availability-set-back-end)
  - [Virtual machine 1 (front-end #1)](#virtual-machine-1-front-end-1)
  - [Virtual machine 2 (front-end #2)](#virtual-machine-2-front-end-2)
  - [Virtual machine 3 (back-end #1)](#virtual-machine-3-back-end-1)
  - [Virtual machine 4 (back-end #2)](#virtual-machine-4-back-end-2)
  - [Create Public Load Balancer](#create-public-load-balancer)
  - [Create Internal Load Balancer](#create-internal-load-balancer)
  - [Setup external load balancer rules](#setup-external-load-balancer-rules)
    - [Backend pools](#backend-pools)
    - [Health probes](#health-probes)
    - [Load balancing rules](#load-balancing-rules)
    - [Inbound NAT rules](#inbound-nat-rules)
  - [Setup internal load balancer rules](#setup-internal-load-balancer-rules)
    - [Backend pools](#backend-pools-1)
    - [Health probes](#health-probes-1)
    - [Load balancing rules](#load-balancing-rules-1)
  - [Database](#database)
    - [Database and database server](#database-and-database-server)
    - [Setup database connectivity](#setup-database-connectivity)
    - [Load data](#load-data)
  - [Configure the backend servers (VM-BE-1)](#configure-the-backend-servers-vm-be-1)
  - [Configure the backend servers (VM-BE-2)](#configure-the-backend-servers-vm-be-2)
  - [Configure the front-end servers (VM-FE-1)](#configure-the-front-end-servers-vm-fe-1)
  - [Configure the front-end servers (VM-FE-2)](#configure-the-front-end-servers-vm-fe-2)
  - [Test the infrastructure](#test-the-infrastructure)
  - [Deploy the application and all supplementary software (VM-BE-1)](#deploy-the-application-and-all-supplementary-software-vm-be-1)
  - [Deploy the application and all supplementary software (VM-BE-2)](#deploy-the-application-and-all-supplementary-software-vm-be-2)
  - [Test Deployed Application](#test-deployed-application)
- [Three-tier architecture (CLI)](#three-tier-architecture-cli)
- [AKS (Portal)](#aks-portal)


# Implement three-tier architecture to host a PHP web application with SQL server database.

![image](https://user-images.githubusercontent.com/34960418/161519400-7031f84e-b449-4839-8beb-cfc648c11c4c.png)

## Infrastructure - 5 tasks, 15 pts

-	(T101, 1 pts) Create a resource group named RG-Solution
-	(T102, 2 pts) Create an artifact (availability set or virtual machine scale set) that provides high availability for virtual machines in the front-end group and name it AS-FE
-	(T103, 2 pts) Create an artifact (availability set or virtual machine scale set) that provides high availability for virtual machines in the back-end group and name it AS-BE
-	(T104, 5 pts) Create a set of two Ubuntu 18.04 virtual machines in the front-end group each with a password set as an authentication method. If created in an availability set, name them VM-FE-x, where x is a sequence number
-	(T105, 5 pts) Create a set of two Ubuntu 18.04 virtual machines in the back-end group each with a password set as an authentication method. If created in an availability set, name them VM-BE-x, where x is a sequence number

## Networking - 7 tasks, 19 pts

-	(T201, 1 pts) Create a virtual network named NET with address space 10.0.0.0/16
-	(T202, 2 pts) Create a subnet named NET-Sub-Front with address space 10.0.1.0/24
-	(T203, 2 pts) Create a subnet named NET-Sub-Back with address space 10.0.2.0/24
-	(T204, 3 pts) Create a network security group SG-Front, attach it to the NET-Sub-Front subnet, and create two inbound rules – one to allow communication on port 22/tcp and a second one to allow communication on port 80/tcp
-	(T205, 3 pts) Create a network security group SG-Back, attach it to the NET-Sub-Back subnet, and create two inbound rules – one to allow communication on port 22/tcp and a second one to allow communication on port 9000/tcp
-	(T206, 4 pts) Create an external load balancer named LBP with the corresponding set of backend pool, health probe, and load balancing rule that maps external port 80/tcp to internal port 80/tcp
-	(T207, 4 pts) Create an internal load balancer named LBI with the corresponding set of backend pool, health probe, and load balancing rule that maps external port 9000/tcp to internal port 9000/tcp

## Databases - 3 tasks, 9 pts

-	(T301, 3 pts) Create SQL Server and a database
-	(T302, 3 pts) Configure connectivity to the server
-	(T303, 3 pts) Initialize the database with the help of the load-data.sql file part of the supporting files set

## Software Deployment - 5 tasks, 17 pts

-	(T501, 2 pts) Install NGINX on all front-end servers. For the configuration use (you are free to modify it or use your own) the nginx-sample.conf file part of the supporting files set
-	(T502, 3 pts) Install PHP-FPM on all back-end servers. Configure it to listen on port 9000
-	(T503, 4 pts) Install all supplementary software on all back-end servers to allow them to communicate with the SQL Server database
-	(T504, 5 pts) Deploy and configure (add connection string) all php files (part of the supporting files set) to all back-end servers
-	(T505, 3 pts) Have a fully working web application


# Implement AKS and deploy Azure Web App and 2 Azure Functions

## Infrastructure - 5 tasks, 13 pts

-	(T101, 1 pts) Create a resource group named RG-SolutionB
-	(T102, 3 pts) Create a container registry with Basic SKU
-	(T103, 2 pts) Enable the Admin user
-	(T104, 5 pts) Create an Azure Kubernetes Service resource with one node of size B2s
-	(T105, 2 pts) Link the ACR to the AKS

## Containers and Images - 7 tasks, 16 pts

-	(T201, 2 pts) Add the SQL connection string to the index.php file in the docker/web folder
-	(T202, 2 pts) Build the Docker image from the Dockerfile that is in the docker folder
-	(T203, 2 pts) Tag the Docker image for the Azure Container Registry
-	(T204, 2 pts) Publish the Docker image to the Azure Container Registry
-	(T205, 3 pts) Adjust the deployment.yaml file in the manifests folder to point to the published Docker image
-	(T206, 2 pts) Publish the manifests to the Kubernetes cluster (Azure Kubernetes Service)
-	(T207, 3 pts) Make sure that the app is working and showing correct results 

## Databases - 3 tasks, 9 pts

-	(T301, 3 pts) Create SQL Server and a database
-	(T302, 3 pts) Configure connectivity to the server
-	(T303, 3 pts) Initialize the database with the help of the create-structures.sql file part of the supporting files set

## Web Apps and Functions - 8 tasks, 22 pts

-	(T501, 3 pts) Create a PHP code-based (not container-based) web application (App Service) *
-	(T502, 2 pts) Add the SQL connection string to the index.php file in the webapp folder
-	(T503, 2 pts) Deploy the web application code to Azure
-	(T504, 2 pts) Make sure that the web app is working and showing correct results
-	(T505, 3 pts) Create a code-based Function App with .NET Core as runtime *
-	(T506, 3 pts) Create a Timer triggered function. It must execute every two minutes and insert a row with SubmittedName=TIMER in the database (table SubmittedItems)
-	(T507, 5 pts) Create a HTTP triggered function. When executed it must accept a single parameter (name), store the value in the database (table SubmittedItems), and return how many times the value has been inserted and when was the first time. The format should be VALUE has N copies and the first one was inserted on TIME. For example, if the function was called 5 times with the text Exam, and the first execution was on 17.10.2020 09:30, then it should return Exam has 5 copies and the first one was inserted on 17.10.2020 09:30. Please note that the format of the time is not important and may not match the example
-	(T508, 2 pts) Make sure that you have executed the HTTP triggered function successfully several times



# Three-tier architecture (Portal)

## Exemplary execution plan

1. Create a resource group
2. Take care of the network infrastructure (network + 2 subnets + 2 security groups with rules)
3. Create one public (external) and one internal load balancers
4. Create both front-end and back-end VMs, each in a separate availability set
5. Create and set up the database
6. Connect all together


## Resource group

Search for **Resource groups** in the main search bar and hit Enter. Click on **+ Create**. Check the **Subscription**. For the **Resource group** enter **RG-Solution**. Select **West Europe** for **Region**. Click on **Review + create** and then on **Create**.

![image](https://user-images.githubusercontent.com/34960418/161523236-1c526c07-1543-43fc-ac11-c9a98afe4549.png)


## Network security group (front-end)

Click on **+ Create**. Search for **Network security group**. Click on **Create**.

![image](https://user-images.githubusercontent.com/34960418/161531373-a67d2949-9c73-46d8-9493-dd7314b7e8eb.png)


Check the values for the **Subscription** and **Resource group**. Enter **SG-Front**. Change the **Region** to **West Europe**. Click **Review + create**. Click **Create**.

![image](https://user-images.githubusercontent.com/34960418/161531585-1fffe4e1-6f5b-4897-9f19-96e662fdb0ed.png)


Navigate to the security group **SG-Front**. Go to the **Inbound security** rules option under **Settings**. Click on **+ Add**

![image](https://user-images.githubusercontent.com/34960418/161531945-b023978d-909f-4265-81d8-c16c7e7432f9.png)


Click on **+ Add**. Change Destination port ranges to **22**. Select the **TCP** option under **Protocol**. Enter **Port_22** for **Name**. Click on **Add**.

![image](https://user-images.githubusercontent.com/34960418/161532234-84b73d45-753d-49f3-9212-fa3b3fe54da3.png)


Being in the **Inbound security rules** option under **Settings**. Click on **+ Add**. Change Destination port ranges to **80**. Select the **TCP** option under **Protocol**. Enter **Port_80** for **Name**. Click on **Add**.

![image](https://user-images.githubusercontent.com/34960418/161532470-812f7a09-76b3-4470-9002-f6864d951173.png)


## Network security group (back-end)

Return to the resource group. Click on **+ Create**. Search for **Network security group**. Click on **Create**. Check the values for the **Subscription** and **Resource group**. Enter **SG-Back**. Change the **Region** to **West Europe**. Click **Review + create**. Click **Create**.

![image](https://user-images.githubusercontent.com/34960418/161533067-f05928f7-b3a3-4f17-8638-449a01263f5d.png)


Navigate to the security group **SG-Back**. Go to the **Inbound security rules** option under **Settings**. And add **allow** inbound **TCP** trafic for ports **22** and **9000**.

![image](https://user-images.githubusercontent.com/34960418/161533406-5c5608a3-ee30-461e-b744-de61428b11f7.png)

![image](https://user-images.githubusercontent.com/34960418/161533508-8a3e837d-bb05-4ce1-90f8-888e22082cbb.png)

![image](https://user-images.githubusercontent.com/34960418/161533580-14064802-2df6-4da6-a872-f196d5f4bdc4.png)


## Virtual Network and Subnets

Return to the resource group. Click on **+ Create**. Search for **Virtual networks**. Click on **Create**. 

![image](https://user-images.githubusercontent.com/34960418/161528473-32790a99-d7d6-46c0-a138-3d5eaad82e09.png)


Set the **Name** to **NET**. Change the **Region** to **West Europe**. Click on **Next: IP Addresses >**.

![image](https://user-images.githubusercontent.com/34960418/161528804-1e59b3ea-4ed8-4f94-b875-e5790acb48d6.png)


Check that the **Address space** field contains **10.0.0.0/16**. In the **Subnet** section click on the label **default**. 

Change Subnet name to **NET-SUB-Front**. Adjust the Address range to be **10.0.1.0/24** Click on **Save**.

![image](https://user-images.githubusercontent.com/34960418/161529476-1a47cab7-fb09-41fa-b92c-b354838659e8.png)


In the **Subnet** section click on **+ Add subnet**. For **Subnet name** enter **NET-SUB-Back**. In the **Subnet address range** enter **10.0.2.0/24** Click on **Save**. Click on **Save**. Click on the **Review + create** button and then on **Create**.

![image](https://user-images.githubusercontent.com/34960418/161530337-0727a3f1-60ca-454f-b74d-cd1009b5158b.png)


## Link the subnets and security groups.

Navigate to the Virtual network **NET**. 

Go to the **Subnets** rules option under **Settings**. Click on **NET-SUB-Front** and select **SG-Front** from **Network security group** drop-down.

Go to the **Subnets** rules option under **Settings**. Click on **NET-SUB-Back** and select **SG-Back** from **Network security group** drop-down.

![image](https://user-images.githubusercontent.com/34960418/161534367-f8f14fcb-6591-4bfd-9331-a19a1f09cfde.png)


## Availability set (front-end).

Return to the resource group. Click on **+ Create**. Search for **Availability Set**. Click on **Create**. 

![image](https://user-images.githubusercontent.com/34960418/161525056-77d8c443-59b0-43a2-ab45-de5b95355d55.png)


Set the **Name** to **AS-FE**. Change the **Region** to **West Europe** (or the one you are using). Set **Update domains** to **2**. Click **Review + create**. Click **Create**.

![image](https://user-images.githubusercontent.com/34960418/161525272-72ea5e7c-a6ff-40b5-9b3d-61451c5647a3.png)


## Availability set (back-end)

Return to the resource group. Click on **+ Create**. Search for Availability Set. Click on **Create**. Set the **Name** to **AS-BE**. Change the **Region** to **West Europe** (or the one you are using). Set **Update domains** to **2**. Click **Review + create**. Click **Create**.

![image](https://user-images.githubusercontent.com/34960418/161525790-0b4a68d8-3c45-4485-af62-ad39a01cb41c.png)


## Virtual machine 1 (front-end #1)

Return to the resource group. Click on **+ Create**. Click on Ubuntu Server 18.04 LTS in the Popular resources list.

![image](https://user-images.githubusercontent.com/34960418/161526397-e9544b05-33c3-4313-a20e-60f1a3370a00.png)


Check the values for **Subscription** and **Resource group**. For Virtual machine name enter **VM-FE-1**. Select **West Europe** for **Region**. Select **Availability set** in the **Availability options** drop-down list. Select the **AS-FE** option under the **Availability set** drop-down. Click on **Change size** if necessary. Select **B1s** and click **Select**. Change **Authentication type** to **Password**. Enter ```examuser``` for **Username**. Enter ```ExamPassword2022``` for **Password**. Switch the **Public inbound ports option** to **None**. Click on **Next : Disks >** Leave everything as it is. Click on **Next: Networking >**.


![image](https://user-images.githubusercontent.com/34960418/161527543-9354a2a2-accf-41d4-b96c-e0cb943c1543.png)


In the **Subnet** drop-down select **NET-SUB-Front**. For **Public IP** select **None** or for debugging purposes allow it to create one (you can use the serial console instead). Click on **Next: Management >**. 

![image](https://user-images.githubusercontent.com/34960418/161535682-1a68cd06-e5c2-440b-b779-55b88d37360c.png)


Ensure that the **Boot diagnostics** is set to **On** especially if you chose to NOT have a public IP address and you plan to use the serial console. Accept the default values. Click on **Next: Advanced >**.  

![image](https://user-images.githubusercontent.com/34960418/161535867-c7b20588-c754-4409-8a18-54670eabfc1b.png)

Paste the contents of the **fe-cloud-init.yaml** file in the Custom data text area. Click **Review + create**. Click **Create**.

![image](https://user-images.githubusercontent.com/34960418/161536141-33fdfbc7-522b-476d-9aff-356dbb14f509.png)


## Virtual machine 2 (front-end #2)

Return to the resource group. Click on **+ Create**. Click on Ubuntu Server 18.04 LTS in the Popular resources list.

![image](https://user-images.githubusercontent.com/34960418/161526397-e9544b05-33c3-4313-a20e-60f1a3370a00.png)


Check the values for **Subscription** and **Resource group**. For Virtual machine name enter **VM-FE-2**. Select **West Europe** for **Region**. Select **Availability set** in the **Availability options** drop-down list. Select the **AS-FE** option under the **Availability set** drop-down. Click on **Change size** if necessary. Select **B1s** and click **Select**. Change **Authentication type** to **Password**. Enter ```examuser``` for **Username**. Enter ```ExamPassword2022``` for **Password**. Switch the **Public inbound ports option** to **None**. Click on **Next : Disks >** Leave everything as it is. Click on **Next: Networking >**.

![image](https://user-images.githubusercontent.com/34960418/161543246-0e707e95-32f3-470f-bb50-51004f427c44.png)


In the **Subnet** drop-down select **NET-SUB-Front**. For **Public IP** select **None** or for debugging purposes allow it to create one (you can use the serial console instead). Click on **Next: Management >**. 

![image](https://user-images.githubusercontent.com/34960418/161543454-fad28b93-dc5b-4846-b65d-d97c0573c69a.png)


Ensure that the **Boot diagnostics** is set to **On** especially if you chose to NOT have a public IP address and you plan to use the serial console. Accept the 
default values. Click on **Next: Advanced >**.  

![image](https://user-images.githubusercontent.com/34960418/161543587-d6ee9b6a-8cc9-4123-aa93-04c5d6441695.png)


Paste the contents of the **fe-cloud-init.yaml** file in the Custom data text area. Click **Review + create**. Click **Create**.

![image](https://user-images.githubusercontent.com/34960418/161543702-b41c24d6-eccc-4c55-9f44-36b167a1d18e.png)


## Virtual machine 3 (back-end #1)

Return to the resource group. Click on **+ Create**. Click on Ubuntu Server 18.04 LTS in the Popular resources list.

![image](https://user-images.githubusercontent.com/34960418/161526397-e9544b05-33c3-4313-a20e-60f1a3370a00.png)


Check the values for **Subscription** and **Resource group**. For Virtual machine name enter **VM-BE-1**. Select **West Europe** for **Region**. Select **Availability set** in the **Availability options** drop-down list. Select the **AS-BE** option under the **Availability set** drop-down. Click on **Change size** if necessary. Select **B1s** and click **Select**. Change **Authentication type** to **Password**. Enter ```examuser``` for **Username**. Enter ```ExamPassword2022``` for **Password**. Switch the **Public inbound ports option** to **None**. Click on **Next : Disks >** Leave everything as it is. Click on **Next: Networking >**.

![image](https://user-images.githubusercontent.com/34960418/161544710-b7822ae0-2bd0-45cf-aeee-62cfd0b7fe18.png)


In the **Subnet** drop-down select **NET-SUB-Back**. For **Public IP** select **None** or for debugging purposes allow it to create one (you can use the serial console instead). Click on **Next: Management >**. 

![image](https://user-images.githubusercontent.com/34960418/161544880-ce800fd6-e853-40de-862c-6c7c8639528c.png)


Ensure that the **Boot diagnostics** is set to **On** especially if you chose to NOT have a public IP address and you plan to use the serial console. Accept the 
default values. Click on **Next: Advanced >**.  

![image](https://user-images.githubusercontent.com/34960418/161545007-ab2aef7c-5bd1-46b5-b962-8e320e7f554e.png)


Paste the contents of the **fe-cloud-init.yaml** file in the Custom data text area. Click **Review + create**. Click **Create**.

![image](https://user-images.githubusercontent.com/34960418/161545142-863550e5-308c-4f7a-b6e7-d4cb85d9259e.png)


## Virtual machine 4 (back-end #2)

Return to the resource group. Click on **+ Create**. Click on Ubuntu Server 18.04 LTS in the Popular resources list.

![image](https://user-images.githubusercontent.com/34960418/161526397-e9544b05-33c3-4313-a20e-60f1a3370a00.png)


Check the values for **Subscription** and **Resource group**. For Virtual machine name enter **VM-BE-2**. Select **West Europe** for **Region**. Select **Availability set** in the **Availability options** drop-down list. Select the **AS-BE** option under the **Availability set** drop-down. Click on **Change size** if necessary. Select **B1s** and click **Select**. Change **Authentication type** to **Password**. Enter ```examuser``` for **Username**. Enter ```ExamPassword2022``` for **Password**. Switch the **Public inbound ports option** to **None**. Click on **Next : Disks >** Leave everything as it is. Click on **Next: Networking >**.

![image](https://user-images.githubusercontent.com/34960418/161545883-9d5d1ca5-2baa-42e6-9037-0b30aceb0986.png)


In the **Subnet** drop-down select **NET-SUB-Back**. For **Public IP** select **None** or for debugging purposes allow it to create one (you can use the serial console instead). Click on **Next: Management >**. 

![image](https://user-images.githubusercontent.com/34960418/161546694-373048d3-da69-4170-babe-971eafd3af24.png)


Ensure that the **Boot diagnostics** is set to **On** especially if you chose to NOT have a public IP address and you plan to use the serial console. Accept the 
default values. Click on **Next: Advanced >**.  

![image](https://user-images.githubusercontent.com/34960418/161546901-71b40a93-29f6-47d6-b090-3b26b21ebbd4.png)


Paste the contents of the **fe-cloud-init.yaml** file in the Custom data text area. Click **Review + create**. Click **Create**.

![image](https://user-images.githubusercontent.com/34960418/161547034-8a233ff6-58d2-4b44-bba9-e8833176b859.png)


## Create Public Load Balancer

Return to the resource group. Click on **+ Create**. Search for **Load Balancer** in the main search bar and hit **Enter**. Click **Create**.

![image](https://user-images.githubusercontent.com/34960418/161549053-030881b9-7992-40a8-9a82-a6b69ea855d6.png)


Check the **Subscription**. For Resource group select **RG-Solution** created earlier. For **Name** enter **LBP**. Change **Region** to **West Europe** (or the one you are using so far). Change **SKU** to **Basic**. Click **Next: Frontend IP configuration >** button.

![image](https://user-images.githubusercontent.com/34960418/161560640-1499684d-d809-4745-8879-fdd0c3a91296.png)


Click the **Add a frontnd IP configuration** button. Enter **LBP-FE** in the **Name** field. Then click **Create new** under **Public IP address**. In the **Name** field enter **LBP-IP**. Click **OK** to confirm the IP address creation. Then click **Add** to confirm the frontend configuration creation. Click **Review + create**. Click **Create**.

![image](https://user-images.githubusercontent.com/34960418/161561269-00243f4f-6de3-40bb-a4bb-d416210f03f3.png)

![image](https://user-images.githubusercontent.com/34960418/161561428-88553cbb-8a30-4811-ac72-684518dddb49.png)


## Create Internal Load Balancer

Return to the resource group. Click on **+ Create**. Search for **Load Balancer** in the main search bar and hit **Enter**. Click **Create**.

![image](https://user-images.githubusercontent.com/34960418/161549053-030881b9-7992-40a8-9a82-a6b69ea855d6.png)


Check the **Subscription**. For Resource group select **RG-Solution** created earlier. For **Name** enter **LBI**. Change **Region** to **West Europe** (or the one you are using). Change **SKU** to **Basic**. Change the **Type** to **Internal**. Click **Next: Frontend IP configuration**.

![image](https://user-images.githubusercontent.com/34960418/161562056-fb7ec386-5910-4c18-b7ce-fbfa8d4f6feb.png)


Click the **Add a frontnd IP configuration** button. Enter **LBI-FE** in the **Name** field. In the **Subnet** drop-down list select **NET-SUB-Front** item. Change the **Assignment** to **Static**. Enter **10.0.1.254** in the **IP address** field. Then click **Add** to confirm the frontend configuration creation. Click **Review + create**. Click **Create**.

![image](https://user-images.githubusercontent.com/34960418/161562592-0f539ccd-0308-40be-8a73-287f8042db7c.png)

![image](https://user-images.githubusercontent.com/34960418/161562641-26f8a526-817a-480e-9d03-307bd89838c9.png)


## Setup external load balancer rules

Navigate to the front-end (public) load balancer (LBP)

![image](https://user-images.githubusercontent.com/34960418/161563773-51d856a7-3a71-44bb-9333-dc1ebc1f6d8d.png)


### Backend pools

Go to **Backend pools** under **Settings**. Click on **+ Add**.

![image](https://user-images.githubusercontent.com/34960418/161563996-bd19b68b-dbaf-4aad-9f8f-b3e12634508f.png)


For **Name** enter **LBP-BP**. Under **Virtual network** select **NET**. Select **Virtual machines** under the **Associated to**. Click the **+ Add** button. Then select both **VM-FE-1** and **VM-FE-2** and click **Add**. Click once more on **Add**.

![image](https://user-images.githubusercontent.com/34960418/161564541-60239bb0-b2e9-42ba-80df-7516502f70af.png)

![image](https://user-images.githubusercontent.com/34960418/161564582-8926863f-798f-4df4-b446-646336d31bf1.png)


### Health probes

Go to **Health probes**. Click on the **+ Add** button.

![image](https://user-images.githubusercontent.com/34960418/161565206-b1912911-c077-49d9-bf51-23c2a702f1b7.png)


For Name enter LBP-HP. Accept the default values. Click on **Add**. Wait a while for the health probe to be created. 


### Load balancing rules

Go to Load balancing rules. Click on the **+ Add** button. 

![image](https://user-images.githubusercontent.com/34960418/161565850-8bb78c8b-3451-438d-aca1-c625314823ad.png)


For Name enter **LBP-RULE**. Select the **LBP-FE** item in the Frontend IP address list. Select **LBP-BP** in the **Backend pool** list. Both for Port and Backend port enter **80**. Select **LBP-HP** in the **Health probe** list. Click **Add**. Wait a while for the load balancing rule to be created.

![image](https://user-images.githubusercontent.com/34960418/161566380-456e8279-47df-4524-8721-045b8488242b.png)


### Inbound NAT rules

If order to be able to connect to a particular VM behind the load balancer, we can create one or more NAT rules. Go to **Inbound NAT rules**. Click on the **+ Add** button.

![image](https://user-images.githubusercontent.com/34960418/161567364-cb4eaab8-e647-4b1f-8a60-eaf68914d8da.png)


For **Name** enter **LBP-NAT-SSH-1**. Select **VM-FE-1** as **Target virtual machine**. Select **ipconfig1** for **Network IP configuration**. Select the **LBP-FE** item in the **Frontend IP address** list. Enter **11001** in the **Frontend Port** field. Leave **Service Tag** to **Custom**. Enter **22** in the **Backend Port** field. Set **Protocol** to **TCP**. Click **Add**.

![image](https://user-images.githubusercontent.com/34960418/161568249-5c4fb739-07da-465f-8205-eb04f1faa669.png)


Repeat the procedure for the second VM as well, but change the name (**LBP-NAT-SSH-2**) and port (**11002**)

![image](https://user-images.githubusercontent.com/34960418/161569076-b92dc7e8-c4fd-4ac4-a8ca-37a36de8a01b.png)


## Setup internal load balancer rules

### Backend pools

Go to **Backend pools** under **Settings**. Click on **+ Add**.

![image](https://user-images.githubusercontent.com/34960418/161571296-2a1c7b03-9fc0-4c7f-886b-5b20ac4b3e05.png)

For **Name** enter **LBI-BP**. Under Virtual network, you should see that the **NET** is already selected (and you can not change it). Select **Virtual machines** under the **Associated to**. Click the **+ Add** button. Select both **VM-BE-1** and **VM-BE-2** machines. Click on **Add**. Once again, click on **Add**.

![image](https://user-images.githubusercontent.com/34960418/161571778-3055703e-51d2-4954-880a-a843c4113d11.png)


### Health probes

Go to **Health probes**. Click on the **+ Add** button. 

![image](https://user-images.githubusercontent.com/34960418/161572453-cbdc8e1a-067d-43b2-98fb-794faeadc4d2.png)


For **Name** enter **LBI-HP**. Change the **Port** to **9000**. Accept the default values for the rest of the parameters. Click on **Add**.

![image](https://user-images.githubusercontent.com/34960418/161572587-73b8721b-b5cf-4420-ae6b-1d9018889a4e.png)


### Load balancing rules

Go to **Load balancing rules**. Click on the **+ Add** button.

![image](https://user-images.githubusercontent.com/34960418/161572921-2ebc0eac-966b-466c-a8e6-7e6469d0eb59.png)


For **Name** enter **LBI-RULE**. Select **LBI-FE (10.0.1.254)** item in the Frontend IP address list. Select **LBI-BP** in the **Backend pool** list. Change both **Port** and **Backend port** to **9000**. Select **LBI-HP** in the **Health probe** list. Click **Add**.

![image](https://user-images.githubusercontent.com/34960418/161573745-bc5c456b-c7fa-4556-8a48-9fdb48c8cd52.png)


## Database

### Database and database server

Return to the resource group. Click on **+ Create**. Click on **SQL Database** in the **Popular** resources list. Click **Create**.

Check the values for **Subscription** and **Resource group**. Enter **azesqldb** in the Database name field. Click on **Create new** link under the **Server** field. In the New server windows enter the following values:
-	For Server name enter **azesql**
-	In Server admin login enter **demosa**
-	Use **ExamPassword2022** for Password
-	Select **West Europe** for Location (or another one you prefer)

Click on **OK**

![image](https://user-images.githubusercontent.com/34960418/161579269-2e8b73d0-37f4-4eb8-9f3d-3765440022a5.png)


Click on **Configure database** link under **Compute + storage**. Select **Basic** plan (**5 DTU**) and click **Apply**. Change the **Backup storage redundancy** setting to **Locally-redundant backup storage**. Click on **Review + create**. Click on **Create**.

![image](https://user-images.githubusercontent.com/34960418/161579688-42354e48-5698-4a60-8d66-d6ee0a375de7.png)


### Setup database connectivity

Navigate to the SQL server. Click on the **Firewalls and virtual networks** option under **Settings**. Select **Yes** in **Allow Azure services and resources to access this server**. Click on **+ Add client IP**. Click **Save**. Click **OK**.

![image](https://user-images.githubusercontent.com/34960418/161580565-73ee4227-3f36-4024-b590-4c97ddc0088b.png)


### Load data

Navigate to the SQL database. Click on **Query editor (preview)**. Enter the credentials specified during the creation process (should be **examsa** / **ExamPassword2022**). Click **OK**. Paste the code from **sql/load-data.sql** file. Click on **Run**. Check that the data is indeed loaded into the database.


## Configure the backend servers (VM-BE-1)

Connect to backend VMs. Check if **php-fpm** is installed and running.

```bash
systemctl status php7.2-fpm
```

![image](https://user-images.githubusercontent.com/34960418/161582968-fe26eb45-fef3-48a0-b216-bbdcb2f7f2c0.png)


If is not installed execute

```bash
sudo apt update
sudo apt upgrade
sudo apt install php-fpm
```


Modify the **PHP FPM** configuration to make it listen on port **9000**.

```bash
sudo nano /etc/php/7.2/fpm/pool.d/www.conf
```

![image](https://user-images.githubusercontent.com/34960418/161583578-abe104d0-2385-4f5b-9449-38c47cd90488.png)


Restart the service and check its state:

```bash
sudo systemctl restart php7.2-fpm.service
systemctl status php7.2-fpm.service
```

![image](https://user-images.githubusercontent.com/34960418/161583788-42c017cd-e2b4-45dd-8aee-409167f4f135.png)


Create a folder **/site** and change the ownership to **www-data** user and group:

```bash
sudo mkdir /site
sudo chown -R www-data:www-data /site
```

### Test it

Create a simple **/site/index.php** file that contains **<?php phpinfo(); ?>** construction in it.

```bash
echo '<?php phpinfo(); ?>' | sudo tee /site/index.php
```

![image](https://user-images.githubusercontent.com/34960418/161584395-0c2d984f-0677-471c-aace-e6245a6055e0.png)


Test it on the command line by executing:

```bash
php /site/index.php
```

You should see a dump of the PHP configuration

![image](https://user-images.githubusercontent.com/34960418/161584569-b1d15bf3-6690-434f-8b5b-394c075c15d7.png)


## Configure the backend servers (VM-BE-2)

Repeat the steps from the [VM-BE-1](#configure-the-backend-servers-vm-be-1)


## Configure the front-end servers (VM-FE-1)

Connect to backend VMs. Check if NGINX is installed and running.

```bash
systemctl status nginx
```

![image](https://user-images.githubusercontent.com/34960418/161586317-6be9454b-a4f5-4968-8433-3127dc0b4ee2.png)


Modify the NGINX configuration file by pasting the contents of the **conf/nginx-sample.conf** file over the default one.

```bash
sudo nano /etc/nginx/sites-available/default
```

![image](https://user-images.githubusercontent.com/34960418/161586707-5228deff-3994-4efa-b337-3b5746200037.png)


Restart and test that the **NGINX** service is working

```bash
sudo systemctl restart nginx
systemctl status nginx
```

![image](https://user-images.githubusercontent.com/34960418/161587118-454e5913-59c0-4700-b3fb-f1fa8f30ca80.png)


Test the page can be open locally

```bash
curl http://localhost/index.php
```

![image](https://user-images.githubusercontent.com/34960418/161587056-2beceeb6-ec75-4ca7-ab0d-b8ed0968daba.png)


## Configure the front-end servers (VM-FE-2)

Repeat the steps from the [VM-FE-1](#configure-the-front-end-servers-vm-fe-1)


## Test the infrastructure

Copy the **Public IP address** of the public load balancer. Open a browser tab and navigate to it (don’t forget to add **/index.php**). You should see the same configuration information.

![image](https://user-images.githubusercontent.com/34960418/161587994-211bda28-2ad1-4132-93a8-9e3b388c4717.png)


## Deploy the application and all supplementary software (VM-BE-1)

Add the Microsoft’s repository:

```bash
sudo bash -c "curl https://packages.microsoft.com/keys/microsoft.asc | apt-key add -"
sudo bash -c "curl https://packages.microsoft.com/config/ubuntu/18.04/prod.list > /etc/apt/sources.list.d/mssql-release.list"
```

Update package information

```bash
sudo apt-get update
```


Install the Microsoft tools:

```bash
sudo ACCEPT_EULA=Y apt-get install -y msodbcsql17 mssql-tools
```


Install the ODBC driver:

```bash
sudo apt-get install -y unixodbc-dev
```


Install all necessary packages:

```bash
sudo apt-get install -y gcc g++ make autoconf libc-dev pkg-config
```


Install PHP PEAR and PHP development packages:

```bash
sudo apt-get install -y php-pear php-dev
```

Install SQL server extensions: 

```bash
sudo pecl install sqlsrv-5.8.1
sudo pecl install pdo_sqlsrv-5.8.1
```


Adjust the configuration:

```bash
sudo bash -c "echo extension=sqlsrv.so > /etc/php/7.2/mods-available/sqlsrv.ini"
sudo bash -c "echo extension=pdo_sqlsrv.so > /etc/php/7.2/mods-available/pdo_sqlsrv.ini"
```


Enable both modules:

```bash
sudo phpenmod sqlsrv pdo_sqlsrv
```

Restart the service:

```bash
sudo systemctl restart php7.2-fpm.service
```

Open the **/site/index.php** file and paste the contents of the **web/index.php** file from the accompanying files. Return to the **Azure Portal** and go to the SQL database. In the **Settings** section click on **Connection strings**. Switch to **PHP** and copy the connection string for SQL Server Extension (the second one). Paste it at the beginning of the file and enter the password for the database set during the creation process. Save and close the file.

```php
<h1>Top 10 cities in Bulgaria</h1>
<?php

	// SQL Server Extension Sample Code:
	$connectionInfo = array("UID" => "examsa", "pwd" => "ExamPassword2022", "Database" => "azesqldb", "LoginTimeout" => 30, "Encrypt" => 1, "TrustServerCertificate" => 0);
	$serverName = "tcp:azesql.database.windows.net,1433";
	$conn = sqlsrv_connect($serverName, $connectionInfo);

	if( $conn === false ) {
	     die( print_r( sqlsrv_errors(), true));
	}

	$stmt = sqlsrv_query( $conn, "SELECT * FROM Cities");

	if( $stmt === false ) {
	     die( print_r( sqlsrv_errors(), true));
	}

	print "<ol>\n";
	
	while( $row = sqlsrv_fetch_array( $stmt, SQLSRV_FETCH_ASSOC) ) {
	     echo "<li>".$row['CityName']." -> ".$row['Population']."</li>\n";
	}
	
	print "</ol>\n";
	
	print "<hr />\n";
	
	print "<small>Serverd by: ".gethostname()."</small>\n";
?>
```

## Deploy the application and all supplementary software (VM-BE-2)

Repeat all steps that you did on [VM-BE-1](#deploy-the-application-and-all-supplementary-software-vm-be-1) on VM-BE-2 as well.


## Test Deployed Application

Copy the **Public IP address** of the public load balancer. Open a browser tab and navigate to it but do not forget to add **/index.php** at the end. 

![image](https://user-images.githubusercontent.com/34960418/161595712-4a703bba-2247-46bd-b27f-21a172047b0d.png)

![image](https://user-images.githubusercontent.com/34960418/161595775-c1d6a5c7-45e4-4085-bf4d-37f88d9e9eb5.png)






# Three-tier architecture (CLI)

# AKS (Portal)
