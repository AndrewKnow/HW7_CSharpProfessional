using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW7_CSharpProfessional
{
    public class ParallelFileReader
    {
        public long ReadFiles(string path)
        {
            List<string> fileList = Directory.GetFiles(path, "*.txt").ToList();
            var sw = new Stopwatch();
            sw.Start();
            Parallel.ForEach(fileList, file =>
            {
                var file1Text = File.ReadAllText(file);
                var spaceCount = file1Text.Count(it => it == ' ');
                //Console.WriteLine($"{file}  {spaceCount}");
            });

            sw.Stop();
            return sw.ElapsedMilliseconds;
        }
    }
}
