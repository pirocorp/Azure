# Overview

This guide aims to bring you on speed with the Ubuntu Linux distribution.

# Repository Command

Most Linux distributions use the repository approach to install software packages. Also is used to track the dependencies between packages. The package manager can have multiple repositories registered on a system. To refresh the information about the registered package catalogs (repositories), execute:

```bash
sudo apt-get update
```

Usually is done before installing or upgrading packages. To update all installed packages on the system,  execute:

```bash
sudo apt-get upgrade
```

To install a package, for example, the **NGINX** server,  execute:

```bash
sudo apt-get install nginx
```

* All above commands are prefixed with the **sudo**. It gives the user temporary superpowers required to alter the system’s state,  like software management, service management, hardware management, etc.

* Different Linux distributions may use different types of repositories with a different set of commands. Even package names, for the same software, may be different.



# Service Management Commands

The central system component manages services or background processes (also known as daemons). In Ubuntu, these services are managed by **SystemD**. To check the service status, for example, the **NGINX** service:

```bash
systemctl status nginx
```

To start service:

```bash
sudo systemctl start nginx
```

To stop service:

```bash
sudo systemctl stop nginx
```

To enable service to start automatically on boot:

```bash
sudo systemctl enable nginx
```

To prevent service to start on boot:

```bash
sudo systemctl disable nginx
```

* For the first command, no need to use the **sudo** command. Because when asking for information without changing something, typically don't need superpowers.

* Those commands apply to most Linux distributions because they use **SystemD**.



# Disk Management

Disk drives under **UNIX**-like operating systems are accessible via a pseudo-file system at **/dev**. Typically, if we have just one SATA hard disk drive in our system, it will be accessible via the **/dev/sda file**. The last letter (**a** in the given example) denotes the order of the device (**a** for the first, **b** for the second, etc.). Usually, the hard disk is split into one or more partitions. They are shown as numbers after the name of the disk. For example, the first partition of the first disk will be named **/dev/sda1**.

One way, to list all connected disk drives (or block devices) with their partitions is to use the **lsblk** command

![image](https://user-images.githubusercontent.com/34960418/151803821-99126aec-9bf6-45b6-a53d-3df6d6089fbf.png)

To manage the partitions of the third disk drive, execute:

```bash
sudo fdisk /dev/sdc
```

Linux distributions support many file systems. Two of the most popular ones are **EXT4** and **XFS**. To create an **EXT4** file system on the first partition of the third disk drive, execute: 

```bash
sudo mkfs.ext4 /dev/sdc1
```

The file system must be mounted to an empty folder before usage. To create a folder, execute:

```bash
sudo mkdir /data
```

To delete an empty folder, execute:

```
sudo rmdir /data
```

To mount a file system, for example the one created earlier, execute:

```bash
sudo mount /dev/sdc1 /data
```

To unmount a file system by its partition name, execute:

```bash
sudo umount /dev/sdc1
```

Or unmount it by its mount point, execute:

```bash
sudo umount /data
```

For automounting file system on boot, add a record to a file - **/etc/fstab**. Open the file with one of the popular text editors, for example:

```bash
sudo nano /etc/fstab
```

Add a line like the following:

```
/dev/sdc1      /data      ext4      defaults      0     0
```

A **good practice** is to test the file's correctness **before rebooting**. Do test with:

```bash
sudo mount -a
```

* Those commands apply to all **UNIX**-like operating systems
