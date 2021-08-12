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


             private static List<string> GetHeadesTypeOf(FeedBackReportResponseModel results)
            {
                List<string> resList = new List<string>();
                Type t = results.items.FirstOrDefault().GetType();
                // Get the public properties.
                PropertyInfo[] propInfos = t.GetProperties(BindingFlags.Public | BindingFlags.Instance);
                foreach (var propInfo in propInfos)
                {
                    resList.Add(propInfo.Name);
                }
                return resList;
            }

            */
            Console.WriteLine("process end");
        }
    }
}
