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


Get information about the nodes

```bash
kubectl get nodes
```

![image](https://user-images.githubusercontent.com/34960418/160817023-200cf70d-cbad-482e-8e89-47bc54881c01.png)


Build docker image

```bash
docker build . -t aze-simple-app
```

![image](https://user-images.githubusercontent.com/34960418/160821862-ac25ae24-5f62-4d19-8a84-5ef179a4c851.png)
![image](https://user-images.githubusercontent.com/34960418/160822018-88e19b44-3ef1-4210-8a7a-93b531e2d034.png)


Test the app locally:

```bash
docker run -d --name webapp -p 8000:80 aze-simple-app
```

![image](https://user-images.githubusercontent.com/34960418/160822290-89ced656-bc52-47f6-b98b-34edc3fd31a0.png)

![image](https://user-images.githubusercontent.com/34960418/160822357-13e63899-3c2e-4fb7-a687-984b2e6fa308.png)


Login to the ACR (Azure Container Registry)

```bash
az acr login --name azesucli
```

![image](https://user-images.githubusercontent.com/34960418/160822763-ce175ffa-07a6-4ae3-8eaf-f402c8722832.png)


Check the login server

```bash
az acr list --resource-group RG-Homework --query "[].{acrLoginServer:loginServer}" --output table
```

![image](https://user-images.githubusercontent.com/34960418/160823028-e7086d2b-563f-4a0a-ae8e-da042d89df75.png)


Tag the image:

```bash
docker tag aze-simple-app azesucli.azurecr.io/aze-simple-app:v1
```

![image](https://user-images.githubusercontent.com/34960418/160823283-6a3e2d22-f92c-4cf9-a817-5e7fd60df766.png)


Push the image to our ACR

```bash
docker push azesucli.azurecr.io/aze-simple-app:v1
```

![image](https://user-images.githubusercontent.com/34960418/160823466-171a7730-51c3-47e3-b91f-4fa536b8d0e5.png)


Check the list of images available on our ACR

```bash
az acr repository list --name azesucli --output table
```

![image](https://user-images.githubusercontent.com/34960418/160823689-d0cf3850-bb23-49a1-abd8-dbabdf57bede.png)


And all tags for an image

```bash
az acr repository show-tags --name azesucli --repository aze-simple-app --output table
```

![image](https://user-images.githubusercontent.com/34960418/160823861-0dc336ac-16d6-4790-bd10-a0796b6ed744.png)


Validate the ACR is accessible from the AKS cluster.

```bash
az aks check-acr --name k8s-homework --resource-group RG-Homework --acr azesucli.azurecr.io
```

![image](https://user-images.githubusercontent.com/34960418/160824990-c2a5365e-8555-4b0a-97d4-6c0ca4d7dc56.png)


Integrate existing ACR with existing AKS cluster (if not done):

```bash
az aks update -n k8s-homework -g RG-Homework --attach-acr azesucli
```

