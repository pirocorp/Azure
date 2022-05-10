namespace AzureCacheRedis
{
    public class GameStat
    {
        public GameStat(
            string sport, 
            DateTimeOffset datePlayed, 
            string game, 
            IEnumerable<string> teams, 
            IEnumerable<(string team, int score)> results)
        {
            Id = Guid.NewGuid().ToString();
            Sport = sport;
            DatePlayed = datePlayed;
            Game = game;
            Teams = teams.ToList();
            Results = results.ToList();
        }

        public string Id { get; set; }

        public string Sport { get; set; }

        public DateTimeOffset DatePlayed { get; set; }

        public string Game { get; set; }

        public IReadOnlyList<string> Teams { get; set; }

        public IReadOnlyList<(string team, int score)> Results { get; set; }
        
        public override string ToString()
        {
            return $"{Sport} {Game} played on {DatePlayed.Date.ToShortDateString()} - " +
                   $"{string.Join(',', Teams)}\r\n\t" + 
                   $"{string.Join('\t', Results.Select(r => $"{r.team } - {r.score}\r\n"))}";
        }
    }
}
