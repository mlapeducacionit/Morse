using System;

internal class Program
{
    static readonly Dictionary<string, string> morse2Human = new()
    {
        { ".-", "A" },
        { "-...", "B" },
        { "-.-.", "C" },
        { "-..", "D" },
        { ".", "E" },
        { "..-.", "F" },
        { "--.", "G" },
        { "....", "H" },
        { "..", "I" },
        { ".---", "J" },
        { "-.-", "K" },
        { ".-..", "L" },
        { "--", "M" },
        { "-.", "N" },
        { "---", "O" },
        { ".--.", "P" },
        { "--.-", "Q" },
        { ".-.", "R" },
        { "...", "S" },
        { "-", "T" },
        { "..-", "U" },
        { "...-", "V" },
        { ".--", "W" },
        { "-..-", "X" },
        { "-.--", "Y" },
        { "--..", "Z" },
        { "----", "0" },
        { ".----", "1" },
        { "..---", "2" },
        { "...--", "3" },
        { "....-", "4" },
        { ".....", "5" },
        { "-....", "6" },
        { "--...", "7" },
        { "---..", "8" },
        { "----.", "9" },
        { ".-.-.-", "." }
    };
    static void Main(string[] args)
    {
        string readMorse;
        do
        {
            readMorse = Console.ReadLine();
            Console.WriteLine(DecodeMorse2Human(readMorse));
        }
        while (true);
    }
    static string DecodeMorse2Human(string readMorse)
    {
        List<string> human = new ();
        foreach (string morse in readMorse.Split(" "))
        {
            human.Add(morse2Human[morse]);
        }
        return String.Join(char.MinValue,human); 
    }
}
