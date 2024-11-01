using System.Globalization;

namespace _6_lab
{

    // Интерфейс для отправителей уведомлений
    public interface ISender
    {
        void Send(string message);
    }

    // Реализация для отправки email уведомлений
    public class EmailSender : ISender
    {
        public void Send(string message)
        {
            Console.WriteLine("Отправка Email: " + message);
        }
    }

    // Реализация для отправки SMS уведомлений
    public class SMSSender : ISender
    {
        public void Send(string message)
        {
            Console.WriteLine("Отправка SMS: " + message);
        }
    }

    // Абстрактный класс для уведомлений
    public abstract class Notification
    {
        protected ISender _sender;

        protected Notification(ISender sender)
        {
            _sender = sender;
        }

        // Абстрактный метод для отправки уведомлений
        public abstract void Send(string message);
    }

    // Класс текстовых уведомлений
    public class TextNotification : Notification
    {
        public TextNotification(ISender sender) : base(sender) { }

        public override void Send(string message)
        {
            _sender.Send(message);
        }
    }

    // Класс HTML уведомлений
    public class HtmlNotification : Notification
    {
        public HtmlNotification(ISender sender) : base(sender) { }

        public override void Send(string message)
        {
            // Форматируем сообщение как HTML
            string htmlMessage = $"<html><body><p>{message}</p></body></html>";
            _sender.Send(htmlMessage);
        }
    }

    // Основной класс программы
    class Program
    {
        static void Main()
        {
            // Создаем отправителей
            ISender emailSender = new EmailSender();
            ISender smsSender = new SMSSender();

            // Создаем текстовые уведомления
            Notification textEmailNotification = new TextNotification(emailSender);
            Notification textSMSNotification = new TextNotification(smsSender);

            // Создаем HTML уведомления
            Notification htmlEmailNotification = new HtmlNotification(emailSender);
            Notification htmlSMSNotification = new HtmlNotification(smsSender);

            // Отправляем уведомления
            textEmailNotification.Send("Это текстовое уведомление через Email");
            textSMSNotification.Send("Это текстовое уведомление через SMS");
            htmlEmailNotification.Send("Это HTML уведомление через Email");
            htmlSMSNotification.Send("Это HTML уведомление через SMS");
        }
    }
}
