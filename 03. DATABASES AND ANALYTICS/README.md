# TOC

- [Relational Databases (Azure SQL)](#relational-Databases-azure-SQL)
- [NoSQL Databases (Csomos DB)](#nosql-databases-cosmos-db)
  - [NoSQL Key-Value Type](#nosql-key-value-type)
  - [NoSQL Document Type](#nosql-document-type)
  - [NoSQL Column Store Type](#nosql-column-store-type)
  - [NoSQL Graph Type](#nosql-graph-type) 
  - [Azure Cosmos DB](#azure-cosmos-db)
- [Azure Analytics Services](#azure-analytics-services)
- [Azure Stream Analytics (ASA)](#azure-stream-analytics-asa)
  - [Tumbling Window](#tumbling-window)
  - [Hopping Window](#hopping-window)
  - [Sliding Window](#sliding-window)
  - [Session Window](#session-window)
  - [Snapshot Window](#snapshot-window)

# Jump to practical guides
- Azure SQL
  - [Azure SQL (Azure Portal)](#azure-sql-azure-portal)
    - [SQL Server](#sql-server)
    - [Create a database](#create-a-database)
    - [Database connectivity](#database-connectivity)
    - [Connect to a database with Query editor](#connect-to-a-database-with-query-editor)
    - [Connect to a database with SQL Server Management Studio (SSMS)](#connect-to-a-database-with-sql-server-management-studio-ssms)
    - [Restore a database](#restore-a-database)
  - [Azure SQL (Azure CLI)](#azure-sql-azure-cli)
    - [Create a database](#create-a-database-1)
  - [Azure SQL (Azure PowerShell)](#azure-sql-azure-powershell)
    - [Create a database](#create-a-database-2)
  - [Connect to database from the command line (sqlcmd)](#connect-to-database-from-the-command-line-sqlcmd)
- Cosmos DB
  - [Cosmos DB (Azure Portal)](#cosmos-db-azure-portal)
    - [Azure Cosmos DB account](#azure-cosmos-db-account)
    - [Database](#database)
    - [Work with data](#work-with-data)
  - [Cosmos DB (Azure CLI)](#cosmos-db-azure-cli)
    - [Create database](#create-database)
  - [Cosmos DB (Azure PowerShell)](#cosmos-db-azure-powershell)
    - [Inspect Cosmos DB (without Az.CosmosDB module)](#inspect-cosmos-db-without-azcosmosdb-module)
    - [Use the Az.CosmosDB module](#use-the-azcosmosdb-module)
  - [Import data from (from Azure SQL)](#import-data-from-from-azure-sql)
- [Azure Stream Analytics](#azure-stream-analytics)
  - [Resource group and storage account](#resource-group-and-storage-account)
  - [Storage preparation](#storage-preparation)
  - [Configure input and output for a stream analytics job](#configure-input-and-output-for-a-stream-analytics-job)
  - [Sample data](#sample-data)
  - [Adjust the data generation process](#adjust-the-data-generation-process)
  - [Start the job](#start-the-job)
  - [BLOB output](#blob-output)
  - [Job monitoring](#job-monitoring)
  - [Cleaning](#cleaning)


# [Relational Databases (Azure SQL)](https://azure.microsoft.com/en-us/product-categories/databases/)

RDBMS follow ACID rules:

- **Atomicity** – treats transactions as single units.
- **Consistency** – transactions bring DB from one valid state to another. Written data must be valid according to all rules.
- **Isolation** – concurrent execution of transactions leaves the DB in the same state as executed sequentially.
- **Durability** – committed transaction remains committed even in case of system failure.

Types of Offerings

![image](https://user-images.githubusercontent.com/34960418/153888078-c18046fb-7904-441d-9676-e3d5b7b34a1f.png)

## [Azure SQL](https://docs.microsoft.com/en-us/azure/sql-database/)

- **SQL Databases**
  - **Single Database** - fully managed, isolated database.
  - **Elastic Pool** - a collection of databases with a shared set of resources.
  - **Database Server** - groups of single databases and elastic pools.
- **SQL Managed Instances** - fully managed instance, easy migration.
- **SQL Virtual Machines** - full administrative control over SQL & OS. Option for Bring Your Own License (BYOL).

## [Purchasing Models](https://docs.microsoft.com/en-us/azure/sql-database/sql-database-purchase-models)

 - **vCore-based** - Choose the number of vCores, the amount of memory, and the amount and speed of storage.
 - **DTU-based** (DTU - Database Transaction Unit) - Offers a blend of computing, memory, and I/O resources in three service tiers.
 - **Serverless** - Automatically scales compute based on workload demand and bills for the amount of compute used per second.

## Service Tiers*

\***Basic**, **Standard**, and **Premium** are applicable for the DTU model.

### [General Purpose (Standard)](https://docs.microsoft.com/en-us/azure/azure-sql/database/service-tier-general-purpose)

Designed for common workloads. Offers budget-oriented balanced compute and storage options.

### [Business Critical (Premium)](https://docs.microsoft.com/en-us/azure/azure-sql/database/service-tier-business-critical)

Designed for OLTP applications with a high transaction rate and lowest-latency I/O. It offers the highest resilience to failures by using several isolated replicas.

### [Hyperscale](https://docs.microsoft.com/en-us/azure/azure-sql/database/service-tier-hyperscale)

Designed for a very large OLTP database. It offers the ability to auto-scale storage and scale compute fluidly.



# NoSQL Databases (Cosmos DB)

NoSQL = Not-only-SQL

RDBMS are hard to scale and there is need for unstructured data. NoSQL databases store unstructured data. Data is stored in a denormalized form.

Key features offered:
 - **Speed** – swift response usually the data is stored in memory.
 - **Scale** – easily scalable, following the ever-growing demand.
 - **Continuous availability** – redundant copies across multiple locations with no downtime.
 - **Location independence** – serve data quickly to multiple locations.


## NoSQL Key-Value Type

**NoSQL Key-Value** databases are a **collection of keys associated with values**. **Keys** are **strings**, and **values** are **BLOBs**. There is no query language, just simple commands (put, get, delete, update). Use Cases: Session tracking, shopping carts, etc. Examples: Redis, Cassandra, Memcached, Couchbase, etc.


## NoSQL Document Type

Similar to key-value DBs, **values** store **XML**, **JSON**, or **BSON**. They offer the storage of complex data like trees, collections, dictionaries. It doesn’t support relations and joins. No query language. Examples: MongoDB, CouchDB, OrientDB.


## NoSQL Column Store Type

**Store data in column families as rows**. Rows have many columns associated with them. Each row can have a different set of columns. Offer compression, aggregation queries, and scalability. They are fast to load and query. Examples: Cassandra, DynamoDB, Hbase.


## NoSQL Graph Type

Data is stored in the form of nodes and edges. Nodes are the data entries. Edges are the relationships between the data entries. Edges can have their properties and direction examples: Neo4J, FlockDB, OrientDB.


## [Azure Cosmos DB](https://docs.microsoft.com/en-us/azure/cosmos-db/introduction)

It is Microsoft’s NoSQL database solution. Cosmos DB supports **all four NoSQL models** offers multiple APIs. Some of the features include. **Global distribution** for highly responsive and highly available apps. **Elastic scalability** of throughput and storage. **Five consistency levels** ranging from **strong** to **eventual**.

![image](https://user-images.githubusercontent.com/34960418/153903202-a893ac8e-df2b-422c-bc20-0ec6f428f403.png)


### Azure Cosmos DB Supported APIs

![image](https://user-images.githubusercontent.com/34960418/153903508-e8e86e63-e03c-45a1-bb1a-611cf051e587.png)


### [Azure Cosmos DB SQL](https://docs.microsoft.com/en-us/azure/cosmos-db/sql-query-getting-started)

- Standard clauses
  - SELECT, FROM, WHERE, ORDER BY, GROUP BY
- Subqueries
- Joins
- Aggregate functions
  - COUNT, SUM, MIN, MAX, and AVG
- Many system functions
  - ABS, ROUND, TRUNC, CONCAT, LEFT, TRIM, UPPER, …


### [Azure Cosmos DB Request Units (RUs)](https://docs.microsoft.com/en-us/azure/cosmos-db/request-units)

**Serverless** or **Provisioned Throughput** Modes. **Throughput** is provisioned in increments of **100 RUs / sec**. Throughput can be set on **Container** and **Database** level. 1 RU = **single 1 KB item read**. 

![image](https://user-images.githubusercontent.com/34960418/153904865-41f50279-af2b-45b6-bc91-449408655dd7.png)


### [Azure Cosmos DB Hierarchy](https://docs.microsoft.com/en-us/azure/cosmos-db/databases-containers-items)

![image](https://user-images.githubusercontent.com/34960418/153905090-cb7dc452-0a81-437b-bdd2-a180fa44858c.png)



# Azure Analytics Services

They are a broad and essential set of services. Typically, those are complex services that depend on others. 

Types of Azure Analytics Services
- Azure Synapse Analytics (formerly SQL Data Warehouse)
- Azure Databricks
- HDInsight clusters
- PowerBI Embedded
- Stream Analytics jobs


# [Azure Stream Analytics (ASA)](https://docs.microsoft.com/en-us/azure/stream-analytics/stream-analytics-introduction)

Azure Stream Analytics (ASA) is **real-time analytics** and complex **event-processing** engine. ASAs are designed to simultaneously **analyze** and **process** high volumes of fast streaming data from **multiple sources**. Sources include devices, sensors, clickstreams, social media feeds, and applications. Can identify **patterns** and **relationships**. Uses findings to **trigger actions** and **initiate workflows**. Supports **alerts**, feeding information to a **reporting tool** or **storing** transformed data for later use.

![image](https://user-images.githubusercontent.com/34960418/153907705-dc52812c-98ce-4390-b8b0-e17e414ac4ef.png)


## [Streaming Units (SUs)](https://docs.microsoft.com/en-us/azure/stream-analytics/stream-analytics-streaming-unit-consumption)

![image](https://user-images.githubusercontent.com/34960418/153907817-8089637f-ec8d-4b29-9d4d-9f52e2616a06.png)


## [Azure Stream Analytics Query Language](https://docs.microsoft.com/en-us/stream-analytics-query/stream-analytics-query-language-reference)

- Standard clauses
  - SELECT, FROM, WHERE, GROUP BY, etc.
- Built-in functions
  - COUNT, SUM, MIN, MAX, AVG, etc.
- Time management
- Windowing


## [Windowing](https://docs.microsoft.com/en-us/stream-analytics-query/windowing-azure-stream-analytics)

In real-time events processing, it is common to perform some **set-based computation** (aggregation) or other operations **over subsets of events** that fall **within some period of time**. In Azure Stream Analytics, these subsets of events are defined through **windows** to represent groupings by time. There are five types of windows:

- Tumbling
- Hopping
- Sliding
- Session
- Snapshot


## [Tumbling Window](https://docs.microsoft.com/en-us/stream-analytics-query/tumbling-window-azure-stream-analytics)

![image](https://user-images.githubusercontent.com/34960418/153909625-65091be4-9789-46e9-88fd-497f34797886.png)


## [Hopping Window](https://docs.microsoft.com/en-us/stream-analytics-query/hopping-window-azure-stream-analytics)

![image](https://user-images.githubusercontent.com/34960418/153909773-ed7f9e2b-2b41-4468-9ad1-bf7bd7d1586b.png)


## [Sliding Window](https://docs.microsoft.com/en-us/stream-analytics-query/sliding-window-azure-stream-analytics)

![image](https://user-images.githubusercontent.com/34960418/153909945-e0fcf83c-2065-4975-8407-f00d17f267d9.png)


## [Session Window](https://docs.microsoft.com/en-us/stream-analytics-query/session-window-azure-stream-analytics)

![image](https://user-images.githubusercontent.com/34960418/153910069-93010b01-e7e3-46b7-b25b-80c28ba87c25.png)


## [Snapshot Window](https://docs.microsoft.com/en-us/stream-analytics-query/snapshot-window-azure-stream-analytics)

![image](https://user-images.githubusercontent.com/34960418/153910198-54494bca-254a-456c-852c-c03c683f886e.png)



# Azure SQL (Azure Portal)

## Resource group

Navigate to the **resource groups** section. Create a new resource group, for example, **RG-SQL** in the **West Europe** region. Enter the resource group.

![image](https://user-images.githubusercontent.com/34960418/154043635-68959318-cc20-4d7f-9ba9-b085fe33df00.png)


## SQL Server

In the resource group, click on the **+ Create** button to add a new resource. Enter **Azure SQL** and hit the **Enter** key in the search field. Click on the **Create** button.

![image](https://user-images.githubusercontent.com/34960418/154044146-04ea6cb7-1b73-48c3-9a24-f02bea66bcda.png)


In the drop-down menu **Resource type** of the **SQL databases** section select **Database server**. Click on the **Create** button.

![image](https://user-images.githubusercontent.com/34960418/154047834-170197d6-875a-4fc7-b804-ac20aa28f3cc.png)


Ensure both fields **Subscription** and **Resource group** are filled appropriately. Enter a globally unique name in the **Server name** field to become part of an URL. Adjust the Location to your liking, for example, **West Europe**. In the Server admin login enter something different from **sa**, **root**, **admin**, etc. for example **demosa**. For a password, choose between **8** and **128** characters, for example, **DemoPassword-2022**. Click on **Review + create** button. Finally, click on the **Create** button. After a while, we will have our new SQL Server ready. Once the deployment is done, click on the **Go to resource** button.

![image](https://user-images.githubusercontent.com/34960418/154048527-2af88512-02ba-4537-954d-ee66e2c76205.png)


## Create a database

Click on the **+ Create database** button. 

![image](https://user-images.githubusercontent.com/34960418/154049797-c34f7910-d916-4e22-ad89-08085f70fcfe.png)


In the **Database name** field enter for example **db1**. Click on **Configure database**.

![image](https://user-images.githubusercontent.com/34960418/154050407-f5fbb3db-b6ac-4962-bd5f-21fb374e31f8.png)

Select the **Basic** plan and click on **Apply**.

![image](https://user-images.githubusercontent.com/34960418/154050237-9daf0590-c9f3-46e3-ade6-a111c666e25d.png)


Select **Locally-redundant backup storage**, and click on the **Next: Networking** button. Then click on the **Next: Security** button. Click on the **Next: Additional settings** button.

![image](https://user-images.githubusercontent.com/34960418/154050657-ee47db2b-83fa-419c-8ebe-d78b92c65022.png)

Change the **Use existing data** to **Sample**. It will load the **AdventureWorksLT** sample database. Click on the **Review + create** button. Click on **Create** to create the database.

![image](https://user-images.githubusercontent.com/34960418/154051380-648dbba3-10bc-4124-9c7d-4bd356202c53.png)

After a while, the new database will appear in the bottom table of the **Overview** screen.

![image](https://user-images.githubusercontent.com/34960418/154052128-e2e1f6f8-3c4a-4d6e-b48d-5e7aa442ece4.png)


## Database connectivity

Make sure that you are in the **Overview** screen of the **database server**. Click on the **Firewall and virtual networks** option in the **Security** section. You can turn on the **Allow Azure services and resource to access this server** option. Click on the **+ Add client IP** button to allow tools on your station to access the databases on the server. Don’t forget to click on the **Save** button. Then click **OK**.

![image](https://user-images.githubusercontent.com/34960418/154053151-19f3b513-902d-42af-9acb-8701fcad0d06.png)


## Connect to a database with Query editor

Click on the **SQL databases** option under the **Settings** section. Select the **DB1** database.

![image](https://user-images.githubusercontent.com/34960418/154054426-be3e9ff7-95e4-4d61-a6b2-f0f7eb4975fa.png)


Click on the **Query editor (preview)** option. Ensure that you enter the correct values in the **Login** and **Password** fields. Click **OK**.

![image](https://user-images.githubusercontent.com/34960418/154054906-b7fe5916-c8cf-410f-b4d1-3ec7522e764a.png)


Test some queries.

![image](https://user-images.githubusercontent.com/34960418/154055718-02edc71c-64eb-4b9b-97ff-892112f04f70.png)


## Connect to a database with SQL Server Management Studio (SSMS)

Click on the **Connection strings** option under the **Settings** section. There are several prepared connection strings. Click on the **ADO.NET** and then explore the others as well. And copy the **server name** and the **port** (from the **ADO.NET** section). It should be something like ```pirocorp.database.windows.net,1433```

![image](https://user-images.githubusercontent.com/34960418/154056185-f0630457-2cc2-4d64-a994-3dbe7970fd3f.png)


Open the **SSMS** tool. Paste the copied string in the **Server name** section. In the **Login** field enter a valid user and the corresponding password. Click on the **Connect** button. 

![image](https://user-images.githubusercontent.com/34960418/154056860-ab462684-fdec-4879-aadb-07f6be8a6508.png)


Execute some SQL queries

![image](https://user-images.githubusercontent.com/34960418/154057054-b8012377-faf3-46d6-8716-8143fb2af5be.png)


## Restore a database

Return to the **Azure Portal**. Navigate to the **Overview** of the **SQL servers**. Click on the **Import database** button. 

![image](https://user-images.githubusercontent.com/34960418/154057536-b18fd5ce-c10c-437b-b71b-3745f835391e.png)


Click on **Select backup** in the **Storage** section. 

![image](https://user-images.githubusercontent.com/34960418/154057841-a68b9d82-d133-4954-8304-a7729cfa63ff.png)


Select an existing storage account. If you do not see one, go and create, then return back here. 

![image](https://user-images.githubusercontent.com/34960418/154058599-843de533-3219-4dad-8d93-a8a2c7a87563.png)


Click on **+ Container**.

![image](https://user-images.githubusercontent.com/34960418/154058696-cbded88a-62f2-47c6-bff5-8980ba8cf5e5.png)


For Name enter **db1** and click **Create**

![image](https://user-images.githubusercontent.com/34960418/154058843-6e682bfc-7439-491d-8739-3962662afe4d.png)


Click on the new container.

![image](https://user-images.githubusercontent.com/34960418/154058919-55f2de22-266f-4e1c-adfa-ac0ca6e87c03.png)


Click on the **Upload** button. Select the database **bacpac** file and click **Upload**.

![image](https://user-images.githubusercontent.com/34960418/154058990-7c78eb60-479d-4e4f-bf8b-d5c8ed177799.png)


Select the uploaded export and click on the **Select** button.

![image](https://user-images.githubusercontent.com/34960418/154059242-8ccb8019-329e-4213-b1c7-3930239f3b93.png)


Click on the **Pricing tier** to select a different one.

![image](https://user-images.githubusercontent.com/34960418/154059459-b0264f1b-df19-4235-87f5-05374ba87fc6.png)


Select **Basic** and confirm with **Apply**. Adjust the **collation** if needed. Enter the credentials and click **OK**.

![image](https://user-images.githubusercontent.com/34960418/154059769-f81bc0b3-d641-4866-80d2-8517cb288c10.png)


Once the process finishes, you can go to the database and query its data.

![image](https://user-images.githubusercontent.com/34960418/154060259-2a2ba0a5-34b2-41cd-86b2-a56331add8d4.png)

![image](https://user-images.githubusercontent.com/34960418/154061382-0343bb21-5f36-414c-ac00-38ab0c391a48.png)


# Azure SQL (Azure CLI)

## Create a database

If using local shell, login first by issuing:

```bash
az login
```

First, let’s set a few default values in order to shorten our commands. We will set the region and the SQL server:

```bash
az configure --defaults group=RG-SQL sql-server=pirocorp
```


Now, list the existing databases:

```bash
az sql db list --output table
```

![image](https://user-images.githubusercontent.com/34960418/154061993-a1e8e776-2a14-4b8c-a8fd-2eab06969230.png)

Create database with:

```bash
az sql db create --name DBCLI --edition Basic --capacity 5 --output table
```

![image](https://user-images.githubusercontent.com/34960418/154062269-0b76cc43-8fd3-4f62-97fe-46f4aa8aabe0.png)


# Azure SQL (Azure PowerShell)

## Create a database

If not working in **Azure Cloud Shell**, then first login

```powershell
Connect-AzAccount
```

For the SQL server

```powershell
Get-Command *pirocorp*
```

For the SQL databases:

```powershell
Get-Command *pirocorpdatabase*
```

List all existing databases:

```powershell
Get-AzSqlDatabase -ServerName pirocorp -ResourceGroupName RG-SQL | Format-Table
```

![image](https://user-images.githubusercontent.com/34960418/154063435-52677056-5251-4f34-a051-1df3ba25a441.png)


Create new database with:

```powershell
New-AzSqlDatabase -DatabaseName DBPS -ResourceGroupName RG-SQL -ServerName pirocorp -Edition Basic
```

![image](https://user-images.githubusercontent.com/34960418/154064002-845e4c0a-20a9-4a0d-8da8-132f543b8fd3.png)


# Connect to database from the command line (sqlcmd)

With the help of Azure CLI we can get a connection string for a particular database:

```bash
az sql db show-connection-string --client sqlcmd --name BGCities
```

![image](https://user-images.githubusercontent.com/34960418/154064732-d192dba9-7cb5-48ac-be35-5fc63f8053b4.png)


Connect with the help of the sqlcmd tool using the provided connection string:

```bash
sqlcmd -S tcp:pirocorp.database.windows.net,1433 -d BGCities -U demosa -P DemoPassword-2022 -N -l 30
```

![image](https://user-images.githubusercontent.com/34960418/154065023-d8299551-fff5-491e-ac64-efd74dc8dbe0.png)


ask for the version of the database:

```sqlcmd
SELECT @@version;
GO
```

![image](https://user-images.githubusercontent.com/34960418/154065167-c40c20f6-9617-4c03-9eb7-44d7958077a9.png)


Change the database to BGCities:

```sqlcmd
USE BGCities;
GO
```

![image](https://user-images.githubusercontent.com/34960418/154065280-40ed3301-0504-4a9a-9271-d53441227654.png)


Ask for the list of top cities:

```sqlcmd
SELECT * FROM TopCities;
GO
```

![image](https://user-images.githubusercontent.com/34960418/154065424-9b73f42e-dfdf-4ca9-8465-7159e8c42947.png)


Close the session with:

```sqlcmd
QUIT
```


# Cosmos DB (Azure Portal)

Navigate to [Azure Portal](https://portal.azure.com)


## Resource group

Search for resource groups. Click on **+ Create** to create a new resource group. For **Resource group**, set **RG-CosmosDB**. Select the region to be **West Europe**. Click on **Review + create**. Then on **Create**.

![image](https://user-images.githubusercontent.com/34960418/154066344-4b396ea2-a1b4-4199-a933-737f40337fec.png)


## Azure Cosmos DB account

Go to the resource group. Click on the **+ Create** button to create new resource. Search for **Azure Cosmos DB** and hit **Enter**. Click on the **Create** button.

![image](https://user-images.githubusercontent.com/34960418/154066668-557277cc-0fc3-4fd4-b956-4faff34147c2.png)


Select the Core (SQL) and click on the **Create** button for the API.

![image](https://user-images.githubusercontent.com/34960418/154066974-8d868257-1c96-4e98-85a6-1ddd6c8eb01d.png)


Change the **Location** to **West Europe**. In the **Account Name** field, enter a globally unique name, for example, **azecos**. Accept the default values for all other parameters. Click on **Review + create**. Click on **Create**.

![image](https://user-images.githubusercontent.com/34960418/154067818-2caed596-51ba-4228-8f8c-e5898cbb3eac.png)


Once the deployment is done, click on the **Go to resource** button.


## Database

While in the Overview section, click on the **+ Add Container** button

![image](https://user-images.githubusercontent.com/34960418/154068574-c72345f7-98a2-444c-b8ab-7ef5c48d4d0c.png)


Click on the **New Container** button.

![image](https://user-images.githubusercontent.com/34960418/154068700-67a4ddd8-8ab8-4205-a31d-cca8d231779b.png)


For **Database id** enter **TimeTracker**. Explore the provisioning options. Either accept the provisioning options with their default values or adjust them. For **Container id** enter **TimeSlots**. In the **Partition key** enter **/category**. Click **OK**.

![image](https://user-images.githubusercontent.com/34960418/154069169-1eb12cf0-141b-4b2b-b493-7011c6a2b79f.png)


## Work with data

Expand the **TimeSlots** container and click on **Items** option. Then click on the **New Item** button. Add the following text and click on the **Save** button.

```json
{
	"id": "1",
	"category": "personal", 
	"description": "Bathroom activities",
	"startedOn": "2019-12-09 07:30:00", 
	"slotLength": "900"
}
```

![image](https://user-images.githubusercontent.com/34960418/154069790-a47d2335-2011-4876-ba1e-8a81e23c48f9.png)


Repeat the procedure with another two records.

```json
{
	"id": "2",
	"category": "personal", 
	"description": "Breakfast",
	"startedOn": "2019-12-09 07:45:00", 
	"slotLength": "900"
},
{
	"id": "3",
	"category": "business", 
	"description": "Check and answer all pending messages",
	"startedOn": "2019-12-09 08:00:00", 
	"slotLength": "600"
}
```

Note that there is a query. Let’s edit it. Click on the **Edit Filter**. Enter ```WHERE c.category = "business"``` and click on the **Apply Filter** button.

![image](https://user-images.githubusercontent.com/34960418/154079551-374b5fff-2c88-4540-b123-c692091d9787.png)


Click on the **New SQL Query** button. 

![image](https://user-images.githubusercontent.com/34960418/154079784-0969f062-03f7-4842-9438-9b8eb661d172.png)



New window will open with a prepopulated query. Click on the **Execute Query** button. On the tab Results you can see the output and on the tab Query Stats you can explore what it took to execute it

![image](https://user-images.githubusercontent.com/34960418/154080001-00f69403-f0fe-475c-af03-7cd8e648deae.png)


On the tab **Results** you can see the output and on the tab **Query Stats** you can explore what it took to execute it.

![image](https://user-images.githubusercontent.com/34960418/154080373-e49c6af0-7c8b-4166-8485-7a309bbe8db3.png)

Test with another query. Click on the **Execute Query** button to see the results.

```sql
SELECT c.category, COUNT(c.id) AS slotsCount FROM TimeSlots c GROUP BY c.category
```

![image](https://user-images.githubusercontent.com/34960418/154080694-7a413aee-459b-4237-8578-eca23e23aed4.png)



# Cosmos DB (Azure CLI)

If using local shell, login first by issuing:

```bash
az login
```

## Create database

List all databases:

```bash
az cosmosdb sql database list --account-name azecos --resource-group RG-CosmosDB --output table
```

![image](https://user-images.githubusercontent.com/34960418/154082539-a1fe8bdf-6ff8-4691-bb0d-3eb0686d1cb1.png)


Create new database:

```bash
az cosmosdb sql database create --account-name azecos --resource-group RG-CosmosDB --name AZDB
```

![image](https://user-images.githubusercontent.com/34960418/154082886-37860686-0977-45ef-b35e-7aee7d1c02fb.png)


And a container for storing people partitioned by city:

```bash
az cosmosdb sql container create --account-name azecos --resource-group RG-CosmosDB --database-name AZDB --name People --partition-key-path /city --throughput 400
```


# Cosmos DB (Azure PowerShell)

If not working in **Azure Cloud Shell**, then first login:

```bash
Connect-AzAccount
```

## Inspect Cosmos DB (without Az.CosmosDB module)

Here the situation is a little bit more complex. Because of the lack of specialized commands, must pass everything through the Resource object. For example, to list all databases must execute:

```powershell
Get-AzResource -ResourceType Microsoft.DocumentDB/databaseAccounts/apis/databases `
-ApiVersion "2015-04-08" -ResourceGroupName "RG-CosmosDB" -Name "azecos/sql/" | Format-Table
```

![image](https://user-images.githubusercontent.com/34960418/154084717-d4851fc0-db4e-4e14-b909-9a8365bae505.png)


To show information for a particular database, execute:

```powershell
Get-AzResource -ResourceType Microsoft.DocumentDB/databaseAccounts/apis/databases `
-ApiVersion "2015-04-08" -ResourceGroupName "RG-CosmosDB" -Name "azecos/sql/TimeTracker"
```

![image](https://user-images.githubusercontent.com/34960418/154084895-ae422105-dcbc-4619-9a44-62b981ebb34e.png)


For all information, execute:

```powershell
Get-AzResource -ResourceType Microsoft.DocumentDB/databaseAccounts/apis/databases `
-ApiVersion "2015-04-08" -ResourceGroupName "RG-CosmosDB" -Name "azecos/sql/TimeTracker" `
| Select *
```

![image](https://user-images.githubusercontent.com/34960418/154085222-8a4d1459-2b5b-4f5c-8870-1b4d3311ce8c.png)


For all containers in a database, execute:

```powershell
Get-AzResource -ResourceType Microsoft.DocumentDB/databaseAccounts/apis/databases/containers `
-ApiVersion "2015-04-08" -ResourceGroupName "RG-CosmosDB" -Name "azecos/sql/TimeTracker"
```

![image](https://user-images.githubusercontent.com/34960418/154085663-262d6c79-7569-4480-b415-4bfb5905eaaf.png)


Retrieve information for a container in a database via:

```powershell
Get-AzResource -ResourceType Microsoft.DocumentDB/databaseAccounts/apis/databases/containers `
-ApiVersion "2015-04-08" -ResourceGroupName "RG-CosmosDB" `
-Name "azecos/sql/TimeTracker/TimeSlots" | Select *
```

![image](https://user-images.githubusercontent.com/34960418/154085956-022e93f4-9618-43ed-b5a9-79faf4ff1e75.png)


## Use the Az.CosmosDB module

If you do not have it installed, you can do it with:

```powershell
Install-Module -Name Az.CosmosDB
```

List all Azure CosmosDB accounts in a resource group we can execute

```powershell
Get-AzCosmosDBAccount -ResourceGroupName RG-CosmosDB
```

![image](https://user-images.githubusercontent.com/34960418/154086640-733254a5-b98d-4b2a-8c51-6b1b1cecdc3f.png)


The properties of a CosmosDB account can be seen with:

```powershell
Get-AzCosmosDBAccount -ResourceGroupName RG-CosmosDB -Name azecos
```

![image](https://user-images.githubusercontent.com/34960418/154086895-a9e68ba2-0957-473f-863e-b94a61083ca0.png)


List account keys with:

```powershell
Get-AzCosmosDBAccountKey -ResourceGroupName RG-CosmosDB -Name azecos -Type "Keys"
```

![image](https://user-images.githubusercontent.com/34960418/154087068-85094ec2-5ec3-4a0b-8048-b863ae173aeb.png)


And all connection strings with:

```powershell
Get-AzCosmosDBAccountKey -ResourceGroupName RG-CosmosDB -Name azecos -Type "ConnectionStrings"
```

![image](https://user-images.githubusercontent.com/34960418/154087430-76e16e3f-7ffc-4c64-bcce-a7c821e80638.png)


A list of all databases in an account can be retrieved with:

```powershell
Get-AzCosmosDBSqlDatabase -ResourceGroupName RG-CosmosDB -AccountName azecos
```

![image](https://user-images.githubusercontent.com/34960418/154087615-b7cf126e-bb57-408c-8068-46c8fed238f6.png)


Create a new database with:

```powershell
New-AzCosmosDBSqlDatabase -ResourceGroupName RG-CosmosDB -AccountName azecos -Name PSDB -Throughput 400
```

![image](https://user-images.githubusercontent.com/34960418/154087900-c1d9a762-9137-4296-9231-ed89f4b1a438.png)


And finally, a container (collection):

```powershell
New-AzCosmosDBSqlContainer -ResourceGroupName RG-CosmosDB -AccountName azecos -DatabaseName PSDB -Name Cities -PartitionKeyKind Hash -PartitionKeyPath "/cityname" -Throughput 400
```

![image](https://user-images.githubusercontent.com/34960418/154088314-a0767b1a-edf4-44bb-a809-03e026d2960e.png)


List all containers in a database with:

```powershell
Get-AzCosmosDBSqlContainer -ResourceGroupName RG-CosmosDB -AccountName azecos -DatabaseName PSDB
```

![image](https://user-images.githubusercontent.com/34960418/154088714-a0063e05-0b8d-4add-885a-484c6a3bb97c.png)


## Import data from (from Azure SQL)

Use [Azure Cosmos DB Data Migration tool](https://docs.microsoft.com/en-us/azure/cosmos-db/import-data#Install). 


Extract it to a folder of your choice. The tool supports command line mode and graphics mode. Let’s go with the second option. Navigate to the folder and double-click over **dtui.exe**. On the **Welcome** screen, click the **Next** button.

![image](https://user-images.githubusercontent.com/34960418/154090274-377c03b8-b9a1-4ec6-b402-f1aabdaecf9c.png)


Change the **Import from** selected value to **SQL**. Return to the **Azure Portal**, go to the **Azure SQL server**, and then to **SQL databases**. Click on the one that we will export. Let’s select the **BGCities** one.

![image](https://user-images.githubusercontent.com/34960418/154090831-28dd328e-a65f-4bea-8843-c8b05700850b.png)


Go to the **Connection strings** option under the **Settings** section. Copy the connection string for the **ADO.NET**.

![image](https://user-images.githubusercontent.com/34960418/154091308-8c79acaa-212f-4235-b3c9-f3cf4c67fb77.png)


Paste it in the **Connection String** field of the **Data Migration Tool**. Don’t forget to substitute the {your_password} with the appropriate password, for example **DemoPassword-2022**. Click on the **Verify** button to test the connectivity.


![image](https://user-images.githubusercontent.com/34960418/154091661-b2e0690c-91fb-4793-b158-3a48950979ad.png)


Select the **Enter Query** option and paste the following SQL statement and click on **Next** button.

```sql
SELECT CityName, Population FROM TopCities
```

![image](https://user-images.githubusercontent.com/34960418/154091875-a970cf98-cffc-4dd9-8017-5486c20d9432.png)


Make sure that **Azure Cosmos DB – Sequential record import (partitioned collection)** is selected under **Export to**. 

![image](https://user-images.githubusercontent.com/34960418/154092210-a21e86a6-fc0b-45f5-b7f6-4c9bc2f43c05.png)


Return to the **Azure Portal**, go to the **Azure Cosmos DB**, select the **azecos** database account. Click on the **Keys** option under the **Settings** section. Copy the **PRIMARY CONNECTION STRING** value.

![image](https://user-images.githubusercontent.com/34960418/154092711-2ad6ac88-23c3-4967-aba3-f4bc09fde885.png)


Return to the **Data Migration Tool** and paste the value to the **Connection** field. At the end add **Database=AZDB** or **PSDB** or another one. Click on the **Verify** button to check the connectivity.

![image](https://user-images.githubusercontent.com/34960418/154093226-78687b38-adc5-49b7-b79e-9913ce1cb694.png)


Type **TopCities** in the **Collection** field. Enter **/CityName** as a **Partition Key**. Set **Collection Throughput** to **400**. Click on **Next**. Click again **Next**.

![image](https://user-images.githubusercontent.com/34960418/154093544-8a2474e3-4666-4d1b-aa5d-c65789e7043c.png)


Click **Import** to start the process.

![image](https://user-images.githubusercontent.com/34960418/154093793-4e2f057a-cb9c-49f7-b665-8ba1bf9199e8.png)


Once the import is complete, close the application and return to the **Azure Portal**. Go to the **Azure Cosmos DB**and select the **azecos** database. Navigate to the **Data Explorer** option. You should click on the database used during the import process and the **TopCities** container under it. Expand **TopCities** and click on **Items**. You should see the list of Bulgaria's top 10 cities by population.

![image](https://user-images.githubusercontent.com/34960418/154094521-7f2d673f-118e-4032-85d8-e7cae97483bf.png)



# Azure Stream Analytics

Navigate to [Azure Portal](https://portal.azure.com). 


## Resource group and storage account

Create a new resource group, for example **RG-Stream-Analytics** in the **West Europe** region. Enter the resource group. 

![image](https://user-images.githubusercontent.com/34960418/154246723-18dfb99f-904b-4c12-87c6-082a750b45c0.png)


Create a new storage account in the same resource group. During creation process you can leave most of or all the parameters with their default values. For example, you may want to change the Replication to **Locally redundant storage (LRS)** to achieve lower price

![image](https://user-images.githubusercontent.com/34960418/154247109-935ad57f-b485-433b-8f8b-8a4836f46a88.png)


## Storage preparation

Go to the storage account, you created. Click on **Containers** option in the **Data storage** section. Click on the **+ Container** button to create a new one. In the **Name** field enter **demo** and click **Create**.

![image](https://user-images.githubusercontent.com/34960418/154247880-667a79b6-d4c5-472b-8941-f721043f9fb5.png)


## Create a stream analytics job

Enter in the search bar **stream analytics** text and press **Enter**. Then, click on the **+ Create** button. 

![image](https://user-images.githubusercontent.com/34960418/154248285-41693a45-1685-4738-a45f-721c451955a1.png)


For **Job name** use **SimpleStreamAnalyticsJob**. Make sure that the resource group is set to the one created earlier. Change the **Streaming units** to **1**. Click on the **Create** button. 

![image](https://user-images.githubusercontent.com/34960418/154248644-5ae98522-3c49-46d8-a153-41dfdef570a1.png)


## Configure input and output for a stream analytics job

Navigate back to the resource group. In the **Overview** section click on the **SimpleStreamAnalyticsJob** item. Click on the **Inputs** option in the **Job topology** section. Select **+ Add stream input** to create new input stream. In the drop-down list choose **Blob storage/ADLS Gen2\***

* ADLS stands for Azure Data Lake Storage

![image](https://user-images.githubusercontent.com/34960418/154249261-2d0fbb9e-643a-46cd-9ce5-0f11f7af3ad6.png)


For **Input alias** enter **StreamIn**. Ensure that the **Subscription** and the **Storage account** are correctly set. Under the **Container** select **Use existing**. Select the **blob container** that you created earlier. For example, **demo**. Switch the **Authentication mode** to **Connection string**. In the **Path pattern** field enter **input/**. Click on the **Save** button.

![image](https://user-images.githubusercontent.com/34960418/154249883-5f410fb7-d97e-4e2b-b6b7-8141dbf86c00.png)


Configure the output stream. Click on the **Outputs** command in the **Job topology** section. Click on the **+ Add** button. In the drop-down menu select **Blob storage/ADLS Gen2**

![image](https://user-images.githubusercontent.com/34960418/154250382-7754c100-1975-4138-84fc-fa3453d89607.png)


For **Output alias** enter **StreamOut**. Pay attention to the **Subscription** and **Storage account** settings. In the **Container** section select **Use existing**. Select the **demo** container from the drop-down list. Switch the **Authentication mode** to **Connection string**. Enter **output/** in the **Path pattern** field. Click on **Save**

![image](https://user-images.githubusercontent.com/34960418/154250941-4b0d150f-11e1-4350-acf3-8c887e324bca.png)


## Sample data

Using the **Azure Portal** or the **Microsoft Azure Storage Explorer** application upload the** sensor-sample.json** file in a folder **input/** in the **demo** container.

sensor-sample.json:

```json
{ "Sensor" : "S001", "Measurement" : { "Index" : 1, "Taken" : "2019-01-01T10:52:09.2Z", "Value" : 75.299 } }
```

![image](https://user-images.githubusercontent.com/34960418/154251868-fad13d89-152b-4d7d-a15b-d4f84a150439.png)

![image](https://user-images.githubusercontent.com/34960418/154252624-ac817de7-2903-4c35-be59-c081d9d3ecb5.png)


## Create a query

Return to the stream analytics job. Click on the **Query** option in the **Job topology** section. Change the query to:

```sql
SELECT CONCAT(Measurement.[Index], '-', Sensor) AS ID,
       Sensor,
       Measurement.[Index] AS MeasureId,
       Measurement.Taken AS MeasuredAt,
       Measurement.Value AS Temperature
INTO StreamOut
FROM StreamIn
```

Can note a few things:
- It is indeed an SQL-like syntax. In fact, it is a subset of SQL.
- Reserved words, when used for names, must be surrounded with square brackets.
- We can use aliases for the columns.
- We can create custom columns as well.

Now, click on the **Save query** button.

![image](https://user-images.githubusercontent.com/34960418/154253760-aaa09a61-1ab8-411f-ac35-5c80fd29a30e.png)


## Adjust the data generation process

Go to the storage account. Then, navigate to the **Access Keys** option under the **Security + networking** section. Copy the **Connection string** value either for **key1** or **key2**.

![image](https://user-images.githubusercontent.com/34960418/154255137-d4c15831-eafa-4a77-8558-c5d95e2a2eb7.png)


Extract the provided archive – **AzureBlobJsonGenerator-bin** in a local folder of your choice. Open the **AzureBlobJsonGenerator.exe.config** file in a text editor. Check the **BlobContainer** setting. Please set it to match the container you created earlier. By default, it is **demo**. Paste the value copied from **key1** or **key2** in the **StorageConnectionString** setting. Check and also adjust the **LocalTempPath** parameter. It must point to a folder on your PC to store the files generated while the application is working. Save and close the file.

![image](https://user-images.githubusercontent.com/34960418/154255724-51021b60-5fbd-4c61-a780-0e70fbf3b039.png)


## Start the job

Return to the **Overview** mode of the stream analytics job. Click on the **Start** button. Leave the **Job output start time** to **Now** and click on Start.

![image](https://user-images.githubusercontent.com/34960418/154256310-122a4e05-e830-478d-b0e2-d15b2540f221.png)


Wait for the job to start. Once it is started, go to the folder where you did extract the data generation application. Doble click on the **AzureBlobJsonGenerator.exe**. Press the Enter key to initiate the data generation process. Check the **input/YYYY-MM-DD** folder to see if there are files being generated.

![image](https://user-images.githubusercontent.com/34960418/154256889-ed3ad6ba-30e2-4c06-83e1-5566a37ba52a.png)

![image](https://user-images.githubusercontent.com/34960418/154256916-9d37b145-8135-4eb6-a902-1e8185f5d07d.png)


## BLOB output

After a minute or so, there should be some data on the output stream. Go to the storage account. Enter the container. Go to the **output/** folder. 

![image](https://user-images.githubusercontent.com/34960418/154257266-f8b78438-267e-4c05-b72b-06ab7de3f439.png)


Click on the file to download it. Open it with a text editor. The result should match what we defined for the output stream. 

![image](https://user-images.githubusercontent.com/34960418/154257375-bdd0c97d-7ada-4420-8308-30aa131cb81a.png)


## Job monitoring

Return to the **Azure Portal** and go to the **Overview** view of the stream analytics job. There, can see the performance. 

![image](https://user-images.githubusercontent.com/34960418/154257788-a3551c15-7fd7-41f8-b46b-8da79e599dfc.png)


## Cleaning

Return to the Overview. Click on Stop button and confirm that you want to stop the job. Stop the data generation application and delete the files under the target folder you specified in the configuration. Delete either the whole storage account, or just the blob container. Delete the resource group. 

![image](https://user-images.githubusercontent.com/34960418/154257943-0a3082e7-4217-4b8b-a427-d24c4a2bdbb4.png)
