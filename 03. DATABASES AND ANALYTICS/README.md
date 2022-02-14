# TOC

- [Relational Databases (Azure SQL)](#relational-Databases-azure-SQL)
- [NoSQL Databases (Csomos DB)](#nosql-databases-cosmos-db)



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



