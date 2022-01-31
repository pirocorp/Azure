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

