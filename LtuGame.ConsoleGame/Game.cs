using LtuGame.ConsoleGame;
using LtuGame.ConsoleGame.Extensions;
using LtuGame.ConsoleGame.GameWorld;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

internal class Game
{
    private Map _map = null!;
    private Player _player = null!;

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
            GetCommand();

            //Act

            //Drawmap

            //Ememyaction

            //Drawmap

           // Console.ReadLine();

        }while (gameInProgress);
    }

    private void GetCommand()
    {
        var keyPressed = ConsoleUI.GetKey();

        switch (keyPressed)
        {
          
            case ConsoleKey.UpArrow:
                Move(Direction.North);
                break;
            case ConsoleKey.DownArrow:
                Move(Direction.South);
                break;
            case ConsoleKey.LeftArrow:
                Move(Direction.West);
                break;
            case ConsoleKey.RightArrow:
                Move(Direction.East);
                break;
            case ConsoleKey.P:
                PickUp();
                break;
           
        }
    }

    private void PickUp()
    {
        if(_player.BackPack.IsFull)
        {
            ConsoleUI.AddMessage("Backpack is full");
            return;
        }

        var items = _player.Cell.Items;
        var item = items.FirstOrDefault();

        if (item is null) return;

        if (_player.BackPack.Add(item)) 
        {
            ConsoleUI.AddMessage($"player pick up {item}");
            items.Remove(item);
        }

    }

    private void Move(Position movement)
    {
        var newPosition = _player.Cell.Position + movement;
        var newCell = _map.GetCell(newPosition);
        if(newCell is not null) _player.Cell = newCell;
    }

    private void Drawmap()
    {
         ConsoleUI.Clear();
         ConsoleUI.Draw(_map);
         ConsoleUI.PrintStats($"Health: {_player.Health}");
         ConsoleUI.PrintLog();

        
    }

   // [MemberNotNull(nameof(_map), nameof(_player))]
    private void Init()
    {
        //ToDo: Read from config
        _map = new Map(height: 10, width: 10);
        Cell? playerCell = _map.GetCell(0, 0);
        _player = new Player(playerCell!);
        _map.Creatures.Add(_player);

        _map.GetCell(2, 6)?.Items.Add(Item.Coin());
        _map.GetCell(2, 6)?.Items.Add(Item.Coin());
        _map.GetCell(5, 2)?.Items.Add(Item.Coin());
        _map.GetCell(4, 4)?.Items.Add(Item.Stone());
        
    }
}
