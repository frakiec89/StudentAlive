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
        public string Job { get; set; }
      
        public int  WorkDay { get; set; }
        /// <summary>
        /// Сытость
        /// </summary>
        public double Satiety { get; set; }
        /// <summary>
        /// Настрение 
        /// </summary>
        public double Mood { get; set; }

        public  Student (string name )
        {
            Name = name;
            Job = "Без Работы";
            Salary = 100; 
            Mood = 100;
            Money = 500;
        }

        public bool IsAlive ()
        {
            if (Money <=0 || Satiety <=0) return false;
            
            return true;
        }



        /// <summary>
        /// Пойти на собеседование
        /// </summary>
        /// <param name="job"></param>
        /// <returns></returns>
        public string ChangeJob (Job job)
        {
           return  job.PretendJobs(this);
        }
 
        public  void MoveWork ()
        {
            Experience++;
            Mood -=10; 
            Satiety -=10;
            WorkDay++;
        }

        /// <summary>
        /// схолить  за зарплатой 
        /// </summary>
        /// <param name="job"></param>
        /// <returns></returns>
        public string MoveBookkeeping(Job job)
        {
            return job.GetSalary(this);
        }

        /// <summary>
        /// поесть
        /// </summary>
        /// <param name="price"></param>
        /// <returns></returns>
        public string EatUp(double price)
        {
            if(price> Money)
            {
                Mood--; 
                return "Не хватает денег (";
            }    
              

            if (price < 0)
                return "Вы не поели";
            else if (price <= 10)
            {
                Satiety += 10;
                Mood++;
            }
            else if (price <= 50)
            {
                Satiety += 20;
                Mood+=5;
            }
            else if (price <= 100)
            {
                Satiety += 30;
                Mood += 30;
            }
            else
            {
                Satiety += 30;
                Mood += 30 + price /50.0; 
            }
            Money-=price;

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
            return $"Вы  получили  знаний на {experience}  опыта";
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


            return $"Студент:{Name}\n" +
                   $"Опыт:{Experience}, Деньги: {Money},\n" +
                   $"Сытость:{Satiety}, Настроение: {Mood},\n" +
                   $"Работа: должность: {Job}, Зарплата: {Salary}\n";
        }

    }
    
}
