namespace Decoder
{    public class Decode
    {
        private static readonly Dictionary<string, string> morse2Human = new()
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
        public static string Morse2Human(string readMorse)
        {
            List<string> human = new();
            foreach (string morse in readMorse.Split(" "))
            {
                human.Add(morse2Human[morse]);
            }
            return String.Join(string.Empty, human);
        }
        public static string Bits2Morse(string readBits)
        {
            List<string> dataPackages = new();
            int start = 0;

            for (int i = 1; i < readBits.Length; i++)
            {
                if (readBits[i - 1] != readBits[i] | i == readBits.Length - 1)
                {
                    dataPackages.Add(readBits[start..i]);
                    start = i;
                }
            }

            if (dataPackages[0].Contains('0')) { dataPackages.RemoveAt(0); }
            if (dataPackages[^1].Contains('0')) { dataPackages.RemoveAt(dataPackages.Count - 1); }

            int dotLength = int.MaxValue;//dot 2-3
            int dashLength = int.MinValue;//dash 6-8
            int charSpaceLength = int.MaxValue;//char separator 4-7
            int wordSpaceLength = int.MinValue;//word separator 5

            foreach (string dataPackage in dataPackages)
            {
                if (dataPackage[0] == '1')
                {
                    if (dataPackage.Length <= dotLength) dotLength = dataPackage.Length;
                    if (dataPackage.Length >= dashLength) dashLength = dataPackage.Length;
                }
                else
                {
                    if (dataPackage.Length <= charSpaceLength) charSpaceLength = dataPackage.Length;
                    if (dataPackage.Length >= wordSpaceLength) wordSpaceLength = dataPackage.Length;
                }
            }

            List<char> morseString = new();
            foreach (string dataPackage in dataPackages)
            {
                if (dataPackage[0] == '1')
                {
                    if (Math.Abs(dataPackage.Length - dotLength) <= Math.Abs(dataPackage.Length - dashLength))
                    {
                        morseString.Add('.');
                    }
                    else
                    {
                        morseString.Add('-');
                    }
                }
                else
                {
                    if (Math.Abs(dataPackage.Length - wordSpaceLength) <= Math.Abs(dataPackage.Length - charSpaceLength))
                    {
                        morseString.Add(' ');
                    }
                }
            }
            return string.Join(string.Empty, morseString);
        }
    }
}
