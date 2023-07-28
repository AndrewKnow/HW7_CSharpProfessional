using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace HW7_CSharpProfessional
{
    internal class Program
    {

        static void Main()
        {
            // пп. 1
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Прочитать 3 файла параллельно и вычислить количество пробелов в них (через Task):");
            Console.ForegroundColor = ConsoleColor.White;

            var (file1, file2, file3) = ("file1.txt", "file2.txt", "file3.txt");

            WorkingWithFiles.CreateFiles(file1, file2, file3);

            Task task1 = Task.Run(() =>
            {
                Console.WriteLine($"File {file1} contains {WorkingWithFiles.CountSpacesInFile(file1)} spaces");
            });
            Task task2 = Task.Run(() =>
            {
                Console.WriteLine($"File {file2} contains {WorkingWithFiles.CountSpacesInFile(file2)} spaces");
            });
            Task task3 = Task.Run(() =>
            {
                Console.WriteLine($"File {file3} contains {WorkingWithFiles.CountSpacesInFile(file3)} spaces");
            });

            Task.WaitAll(task1, task2, task3);


            // пп. 2 - 3
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Написать функцию, принимающую в качестве аргумента путь к папке. " +
                "Из этой папки параллельно прочитать все файлы и вычислить количество пробелов в них.");
            Console.ForegroundColor = ConsoleColor.White;

            var CountOfFiles = 10000;

            Console.WriteLine($"Заупуск процедуры считывания {CountOfFiles} файлов");

            Task taskPB = Task.Run(() =>
            {
                ProgressBar progressBar = new();
                while (true)
                {
                    progressBar.Turn();
                }
            });

            string path = Directory.GetCurrentDirectory() + @"\Папка";
            DirectoryInfo di = new DirectoryInfo(path);
            try
            {
                di.Delete(true);
            }
            catch
            {
                Console.WriteLine("Ошибка удаления папки и файлов");
            }

            Directory.CreateDirectory("Папка");


            WorkingWithFiles.CreateFilesWithRandomWhitespaces(path, CountOfFiles);

            // паралелльное чтение файлов
            var sw1 = new Stopwatch();

            sw1.Start();
            List<Task> tasks = new List<Task>();    
            foreach (FileInfo file in di.GetFiles())
            {
                //Task taskFile = Task.Run(() => Console.WriteLine($"Task: {file.Name} {WorkingWithFiles.CountSpacesInFile(file.FullName)} spaces"));
                Task taskFile = Task.Run(() => WorkingWithFiles.CountSpacesInFile(file.FullName));
                tasks.Add(taskFile);
            }
            Task.WaitAll(tasks.ToArray());
            sw1.Stop();
          
            // последовательное чтение файлов
            var sw2 = new Stopwatch();
            sw2.Start();
            foreach (FileInfo file in di.GetFiles())
            {
                //Console.WriteLine($"Цикл: {file.Name} {WorkingWithFiles.CountSpacesInFile(file.FullName)} spaces");
                WorkingWithFiles.CountSpacesInFile(file.FullName);
            }
            sw2.Stop();
            ProgressBar.StopProgress = false;

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Итоги:");
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine($"Время обработки из Task {sw1.ElapsedMilliseconds} мс");
            Console.WriteLine($"Время обработки последовательно {sw2.ElapsedMilliseconds} мс");
        }

    }
}