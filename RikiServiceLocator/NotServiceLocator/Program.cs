using System;

namespace NotServiceLocator
{
    class Program
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
            private readonly IOperatingSystem _operatingSystem = null;
            public Computer()
            {
                _operatingSystem = new Windows();
                Console.WriteLine("Service Locator: " + _operatingSystem.Name);
            }
            public void Start()
            {
                _operatingSystem.Run();
            }
        }
        static void Main(string[] args)
        {
            var computer = new Computer();
            computer.Start();
            Console.Read();
        }
    }
}
