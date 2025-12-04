using System;
// Порушено принцип Liskov Substitution Principle

public interface IShape
{
    int GetArea();
}
class Rectangle: IShape
{
    public int Width { get; set; }
    public int Height { get; set; }
    public int GetArea()
    {
        return Width * Height;
    }
}

class Square : IShape
{
    private int side;
    public int Side { 
        get{return side;}
        set{side = value;}
    }
        
    public int GetArea()
    {
        return Side * Side;
    }
}
class Program
{
    static void Main(string[] args)
    {
        Rectangle rect = new Rectangle();
        rect.Width = 5;
        rect.Height = 10;

        Console.WriteLine(rect.GetArea());
        //Відповідь 100? Що не так???
          
        Square sq = new Square();
        sq.Side = 10; 
        Console.WriteLine($"Площа Квадрата (10x10): {sq.GetArea()}");
        Console.ReadKey();
    }
}