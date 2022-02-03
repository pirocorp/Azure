# Homework

Utilizing what was discussed and shown during the lecture, try to do the following:
1.	Create an Ubuntu Server 20.04 based virtual machine using the B1s size or similar
2.	Add a second hard disk with 20 GB in size, format it with a file system (i.e. EXT4) and mount it
3.	Install Apache web server and make sure it is started and set to start automatically on boot
4.	Adjust the configuration of Apache to make it listen on port 8080 instead of port 80
5.	Make sure that the service is accessible from Internet
6.	Create a simple index.html page that displays your SoftUni ID 

# Soluttion

Before doing anything with Azure subscription from Azure CLI, log in first:

```bash
az login
```

Create the resource group

```bash
az group create --name Homework --location westeurope --output table
```

![image](https://user-images.githubusercontent.com/34960418/152345471-fcb61cf1-3144-4a52-bd5e-6fa48c90b20d.png)


Get all images for Ubuntu Server 20.04 based virtual machine.

```bash
az vm image list --publisher Canonical --offer 0001-com-ubuntu-server-focal --location westeurope --all --output table
```

![image](https://user-images.githubusercontent.com/34960418/152344264-fe86c7a6-bec4-4ca9-b2e9-eaa9831286ec.png)


Create VM:

```bash
az vm create --name VM-Ubuntu-20.04 --resource-group Homework --image Canonical:0001-com-ubuntu-server-focal:20_04-lts:latest --size Standard_B1s --admin-username homeuser --admin-password HomePassword-2022 --output table
```

![image](https://user-images.githubusercontent.com/34960418/152346487-685ebf89-50a5-4f31-85bc-2c1d621660e3.png)



