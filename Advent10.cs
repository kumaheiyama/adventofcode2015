internal class Advent10
{
    internal async static Task Run()
    {
        var fileContent = "1113222113";

        int score1, score2 = 0;
        var output = LookAndSay(fileContent, 40);
        var output2 = LookAndSay(fileContent, 50);
        score1 = output.Length;
        score2 = output2.Length;

        Console.WriteLine($"Advent10: 1 ({score1}), 2 ({score2})");
    }

    private static string LookAndSay(string input, int loops)
    {
        var outputStr = "";
        for (int i = 0; i < loops; i++)
        {
            var cnt = 0;
            char currentChar = input[0];
            for (int j = 0; j < input.Length; j++)
            {
                var chr = input[j];
                if (chr == currentChar)
                {
                    cnt++;
                }
                else
                {
                    outputStr += $"{cnt}{currentChar}";
                    currentChar = chr;
                    cnt = 1;
                }
            }
            input = outputStr += $"{cnt}{currentChar}";
            outputStr = "";
        }
        return input;
    }
}
