internal class Advent1
{
    internal static async Task Run()
    {
        var fileContent = await File.ReadAllTextAsync("input1.txt");

        int score1 = 0, score2 = 0;

        for (int i = 0; i < fileContent.Length; i++)
        {
            score1 += fileContent[i] == '(' ? 1 : -1;
            if (score2 == 0 && score1 == -1) {
                score2 = i + 1;
            }
        }
        Console.WriteLine($"Advent1 - 1 ({score1}) - 2 ({score2})");
    }
}