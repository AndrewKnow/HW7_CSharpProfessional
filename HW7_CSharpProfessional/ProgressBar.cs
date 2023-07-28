using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW7_CSharpProfessional
{
    public class ProgressBar
    {
        public static bool StopProgress { get; set; } = false;


        int counter;

        public ProgressBar()
        {
            counter = 0;
        }
        public void Turn()
        {
            counter++;

            if (StopProgress == false)
            {
                Thread.Sleep(300);

                switch (counter % 4)
                {
                    case 0: Console.Write("/"); break;
                    case 1: Console.Write("-"); break;
                    case 2: Console.Write("\\"); break;
                    case 3: Console.Write("|"); break;
                }
                Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
            }

        }
    }
}
