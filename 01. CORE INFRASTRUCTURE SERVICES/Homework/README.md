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


Add Additional Disk:

```bash
az vm disk attach --vm-name VM-Ubuntu-20.04 --resource-group Homework --name VM-Ubuntu-20.04_Disk2 --size-gb 20 --sku Standard_LRS --new --output table
```

Connect to VM’s public IP address with ssh with:

```bash
ssh homeuser@20.123.151.220
```

Check what disks are available with:

```bash
lsblk
```

![image](https://user-images.githubusercontent.com/34960418/152348003-19f69bf3-c7b6-4460-8de4-517368584263.png)


Partition disk:

```bash
sudo fdisk /dev/sdc
```

![image](https://user-images.githubusercontent.com/34960418/152348192-7429bde4-916d-4aea-b2d8-6d937298053a.png)


Check again the situation with the disks:

```bash
lsblk
```

![image](https://user-images.githubusercontent.com/34960418/152348328-544a86de-cbde-4e3b-9168-cb4f614e5390.png)


Create a file system in the newly created partition there:

```bash
sudo mkfs.ext4 /dev/sdc1
```

Mount the disk:

```bash
sudo mkdir /disk
sudo mount /dev/sdc1 /disk
```

Check again the situation with the disks:

```bash
lsblk
```

![image](https://user-images.githubusercontent.com/34960418/152348678-2056ca99-8b0d-4905-bfd6-30a3fe876a43.png)


To make disk auto-mountable on reboot, change the **/etc/fstab** file

```bash
sudo nano /etc/fstab
```

![image](https://user-images.githubusercontent.com/34960418/152349108-b7c5df8e-41e3-411e-9c6a-32c2f535860c.png)


Test if everything with the **/etc/fstab** file is okay:

```bash
sudo mount -a
```

![image](https://user-images.githubusercontent.com/34960418/152349271-56f5a4d8-d8a9-4b80-921d-b9e34a1ee8fe.png)

Install the apache2 package

```bash
sudo apt update
sudo apt upgrade
sudo apt install apache2
```

Check with the systemd init system to make sure the service is running by typing:

```bash
sudo systemctl status apache2
```

![image](https://user-images.githubusercontent.com/34960418/152350134-ef470a85-8efd-4110-ad5c-efb3bd7baae6.png)


[Change listening port](https://www.digitalocean.com/community/tutorials/how-to-install-the-apache-web-server-on-ubuntu-20-04)

```bash
sudo nano /etc/apache2/ports.conf
```

![image](https://user-images.githubusercontent.com/34960418/152351092-8e0acba3-476a-4a1f-9f79-f1e9cc40bf7c.png)

```bash
sudo nano /etc/apache2/sites-enabled/000-default.conf
```

![image](https://user-images.githubusercontent.com/34960418/152351472-13df0836-51d2-46d4-9135-96a2944b6730.png)


Restart apache server
```bash
sudo systemctl restart apache2
```

Check that apache listens on port 8080

```bash
curl http://localhost:8080
```

![image](https://user-images.githubusercontent.com/34960418/152352103-fa26b563-5074-4e9a-ab64-8e5f36b9aa95.png)


Modify index page to include my SoftUni ID

```bash
sudo nano /var/www/html/index.html
```

![image](https://user-images.githubusercontent.com/34960418/152353407-dd54adaf-2b21-43ac-9b35-4b0842768678.png)


Return to host. 

```bash
exit
```

Open port 8080

```bash
az vm open-port --name VM-Ubuntu-20.04 --resource-group Homework --port 8080
```

The site must be reachable now. Test with:

```bash
curl http://20.123.151.220:8080
```

![image](https://user-images.githubusercontent.com/34960418/152354336-f05a0558-781a-4f08-9c72-364f0d38af2b.png)

