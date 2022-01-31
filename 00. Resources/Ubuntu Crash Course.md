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

* All above commands are prefixed with the **sudo**. It gives the user temporary super-powers required to alter the system’s state,  like software management, service management, hardware management, etc.

** Different Linux distributions may use different types of repositories with a different set of commands. Even package names, for the same software, may be different.
