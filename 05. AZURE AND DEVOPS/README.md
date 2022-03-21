# Azure Kubernetes Service

Container Orchestration

- Workload deployment and distribution
- Resource governance
- Scalability and availability
- Automatization and management
- Internal and external communication


What Kubernetes Does?

- **Run a cluster** of hosts.
- **Schedule containers** to run on different hosts.
- Facilitate the **communication between** the **containers**.
- Provide and control access to/from **outside world**.
- Track and optimize the **resource usage**.


## Architecture Overview

![image](https://user-images.githubusercontent.com/34960418/159252034-da006e4a-9599-4749-a898-59d5dfbcd660.png)


### Masters

- Responsible for **managing** the cluster.
- Typically, **more than one** is installed.
- In HA mode one Master node is the **Leader**.
- It is **work-free**.
- Components running on master are also known as **Control Plane**.
- Can be reached via **CLI (kubectl)**, **APIs**, or **Dashboard**.

![image](https://user-images.githubusercontent.com/34960418/159252789-fc7cdbc8-480c-4c13-bddd-3dc20b1efd5d.png)


### (Worker) Nodes

- Initially called **Minions**
- **Container runtime**
    - containerd, rkt, lxd
- **Kubelet**
    - Communicates with master
    - Uses CRI shims
- **kube-proxy** 
    - Network proxy

![image](https://user-images.githubusercontent.com/34960418/159253096-2d448ccf-dc57-4501-b88f-80341c0b5fc1.png)





