using System;

namespace Curso.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("process init");


            /*

              public static string GetFile(string fileName)
                {
                    return File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "\\Templates\\" + fileName , System.Text.Encoding.UTF8);
                }

                public static string GetFileJson(string fileName)
                {
                    return File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "\\Templates\\" + fileName , System.Text.Encoding.UTF8);
                    //var algo = JsonConvert.DeserializeObject<Objeto>(string);
                }

                public static string GetAllFiles(string dirName)
                {
                    foreach (var file in Directory.EnumerateFiles(dirName, "*.json", SearchOption.AllDirectories))
                    {
                        Console.WriteLine(" - " + file);
               
                    }
                    return null;
                }

            */
            Console.WriteLine("process end");
        }
    }
}
