// See https://aka.ms/new-console-template for more information

using StudentAlive;
while (true)
{
    Start();
}

static void Start()
{
    bool f = true;

    Console.WriteLine("Начало  игры:");
    Console.WriteLine("Введите ваше имя:");
    Game game = new Game(Console.ReadLine());

    Console.WriteLine(game.GetCommand());
    while (f)
    {
        f = game.Run();
        if (f == false)
        {
            Console.WriteLine("Спасибо  что согласились поиграть  в  студента");
            Console.ReadLine();
            return;
        }

        Console.WriteLine(game.GetCommand());
    }
}