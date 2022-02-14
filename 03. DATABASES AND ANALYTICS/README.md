# TOC

- [Relational Databases (Azure SQL)](#relational-Databases-azure-SQL))




# [Relational Databases (Azure SQL)](https://azure.microsoft.com/en-us/product-categories/databases/)

Types of Offerings

![image](https://user-images.githubusercontent.com/34960418/153888078-c18046fb-7904-441d-9676-e3d5b7b34a1f.png)

## [Azure SQL](https://docs.microsoft.com/en-us/azure/sql-database/)

- **SQL Databases**
  - **Single Database** - fully managed, isolated database
  - **Elastic Pool** - a collection of databases with a shared set of resources
  - **Database Server** - groups of single databases and elastic pools
- **SQL Managed Instances**
  - Fully managed instance, easy migration
- **SQL Virtual Machines**
  - Full administrative control over SQL & OS
  - Option for Bring Your Own License (BYOL)

## [Purchasing Models](https://docs.microsoft.com/en-us/azure/sql-database/sql-database-purchase-models)

 - **vCore-based** - Choose the number of vCores, the amount of memory, and the amount and speed of storage.
 - **DTU-based** (DTU - Database Transaction Unit) - Offers a blend of compute, memory, and I/O resources in three service tiers.
 - **Serverless** - Automatically scales compute based on workload demand, and bills for the amount of compute used per second.

## Service Tiers*

\***Basic**, **Standard**, and **Premium** are applicable for the DTU model.

### [General Purpose (Standard)](https://docs.microsoft.com/en-us/azure/azure-sql/database/service-tier-general-purpose)

Designed for common workloads. Offers budget-oriented balanced compute and storage options.

### [Business Critical (Premium)](https://docs.microsoft.com/en-us/azure/azure-sql/database/service-tier-business-critical)

Designed for OLTP applications with high transaction rate and lowest-latency I/O. Offers the highest resilience to failures by using several isolated replicas.

### [Hyperscale](https://docs.microsoft.com/en-us/azure/azure-sql/database/service-tier-hyperscale)

Designed for very large OLTP database. Offers the ability to auto-scale storage and scale compute fluidly.



## 
