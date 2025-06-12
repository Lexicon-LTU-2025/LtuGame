﻿
using LtuGame.ConsoleGame.Extensions;
using LtuGame.LimitedList;

internal class ConsoleUI : IUI
{
    private ILimitedList<string> _messageLog;
    private readonly IMap _map;

    public void AddMessage(string message) => _messageLog.Add(message);

    public ConsoleUI(IMap map, ILimitedList<string> messageLog)
    {
        _map = map;
        _messageLog = messageLog;
    }

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

    public void Draw()
    {
        for (int y = 0; y < _map.Height; y++)
        {
            for (int x = 0; x < _map.Width; x++)
            {
                Cell? cell = _map.GetCell(y, x);
                ArgumentNullException.ThrowIfNull(cell, nameof(cell));

                IDrawable drawable = _map.CreatureAt(cell)
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