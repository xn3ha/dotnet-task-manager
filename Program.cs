using System;
using System.Collections.Generic;

class TaskItem
{
    public string Description { get; }
    public bool IsCompleted { get; set; }

    public TaskItem(string desc)
    {
        Description = desc;
        IsCompleted = false;
    }
}

class Program
{
    static List<TaskItem> tasks = new();

    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Task Manager ===");
            Console.WriteLine($"Tasks: {tasks.Count}");
            Console.WriteLine("1. Add Task");
            Console.WriteLine("2. View Tasks");
            Console.WriteLine("3. Mark Complete");
            Console.WriteLine("4. Delete Task");
            Console.WriteLine("5. Exit");
            Console.Write("Choose (1-5): ");
            string? choice = Console.ReadLine();

            if (choice == "1") AddTask();
            else if (choice == "2") ViewTasks();
            else if (choice == "3") MarkComplete();
            else if (choice == "4") DeleteTask();
            else if (choice == "5") return;
            else { Console.WriteLine("Invalid!"); Console.ReadKey(); }
        }
    }

    static void AddTask()
    {
        Console.Write("Enter task: ");
        string? desc = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(desc))
        {
            tasks.Add(new TaskItem(desc));
            Console.WriteLine("Task added!");
        }
        else Console.WriteLine("Empty ignored.");
        Console.WriteLine("Press any key...");
        Console.ReadKey();
    }

    static void ViewTasks()
    {
        if (tasks.Count == 0) { Console.WriteLine("No tasks."); Console.ReadKey(); return; }
        for (int i = 0; i < tasks.Count; i++)
        {
            string status = tasks[i].IsCompleted ? "[X]" : "[ ]";
            Console.WriteLine($"{i+1}. {status} {tasks[i].Description}");
        }
        Console.WriteLine("Press any key...");
        Console.ReadKey();
    }

    static void MarkComplete()
    {
        ViewTasks();
        if (tasks.Count == 0) return;
        Console.Write("Task number: ");
        if (int.TryParse(Console.ReadLine(), out int num) && num > 0 && num <= tasks.Count)
        {
            tasks[num-1].IsCompleted = true;
            Console.WriteLine("Marked complete!");
        }
        else Console.WriteLine("Invalid number.");
        Console.ReadKey();
    }

    static void DeleteTask()
    {
        ViewTasks();
        if (tasks.Count == 0) return;
        Console.Write("Task number: ");
        if (int.TryParse(Console.ReadLine(), out int num) && num > 0 && num <= tasks.Count)
        {
            tasks.RemoveAt(num-1);
            Console.WriteLine("Deleted!");
        }
        else Console.WriteLine("Invalid number.");
        Console.ReadKey();
    }
}