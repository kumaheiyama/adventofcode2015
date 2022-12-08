using Newtonsoft.Json;
using System.Text.RegularExpressions;

internal partial class Advent12
{
    internal async static Task Run()
    {
        var fileContent = await File.ReadAllTextAsync("input12.txt");

        int score1 = 0, score2 = 0;

        var match = MatchAllNumbers().Matches(fileContent);
        score1 = match.Sum(x => int.Parse(x.Value));

        dynamic jsonStr = JsonConvert.DeserializeObject(fileContent);

        foreach (dynamic item in jsonStr)
        {

        }

        Console.WriteLine($"Advent12: 1 ({score1}), 2 ({score2})");
    }

    [GeneratedRegex("([\\d-]{1,})")]
    private static partial Regex MatchAllNumbers();
}
