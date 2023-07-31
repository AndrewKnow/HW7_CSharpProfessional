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
        public static long ReadFiles(List<string> fileList)
        {
            var sw = new Stopwatch();
            sw.Start();
            Parallel.ForEach(fileList, file =>
            {
                var file1Text = File.ReadAllText(file);
                var spaceCount = file1Text.Count(it => it == ' ');
            });

            sw.Stop();
            return sw.ElapsedMilliseconds;
        }
    }
}
