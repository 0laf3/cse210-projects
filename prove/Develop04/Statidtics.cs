// Add a Statistics class to track activity usage
public static class Statistics
{
    private static Dictionary<string, int> activityCounts = new Dictionary<string, int>();

    public static void IncrementActivityCount(string activityName)
    {
        if (activityCounts.ContainsKey(activityName))
        {
            activityCounts[activityName]++;
        }
        else
        {
            activityCounts.Add(activityName, 1);
        }
    }

    public static int GetActivityCount(string activityName)
    {
        return activityCounts.ContainsKey(activityName) ? activityCounts[activityName] : 0;
    }

    public static void DisplayStatistics()
    {
        Console.WriteLine("\nActivity Statistics:");
        foreach (var kvp in activityCounts)
        {
            Console.WriteLine($"{kvp.Key}: {kvp.Value} times");
        }
        Console.WriteLine();
    }
}