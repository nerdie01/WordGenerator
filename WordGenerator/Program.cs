using System.Text;

public static class Program
{
    private static Random random = new Random();

    public static void Main(string[] args)
    {
        for (int i = 0; i < 100; i++)
        {
            Console.Write(GenerateWord(2, 4, 1, 5) + " ");
        }
    }

    static string GenerateWord(int syllableMinLength, int syllableMaxLength, int minNumSyllables, int maxNumSyllables)
    {
        string vowels = "aeiou";
        string consonants = "bcdfghjklmnprstvxyz";
        string letters = "abcdefghijklmnoprstuvxyz";

        int numSyllables = random.Next(minNumSyllables, maxNumSyllables);
        string[] syllable = new string[numSyllables];

        for (int i = 0; i < numSyllables; i++)
        {
            int length = random.Next(syllableMinLength, syllableMaxLength);

            StringBuilder syllableBuilder = new StringBuilder(letters[random.Next(letters.Length)].ToString(), length);

            for (int j = 0; j < length - 1; j++)
            {
                foreach (char c in consonants)
                {
                    if (syllableBuilder[j] == c) { syllableBuilder.Append(vowels[random.Next(vowels.Length - 1)]); }
                }

                foreach (char v in vowels)
                {
                    if (syllableBuilder[j] == v) { syllableBuilder.Append(consonants[random.Next(consonants.Length - 1)]); }
                }
            }

            syllable[i] = syllableBuilder.ToString();
        }

        return String.Join("", syllable);
    }
}