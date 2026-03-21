// 1. I created a library of scriptures to be randomly prompted at each start of 
//    the program (lines 35-43, 45-47).
// 2. I also took on the stretch challenge to only hide words that are not already 
//    hidden in the Scripture.cs class (lines 22-30)

using System;

class Program
{
    static void Main(string[] args)
    {
        Reference ref1 = new("Joshua", 1, 9);
        Reference ref2 = new("John", 3, 16);
        Reference ref3 = new("Mosiah", 2, 17);
        Reference ref4 = new("2 Nephi", 2, 25, 26);
        Reference ref5 = new("Doctrine and Covenants", 4, 5, 6);
        Reference ref6 = new("Proverbs", 3, 5, 6);

        //Console.WriteLine(ref1.GetDisplayText());

        Scripture script1 = new(ref1, "Be strong and of a good courage, be not afraid neither be thou dismayed for the Lord thy God is with thee withersoever thou goest.");

        Scripture script2 = new(ref2, "For God so loved the world that he gave his only begotten Son, that whosoever believeth in him should not perish but have everlasting life.");

        Scripture script3 = new(ref3, "When ye are in the service of your fellow beings, ye are only in service of your God.");

        Scripture script4 = new(ref4, "Adam fell that men might be and that men are that they might have joy. And the Messiah cometh in the fulness of time that he may redeem the children of men from the fall.");

        Scripture script5 = new(ref5, "And faith, hope, charity, and love with an eye single to the glory of God qualify him for the work. And remember faith, virtue, knowledge, temperance, patience, brotherly kindness, godliness, charity, humility, diligence.");

        Scripture script6 = new(ref6, "Trust in the Lord with all thine heart and lean not unto thine own understanding. In all thy ways acknowledge him and he shall direct thy paths.");

        //Console.WriteLine(script1.GetDisplayText());

        List<Scripture> scriptures =
        [
            script1,
            script2,
            script3,
            script4,
            script5,
            script6,
        ];

        Random random = new();
        int index = random.Next(scriptures.Count);
        Scripture scripts = scriptures[index];

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripts.GetDisplayText());
            if (scripts.IsCompletelyHidden())
            {
                break;
            }
            
            Console.WriteLine("Press enter to continue or type 'quit' to finish:");
            string userInput = Console.ReadLine();

            if (userInput.ToLower() == "quit")
            {
                break;
            }
            else
            {
                scripts.HideRandomWords(3);
            }
        }
    }

}