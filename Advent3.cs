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
            var move = fileContent[i];

            var top = santaPos.Item1;
            var left = santaPos.Item2;
            if (move == '^') {
                santaPos = new Tuple<int, int>(--top, left);
            }
            else if (move == '>') {
                santaPos = new Tuple<int, int>(top, ++left);
            }
            else if (move == 'v') {
                santaPos = new Tuple<int, int>(++top, left);
            }
            else if (move == '<') {
                santaPos = new Tuple<int, int>(top, --left);
            }

            var val = table[santaPos.Item1][santaPos.Item2];
            table[santaPos.Item1][santaPos.Item2] = val + 1;
        }
        var score1 = GetGiftCount(table);

        santaPos = new Tuple<int, int>(500, 500);
        var robosantaPos = new Tuple<int, int>(500, 500);
        table2[santaPos.Item1][santaPos.Item2] = 2;
        for (int i = 0; i < fileContent.Length; i += 2)
        {
            var santaMove = fileContent[i];
            var robosantaMove = fileContent[i+1];

            var top = santaPos.Item1;
            var left = santaPos.Item2;
            var top2 = robosantaPos.Item1;
            var left2 = robosantaPos.Item2;
            if (santaMove == '^')
            {
                santaPos = new Tuple<int, int>(--top, left);
            }
            else if (santaMove == '>')
            {
                santaPos = new Tuple<int, int>(top, ++left);
            }
            else if (santaMove == 'v')
            {
                santaPos = new Tuple<int, int>(++top, left);
            }
            else if (santaMove == '<')
            {
                santaPos = new Tuple<int, int>(top, --left);
            }

            if (robosantaMove == '^')
            {
                robosantaPos = new Tuple<int, int>(--top2, left2);
            }
            else if (robosantaMove == '>')
            {
                robosantaPos = new Tuple<int, int>(top2, ++left2);
            }
            else if (robosantaMove == 'v')
            {
                robosantaPos = new Tuple<int, int>(++top2, left2);
            }
            else if (robosantaMove == '<')
            {
                robosantaPos = new Tuple<int, int>(top2, --left2);
            }

            var santaVal = table2[santaPos.Item1][santaPos.Item2];
            var robosantaVal = table2[robosantaPos.Item1][robosantaPos.Item2];
            table2[santaPos.Item1][santaPos.Item2] = santaVal + 1;
            table2[robosantaPos.Item1][robosantaPos.Item2] = robosantaVal + 1;
        }
        var score2 = GetGiftCount(table2);

        Console.WriteLine($"Advent3: 1 ({score1}), 2 ({score2})");
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
