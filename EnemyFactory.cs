using System;

namespace WarOfNovus
{
    public class EnemyFactory
    {
        public static Enemy CreateEnemy(string type)
        {
            switch (type)
            {
                case "Fire":
                    return new Enemy("Ash", 80, 12, 6, "Fire");
                case "Wind":
                    return new Enemy("Draco Hatchling", 90, 10, 5, "Wind");
                case "Terra":
                    return new Enemy("Giant Marsh Scud", 85, 11, 7, "Terra");
                case "Aqua":
                    return new Enemy("Blue Scale Klan", 100, 8, 8, "Aqua");
                default:
                    throw new ArgumentException("Invalid enemy type.");
            }
        }
    }
}
