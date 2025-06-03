
using LtuGame.LimitedList;

var lm = new LimitedList<int>(10);
var li = new List<int>(10);

var str = "adafasgfsge";

foreach (var item in str)
{
    Console.WriteLine(item);
}

foreach (var item in li)
{
    Console.WriteLine(item);
}

foreach (var item in lm)
{
    Console.WriteLine(item);
}




var game = new Game();
game.Run();

Console.WriteLine("Game over");