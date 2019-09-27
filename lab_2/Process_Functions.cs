using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_2
{
    class Process_Functions
    {
        /// <summary>
        /// Вывод актуальных процессов в консоль
        /// </summary>
        /// <param name="proc">Массив процессов типа Process<</param>
        static public void _showActual(Process[] proc)
        {
            Console.WriteLine("Актуальные процессы:");
            foreach (Process process in proc)
            {
                try
                {
                    Console.WriteLine($"Компьютер:{process.MachineName}\t Идентификатор:{process.Id}\t Время начала процесса:{process.StartTime}\t Имя:{process.ProcessName}");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Ошибка - " + e.Message);
                }
            }
        }


    }
}
