using System;
using System.Collections;


namespace _911_ConsoleApp_Observer
{
    public interface INotify
    {
        void Notify();
    }

    class MailNotif : INotify
    {
        public void Notify()
        {
            Console.WriteLine("Mail notification");
        }
    }

    class SmsNotif : INotify
    {
        public void Notify()
        {
            Console.WriteLine("Sms notification");
        }
    }

    class EventNotif : INotify
    {
        public void Notify()
        {
            Console.WriteLine("Event notification");
        }
    }

    class Notifier
    {
        ArrayList _notificators = new ArrayList();
        public void AddNotif(INotify n)
        {
            _notificators.Add(n);
        }
        public void RemoveNotif(INotify n)
        {
            _notificators.Remove(n);
        }
        public void NotifAll()
        {
            foreach (INotify notificator in _notificators)
            {
                notificator.Notify();
            }
        }
    }

    class Program
    {
        static void Main()
        {
            Console.WriteLine("Observer");
            var n1 = new MailNotif();
            var n2 = new SmsNotif();
            var observer = new Notifier();
            observer.AddNotif(n1);
            observer.AddNotif(n2);
            observer.NotifAll();
            Console.WriteLine("REMOVE ONE");
            observer.RemoveNotif(n1);
            observer.NotifAll();
            Console.ReadKey();
        }
    }
}
