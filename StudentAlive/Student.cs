namespace StudentAlive
{
    // track
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
      
        public int  WorkDay { get; set; } // CountWorkDay
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
            throw new NotImplementedException ();
        }

        public bool IsAlive ()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Пойти на собеседование
        /// </summary>
        /// <param name="job"></param>
        /// <returns></returns>
        public string ChangeJob (Job job)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Сходить на  работу
        /// </summary>
        public  string MoveWork ()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// сходить  за зарплатой 
        /// </summary>
        /// <param name="job"></param>
        /// <returns></returns>
        public string MoveBookkeeping(Job job)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// поесть
        /// </summary>
        /// <param name="price"></param>
        /// <returns></returns>
        public string EatUp(double cash)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Учится
        /// </summary>
        /// <returns></returns>
        public string  Study ()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Поспать  - настроение  поднимается но хочется есть
        /// </summary>
        public string Sleep ()
        {
            throw new NotImplementedException();
        }

        public string Relax (double cash)
        {
            throw new NotImplementedException();
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
