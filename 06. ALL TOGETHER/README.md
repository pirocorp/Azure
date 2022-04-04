# TOC

## Assignments

- [Implement three-tier architecture to host a PHP web application with SQL server database](#implement-three-tier-architecture-to-host-a-php-web-application-with-sql-server-database)
- [Implement AKS and deploy Azure Web App and 2 Azure Functions](#implement-aks-and-deploy-azure-web-app-and-2-azure-functions)


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
