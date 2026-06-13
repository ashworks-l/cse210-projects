using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;

    public void Start()
    {
        int choice = 0;

        while (choice != 6)
        {
            Console.Clear();

            Console.WriteLine($"Score: {_score}");
            Console.WriteLine($"Level: {GetLevel()}");
            Console.WriteLine();

            Console.WriteLine("1. Create Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");

            Console.Write("\nChoice: ");
            int.TryParse(Console.ReadLine(), out choice);

            switch (choice)
            {
                case 1: CreateGoal(); break;
                case 2: ListGoals(); break;
                case 3: SaveGoals(); break;
                case 4: LoadGoals(); break;
                case 5: RecordEvent(); break;
            }
        }
    }

    private int GetLevel()
    {
        return (_score / 1000) + 1;
    }

    private int ReadInt(string prompt)
    {
        int value;
        Console.Write(prompt);

        while (!int.TryParse(Console.ReadLine(), out value))
        {
            Console.Write("Invalid input. Try again: ");
        }

        return value;
    }

    private void CreateGoal()
    {
        Console.WriteLine("1. Simple");
        Console.WriteLine("2. Eternal");
        Console.WriteLine("3. Checklist");

        int type = ReadInt("Type: ");

        Console.Write("Name: ");
        string name = Console.ReadLine();

        Console.Write("Description: ");
        string desc = Console.ReadLine();

        int points = ReadInt("Points: ");

        if (type == 1)
            _goals.Add(new SimpleGoal(name, desc, points));

        else if (type == 2)
            _goals.Add(new EternalGoal(name, desc, points));

        else if (type == 3)
        {
            int target = ReadInt("Target: ");
            int bonus = ReadInt("Bonus: ");

            _goals.Add(new ChecklistGoal(name, desc, points, target, bonus));
        }
    }

    private void ListGoals()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals yet.");
            Console.ReadLine();
            return;
        }

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }

        Console.ReadLine();
    }

    private void RecordEvent()
    {
        ListGoals();

        int index = ReadInt("Goal #: ") - 1;

        if (index < 0 || index >= _goals.Count) return;

        int earned = _goals[index].RecordEvent();
        _score += earned;

        Console.WriteLine($"You earned {earned} points!");
        Console.ReadLine();
    }

    private void SaveGoals()
    {
        Console.Write("Filename: ");
        string file = Console.ReadLine();

        using (StreamWriter output = new StreamWriter(file))
        {
            output.WriteLine(_score);

            foreach (Goal g in _goals)
                output.WriteLine(g.GetStringRepresentation());
        }
    }

    private void LoadGoals()
    {
        Console.Write("Filename: ");
        string file = Console.ReadLine();

        string[] lines = File.ReadAllLines(file);

        _goals.Clear();
        _score = int.Parse(lines[0]);

        for (int i = 1; i < lines.Length; i++)
        {
            string[] p = lines[i].Split('|');

            switch (p[0])
            {
                case "SimpleGoal":
                    _goals.Add(new SimpleGoal(p[1], p[2], int.Parse(p[3]), bool.Parse(p[4])));
                    break;

                case "EternalGoal":
                    _goals.Add(new EternalGoal(p[1], p[2], int.Parse(p[3])));
                    break;

                case "ChecklistGoal":
                    _goals.Add(new ChecklistGoal(
                        p[1], p[2],
                        int.Parse(p[3]),
                        int.Parse(p[5]),
                        int.Parse(p[4]),
                        int.Parse(p[6])));
                    break;
            }
        }
    }
}