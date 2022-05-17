namespace AdventureWorks.Context
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using AdventureWorks.Models;

    public interface IAdventureWorksProductContext
    {
        Task<Model> FindModelAsync(Guid id);

        Task<List<Model>> GetModelsAsync();

        Task<Product> FindProductAsync(Guid id);
    }
}