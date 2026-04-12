using System;

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = [];

        activities.Add(new Running("13 Jan 2025", 25, 2.3));
        activities.Add(new Running("07 Mar 2025", 50, 5.1));
        activities.Add(new Running("19 Aug 2024", 35, 3.7));

        activities.Add(null);

        activities.Add(new Cycling("02 Feb 2025", 40, 11.5));
        activities.Add(new Cycling("28 Jun 2024", 55, 8.3));
        activities.Add(new Cycling("11 Oct 2024", 20, 14.2));

        activities.Add(null);

        activities.Add(new Swimming("15 Apr 2025", 30, 17));
        activities.Add(new Swimming("03 Jan 2024", 48, 25));
        activities.Add(new Swimming("22 Jan 2024", 62, 33));

        foreach (Activity activity in activities)
        {
            if (activity == null) Console.WriteLine();
            else
            {
                Console.WriteLine(activity.GetSummary());
            }
        }
    }

}