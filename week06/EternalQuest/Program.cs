class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}

/*
EXCEEDING REQUIREMENTS

Added a Level System:
- Level 1: 0 points
- Level 2: 1000 points
- Level 3: 2500 points
- Level 4: 5000 points

The player's level is displayed in the menu based on total score.
*/