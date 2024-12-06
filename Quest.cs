public class Quest
{
    public string Title { get; set; }
    public string Description { get; set; }
    public List<string> Objectives { get; private set; }
    public string Reward { get; set; }
    public bool IsCompleted { get; private set; }
    private int damageDealt;

    public Quest(string title, string description, List<string> objectives, string reward)
    {
        Title = title;
        Description = description;
        Objectives = objectives;
        Reward = reward;
        IsCompleted = false;
        damageDealt = 0;
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

    public void TrackDamageDealt(int damage)
    {
        damageDealt += damage;
        if (damageDealt >= 50 && Objectives.Contains("Deal 50 Damage"))
        {
            CompleteObjective("Deal 50 Damage");
        }
    }
}
