using System;
using System.Collections.Generic;

public enum Priority
{
    Urgent = 1,
    Important = 2,
    Needs = 3,
    Today = 4,
    Eventually = 5
}

public class Task
{
    public string Name { get; set; }
    public Priority Priority { get; set; }
    public TimeSpan TimeNeeded { get; set; }
    public bool IsCompleted { get; set; }
    public bool IsFocused { get; set; }

    public Task(string name, Priority priority, TimeSpan timeNeeded)
    {
        Name = name;
        Priority = priority;
        TimeNeeded = timeNeeded;
        IsCompleted = false;
        IsFocused = false;
    }
}

public class TaskBuddy
{
    public string Name { get; set; }

    public TaskBuddy(string name)
    {
        Name = name;
    }

    public void Alert(string message)
    {
        Console.WriteLine($"Task Buddy {Name} alerted: {message}");
    }
}

public class FocusManager
{
    private List<Task> tasks = new List<Task>();
    private List<TaskBuddy> buddies = new List<TaskBuddy>();
    private Dictionary<TaskBuddy, List<Task>> assignedTasks = new Dictionary<TaskBuddy, List<Task>>();
    private DateTime? activeAlarm;

    public void AddTask(Task task)
    {
        tasks.Add(task);
    }

    public void AssignTaskToBuddy(Task task, TaskBuddy buddy)
    {
        // Check if the task exists in the list of tasks
        if (!tasks.Contains(task))
        {
            Console.WriteLine("Error: Task does not exist.");
            return;
        }

        // Check if the buddy exists in the list of buddies
        if (!buddies.Contains(buddy))
        {
            Console.WriteLine("Error: Task buddy does not exist.");
            return;
        }

        // Assign the task to the buddy
        // For simplicity, let's assume we add the task to a dictionary with the buddy as the key
        // In a real-world scenario, you may have a more sophisticated assignment mechanism
        if (!assignedTasks.ContainsKey(buddy))
        {
            assignedTasks[buddy] = new List<Task>();
        }
        assignedTasks[buddy].Add(task);

        Console.WriteLine($"Task '{task.Name}' assigned to buddy '{buddy.Name}'.");
    }


    public void CheckTaskFocus()
    {
        foreach (Task task in tasks)
        {
            // Check if the task is marked as completed, if so, skip focus check
            if (task.IsCompleted)
            {
                continue;
            }

            // Check if the task is marked as focused
            if (task.IsFocused)
            {
                Console.WriteLine($"Task '{task.Name}' is currently being focused on.");
            }
            else
            {
                Console.WriteLine($"Task '{task.Name}' needs attention.");
                // Here you can add additional logic like sending reminders or notifications
            }
        }
    }


    public void SnoozeAlarm(int snoozeTime)
    {
        // Check if there is an active alarm
        if (activeAlarm == null)
        {
            Console.WriteLine("No active alarm to snooze.");
            return;
        }

        // Snooze the active alarm by adding snoozeTime to its current time
        activeAlarm = activeAlarm.Value.AddMinutes(snoozeTime);

        Console.WriteLine($"Alarm snoozed for {snoozeTime} minutes.");
    }


    public bool TurnOffAlarm(string passcode)
    {
        // Predefined passcode to turn off the alarm
        string correctPasscode = "YourPredefinedPasscode";

        // Check if the provided passcode matches the correct passcode
        if (passcode == correctPasscode)
        {
            Console.WriteLine("Alarm turned off.");
            return true; // Return true to indicate successful alarm turn off
        }
        else
        {
            Console.WriteLine("Incorrect passcode. Alarm remains active.");
            return false; // Return false to indicate incorrect passcode
        }
    }


    public void CompleteTask(Task task)
    {
        // Mark the specified task as completed
        task.IsCompleted = true;
        Console.WriteLine($"Task '{task.Name}' marked as completed.");
    }

    public void SetTaskFocus(Task task, bool isFocused)
    {
        // Set the focus status of the specified task
        task.IsFocused = isFocused;
        if (isFocused)
        {
            Console.WriteLine($"Focus set on task '{task.Name}'.");
        }
        else
        {
            Console.WriteLine($"Focus removed from task '{task.Name}'.");
        }
    }

    public void AddAlarm(DateTime alarmTime)
    {
        // Add a new alarm with the specified time
        activeAlarm = alarmTime;
        Console.WriteLine($"Alarm set for {alarmTime}.");
    }

    public void CancelAlarm()
    {
        // Cancel the active alarm
        activeAlarm = null;
        Console.WriteLine("Alarm canceled.");
    }

}

class Program
{
    static void Main(string[] args)
    {
        FocusManager focusManager = new FocusManager();

        Task task1 = new Task("Complete project", Priority.Urgent, TimeSpan.FromHours(3));
        Task task2 = new Task("Reply to emails", Priority.Important, TimeSpan.FromMinutes(30));

        focusManager.AddTask(task1);
        focusManager.AddTask(task2);

        TaskBuddy buddy = new TaskBuddy("John");
        focusManager.AssignTaskToBuddy(task1, buddy);

        // Example usage of other methods
        focusManager.CheckTaskFocus();
        focusManager.SnoozeAlarm(10);
        bool alarmOff = focusManager.TurnOffAlarm("password12345678");
        Console.WriteLine($"Alarm turned off: {alarmOff}");
    }
}
