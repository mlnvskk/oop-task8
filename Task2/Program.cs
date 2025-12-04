using System;

//Який принцип S.O.L.I.D. порушено? Виправте! Порушено Single Responsibility Principle (Принцип єдиної відповідальності).

/*Зверніть увагу на клас EmailSender. Крім того, що за допомогою методу Send, він відправляє повідомлення, 
він ще і вирішує як буде вестися лог. В даному прикладі лог ведеться через консоль.
Якщо трапиться так, що нам доведеться міняти спосіб логування, то ми будемо змушені внести правки в клас EmailSender.
Хоча, здавалося б, ці правки не стосуються відправки повідомлень. Очевидно, EmailSender виконує кілька обов'язків і, 
щоб клас ні прив'язаний тільки до одного способу вести лог, потрібно винести вибір балки з цього класу.*/
class Email
{
    public String Theme { get; set; }
    public String From { get; set; }
    public String To { get; set; }
}
public interface ILogger
    {
        void Log(string message);
    }

public class FileLogger : ILogger
    {
        public void Log(string message)
        {
            
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"[FILE LOG SIMULATION]: Writing to log file: {message}");
            Console.ResetColor();
        }
    }
public class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"[CONSOLE LOG]: {message}");
            Console.ResetColor();
        }
    }
class EmailSender
{
    private readonly ILogger _logger;


        public EmailSender(ILogger logger)
        {

            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public void Send(Email email)
        {
            string logMessage = $"Email (Theme: '{email.Theme}') from '{email.From}' to '{email.To}' was successfully sent.";
            _logger.Log(logMessage);
        }
}

class Program
{
    static void Main(string[] args)
    {
ILogger preferredLogger = new ConsoleLogger(); 
            
            EmailSender es = new EmailSender(preferredLogger);

            Email e1 = new Email() { From = "Me", To = "Vasya", Theme = "Who are you?" };
            Email e2 = new Email() { From = "Vasya", To = "Me", Theme = "vacuum cleaners!" };
            Email e3 = new Email() { From = "Kolya", To = "Vasya", Theme = "No! Thanks!" };
            Email e4 = new Email() { From = "Vasya", To = "Me", Theme = "washing machines!" };
            Email e5 = new Email() { From = "Me", To = "Vasya", Theme = "Yes" };
            Email e6 = new Email() { From = "Vasya", To = "Petya", Theme = "+2" };
 
            es.Send(e1);
            es.Send(e2);
            es.Send(e3);
            es.Send(e4);
            es.Send(e5);
            es.Send(e6);

            Console.ReadKey();
    }
}