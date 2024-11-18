namespace StudentAlive
{
    public class Student
    {
        public string Name { get; set; }
        /// <summary>
        /// Опыт
        /// </summary>
        public int Experience { get; set; }
        public double Money { get; set; }

        /// <summary>
        /// Зарплата
        /// </summary>
        public double Salary { get; set; }

        public bool IsJob 
        {
            get 
            {
                if (Job == "Без Работы")
                    return false;
                return true;
            }
        }

        public string Job { get; set; }
      
        public int  WorkDay { get; set; }
        /// <summary>
        /// Сытость
        /// </summary>
        public double Satiety { get; set; }
        /// <summary>
        /// Настроение 
        /// </summary>
        public double Mood { get; set; }

        public  Student (string name )
        {
            Name = name;
            Job = "Без Работы";
            Mood = 20;
            Money = 500;
            Satiety = 20;
        }

        public bool IsAlive ()
        {
            if (Satiety < 0 || Mood < 0) return false;
            
            return true;
        }

        /// <summary>
        /// Пойти на собеседование
        /// </summary>
        /// <param name="job"></param>
        /// <returns></returns>
        public string ChangeJob (Job job)
        {
           Satiety -= 2;
           return  job.PretendJobs(this);
        }
        /// <summary>
        /// Сходить на  работу
        /// </summary>
        public  string MoveWork ()
        {
            Experience++;
            Mood -=10; 
            Satiety -=10;
            WorkDay++;
            return "Вы сходили на работу";
        }

        /// <summary>
        /// сходить  за зарплатой 
        /// </summary>
        /// <param name="job"></param>
        /// <returns></returns>
        public string MoveBookkeeping(Job job)
        {   if(IsJob==true)
                return job.GetSalary(this);
            return "Вы не работаете";
        }

        /// <summary>
        /// поесть
        /// </summary>
        /// <param name="price"></param>
        /// <returns></returns>
        public string EatUp(double cash)
        {
            if(cash > Money)
            {
                Mood--; 
                return "Не хватает денег (";
            }    

            if (cash <= 0)
                return "Вы не поели";
            else if (cash <= 10)
            {
                Satiety += 10;
                Mood-=10; // вы поели абы чего .. так  и  повеситься можно  
            }
            else if (cash <= 50)
            {
                Satiety += 20;
                Mood+=5;
            }
            else if (cash <= 100)
            {
                Satiety += 30;
                Mood += 30;
            }
            else
            {
                Satiety += 30;
                Mood += 30 + cash / 50.0; 
            }
            Money-= cash;

            return $"Вы покушали... Сытость: {Satiety}. настроение:{Mood}";
        }

        /// <summary>
        /// Учится
        /// </summary>
        /// <returns></returns>
        public string  Study ()
        {
            Mood -= 10;
            Satiety -= 10;

            Random random = new Random();
            int experience = random.Next(0, 10);

            Experience += experience;
            return $"Вы получили знаний на {experience} ед. опыта";
        }

        /// <summary>
        /// Поспать  - настроение  поднимается но хочется есть
        /// </summary>
        public string Sleep ()
        {
            Mood += 5;
            Satiety -= 5;
            return "Вы поспали. проверьте статус"; 
        }

        public string Relax (double cash)
        {
            if (cash > Money)
            {
                Mood--;
                return "Не хватает денег (";
            }

            if (cash <= 0)
                return "error";
            else if (cash <= 10)
                Mood+=10;
            else if (cash <= 50)
                Mood += 50;
            else if (cash <= 100)
                Mood += 100;
            else
                Mood += 100 + cash / 50.0;
            
            Money -= cash;

            return $"Вы хорошо провели время... Сытость: {Satiety}. настроение:{Mood}";
        }

        /// <summary>
        /// Получить  информацию  о  студенте
        /// </summary>
        /// <returns></returns>
        public string GetInfo ()
        {
            if (Satiety < 0)
                return $"Студент:{Name} - Вы умерли от голода -RIP";

            if (Mood < 0)
                return $"Студент:{Name} - Вы умерли от тоски -RIP";

            return $"________________________________\n" +
                   $"|Студент:{Name}\n" +
                   $"|Опыт:{Experience}, Деньги: {Money},\n" +
                   $"|Сытость:{Satiety}, Настроение: {Mood},\n" +
                   $"|Работа: Должность: {Job}, Зарплата: {Salary}\n" +
                   $"---------------------------------";
        }
    }
}
