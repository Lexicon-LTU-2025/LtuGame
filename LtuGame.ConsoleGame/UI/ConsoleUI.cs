
using LtuGame.ConsoleGame.Extensions;
using LtuGame.LimitedList;

internal class ConsoleUI : IUI
{
    private MessageLog<string> _messageLog = new(6);

    public void AddMessage(string message) => _messageLog.Add(message);

    public void PrintLog()
    {
        _messageLog.Print(m => Console.WriteLine(m + new string(' ', Console.WindowWidth - m.Length)));
        //_messageLog.Print(Console.WriteLine);
        //_messageLog.Print(HowToPrint);
        //_messageLog.Print(x => HowToPrint(x));
    }

    //private  void HowToPrint(string message)
    //{
    //    //...
    //    //..
    //    Console.WriteLine(message);
    //}

    public void Draw(IMap map)
    {
        for (int y = 0; y < map.Height; y++)
        {
            for (int x = 0; x < map.Width; x++)
            {
                Cell? cell = map.GetCell(y, x);
                ArgumentNullException.ThrowIfNull(cell, nameof(cell));

                IDrawable drawable = map.CreatureAt(cell)
                                                                    ?? cell.Items.FirstOrDefault() as IDrawable
                                                                    ?? cell;

                Console.ForegroundColor = drawable.Color;
                Console.Write(drawable.Symbol);

            }
            Console.WriteLine();
        }

        Console.ResetColor();
    }

    public ConsoleKey GetKey() => Console.ReadKey(intercept: true).Key;

    public void Clear()
    {
        Console.CursorVisible = false;
        Console.SetCursorPosition(0, 0);
    }

    public void PrintStats(string stats)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(stats);
        Console.ForegroundColor = ConsoleColor.White;
    }
}