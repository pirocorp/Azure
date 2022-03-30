# AKS task

- Create an AKS cluster with one node
- Prepare a simple web app (single static HTML page) with one picture (or whatever you decide) and a text with your SoftUni ID
- Create a Dockerfile to containerize the app
- Create an ACR and publish the app image there
- Create a manifest (or two) and deploy the app on the cluster

You may use the files and the steps from the practice to help yourself.

# DevOps task

- Create an AKS cluster with one node or reuse the one created earlier
- Publish the app created earlier in a code repository (for example in GitHub)
- Create a DevOps Starter project in Azure and deploy the app from the code repository to the AKS cluster


# AKS Solution

login into azure

```bash
az login
```

Create a resource group

```bash
az group create -n RG-Homework -l westeurope
```

![image](https://user-images.githubusercontent.com/34960418/160814494-e405c662-1218-4066-bfa4-639101ee1f45.png)


Create a container registry

```bash
az acr create -g RG-Homework -n azesucli --sku Basic
```

![image](https://user-images.githubusercontent.com/34960418/160814718-da705478-5e4c-4d4f-a525-5a696f998035.png)


Create the cluster

```bash
az aks create -g RG-Homework -n k8s-homework --node-count 1 --node-vm-size Standard_B2s --enable-addons monitoring --generate-ssh-keys --attach-acr azesucli
```

![image](https://user-images.githubusercontent.com/34960418/160816045-1b998831-99d9-45d6-9a6f-ae7446b978d4.png)


Get and store the credentials needed for communication with the cluster

```bash
az aks get-credentials --resource-group RG-Homework --name k8s-homework
```

![image](https://user-images.githubusercontent.com/34960418/160816392-0f181e02-8fdb-441e-8d3f-161a3a747460.png)


Check versions. Plus minus one minor version is ok.

```bash
kubectl version
```

![image](https://user-images.githubusercontent.com/34960418/160816589-950e2181-ce74-448f-91a6-789002aa2a39.png)


```bash
kubectl get nodes
```

![image](https://user-images.githubusercontent.com/34960418/160817023-200cf70d-cbad-482e-8e89-47bc54881c01.png)

