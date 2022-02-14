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
  - [Azure SQL (Azure CLI)](#azure-sql-azure-cli)
  - [Azure SQL (Azure PowerShell)](#azure-sql-azure-powershell)
- Cosmos DB
  - [Cosmos DB (Azure Portal)](#cosmos-db-azure-portal)
  - [Cosmos DB (Azure CLI)](#cosmos-db-azure-cli)
  - [Cosmos DB (Azure PowerShell)](#cosmos-db-azure-powershell)
- [Azure Stream Analytics](#azure-stream-analytics)


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

# Azure SQL (Azure CLI)

# Azure SQL (Azure PowerShell)

# Cosmos DB (Azure Portal)

# Cosmos DB (Azure CLI)

# Cosmos DB (Azure PowerShell)

# Azure Stream Analytics
