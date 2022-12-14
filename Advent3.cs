internal class Advent3
{
    private static readonly Dictionary<int, Dictionary<int, int>> table = new();
    private static readonly Dictionary<int, Dictionary<int, int>> table2 = new();

    internal async static Task Run()
    {
        var fileContent = await File.ReadAllTextAsync("input3.txt");
        //var fileContent = "^v";
        //var fileContent = "^>v<";
        //var fileContent = "^v^v^v^v^v";

        for (int i = 0; i <= 999; i++)
        {
            table[i] = new Dictionary<int, int>();
            table2[i] = new Dictionary<int, int>();
        }
        for (int i = 0; i <= 999; i++)
        {
            var row = table[i];
            var row2 = table2[i];
            for (int j = 0; j <= 999; j++)
            {
                row[j] = 0;
                row2[j] = 0;
            }
        }

        var santaPos = new Tuple<int, int>(500, 500);
        table[santaPos.Item1][santaPos.Item2] = 1;
        for (int i = 0; i < fileContent.Length; i++)
        {
            santaPos = Move(santaPos, fileContent[i], table);
        }
        var score1 = GetGiftCount(table);

        santaPos = new Tuple<int, int>(500, 500);
        var robosantaPos = new Tuple<int, int>(500, 500);
        table2[santaPos.Item1][santaPos.Item2] = 2;
        for (int i = 0; i < fileContent.Length; i += 2)
        {
            santaPos = Move(santaPos, fileContent[i], table2);
            robosantaPos = Move(robosantaPos, fileContent[i+1], table2);
        }
        var score2 = GetGiftCount(table2);

        Console.WriteLine($"Advent3: 1 ({score1}), 2 ({score2})");
    }

    private static Tuple<int, int> Move(Tuple<int, int> pos, char move, Dictionary<int, Dictionary<int, int>> tbl)
    {
        var newPos = GetSantaPos(pos, move);
        var val = tbl[pos.Item1][pos.Item2];
        tbl[pos.Item1][pos.Item2] = val + 1;
        return newPos;
    }

    private static Tuple<int, int> GetSantaPos(Tuple<int, int> input, char santaMove)
    {
        var top = input.Item1;
        var left = input.Item2;
        Tuple<int, int> output;
        if (santaMove == '^')
        {
            output = new Tuple<int, int>(--top, left);
        }
        else if (santaMove == '>')
        {
            output = new Tuple<int, int>(top, ++left);
        }
        else if (santaMove == 'v')
        {
            output = new Tuple<int, int>(++top, left);
        }
        else
        {
            output = new Tuple<int, int>(top, --left);
        }
        return output;
    }

    private static int GetGiftCount(Dictionary<int, Dictionary<int, int>> tbl)
    {
        var score = 0;
        for (int i = 0; i <= 999; i++)
        {
            for (int j = 0; j <= 999; j++)
            {
                score += tbl[i][j] > 0 ? 1 : 0;
            }
        }
        return score;
    }
}
