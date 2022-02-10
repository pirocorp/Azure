# A virtual machine scale set with two Windows VMs, each with IIS installed and a custom index page. 

Start from [here](https://docs.microsoft.com/en-us/azure/virtual-machines/windows/tutorial-create-vmss).

## Create Resource Group

![image](https://user-images.githubusercontent.com/34960418/153445564-6707eb47-40ad-48d3-9b2c-2328eeaf839e.png)


## Virtual machines scale set

![image](https://user-images.githubusercontent.com/34960418/153451591-b4326603-0df5-46d8-8523-41439f37fefe.png)

![image](https://user-images.githubusercontent.com/34960418/153447770-d349b783-a83c-4d97-9c49-199f206a945b.png)

![image](https://user-images.githubusercontent.com/34960418/153447810-0411fc8e-84e7-4dc8-87db-1018322e62e9.png)

![image](https://user-images.githubusercontent.com/34960418/153448101-76f52770-66b0-4a2a-8687-f71783d78261.png)

![image](https://user-images.githubusercontent.com/34960418/153448216-291cf46b-6add-4a3e-8a27-6e323b8e830a.png)


### Enable IIS using RunCommand

1. Select the first VM in the list of Instances.
2. In the left menu, under Operations, select Run command. The Run command page will open.
3. Select RunPowerShellScript from the list of commands. The Run Command Script page will open.
4. Under PowerShell Script, paste in the following snippet:

```powershell
Add-WindowsFeature Web-Server
Set-Content -Path "C:\inetpub\wwwroot\Default.htm" -Value "Hello world from host $($env:computername) !"
```
5. When you are done, select Run. You will see the progress in the Output window.
6. Once the the script is complete on the first VM, you can select the X in the upper-right to close the page.
7. Go back to your list of scale set instances and use the Run command on each VM in the scale set.


![image](https://user-images.githubusercontent.com/34960418/153449249-18fdf0d8-13b5-4126-a421-f0f129b1f69b.png)


