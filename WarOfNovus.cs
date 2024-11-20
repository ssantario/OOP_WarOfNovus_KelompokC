using System;

namespace WarOfNovus
{
    class WarOfNovus
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to War of Novus!");

            // Meminta pengguna memilih karakter: Player atau Enemy
            Console.WriteLine("Apakah Anda ingin membuat Player atau Enemy? (Ketik 'Player' atau 'Enemy')");
            string characterType = Console.ReadLine();

            if (characterType.ToLower() == "player")
            {
                // Setup Player
                Console.WriteLine("Masukkan nama karakter Anda:");
                string playerName = Console.ReadLine();

                Console.WriteLine("Masukkan Nation Anda (Bellato, Cora, atau Accretia):");
                string playerNation = Console.ReadLine();

                Console.WriteLine("Masukkan Job Anda (Warrior, Mage, Archer, dll.):");
                string playerJob = Console.ReadLine();

                var player = new Player(playerName, playerNation, playerJob);

                // Menampilkan statistik Player
                Console.WriteLine($"Player berhasil dibuat: {player.Name}, Nation: {player.Nation}, Job: {player.Job}");
                Console.WriteLine($"Health: {player.Health}, Attack: {player.AttackPower}, Defense: {player.Defense}");

                // Contoh Pertarungan
                var enemy = EnemyFactory.CreateEnemy("Fire"); // Musuh default
                IAttackStrategy strategy = new PhysicalAttack();
                strategy.ExecuteAttack(player, enemy);
                Console.WriteLine($"{enemy.Name} Health: {enemy.Health}");
            }
            else if (characterType.ToLower() == "enemy")
            {
                // Setup Enemy
                Console.WriteLine("Masukkan tipe enemy yang ingin Anda buat (Fire, Wind, Terra, Aqua):");
                string enemyType = Console.ReadLine();

                var enemy = EnemyFactory.CreateEnemy(enemyType);

                // Menampilkan statistik Enemy
                Console.WriteLine($"Enemy berhasil dibuat: {enemy.Name}, Elemen: {enemy.Element}");
                Console.WriteLine($"Health: {enemy.Health}, Attack: {enemy.AttackPower}, Defense: {enemy.Defense}");

                // Contoh Pertarungan
                var player = new Player("Hero", "Bellato", "Warrior"); // Player default
                IAttackStrategy strategy = new PhysicalAttack();
                strategy.ExecuteAttack(player, enemy);
                Console.WriteLine($"{enemy.Name} Health: {enemy.Health}");
            }
            else
            {
                Console.WriteLine("Pilihan tidak valid. Silakan ketik 'Player' atau 'Enemy'.");
            }

            // Contoh Inventory dan Senjata
            InventoryItem sword = new Sword();
            InventoryItem poisonedSword = new PoisonedDecorator(sword);
            Console.WriteLine($"Weapon: {poisonedSword.Description} - Power: {poisonedSword.GetPower()}");
        }
    }
}
