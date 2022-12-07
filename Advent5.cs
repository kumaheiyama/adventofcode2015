using System.Text.RegularExpressions;

internal partial class Advent5
{
    internal async static Task Run()
    {
        var fileContent = await File.ReadAllLinesAsync("input5.txt");

        int score1 = 0, score2 = 0;
        for (int i = 0; i < fileContent.Length; i++)
        {
            var line = fileContent[i];
            var match1 = ContainsThreeVowels();
            var match2 = HasDoubleLetters();
            var match3 = DoesNotContainForbiddenWords();
            if (match1.IsMatch(line) && match2.IsMatch(line) && !match3.IsMatch(line)) {
                score1++;
            }

            var match4 = ContainsTwoIdenticalStringsWithLettersBetween();
            var match5 = ContainsTwoIdenticalLettersWithOneLetterBetween();
            if (match4.IsMatch(line) && match5.IsMatch(line))
            {
                score2++;
            }
        }

        Console.WriteLine($"Advent5: 1 ({score1}), 2 ({score2})");
    }

    [GeneratedRegex("[aeiou]{1,}[a-z]{0,}[aeiou]{1,}[a-z]{0,}[aeiou]{1,}")]
    private static partial Regex ContainsThreeVowels();
    [GeneratedRegex("([a-z])\\1")]
    private static partial Regex HasDoubleLetters();
    [GeneratedRegex("ab|cd|pq|xy")]
    private static partial Regex DoesNotContainForbiddenWords();
    [GeneratedRegex("([a-z]{2})[a-z]{0,}\\1")]
    private static partial Regex ContainsTwoIdenticalStringsWithLettersBetween();
    [GeneratedRegex("([a-z]{1})[a-z]{1}\\1")]
    private static partial Regex ContainsTwoIdenticalLettersWithOneLetterBetween();
}
