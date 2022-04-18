namespace az204_cosmos
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.Azure.Cosmos;

    public class Program
    {
        public static async Task Main()
        {
            try
            {
                Console.WriteLine("Beginning operations...\n");
                var cosmosService = new CosmosService();

                var response = await cosmosService.CreateDatabaseAsync();
                Console.WriteLine(response);

                response = await cosmosService.CreateContainerAsync();
                Console.WriteLine(response);
            }
            catch (CosmosException de)
            {
                var baseException = de.GetBaseException();
                Console.WriteLine("{0} error occurred: {1}", de.StatusCode, de);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}", e);
            }
            finally
            {
                Console.WriteLine("End of program, press any key to exit.");
                Console.ReadKey();
            }
        }
    }
}
