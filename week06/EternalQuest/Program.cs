// 1. I added a gamification feature so users can accumulate points and level up or down depending on their habits.
// 2. I added a new class NegativeGoal to record bad habits and deduct points each time a bad habit is recorded.
// 3. I also added a delete goal method/feature so that users can delete goals they no longer want to track.
// 4. I updated the SaveGoals() and LoadGoals() method to work automatically after every change that requires saving
//    (creating goals, deleting goals, etc). LoadGoals() loads the goals automatically at startup. First time users
//    are asked for a filename. Returning users have their goals restored without any extra steps.

using System;

class Program
{
    static void Main(string[] args)
    {
       GoalManager manager = new();
       manager.Start();
    }
}