using System.IO;

namespace Tax0r_Proxy_Checker.Classes
{
    class FileHelperClass
    {
        public string[] ReadLines(string path)
        {
            return File.ReadAllLines(path);
        }

        public void WriteLines(string path, string[] lines)
        {
            File.WriteAllLines(path, lines);
        }

        public int GetAmountOfLines(string path)
        {
            string[] lines = File.ReadAllLines(path);
            int amount = 0;
            foreach (string line in lines) amount++;
            return amount;
        }
    }
}
