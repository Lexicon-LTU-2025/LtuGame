
using LtuGame.LimitedList;

var li = new LimitedList<Creature>(10);


var game = new Game();
game.Run();

Console.WriteLine("Game over");