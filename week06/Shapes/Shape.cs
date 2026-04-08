public class Shape
{
    private string _color;
    private string _name;

    public Shape(string name, string color)
    {
        _color = color;
        _name = name;
    }

    public string GetName()
    {
        return _name;
    }
    
    public string GetColor()
    {
        return _color;
    }

    public void SetColor(string newColor)
    {
        _color = newColor;
    }

    public virtual double GetArea()
    {
        return 0;
    }

}