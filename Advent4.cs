using System.Security.Cryptography;
using System.Text;

internal class Advent4
{
    internal async static Task Run()
    {
        var input = "ckczppom";

        int output = 0, output2 = 0;
        for (int i = 0; i <= 999999; i++)
        {
            var hash = CreateMD5(input + i.ToString());
            if (hash[..5] == "00000")
            {
                output = i;
                break;
            }
        }
        for (int i = 0; i <= 9999999; i++)
        {
            var hash = CreateMD5(input + i.ToString().PadLeft(6, '0'));
            if (hash[..6] == "000000")
            {
                output2 = i;
                break;
            }
        }

        Console.WriteLine($"Advent4: 1 ({output}), 2 ({output2})");
    }

    private static string CreateMD5(string input)
    {
        byte[] inputBytes = Encoding.ASCII.GetBytes(input);
        byte[] hashBytes = MD5.HashData(inputBytes);

        return Convert.ToHexString(hashBytes);
    }
}
