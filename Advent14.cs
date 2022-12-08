using System.Text.RegularExpressions;

internal partial class Advent14
{
    internal async static Task Run()
    {
        var fileContent = await File.ReadAllLinesAsync("input14.txt");

        var reindeer = new Dictionary<string, Reindeer>();
        decimal score1 = 0, score2 = 0;
        for (int i = 0; i < fileContent.Length; i++)
        {
            var line = fileContent[i];
            var match = MatchReindeer().Match(line);
            reindeer.Add(match.Groups["name"].Value, new Reindeer
            {
                Name = match.Groups["name"].Value,
                Speed = int.Parse(match.Groups["speed"].Value),
                Duration = int.Parse(match.Groups["duration"].Value),
                Rest = int.Parse(match.Groups["rest"].Value)
            });
        }

        for (int i = 0; i < 2503; i++)
        {
            foreach (var item in reindeer.Values)
            {
                if (--item.RestingUntil > 0)
                {
                    continue;
                }

                if (item.TravelledDuration == item.Duration)
                {
                    item.RestingUntil = item.Rest;
                    item.TravelledDuration = 0;
                }
                else
                {
                    item.TravelledDistance += item.Speed;
                    item.TravelledDuration++;
                }
            }

            var topDistance = reindeer.Values
                .OrderByDescending(x => x.TravelledDistance)
                .Take(1)
                .First()
                .TravelledDistance;
            var topContenders = reindeer.Values
                .Where(x => x.TravelledDistance == topDistance);
            foreach (var item in topContenders)
            {
                item.Points++;
            }
        }
        score1 = reindeer.Values
            .OrderByDescending(x => x.TravelledDistance)
            .Take(1)
            .First()
            .TravelledDistance;
        score2 = reindeer.Values
            .OrderByDescending(x => x.Points)
            .Take(1)
            .First()
            .Points;

        Console.WriteLine($"Advent14: 1 ({score1}), 2 ({score2})");
    }

    [GeneratedRegex("(?<name>[\\w]+) can fly (?<speed>[\\d]+) km\\/s for (?<duration>[\\d]+) seconds, but then must rest for (?<rest>[\\d]+)")]
    private static partial Regex MatchReindeer();
}

internal class Reindeer
{
    public string Name { get; set; }
    public decimal Speed { get; set; }
    public decimal Duration { get; set; }
    public int Rest { get; set; }
    public decimal TravelledDistance { get; set; }
    public int TravelledDuration { get; set; }
    public int RestingUntil { get; set; }
    public int Points { get; set; }
}