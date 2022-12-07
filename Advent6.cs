using System.Data;
using System.Text.RegularExpressions;

internal partial class Advent6
{
    private static readonly Dictionary<int, Dictionary<int, bool>> table = new();
    private static readonly Dictionary<int, Dictionary<int, int>> table2 = new();

    internal async static Task Run()
    {
        var fileContent = await File.ReadAllLinesAsync("input6.txt");

        for (int i = 0; i <= 999; i++)
        {
            table[i] = new Dictionary<int, bool>();
            table2[i] = new Dictionary<int, int>();
        }
        for (int i = 0; i <= 999; i++)
        {
            var row = table[i];
            var row2 = table2[i];
            for (int j = 0; j <= 999; j++)
            {
                row[j] = false;
                row2[j] = 0;
            }
        }

        for (int i = 0; i < fileContent.Length; i++)
        {
            var line = fileContent[i];
            var match = RegexLineParse().Match(line);

            if (match.Groups[1].Value == "toggle")
            {
                Toggle(int.Parse(match.Groups[2].Value), int.Parse(match.Groups[3].Value), int.Parse(match.Groups[4].Value), int.Parse(match.Groups[5].Value));
            }
            else if (match.Groups[1].Value == "turn on")
            {
                Turn(int.Parse(match.Groups[2].Value), int.Parse(match.Groups[3].Value), int.Parse(match.Groups[4].Value), int.Parse(match.Groups[5].Value), true);
            }
            else if (match.Groups[1].Value == "turn off")
            {
                Turn(int.Parse(match.Groups[2].Value), int.Parse(match.Groups[3].Value), int.Parse(match.Groups[4].Value), int.Parse(match.Groups[5].Value), false);
            }
        }
        var score1 = GetLightCount();

        for (int i = 0; i < fileContent.Length; i++)
        {
            var line = fileContent[i];
            var match = RegexLineParse().Match(line);

            if (match.Groups[1].Value == "toggle")
            {
                Toggle2(int.Parse(match.Groups[2].Value), int.Parse(match.Groups[3].Value), int.Parse(match.Groups[4].Value), int.Parse(match.Groups[5].Value));
            }
            else if (match.Groups[1].Value == "turn on")
            {
                Turn2(int.Parse(match.Groups[2].Value), int.Parse(match.Groups[3].Value), int.Parse(match.Groups[4].Value), int.Parse(match.Groups[5].Value), 1);
            }
            else if (match.Groups[1].Value == "turn off")
            {
                Turn2(int.Parse(match.Groups[2].Value), int.Parse(match.Groups[3].Value), int.Parse(match.Groups[4].Value), int.Parse(match.Groups[5].Value), -1);
            }
        }
        var score2 = GetLightCount2();

        Console.WriteLine($"Advent6: 1 ({score1}), 2 ({score2})");
    }

    private static int GetLightCount()
    {
        var score = 0;
        for (int i = 0; i <= 999; i++)
        {
            for (int j = 0; j <= 999; j++)
            {
                score += table[i][j] == true ? 1 : 0;
            }
        }
        return score;
    }

    private static int GetLightCount2()
    {
        var score = 0;
        for (int i = 0; i <= 999; i++)
        {
            for (int j = 0; j <= 999; j++)
            {
                score += table2[i][j];
            }
        }
        return score;
    }

    private static void Turn(int fromTop, int fromLeft, int toTop, int toLeft, bool status)
    {
        for (int i = fromTop; i <= toTop; i++)
        {
            for (int j = fromLeft; j <= toLeft; j++)
            {
                table[i][j] = status;
            }
        }
    }

    private static void Turn2(int fromTop, int fromLeft, int toTop, int toLeft, int status)
    {
        for (int i = fromTop; i <= toTop; i++)
        {
            for (int j = fromLeft; j <= toLeft; j++)
            {
                var val = table2[i][j];
                table2[i][j] = Math.Max(0, val + status);
            }
        }
    }

    private static void Toggle(int fromTop, int fromLeft, int toTop, int toLeft)
    {
        for (int i = fromTop; i <= toTop; i++)
        {
            for (int j = fromLeft; j <= toLeft; j++)
            {
                var val = table[i][j];
                table[i][j] = !val;
            }
        }
    }

    private static void Toggle2(int fromTop, int fromLeft, int toTop, int toLeft)
    {
        for (int i = fromTop; i <= toTop; i++)
        {
            for (int j = fromLeft; j <= toLeft; j++)
            {
                var val = table2[i][j];
                table2[i][j] = val + 2;
            }
        }
    }

    [GeneratedRegex("(toggle|turn off|turn on) (\\d{1,3}),(\\d{1,3}) through (\\d{1,3}),(\\d{1,3})")]
    private static partial Regex RegexLineParse();
}
