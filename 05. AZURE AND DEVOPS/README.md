# [Azure Kubernetes Service](https://azure.microsoft.com/en-us/services/kubernetes-service/)

- Accelerate containerized application development
- Manage Kubernetes with ease
- Build on an enterprise-grade, more secure foundation
- Run any workload in the cloud, at the edge, or as a hybrid

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


## Masters

- Responsible for **managing** the cluster.
- Typically, **more than one** is installed.
- In HA mode one Master node is the **Leader**.
- It is **work-free**.
- Components running on master are also known as **Control Plane**.
- Can be reached via **CLI (kubectl)**, **APIs**, or **Dashboard**.

![image](https://user-images.githubusercontent.com/34960418/159252789-fc7cdbc8-480c-4c13-bddd-3dc20b1efd5d.png)


## (Worker) Nodes

- Initially called **Minions**
- **Container runtime**
    - containerd, rkt, lxd
- **Kubelet**
    - Communicates with master
    - Uses CRI shims
- **kube-proxy** 
    - Network proxy

![image](https://user-images.githubusercontent.com/34960418/159253096-2d448ccf-dc57-4501-b88f-80341c0b5fc1.png)


## Pods

- Smallest **unit of scheduling**.
- **One** or **more** containers.
- Containers **share** the pod **environment**.
- **Scheduled** on nodes.
- It is **atomic** – **deployed as one** and on **one node**.
- Created via **manifest files**.

![image](https://user-images.githubusercontent.com/34960418/159253400-925dc582-ae77-4967-9033-2b7287853072.png)

- Each pod has **unique IP** address.
- **Inter-pod** communication is via a **pod network**.
- **Intra-pod** communication is via **localhost** and **port**.

![image](https://user-images.githubusercontent.com/34960418/159253613-29f22d1f-b64d-432c-bec0-5079c029e139.png)


## Replication Controllers

- **Higher** level workload.
- Looks after **pod** or **set of pods**.
- **Scale** up/down **pods**.
- Sets **Desired State**.

![image](https://user-images.githubusercontent.com/34960418/159253974-1340c5cf-e9b2-49fe-8c8e-8063a5b4ff18.png)


## Deployments

- **Even higher** level workload.
- Simplifies **updates** and **rollbacks**.
- **Declarative** and **imperative** approach.
- Self **documenting**.
- Suitable for **versioning**.

![image](https://user-images.githubusercontent.com/34960418/159254292-b00f0bc2-9140-454f-9a33-2687e82dc995.png)


## Services

- Provide reliable network endpoint
  - **IP address**
  - **DNS name**
  - **Port**
- Expose Pods to the outside world
  - **NodePort** (cluster-wide port)
  - **LoadBalancer** (cloud-based)
- Use End Point object to track Pods

![image](https://user-images.githubusercontent.com/34960418/159254588-3bd11196-13cf-4a29-888a-125c59dbc627.png)


## Services in Action

![image](https://user-images.githubusercontent.com/34960418/159254828-615adde8-cdeb-4ca1-9232-7e5ccd7e3374.png)

![image](https://user-images.githubusercontent.com/34960418/159254922-49f6eb91-2084-4189-8896-69ee5a835517.png)

![image](https://user-images.githubusercontent.com/34960418/159254997-5c8ba0ad-b781-46ce-97a9-a9754997818e.png)

![image](https://user-images.githubusercontent.com/34960418/159255099-a9301524-8d39-42f9-ae88-be1c2a7dbe4f.png)



