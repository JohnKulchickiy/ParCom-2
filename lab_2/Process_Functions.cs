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
        static public void _showActualProcess(Process[] processes)
        {
            Console.WriteLine("Актуальные процессы:");
            foreach (Process process in processes)
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

        /// <summary>
        /// Получает список процессов заданного потока 
        /// </summary>
        /// <param name="processes">Список всех процессов</param>
        static public void _showActualStreams(Process[] processes)
        {
            try
            {
                Console.Write("Введите ID процесса: ");
                Int32 _procID = Convert.ToInt32(Console.ReadLine());

                Process _targetProc = Process.GetProcessById(_procID);

                if(_targetProc == null)
                {
                    throw new Exception("Невозможно вывести список потоков так как такого процесса не существует");
                }
                else
                {
                    ProcessThreadCollection _processThreads = _targetProc.Threads;

                    foreach(ProcessThread thread in _processThreads)
                    {
                        Console.WriteLine($"Идентификатор потока:{thread.Id}\tТекущий приоритет потока:{thread.PriorityLevel}\tВремя запуска потока:{thread.StartTime}\tБазовый приоритет потока: {thread.BasePriority}");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка - " + e.Message);
            }
        }

        /// <summary>
        /// Выводит список модулей процесса
        /// </summary>
        /// <param name="processes">Список акутальных процессов</param>
        static public void _showActualModules(Process[] processes)
        {
            Console.Write("Введите ID процесса: ");
            Int32 _procID = Convert.ToInt32(Console.ReadLine());

            Process _targetProc = Process.GetProcessById(_procID);

            if (_targetProc == null)
            {
                throw new Exception("Невозможно вывести список модулей так как такого процесса не существует");
            }
            else
            {
                ProcessModuleCollection _processModule = _targetProc.Modules;

                foreach (ProcessModule module in _processModule)
                {
                    Console.WriteLine($"Имя модуля:{module.ModuleName}\tПуть к модулю:{module.FileName}\tОбьем памяти модуля:{module.ModuleMemorySize}");
                }
            }
        }

        /// <summary>
        /// Запускает процесс, который открывает произвольную веб страницу в браузере
        /// </summary>
        /// <param name="argument">Адрес веб страницы</param>
        static public void _startNewProcess(string argument)
        {
            try
            {
                Process.Start(@"C:\Users\avata\AppData\Local\Programs\Opera", argument);
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка - " + e.Message);
            }
        }

        /// <summary>
        /// Заканчивает выполнение выделенного пользователем процесса
        /// </summary>
        /// <param name="proc">Необходимый к завершению процесс</param>
        static public void _killExistingProcess(Process[] processes)
        {
            try
            {   
                Console.Write("Введите ID процесса: ");
                Int32 _procID = Convert.ToInt32(Console.ReadLine());

                Process _targetProc = Process.GetProcessById(_procID);

                if(_targetProc == null)
                {
                    throw new Exception("Процесс не завершен. Такого процесса не существует");
                }
                else
                {
                    Console.WriteLine($"Процесс {_targetProc.ProcessName} с ID {_targetProc.Id} успешно завершен");
                    _targetProc.Kill();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка - " + e.Message);
            }
        }
    }
}
