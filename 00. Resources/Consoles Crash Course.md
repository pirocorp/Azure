# Consoles Crash Course

## CMD

- This is the classic command-line interface of Windows
- Usually, no Tab completion of commands and arguments
- Environment variables are declared and used like:

```cmd
set LOCATION=westeurope
set RESOURCE_GROUP=RG-Demo-CMD
az group create --name %RESOURCE_GROUP% --location %LOCATION% 
```

Individual lines in a multi-line command are separated with ```^```

```cmd
C:\> az group create --name %RESOURCE_GROUP% ^
More? --location %LOCATION%
```

## Bash

- Case sensitive shell available in most Unix-like OSes 
- Usually, tab completion is available
- Environment variables are declared and used like:

```bash
LOCATION=westeurope
RESOURCE_GROUP=RG-Demo-Bash
az group create --name $RESOURCE_GROUP --location $LOCATION 
```

Individual lines in a multi-line command are separated with ```\```

```bash
$ az group create --name $RESOURCE_GROUP \
>> --location $LOCATION
```

## PowerShell (Core)

- Case in-sensitive shell available in Windows, Linux, and macOS
- Usually, tab completion is available
- Environment variables are declared and used like:

```powershell
$LOCATION="westeurope"
$RESOURCE_GROUP="RG-Demo-PS"
New-AzResourceGroup -Name $RESOURCE_GROUP -Location $LOCATION
```
Individual lines in a multi-line command are separated with ``` ` ```

```powershell
PS C:\> New-AzResourceGroup -Name $RESOURCE_GROUP ` 
>> -Location $LOCATION
```
