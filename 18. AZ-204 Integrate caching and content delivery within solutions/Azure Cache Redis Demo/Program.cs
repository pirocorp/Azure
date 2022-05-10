namespace AzureCacheRedis
{
    using System.Threading.Tasks;

    using StackExchange.Redis;

    public static class Program
    {
        private const string ConnectionString = "zrz-az204redis.redis.cache.windows.net:6380,password=Sr0rzpWp9OVaDWc21ySVGsqQVqImEJjEOAzCaBbYrG4=,ssl=True,abortConnect=False";

        public static async Task Main()
        {
            // The connection to the Azure Cache for Redis is managed by the ConnectionMultiplexer class.
            using var cache = await ConnectionMultiplexer.ConnectAsync(ConnectionString);
            IDatabaseAsync db = cache.GetDatabase();

            await ExecutePingCommand(db);

            await GetAllClientsConnectedToCache(db);

            await SetSampleValue(db);

            await GetSampleValue(db);

            await SetObject(db);

            await GetObject(db);
        }

        private static async Task ExecutePingCommand(IDatabaseAsync db)
        {
            // Snippet below executes a PING to test the server connection
            var result = await db.ExecuteAsync("ping");
            Console.WriteLine($"PING = {result.Type} : {result}");
        }

        private static async Task GetAllClientsConnectedToCache(IDatabaseAsync database)
        {
            // Get all the clients connected to the cache
            var result = await database.ExecuteAsync("client", "list");
            Console.WriteLine($"Type = {result.Type}");
            Console.WriteLine($"Result = {result}");
        }

        private static async Task SetSampleValue(IDatabaseAsync db)
        {
            // Call StringSetAsync on the IDatabase object to set the key "test:key" to the value "100"
            var setValue = await db.StringSetAsync("test:key", "100");
            Console.WriteLine($"SET: {setValue}");
        }

        private static async Task GetSampleValue(IDatabaseAsync db)
        {
            // StringGetAsync takes the key to retrieve and return the value
            string getValue = await db.StringGetAsync("test:key");
            Console.WriteLine($"GET: {getValue}");
        }

        private static async Task SetObject(IDatabaseAsync db)
        {
            var stat = new GameStat("Soccer", new DateTime(2022, 5, 10), "Local Game",
                new[] { "Team 1", "Team 2" },
                new[] { ("Team 1", 2), ("Team 2", 1) });

            var serializedValue = Newtonsoft.Json.JsonConvert.SerializeObject(stat);
            var added = await db.StringSetAsync("event:2022-local-game", serializedValue);
        }

        private static async Task GetObject(IDatabaseAsync db)
        {
            var result = await db.StringGetAsync("event:2022-local-game");
            var stat = Newtonsoft.Json.JsonConvert.DeserializeObject<GameStat>(result.ToString());
            Console.WriteLine(stat?.Sport); // displays "Soccer"
            Console.WriteLine(stat);
        }
    }
}
