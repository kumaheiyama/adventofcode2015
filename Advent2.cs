using System.Text.RegularExpressions;

internal partial class Advent2
{
    internal static async Task Run()
    {
        var fileContent = await File.ReadAllLinesAsync("input2.txt");
        //var fileContent = new[] { "2x3x4" };
        //var fileContent = new[] { "1x1x10" };
        //var fileContent = new[] { "24x5x1" };

        int score1 = 0, score2 = 0;

        for (int i = 0; i < fileContent.Length; i++)
        {
            var match = RegexMatchPackage().Match(fileContent[i]);
            var length = int.Parse(match.Groups[1].Value);
            var width = int.Parse(match.Groups[2].Value);
            var height = int.Parse(match.Groups[3].Value);

            var lowest = new List<int> { length * width, width * height, height * length }.Order().Take(1).ToArray();
            score1 += (length * width * 2) + (width * height * 2) + (height * length * 2) + lowest[0];

            var shortest = new List<int>() { length, width, height }.Order().Take(2).ToArray();
            score2 += (shortest[0] * 2) + (shortest[1] * 2) + (length * width * height);
        }
        Console.WriteLine($"Advent2 - 1 ({score1}) - 2 ({score2})");
    }

    [GeneratedRegex("(\\d+)x(\\d+)x(\\d+)")]
    private static partial Regex RegexMatchPackage();
}