
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

internal class Game
{
    private Map _map = null!;
    private Creature _player = null!;

    public Game()
    {

    }

    internal void Run()
    {
        Init();
        Play();
    }

    private void Play()
    {
       bool gameInProgress = true;

        do
        {
            //Drawmap
            Drawmap();

            //GetCommand

            //Act

            //Drawmap

            //Ememyaction

            //Drawmap

            Console.ReadLine();

        }while (gameInProgress);
    }

    private void Drawmap()
    {
         Console.Clear();

        for (int y = 0; y < _map.Height ; y++)
        {
            for (int x = 0; x < _map.Width; x++)
            {
                Cell? cell = _map.GetCell(y, x);
                ArgumentNullException.ThrowIfNull(cell, nameof(cell));

                IDrawable drawable = cell;

                foreach (Creature creature in _map.Creatures)
                {
                    if(creature.Cell == drawable)
                        drawable = creature;
                }

                Console.ForegroundColor = drawable.Color;
                Console.Write(drawable.Symbol);

            }
            Console.WriteLine();
        }

        Console.ResetColor();
    }

   // [MemberNotNull(nameof(_map), nameof(_player))]
    private void Init()
    {
        //ToDo: Read from config
        _map = new Map(height: 10, width: 10);
        Cell? playerCell = _map.GetCell(0, 0);
        _player = new Player(playerCell!);
        _map.Creatures.Add(_player);
        
    }
}