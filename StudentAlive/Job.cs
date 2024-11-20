namespace StudentAlive
{
    // track

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
          throw new NotImplementedException();
        }

        public string GetSalary( Student student )
        {
            throw new NotImplementedException();
        }
    }
}