using System.IO;
using static System.Net.WebRequestMethods;

namespace HW7_CSharpProfessional
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Прочитать 3 файла параллельно и вычислить количество пробелов в них (через Task):");
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


            Console.WriteLine("Написать функцию, принимающую в качестве аргумента путь к папке. " +
                "Из этой папки параллельно прочитать все файлы и вычислить количество пробелов в них.");
            try
            {
                Directory.CreateDirectory("Папка");
            }
            catch
            {

                Console.WriteLine("Папка создана ранее");
            }
            

            string path = Directory.GetCurrentDirectory() + @"\Папка";

            WorkingWithFiles.CreateFilesWithRandomWhitespaces(path);




            //Console.ReadKey();

            Console.WriteLine("Finished");
        }
    }
}