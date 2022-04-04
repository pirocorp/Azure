# TOC

## Assignments

- [Implement three-tier architecture to host a PHP web application with SQL server database](#implement-three-tier-architecture-to-host-a-php-web-application-with-sql-server-database)
- [Implement AKS and deploy Azure Web App and 2 Azure Functions](#implement-aks-and-deploy-azure-web-app-and-2-azure-functions)

## Solutions

- [Three-tier architecture (Portal)](#three-tier-architecture-portal)
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




# Three-tier architecture (CLI)

# AKS (Portal)
