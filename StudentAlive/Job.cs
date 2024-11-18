namespace StudentAlive
{
    public class Job
    {
        public int MinExperience { get; internal set; }
        public string Name { get; internal set; }
        public double Salary { get; internal set; }

        /// <summary>
        /// расчетный периуд
        /// </summary>
        public  int DaySalary { get; internal set; }



        /// <summary>
        /// Претендвоать на  должность
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public string PretendJobs(Student student)
        {
            if (Name == student.Job)
                return "Вы уже на этой работе";

            if (MinExperience <= student.Experience)
            {
                student.Job = Name;
                student.Salary = Salary;
                return $"Поздравляем вас приняли на  работу в должности: {student.Job}";
            }
            else
            {
                student.Mood -= 5;
                return $"Нам жаль, но вам отказанно в должности: {Name} - попробуйте позже ";
            }
        }

        public string GetSalary( Student student )
        {
            if (DaySalary < student.WorkDay )
            {
                student.Mood--; // дизморал  (
                return $"Вы еще не отработали {DaySalary} суток - зарплаты не  будет";
            }
            double chek = 0;

            while (student.WorkDay - DaySalary >= 0)
            {
                chek += Salary;
                student.WorkDay -= DaySalary;
                student.Money += Salary;
                student.Mood += 10;
            }
            return $"Вы сходили в бугалтерию и получили зарплату {chek} р.";

        }


    }
}