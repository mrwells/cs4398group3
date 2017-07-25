using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficControlSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\nTraffic Control System\n");

            if (args.Length != 1)
            {
                Console.WriteLine("The configuration file name must be provided.");
                Console.WriteLine("   ex:  'program.exe config.txt'");
                return;
            }

            var configurationFile = args[0];
            var configuration = Configuration.Load(configurationFile);

            Console.WriteLine(configuration);
            


        }
    }
}
