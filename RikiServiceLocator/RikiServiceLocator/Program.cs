using System;

namespace RikiServiceLocator
{
    public interface IOperatingSystem
    {
        string Name { get; set; }
        void Run();
    }
    public class Windows : IOperatingSystem
    {
        public string Name { get; set; }
        public Windows()
        {
            Name = "Windows A";
        }
        public void Run()
        {
            Console.WriteLine(Name + " is running.");
        }
    }
    public class Computer
    {
        private readonly IOperatingSystem _operatingSystem;
        public Computer()
        {
            _operatingSystem = ServiceLocator.Instance.GetService<IOperatingSystem>();
            Console.WriteLine("Service Locator: " +  _operatingSystem.Name);
        }
        public void Start()
        {
            _operatingSystem.Run();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ServiceLocator.Instance.Register<IOperatingSystem>(new Windows());
            var computer = new Computer();
            computer.Start();
            Console.Read();
        }
    }
}
