namespace StudentAlive
{
    public class Game
    {
        private  Job[] Jobs = new Job[]
        {
            new Job { Salary = 200, DaySalary = 2, MinExperience = 0, Name = "дворник" },
            new Job { Salary = 600, DaySalary = 5, MinExperience = 100, Name = "продавец на кассе" },
            new Job { Salary = 700, DaySalary = 10, MinExperience = 500, Name = "младший менеджер" },
            new Job { Salary = 5000, DaySalary = 30, MinExperience = 2000, Name = "девелопер джун" },
        };

        public Student Student {  get; private set; }

        int pointDay;
        int pointRelax = 2;
        private int pointEatUp = 1;
        private int pointStudy = 8;
        private int pointMoveWork = 10;
        private int pointChangeJob =4;

        public Game (string name) 
        {
            pointDay = 14;
            Student = new Student (name);
            Console.WriteLine ("Поздравляем  - вы теперь  студент\n" + Student.GetInfo ());
        }

        public bool Run ()
        {
            if (Student.IsAlive()== false)
            {
                Console.WriteLine(   Student.GetInfo ());
                for (int i = 0; i < 5; i++)
                {
                    Console.Write(";-( ");
                    Thread.Sleep (100);
                }
                Console.WriteLine();
                return false;   
            }
            EndPrint(5);
            Console.WriteLine("что будем делать?");
           
            Step(Console.ReadLine());
            return true;
        }

        public void Step (string command)
        {

            Console.Clear();
            Console.WriteLine(GetCommand(command));
            switch (command)
            {
                case "1": CommandChangeJob(); break;
                case "2": CommandMoveWork(); break;
                case "3": CommandMoveBookkeeping(); break;
                case "4": CommandStudy(); break;
                case "5": CommandEatUp(); break;
                case "6": CommandRelax(); break;
                case "7": Console.WriteLine(Student.GetInfo()); break;
                case "8":
                    Console.WriteLine(Student.Sleep());
                    Console.WriteLine("Новый день");
                    pointDay = 24; break;
                case "9": Console.Clear(); break;
                case "10": PrintManual(); break;
                default: Console.WriteLine("не знакомая  команда"); break;
            }
           
        }

        private static void EndPrint(int count )
        {
            for (int i = 0; i < count; i++)
            {
                Console.Write(".");
                Thread.Sleep(50);
            }
            Console.WriteLine();
        }

        private void CommandRelax()
        {
            
            if (IsPoint(pointRelax) == false) // todo 2 ed 
                return;

            Console.WriteLine("Вы в игровом клубе сколько денег вы готовы потратить?");

            if (double.TryParse(Console.ReadLine(), out double cash))
            {
                pointDay -= pointRelax;
                Console.WriteLine( Student.Relax(cash));
            }
            else
            {
                Console.WriteLine("error");
                CommandRelax();
            }
        }

        private void CommandEatUp()
        {
            if (IsPoint(pointEatUp) == false) // todo 1 ed 
                return;

            Console.WriteLine("Вы в столовой - сколько денег вы готовы потратить?");
            
            if(double.TryParse(Console.ReadLine(), out double cash))
            {
                Console.WriteLine( Student.EatUp(cash));
                pointDay -=pointEatUp;
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
            if (IsPoint(pointStudy) == false) // todo 8 ed 
                return;

            pointDay -= pointStudy;
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

            if (IsPoint(pointMoveWork) == false) // todo 10 ed 
                return;
            
            pointDay -= pointMoveWork;
            Console.WriteLine(Student.MoveWork());
            Console.WriteLine(Student.GetInfo ());
        }

        /// <summary>
        /// Пойти на  собеседование 
        /// </summary>
        private void CommandChangeJob()
        {
            if (IsPoint(pointChangeJob) == false) // todo 4 ed 
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
                pointDay -= pointChangeJob;
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
                   "9 -Очистить консоль\n" +
                   "10 -Мануал";

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
        private void PrintManual()
        {
            string manual = "Игра в студента:\n" +
                              "Студент может: учиться, работать, ходить в столовую и игровой клуб, спать...\n" +
                              "Основная информация: Имя, Опыт, Наличные деньги, Настроение, Сытость..." +
                              "Дополнительная информация: Должность, зарплата...\n" +
                              "\n" +
                              "День:\n" +
                              "Каждый день у студента есть ресурс\"время\" - он может тратить его по своему усмотрению\n" +
                              "Если студент идет спать - день заканчивается и ресурс начисляется заново\n" +
                              "Начало дня - \"время\" = 14 ед.\n" +
                              "Сходить на собеседование - \"время\"=4 ед.\n" +
                              "Сходить на работу - \"время\"=10 ед.\n" +
                              "Учиться - \"время\"=8 ед.\n" +
                              "Сходить в столовую - \"время\"=1 ед.\n" +
                              "Сходить в игровой клуб - \"время\"=2 ед.\n" +
                              "Начало дня \"время\"=14 ед.\n" +
                              "\n" +
                              "Питание:\n" +
                              "Студенту надо есть, за каждую активность у студента уменьшается сытость\n" +
                              "Сходить на собеседование -2 ед.\n" +
                              "Сходить на работу -10 ед.\n" +
                              "Сходить на учебу -10 ед.\n" +
                              "Спать -5 ед.\n" +
                              "\n" +
                              "Поход в столовую:\nПри походе в столовую студент может повысить сытость и настроение в обмен на деньги\n" +
                              "Если не хватает денег: Сытость +0, Настроение -1\n" +
                              "До 10 рублей: Сытость +10, Настроение +1\n" +
                              "До 50 рублей: Сытость +20, Настроение +5\n" +
                              "До 100 рублей: Сытость +30, Настроение +30\n" +
                              "Выше 100 рублей: Сытость +30, Настроение +30 + бонус\n" +
                              "\n" +
                              "Поход в игровой клуб:\nПри походе в игровой клуб студент может повысить свое настроение в обмен на деньги\n" +
                              "Если не хватает денег: Настроение -1\n" +
                              "До 10 рублей: Настроение +10\n" +
                              "До 50 рублей: Настроение +50\n" +
                              "До 100 рублей: Настроение +100\n" +
                              "Выше 100 рублей: Настроение +100 + бонус\n" +
                              "\n" +
                              "Учеба:\nВо время учебы у студента повышается опыт (от 0 до +10 ед.) (как повезет)\n" +
                              "Во время учебы у студента понижается сытость на -20 ед. и настроение на -10 ед.\n" +
                              "\n" +
                              "Работа:\n" +
                              "Для того чтобы получать зарплату студент должен ходить на работу\n" +
                              "Во время работы у студента понижается сытость на -10 ед, настроение на -10 ед.\n" +
                              "Во время работы у студента повышается опыт на +1 ед.\n" +
                              "\n" +
                              "Зарплата:\n" +
                              "Студент может получать зарплату за свою работу если он отработает n количество дней: \n" +
                              "Чтобы получить зарплату, студент должен обратиться в бухгалтерию: \n" +
                              "Если студент получает зарплату, то повышается его кошелек на +зарплата и его настроение на +10 \n" +
                              "Если студент еще не отработал расчетный период, бухгалтерия отказывает ему в зарплате и его настроение понижается на -1 ед.\n" +
                              "\n" +
                              "Собеседование: \n" +
                              "Для получения или изменения работы студент может сходить на собеседование\n" +
                              "Результат собеседования зависит от опыта студента\n" +
                              "Если студенту отказывают, его настроение падает на -5\n" +
                              "Список вакансий:\n" +
                              "дворник: Зарплата: 500 , Расчетный период: 2 , минимальный опыт: 0 \n" +
                              "продавец на кассе: Зарплата 600: , Расчетный период: 5 , минимальный опыт: 100 \n" +
                              "младший менеджер: Зарплата 700: , Расчетный период: 10 , минимальный опыт: 500 \n" +
                              "девелопер джун: Зарплата: 1000 , Расчетный период: 30 , минимальный опыт: 1000 \n";

            Console.WriteLine(manual);

        }
    }
}
