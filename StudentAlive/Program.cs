// See https://aka.ms/new-console-template for more information

using StudentAlive;
bool f = true;
Game game = new Game("Ivan");

Console.WriteLine( game.GetCommand());
while (f)
{
    f =   game.Run();
    Console.WriteLine(game.GetCommand());
    
    if (f==false)
    { 
        Console.WriteLine( "Спасибо  что согласились поиграть  в  студента");
        Console.ReadLine();
    }
}