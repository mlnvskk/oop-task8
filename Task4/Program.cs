using System;

/*Даний інтерфейс поганий тим, що він включає занадто багато методів.
 А що, якщо наш клас товарів не може мати знижок або промокодом, або для нього немає сенсу встановлювати матеріал з 
 якого зроблений (наприклад, для книг). Таким чином, щоб не реалізовувати в кожному класі невикористовувані в ньому методи, краще 
розбити інтерфейс на кілька дрібних і кожним конкретним класом реалізовувати потрібні інтерфейси.
Перепишіть, розбивши інтерфейс на декілька інтерфейсів, керуючись принципом розділення інтерфейсу. 
Опишіть класи книжки (розмір та колір не потрібні, але потрібна ціна та знижки) та верхній одяг (колір, розмір, ціна знижка),
які реалізують притаманні їм інтерфейси.*/
public interface IPriceable
{
    void SetPrice(double price);
}
public interface IDiscountable
{
    void ApplyDiscount(string discount);
    void ApplyPromocode(string promocode);
}
public interface IPhysicalProduct
{
    void SetColor(byte color);
    void SetSize(byte size);
}
class Book : IPriceable, IDiscountable
{
    private double _price;

    public void SetPrice(double price)
    {
        _price = price;
        Console.WriteLine($"Книзі встановлено ціну: {_price} грн.");
    }

    public void ApplyDiscount(string discount)
    {
        Console.WriteLine($"До книги застосовано знижку: {discount}.");
    }

    public void ApplyPromocode(string promocode)
    {
        Console.WriteLine($"До книги застосовано промокод: {promocode}.");
    }
    
}
class Outerwear : IPriceable, IDiscountable, IPhysicalProduct
{
    private double _price;
    private byte _size;
    private byte _color;

    public void SetPrice(double price)
    {
        _price = price;
        Console.WriteLine($"Верхньому одягу встановлено ціну: {_price} грн.");
    }

    public void ApplyDiscount(string discount)
    {
        Console.WriteLine($"До одягу застосовано знижку: {discount}.");
    }

    public void ApplyPromocode(string promocode)
    {
        Console.WriteLine($"До одягу застосовано промокод: {promocode}.");
    }

    public void SetColor(byte color)
    {
        _color = color;
        Console.WriteLine($"Встановлено колір одягу: {color}.");
    }

    public void SetSize(byte size)
    {
        _size = size;
        Console.WriteLine($"Встановлено розмір одягу: {size}.");
    }
}
class Program
{
    static void Main(string[] args)
    {
        Book novel = new Book();
        novel.SetPrice(450.00);
        novel.ApplyDiscount("15%");
        
        Outerwear jacket = new Outerwear();
        jacket.SetPrice(2500.00);
        jacket.SetSize(44);
        jacket.SetColor(5);
        jacket.ApplyPromocode("JACKET15");

        Console.ReadKey();
    }
}