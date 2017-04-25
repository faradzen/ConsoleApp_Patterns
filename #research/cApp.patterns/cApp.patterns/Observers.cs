using System;

namespace cApp.patterns
{
    internal interface ISubject
    {
        void Register();
        void Remove();
        void Notify();
    }

    internal interface IObserver
    {
        void Update();
    }

    internal class ConcreteSubject : ISubject
    {
        public void Register()
        {

        }

        public void Remove()
        {

        }

        public void Notify()
        {

        }

        public void GetState()
        {

        }

        public void SetState()
        {

        }
    }

    internal class ConcreteObserver1 : IObserver
    {
        public void Update()
        {
            Console.WriteLine("observer 1 updated");
        }
    }

    internal class ConcreteObserver2 : IObserver
    {
        public void Update()
        {
            Console.WriteLine("observer 2 updated");
        }
    }
}
