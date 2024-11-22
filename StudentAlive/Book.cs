namespace StudentAlive
{

    // track
    public class Book
    {
        public string Name { get; set; }
        public double Price { get; set; }

        /// <summary>
        /// сколько  читать  
        /// </summary>
        public int  PoinstDay { get; set; }

        /// <summary>
        /// опыт за каждый поинт
        /// </summary>
        public int ExperiencePoint { get ; set; }

        public int ExperienceTotal { get => PoinstDay * ExperiencePoint; }

        /// <summary>
        /// Прочитанно  поинтов
        /// </summary>
        public int ReadStatus { get; private set; }
      
        public int ReadOstatok { get => PoinstDay - ReadStatus; }


        /// <summary>
        /// Чтение
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public string Read (Student student)
        {
            if(ReadStatus>= PoinstDay)
                return "Книга уже прочитана";

            student.Satiety--;
            student.Experience += ExperiencePoint;

            ReadStatus++;

            return $"Вы почитали книгу {Name} - Осталось {ReadOstatok} ст.";
        }
    }
}