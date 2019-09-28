using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_2
{
    class Program
    {
        public Program()
        {
            _proc = Process.GetProcesses();
        }

        static Process[] _proc;

        static void Main(string[] args)
        {
            Boolean _exitTrigger = false; //Создаем триггер для loop'а меню
            //Process_Functions proc = new Process_Functions(); // Создаем класс 
            Delegate[] _menuFunc = new Delegate[] {Process_Functions._showActualProcess(), }

            while (_exitTrigger == false)
            {
                Console.WriteLine("Введите цифру для выбора действия\n1.Работа с процессами\n2.Работа с потоками\n3.Выход");

                do
                {

                } while ();

                Console.ReadKey();
            }
        }
    }
}
