public class Video
{
    private string _title;
    private string _author;
    private int _lengthInSeconds;
    private List<Comment> _comments;

    public Video(string title, string author, int length)
    {
        _title = title;
        _author = author;
        _lengthInSeconds = length;
        _comments = [];
    }

    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    public int CalcComments()
    {
        return _comments.Count();
    }

    public string GetTitle()
    {
        return _title;
    }

    public string GetAuthor()
    {
        return _author;
    }
    public int GetLengthInSeconds()
    {
        return _lengthInSeconds;
    }

    public string DisplayVideoInfo()
    {
        return $"Video Title: {_title}\nAuthor: {_author}\nLength: {_lengthInSeconds} seconds\nComments: {CalcComments()}.";
    }

    public List<Comment> GetComments()
    {
        return _comments;
    }
}