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
            new Job { Salary = 700, DaySalary = 10, MinExperience = 500, Name = "Младший  менеджер" },
            new Job { Salary = 1000, DaySalary = 30, MinExperience = 1000, Name = "Девелопер Джун" },
        };

        public Student Student {  get; private set; }

        int pointDay; 

        public Game (string name) 
        {
            Student = new Student (name);
            Console.WriteLine ("Поздраляем  - вы теперь  студент\n" + Student.GetInfo ());
        }


        public void Step (string command)
        {
            switch (command)
            {
               case "1":

                    Console.WriteLine("Введите название должности куда вы хотите сходить");
                    string temp = Console.ReadLine ();
                    Job job = GetJob (temp);
                    if (job != null)
                    {
                        Console.WriteLine(Student.ChangeJob(job));
                        pointDay -= 10;
                    }
                    else
                        Console.WriteLine("Нет такой вакансии");
                    break;

               case "2":
               case "3":
               case "4":
               case "5":
               case "6":
               case "7":
                    default : Console.WriteLine("не знакомая  команда"); break;
            }
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
                    { return j; }
            }

            return null;
        }

        public string GetCommadn ()
        {
            return "1 -устроиться на работу \n" +
                   "2 -сходить на работу \n" +
                   "3 -сходить за зарплатой\n" +
                   "4 -сходить на учебу \n" +
                   "5 -сходить поесть \n" +
                   "6 -Запросить статус \n" +
                   "6 -пойти спать \n";
        }
    }
}
