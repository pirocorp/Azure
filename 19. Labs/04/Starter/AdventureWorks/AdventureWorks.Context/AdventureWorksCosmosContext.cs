namespace AdventureWorks.Context
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Models;

    using Microsoft.Azure.Cosmos;
    using Microsoft.Azure.Cosmos.Linq;

    public class AdventureWorksCosmosContext : IAdventureWorksProductContext
    {
        private readonly Container container;

        public AdventureWorksCosmosContext(
            string connectionString, 
            string database = "Retail", 
            string container = "Online")
        {
            // Don't do this in production!
            this.container = new CosmosClient(connectionString)
                .GetDatabase(database)
                .GetContainer(container);
        }

        public async Task<Model> FindModelAsync(Guid id)
        {
            var iterator = this.container
                .GetItemLinqQueryable<Model>()
                .Where(m => m.id == id)
                .ToFeedIterator();

            var  matches = new List<Model>();

            while (iterator.HasMoreResults)
            {
                var next = await iterator.ReadNextAsync();
                matches.AddRange(next);
            }

            return matches.SingleOrDefault();
        }

        public async Task<List<Model>> GetModelsAsync()
        {
            var query = $@"SELECT * FROM items";
            var iterator = this.container.GetItemQueryIterator<Model>(query);
            var matches = new List<Model>();

            while (iterator.HasMoreResults)
            {
                var next = await iterator.ReadNextAsync();
                matches.AddRange(next);
            }

            return matches;
        }

        public async Task<Product> FindProductAsync(Guid id)
        {
            var query = $@"SELECT VALUE products
                    FROM models
                    JOIN products in models.Products
                    WHERE products.id = '{id}'";

            var iterator = this.container.GetItemQueryIterator<Product>(query);
            var matches = new List<Product>();

            while (iterator.HasMoreResults)
            {
                var next = await iterator.ReadNextAsync();
                matches.AddRange(next);
            }

            return matches.SingleOrDefault();
        }
    }
}
