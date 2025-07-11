using Gwynbleidd.Entities;

namespace Gwynbleidd.GameProcess.GameLogic;

public static class PotionGenerator
{
    public readonly static List<(string name, int duration, int vMod, int cMod)> Potions;

    // Returns a random potion from the list of potions
    public static Potion Generate()
    {
        var random = new Random();
        (string name, int duration, int vMod, int cMod) = Potions[random.Next(Potions.Count)];
        return new Potion(name, duration, vMod, cMod);
    }

    // Loads the database
    static PotionGenerator()
    {

        // Gets the database path for correct reading
        string DB = Path.Combine(
        Directory.GetCurrentDirectory(),
        @"..\..\..\GameProcess\PotionsDB.csv");
        DB = Path.GetFullPath(DB);

        Potions = [];

        try
        {
            if (!File.Exists(DB))
                throw new FileNotFoundException($"Database file not found: {DB}");

            using var sr = new StreamReader(DB);

            // Skips header
            sr.ReadLine();

            while (!sr.EndOfStream)
            {
                string? line = sr.ReadLine();
                if (string.IsNullOrWhiteSpace(line)) continue; //EOF reached

                string[] fields = line.Split(',');
                if (fields.Length < 4)
                    throw new FormatException("Database error");

                if (!int.TryParse(fields[1], out int duration) ||
                    !int.TryParse(fields[2], out int vMod) ||
                    !int.TryParse(fields[3], out int cMod))
                {
                    throw new FormatException("Database error");
                }

                Potions.Add((fields[0], duration, vMod, cMod));
            }
        }
        catch (Exception)
        {
            throw new InvalidOperationException($"Could not open{DB}");
        }
    }
}
