using System;
using System.Diagnostics;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_2
{
    class Program
    {
        static public void _Menu(Process[] processes)
        {
            ConsoleKeyInfo cki_main, cki_sec;

            do
            {
                Console.Clear();
                Console.WriteLine("1.Вывести все процессы\n2.Начать процесс\n3.Закрыть процесс\nEscape - Выход");
                cki_main = Console.ReadKey(false);

                switch (cki_main.Key)
                {
                    //Вывести все процессы
                    case ConsoleKey.D1: 
                        Process_Functions._showActualProcess(processes);

                        do
                        {
                            Console.WriteLine("1.Вывести все потоки в заданном процессе\n2.Вывести все модули заданного процесса\nEscape - назад");
                            cki_sec = Console.ReadKey(false);
                            switch (cki_sec.Key)
                            {
                                //Показываем актуальные потоки
                                case ConsoleKey.D1:
                                    Process_Functions._showActualStreams(processes);
                                    break;
                                // Показываем актуальные модули
                                case ConsoleKey.D2:
                                    Process_Functions._showActualModules(processes);
                                    break;
                                default:
                                    break;
                            }
                        } while (cki_sec.Key != ConsoleKey.Escape);
                        break;

                    // Начать новый процесс
                    case ConsoleKey.D2:
                        Process_Functions._startNewProcess("https://www.google.com");
                        break;

                    // Закрыть процесс
                    case ConsoleKey.D3:
                        Process_Functions._killExistingProcess(processes);
                        break;

                    default:
                        break;
                }
            } while (cki_main.Key != ConsoleKey.Escape);
        }

        static Process[] _proc;

        static void Main(string[] args)
        {
            _proc = Process.GetProcesses();

            // В потоке выполняем все действия 
            Thread menuThread = new Thread(() => _Menu(_proc));

            menuThread.Start();

            // В основном потоке обновляем информацию о актуальный процессах каждую минуту
            while(menuThread.ThreadState != System.Threading.ThreadState.Stopped)
            {
                Thread.Sleep(10000);
                _proc = Process.GetProcesses();
            }
        }
    }
}
