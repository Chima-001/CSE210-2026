using System;

class Program
{
    static void Main(string[] args)
    {
        Video vid1 = new("Python Tutorial for Beginners", "Programming With Mosh", 3796);
        Video vid2 = new("How to Build a Budget PC", "Linus Tech Tips", 1583);
        Video vid3 = new("Photosynthesis Explained", "Kurzgesagt", 614);
        Video vid4 = new("The Art of Code", "Dylan Beattie", 4224);
        //Console.WriteLine(vid1.Display());

        Comment vid1Com1 = new("Alex Turner", "This is the best Python tutorial I've found!");
        Comment vid1Com2 = new("Sarah Kim", "Finally understood functions after watching this");
        Comment vid1Com3 = new("James Obi", "Been coding for a week now thanks to this video");
        Comment vid1Com4 = new("Nina Ross", "Mosh explains everything so clearly");

        Comment vid2Com1 = new("Mike Daniels", "Built my first PC following this, works perfectly");
        Comment vid2Com2 = new("Rachel Green", "The cable management tips were super helpful");
        Comment vid2Com3 = new("Tom Brady", "Best budget build guide on YouTube");
        Comment vid2Com4 = new("Chris Evans", "Saved me so much money on my build");

        Comment vid3Com1 = new("Emma Wilson", "This channel makes science so easy to understand");
        Comment vid3Com2 = new("David Lee", "Showed this to my whole class");
        Comment vid3Com3 = new("Priya Patel", "The animation quality is insane");
        Comment vid3Com4 = new("Jake Morton", "Never thought I'd enjoy learning about photosynthesis");

        Comment vid4Com1 = new("Chris Martin", "Watched this three times, still finding new things");
        Comment vid4Com2 = new("Laura Chen", "Every developer needs to see this talk");
        Comment vid4Com3 = new("Ben Foster", "Changed how I think about programming");
        Comment vid4Com4 = new("Amy Scott", "This is why I love the software community");

        List<Video> videos =
        [
            vid1,
            vid2,
            vid3,
            vid4
        ];

        vid1.AddComment(vid1Com1);
        vid1.AddComment(vid1Com2);
        vid1.AddComment(vid1Com3);
        vid1.AddComment(vid1Com4);

        vid2.AddComment(vid2Com1);
        vid2.AddComment(vid2Com2);
        vid2.AddComment(vid2Com3);
        vid2.AddComment(vid2Com4);

        vid3.AddComment(vid3Com1);
        vid3.AddComment(vid3Com2);
        vid3.AddComment(vid3Com3);
        vid3.AddComment(vid3Com4);

        vid4.AddComment(vid4Com1);
        vid4.AddComment(vid4Com2);
        vid4.AddComment(vid4Com3);
        vid4.AddComment(vid4Com4);

        foreach (Video video in videos)
        {
            Console.WriteLine(video.DisplayVideoInfo());
            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"> {comment.GetCommenterName()}: {comment.GetCommentText()}");
            }
            Console.WriteLine($"");
        }
    }
}