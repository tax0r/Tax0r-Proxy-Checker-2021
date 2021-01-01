using System;
using System.Collections.Generic;
using System.Drawing;
using Tax0r_Proxy_Checker.Classes;
using Console = Colorful.Console;

namespace Tax0r_Proxy_Checker
{
    class Program
    {
        static void Main(string[] args)
        {
            int good = 0;
            int bad = 0;
            int total = 0;
            int timeout = 0;

            Console.Title = $"tax0r Proxy Checker 2021 - Good: {good} / Bad: {bad} / Total: {total} | Timeout: {timeout}ms";

            Console.WriteLine("{+} drag&drop your proxylist [+]", Color.LightPink);

            string key = '"'.ToString();
            string input = Console.ReadLine();
            string path = input.Replace(key, string.Empty);

            Console.WriteLine("{+} enter desired timeout: ", Color.LightPink);

            input = Console.ReadLine();
            TimeSpan timeSpan = TimeSpan.FromSeconds(double.Parse(input));
            timeout = (int)timeSpan.TotalMilliseconds;

            WebHelperClass webHelper = new WebHelperClass();
            FileHelperClass fileHelper = new FileHelperClass();

            string[] proxies = fileHelper.ReadLines(path);
            List<string> goodProxies = new List<string>();
            List<string> badProxies = new List<string>();

            total = fileHelper.GetAmountOfLines(path);

            Console.Clear();
            foreach (string proxie in proxies)
            {
                
                if (webHelper.PingProxy(proxie, timeout))
                {
                    Console.WriteLine("{+} " + proxie, Color.Green);
                    goodProxies.Add(proxie);
                    good++;
                }
                else
                {
                    Console.WriteLine("{-} " + proxie, Color.Red);
                    badProxies.Add(proxie);
                    bad++;
                }
                Console.Title = $"tax0r Proxy Checker 2021 - Good: {good} / Bad: {bad} / Total: {total} | Timeout: {timeout}ms";
            }

            Console.Clear();
            Console.WriteLine("good Proxies: " + goodProxies.Count, Color.Green);
            Console.WriteLine("bad Proxies: " + badProxies.Count, Color.Red);

            path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\proxies (" + goodProxies.Count + ").txt";
            fileHelper.WriteLines(path, goodProxies.ToArray());
            Console.WriteLine("{+} wrote Proxies to: " + path, Color.LightPink);

            Console.WriteLine("\npress any key to exit the process...");
            Console.ReadKey();
        }
    }
}
