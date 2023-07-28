using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW7_CSharpProfessional
{
    /// <summary>
    /// Работа с файлами
    /// </summary>
    public class WorkingWithFiles
    {
        /// <summary>
        /// Подсчёт пробелов
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static int CountSpacesInFile(string s)
        {
            var file1Text = File.ReadAllText(s);
            var spaceCount = file1Text.Count(it => it == ' ');
            return spaceCount;
        }

        /// <summary>
        /// Создание файлов для пп.1
        /// </summary>
        /// <param name="file1"></param>
        /// <param name="file2"></param>
        /// <param name="file3"></param>
        public static void CreateFiles(string file1, string file2, string file3)
        {
            var file1Content = "hello world";
            var file2Content = "hello great world";
            var file3Content = "hello funny great world";

            File.WriteAllText(file1, file1Content);
            File.WriteAllText(file2, file2Content);
            File.WriteAllText(file3, file3Content);
        }

        /// <summary>
        /// Создание заданного кол-ва файлов в папке с рандомным кол-вом пробелов
        /// </summary>
        /// <param name="path"></param>
        public static void CreateFilesWithRandomWhitespaces(string path)
        {
            for (int i = 0; i < 1000; i++)
            {
                FileStream fs = File.Create(path + "\\" + "filename" + i + ".txt");
                StreamWriter writer = new StreamWriter(fs);
                Random randomWhitespace = new Random();
                var countWhitespace = randomWhitespace.Next(1, 1000);

                Func<int, string> whiteSpace = x => new string(' ', x);

                writer.Write(whiteSpace(countWhitespace));
                writer.Close();
              
            }
        }
    }
}
