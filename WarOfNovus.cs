using System;

namespace WarOfNovus
{
    class WarOfNovus
    {
        static void Main(string[] args)
        {
            DisplayTitle(); // Menampilkan title ASCII

            // Transisi ke pembuatan karakter
            TopTitle();
            Console.WriteLine();

            Console.WriteLine("Apakah Anda ingin membuat Player atau Enemy? (Ketik 'Player' atau 'Enemy')");
            string? characterType = Console.ReadLine();

            if (characterType?.ToLower() == "player" || characterType?.ToLower() == "p")
            {
                CreatePlayer();
            }
            else if (characterType?.ToLower() == "enemy" || characterType?.ToLower() == "e")
            {
                CreateEnemy();
            }
            else
            {
                Console.WriteLine("Pilihan tidak valid. Silakan coba lagi.");
            }
        }

        private static void DisplayTitle()
        {
            Console.Clear();
            Console.WriteLine(@"
         _       __              ____  ____   _   __                     
        | |     / /___ ______   / __ \/ __/  / | / /___ _   ____  _______
        | | /| / / __ `/ ___/  / / / / /_   /  |/ / __ \ | / / / / / ___/
        | |/ |/ / /_/ / /     / /_/ / __/  / /|  / /_/ / |/ / /_/ (__  ) 
        |__/|__/\__,_/_/      \____/_/    /_/ |_/\____/|___/\__,_/____/  
                                                                        
        ");

            Console.WriteLine("Tekan ENTER untuk memulai...");
            Console.ReadLine();
            Console.Clear();
        }


        static void TopTitle()
        {
            Console.Clear();
            Console.WriteLine("========================================================");
            Console.WriteLine(@"  _      __           ____  ___  _  __  ");
            Console.WriteLine(@" | | /| / /__ _____  / __ \/ _/ / |/ /__ _  ____ _____ ");
            Console.WriteLine(@" | |/ |/ / _ `/ __/ / /_/ / _/ /    / _ \ |/ / // (_-< ");
            Console.WriteLine(@" |__/|__/\_,_/_/    \____/_/  /_/|_/\___/___/\_,_/___/ ");

            // Border bottom
            Console.WriteLine("========================================================");
        }

        private static void CreatePlayer()
        {
            Console.Clear(); // Bersihkan layar sebelum membuat Player

            TopTitle();
            Console.WriteLine();

            // Membuat Player
            Console.WriteLine("Masukkan nama karakter Anda:");
            string? name = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine("Masukkan Nation Anda (Bellato, Cora, atau Accretia):");
            string? nationInput = Console.ReadLine()?.ToLower();

            Console.WriteLine();
            Console.WriteLine("Masukkan Job Anda (Warrior, Ranger, Spiritualist, dll.):");
            string? jobInput = Console.ReadLine()?.ToLower();

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(nationInput) || string.IsNullOrWhiteSpace(jobInput))
            {
                Console.WriteLine("Semua input harus diisi.");
                return;
            }

            // Handle the creation of the Race
            Race nation;
            switch (nationInput)
            {
                case "bellato":
                    nation = Race.Bellato;
                    break;
                case "cora":
                    nation = Race.Cora;
                    break;
                case "accretia":
                    nation = Race.Accretia;
                    break;
                default:
                    Console.WriteLine("Nation tidak valid.");
                    return;
            }

            // Handle the creation of the Job
            Job job;
            bool isJobValid = Enum.TryParse<Job>(jobInput, true, out job);

            if (!isJobValid)
            {
                Console.WriteLine("Job tidak valid.");
                return;
            }

            // Specific job validation based on nation
            if (nation == Race.Accretia && job == Job.Spiritualist)
            {
                Console.WriteLine("Accretia hanya memiliki job Warrior dan Ranger.");
                return;
            }
            else if (nation == Race.Cora && job != Job.Spiritualist && job != Job.Warrior && job != Job.Ranger)
            {
                Console.WriteLine("Cora hanya memiliki job Spiritualist, Warrior, atau Ranger.");
                return;
            }
            else if (nation == Race.Bellato && job != Job.Warrior && job != Job.Ranger)
            {
                Console.WriteLine("Bellato hanya memiliki job Warrior atau Ranger.");
                return;
            }

            var player = new Player(name, nation, job); // Pass enum for Job
            Console.WriteLine($"Player dibuat: {player.Name}, Nation: {player.Nation}, Job: {player.Job}");
            Console.WriteLine($"Health: {player.Health}, Attack: {player.AttackPower}, Defense: {player.Defense}");

            // Apply initial buffs or debuffs if any
            player.ApplyStatusEffect(new Buff(3, 5, 0)); // Example: Buff for 3 turns
            player.ApplyStatusEffect(new Debuff(2, 2, 0, 0)); // Example: Debuff for 2 turns

            TransitionToFightScene(player);
        }

        private static void CreateEnemy()
        {
            Console.Clear(); // Bersihkan layar sebelum membuat Enemy

            TopTitle();
            Console.WriteLine();

            // Membuat Enemy
            Console.WriteLine("Masukkan tipe enemy (Fire, Wind, Terra, Aqua):");
            string? enemyType = Console.ReadLine()?.ToLower();

            try
            {
                var enemy = EnemyFactory.CreateEnemy(enemyType!);
                Console.WriteLine($"Enemy dibuat: {enemy.Name}, Elemen: {enemy.Element}");
                Console.WriteLine($"Health: {enemy.Health}, Attack: {enemy.AttackPower}, Defense: {enemy.Defense}");

                TransitionToFightScene(enemy);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void TransitionToFightScene(Character character)
        {
            TopTitle();
            Console.WriteLine();

            Console.WriteLine("Tekan ENTER untuk melanjutkan ke Fighting Scene...");
            Console.ReadLine();
            Console.Clear();

            // Fighting Scene
            TopTitle();
            Console.WriteLine();
            Console.WriteLine($"--- FIGHTING SCENE ---");
            var enemy = EnemyFactory.CreateEnemy("Fire"); // Contoh lawan
            Console.WriteLine($"Anda bertemu dengan {enemy.Name}!");

            // Tentukan jenis attack berdasarkan Job karakter
            IAttackStrategy strategy;
            Player player = null;
            if (character is Player p && p.Job == Job.Spiritualist) // Job is now an enum
            {
                strategy = new MagicAttack(); // Spiritualist menggunakan serangan sihir
                Console.WriteLine($"{p.Name} adalah seorang Spiritualist, menggunakan serangan sihir!");
                player = p;
            }
            else
            {
                strategy = new PhysicalAttack(); // Lainnya menggunakan serangan fisik
                Console.WriteLine($"{character.Name} menggunakan serangan fisik!");
                player = (Player)character;
            }

            while (character.IsAlive() && enemy.IsAlive())
            {
                Console.WriteLine("Pilih tindakan: (1) Attack, (2) Use Skill, (3) Defend");
                string? action = Console.ReadLine();

                switch (action)
                {
                    case "1":
                        strategy.ExecuteAttack((Player)character, enemy);
                        break;
                    case "2":
                        UseSkill((Player)character, enemy);
                        break;
                    case "3":
                        Defend((Player)character);
                        break;
                    default:
                        Console.WriteLine("Pilihan tidak valid.");
                        continue;
                }

                Console.WriteLine($"{enemy.Name} tersisa Health: {enemy.Health}");

                // Apply and update status effects
                character.UpdateStatusEffects();
                enemy.UpdateStatusEffects();

                Console.WriteLine($"{character.Name} status effects updated.");
                Console.WriteLine($"{enemy.Name} status effects updated.");

                // Reduce cooldowns for player's skills
                foreach (var skill in player.Skills)
                {
                    skill.ReduceCooldown();
                }

                if (enemy.IsAlive())
                {
                    enemy.Attack(character);
                    Console.WriteLine($"{character.Name} tersisa Health: {character.Health}");
                }
            }

            if (character.IsAlive())
            {
                Console.WriteLine($"{character.Name} menang!");
            }
            else
            {
                Console.WriteLine($"{enemy.Name} menang!");
            }
        }

        private static void UseSkill(Player player, Character enemy)
        {
            Console.WriteLine("Pilih skill untuk digunakan:");
            // Assuming player has a list of skills
            for (int i = 0; i < player.Skills.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {player.Skills[i].Name} (Cooldown: {player.Skills[i].Cooldown})");
            }

            if (int.TryParse(Console.ReadLine(), out int skillIndex) && skillIndex > 0 && skillIndex <= player.Skills.Count)
            {
                var skill = player.Skills[skillIndex - 1];
                ShowOriginalStats(player, enemy);

                skill.Use(player, enemy);

                if (skill is BuffSkill)
                {
                    Console.WriteLine($"Attack Power increased from {player.OriginalAttackPower} to {player.AttackPower}");
                    Console.WriteLine($"Defense increased from {player.OriginalDefense} to {player.Defense}");
                }
                else if (skill is DebuffSkill)
                {
                    Console.WriteLine($"Enemy Health decreased from {enemy.OriginalHealth} to {enemy.Health}");
                }
            }
            else
            {
                Console.WriteLine("Pilihan skill tidak valid.");
            }
        }

        private static void Defend(Player player)
        {
            Console.WriteLine($"{player.Name} is defending!");
            player.IsDefending = true; // Set defending flag
        }

        private static void ShowOriginalStats(Player player, Character enemy)
        {
            player.OriginalAttackPower = player.AttackPower;
            player.OriginalDefense = player.Defense;
            enemy.OriginalHealth = enemy.Health;
        }
    }
}
