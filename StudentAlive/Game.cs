using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAlive
{
    public class Game
    {
        private  Job[] Jobs = new Job[]
        {
            new Job { Salary = 500, DaySalary = 10, MinExperience = 0, Name = "дворник" },
            new Job { Salary = 600, DaySalary = 5, MinExperience = 100, Name = "продавец на кассе" },
            new Job { Salary = 700, DaySalary = 10, MinExperience = 500, Name = "младший менеджер" },
            new Job { Salary = 1000, DaySalary = 30, MinExperience = 1000, Name = "девелопер джун" },
        };

        public Student Student {  get; private set; }

        int pointDay; 

        public Game (string name) 
        {
            pointDay = 24;
            Student = new Student (name);
            Console.WriteLine ("Поздравляем  - вы теперь  студент\n" + Student.GetInfo ());
        }

        public bool Run ()
        {
            if (Student.IsAlive()== false)
            {
                Console.WriteLine(   Student.GetInfo ());
                return false;   
            }

            Console.WriteLine("что будем делать?");
            Step(Console.ReadLine());
            return true;
        }

        public void Step (string command)
        {
            Console.Clear ();
            Console.WriteLine (GetCommand(command));
            switch (command)
            {
                case "1": CommandChangeJob(); break;
                case "2": CommandMoveWork(); break;
                case "3": CommandMoveBookkeeping(); break;
                case "4": CommandStudy(); break;
                case "5": CommandEatUp(); break;    
                case "6": CommandRelax(); break; 
                case "7": Console.WriteLine( Student.GetInfo ()); break;
                case "8": 
                    Console.WriteLine("Новый день");
                    Student.Sleep(); 
                    pointDay = 24 ; break;
                case "9": Console.Clear(); break;
                    default : Console.WriteLine("не знакомая  команда"); break;
            }
        }

        private void CommandRelax()
        {

            if (IsPoint(2) == false) // todo 2 ed 
                return;

            Console.WriteLine("Вы в игровом клубе - сколько денег вы готовы потратить?");

            if (double.TryParse(Console.ReadLine(), out double d))
            {
                pointDay -= 2;
                Console.WriteLine( Student.Relax(d));
            }
            else
            {
                Console.WriteLine("error");
                CommandRelax();
            }
        }

        private void CommandEatUp()
        {
            if (IsPoint(1) == false) // todo 1 ed 
                return;

            Console.WriteLine("Вы в столовой - сколько денег вы готовы потратить?");
            
            if(double.TryParse(Console.ReadLine(), out double d))
            {
                Console.WriteLine( Student.EatUp(d));
                pointDay--;
            }
            else
            {
                Console.WriteLine("error");
                CommandEatUp ();
            }
        }

        /// <summary>
        /// Учиться
        /// </summary>
        private void CommandStudy()
        {
            if (IsPoint(8) == false) // todo 8 ed 
                return;

            pointDay -= 8;
            Console.WriteLine(Student.Study());
        }

        /// <summary>
        /// Запросить зарплату
        /// </summary>
        private void CommandMoveBookkeeping()
        {
            Console.WriteLine(Student.MoveBookkeeping(GetJob(Student.Job)));
        }

        /// <summary>
        /// сходить на  работу 
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        private void CommandMoveWork()
        {
            if(Student.Job == "Без Работы") // todo  спорная  проверка
            {
                Console.WriteLine("Вы не работаете");
                return;
            }

            if (IsPoint(10) == false) // todo 10 ed 
                return;
            
            pointDay -= 10;
            Student.MoveWork();
            Console.WriteLine("Вы сходили на работу:");
            Console.WriteLine(Student.GetInfo ());
        }

        /// <summary>
        /// Пойти на  собеседование 
        /// </summary>
        private void CommandChangeJob()
        {
            if (IsPoint(4) == false) // todo 10 ed 
                return;
            Console.WriteLine("Список вакансий:");
            foreach (Job j in Jobs)
            {
                Console.WriteLine (j.Name);
            }

            Console.WriteLine("Введите название должности на которую вы претендуете:");
            string temp = Console.ReadLine();
            Job job = GetJob(temp);
            if (job != null)
            {
                Console.WriteLine(Student.ChangeJob(job));
                pointDay -= 4;
            }
            else
                Console.WriteLine("Нет такой вакансии");
        }

        /// <summary>
        /// Определяет хватает ли  временя в этот день
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        private bool IsPoint(int point)
        {
            if (pointDay - point >= 0)
                return true;

            Console.WriteLine("Сегодня уже не успеете - попробуйте в другой день");
            return false;
        }

        /// <summary>
        /// поиск работы в массиве
        /// </summary>
        /// <param name="temp"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        private Job GetJob(string? temp)
        {
            foreach (Job j in Jobs)
            {
                if(j.Name == temp)
                    return j; 
            }

            return null; // todo  возвращать null  не очень  хорошая практика
        }

        public string GetCommand ()
        {
            return "1 -Устроиться\\сменить работу\n" +
                   "2 -Сходить на работу\n" +
                   "3 -Сходить за зарплатой\n" +
                   "4 -Сходить на учебу\n" +
                   "5 -Сходить поесть\n" +
                   "6 -Сходить в Игровой клуб\n" +
                   "7 -Запросить статус\n" +
                   "8 -Пойти спать\n" +
                   "9 -Очистить консоль\n";
        }

        private string GetCommand(string command)
        {
            int index = 0;

            if(int.TryParse(command, out index))
            {
                index--;
                string[] strings = GetCommand().Split('\n');

                if (index >= 0 && index < strings.Length )
                    return strings[index];
                else
                    return "Неизвестная команда";
            }

            return "Неизвестная команда";
            
        }
    }
}
