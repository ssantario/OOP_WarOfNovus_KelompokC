public class Quest
{
    public string Title { get; set; }
    public string Description { get; set; }
    public List<string> Objectives { get; private set; }
    public string Reward { get; set; }
    public bool IsCompleted { get; private set; }
    public int damageDealt;
    public int enemiesDefeated;
    public int skillsUsed;
    public int CompletionParameter;

    public Quest(string title, string description, List<string> objectives, string reward, int completionParameter)
    {
        Title = title;
        Description = description;
        Objectives = objectives;
        Reward = reward;
        IsCompleted = false;
        damageDealt = 0;
        enemiesDefeated = 0;
        skillsUsed = 0;
        CompletionParameter = completionParameter;
    }

    public void CompleteObjective(string objective)
    {
        if (Objectives.Contains(objective))
        {
            Objectives.Remove(objective);
            Console.WriteLine($"Objective '{objective}' completed.");

            if (Objectives.Count == 0)
            {
                IsCompleted = true;
                Console.WriteLine($"Quest '{Title}' completed! Reward: {Reward}");
            }
        }
    }

    public void CompletionChecker(string objective)
    {
        if (Title == "Use Skills")
        {
            if (skillsUsed >= CompletionParameter)
            {
                CompleteObjective(objective);
            }

            else
            {
                Console.WriteLine($"Quest '{Title}' is not yet completed, reward still locked.");
            }
        }

        else if (Title == "Deal Damage")
        {
            if (damageDealt >= CompletionParameter)
            {
                CompleteObjective(objective);
            }
            else
            {
                Console.WriteLine($"Quest '{Title}' is not yet completed, reward still locked.");
            }
        }

        else if (Title == "Defeat Enemies")
        {
            if (enemiesDefeated >= CompletionParameter)
            {
                CompleteObjective(objective);
            }

            else
            {
                Console.WriteLine($"Quest '{Title}' is not yet completed, reward still locked.");
            }
        }
    }

    public void TrackDamageDealt(int damage)
    {
        damageDealt += damage;
    }

    public void TrackEnemyDefeated()
    {
        enemiesDefeated++;
    }

    public void TrackSkillUsed()
    {
        skillsUsed++;
    }
}
