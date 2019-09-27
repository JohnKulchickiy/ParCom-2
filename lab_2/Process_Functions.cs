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
        private Process[] _processes;

        public Process_Functions()
        {
            _processes = _GetActual();
        }

        /// <summary>
        /// Получить список актуальных процессов локальной машины
        /// </summary>
        /// <returns></returns>
        public Process[] _GetActual()
        {
            Process[] _proc = Process.GetProcesses();
            Console.WriteLine("Актуальные процессы:");
            foreach (Process proc in _proc)
            {
                try
                {
                    Console.WriteLine($"Компьютер:{proc.MachineName}\t Идентификатор:{proc.Id}\t Время начала процесса:{proc.StartTime}\t Имя:{proc.ProcessName}");
                }
                catch (Exception e)
                {
                    //Console.WriteLine("Ошибка - " + e.Message);
                }
            }
            return _proc;
        }



    }
}
