using LtuGame.ConsoleGame;
using LtuGame.ConsoleGame.Extensions;
using LtuGame.ConsoleGame.GameWorld;
using LtuGame.ConsoleGame.Services;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Channels;

internal class Game
{
    private IMap _map;
    private Player _player = null!;
    private Dictionary<ConsoleKey, Action> actionmeny = null!;
    private bool gameInProgress;
    private IUI _ui;

    public Game(IUI ui, IMap map)
    {
        _ui = ui;
        _map = map;
    }

    internal void Run()
    {
        Init();
        Play();
    }

    private void Play()
    {
        gameInProgress = true;

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

        } while (gameInProgress);
    }

    private void GetCommand()
    {
        var keyPressed = _ui.GetKey();

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
                //case ConsoleKey.P:
                //    PickUp();
                //    break;
                //case ConsoleKey.I:
                //    Inventory();
                //    break;
        }

        

        if (actionmeny.ContainsKey(keyPressed))
        {
            actionmeny[keyPressed]?.Invoke();
        }



    }

    private void Inventory()
    {
        for (int i = 0; i < _player.BackPack.Count; i++)
        {
            _ui.AddMessage($"{i + 1}: {_player.BackPack[i]}");
        }
    }

    private void PickUp()
    {
        if (_player.BackPack.IsFull)
        {
            _ui.AddMessage("Backpack is full");
            return;
        }

        var items = _player.Cell.Items;
        var item = items.FirstOrDefault();

        if (item is null) return;

        if (_player.BackPack.Add(item))
        {
            _ui.AddMessage($"player pick up {item}");
            items.Remove(item);
        }

    }

    private void Move(Position movement)
    {
        var newPosition = _player.Cell.Position + movement;
        var newCell = _map.GetCell(newPosition);
        
        if (newCell is not null)
        {
            Creature? opponent = _map.CreatureAt(newCell);
            if (opponent is not null)
            {
                _player.Attack(opponent);
                opponent.Attack(_player);
            }

            gameInProgress = !_player.IsDead;

            _player.Cell = newCell;
            if (newCell.Items.Any())
                _ui.AddMessage($"You see: {string.Join(", ", newCell.Items)}");
        }
    }

    private void Drawmap()
    {
        _ui.Clear();
        _ui.Draw();
        _ui.PrintStats($"Health: {_player.Health}, Enemys: {_map.Creatures.Where(c => !c.IsDead).Count() -1}  ");
        _ui.PrintLog();
    }

    // [MemberNotNull(nameof(_map), nameof(_player))]
    private void Init()
    {
        CreateActionMeny();
        //ToDo: Read from config
        //_map = new Map(height: 10, width: 10);
        _map = new Map(new GetMapSizeService(new ));
        Cell? playerCell = _map.GetCell(0, 0);
        _player = new Player(playerCell!);
        _map.Creatures.Add(_player);

        var r = new Random();

        RCell().Items.Add(Item.Coin());
        RCell().Items.Add(Item.Coin());
        RCell().Items.Add(Item.Coin());
        RCell().Items.Add(Item.Stone());

        _map.Place(new Orc(RCell()));
        _map.Place(new Orc(RCell()));
        _map.Place(new Troll(RCell()));
        _map.Place(new Troll(RCell()));
        _map.Place(new Troll(RCell()));
        _map.Place(new Goblin(RCell()));
        _map.Place(new Goblin(RCell()));

        //_map.Creatures.ForEach(c =>
        //{
        //    c.AddToLog = ConsoleUI.AddMessage;
        //    c.AddToLog += Console.WriteLine;
        //});

        Creature.AddToLog = _ui.AddMessage;
        //Creature.AddToLog += Console.Write;

        Cell RCell()
        {
            var width = r.Next(0, _map.Width);
            var height = r.Next(0, _map.Height);

            var cell = _map.GetCell(height, width);
            ArgumentNullException.ThrowIfNull(cell, nameof(cell));

            return cell;
        }

    }

    private void CreateActionMeny()
    {
        actionmeny = new Dictionary<ConsoleKey, Action>()
                {
                    {   ConsoleKey.P, PickUp    },
                    {   ConsoleKey.I, Inventory },
                    {   ConsoleKey.D, Drop }
                };
    }

    private void Drop()
    {
        Item? item = _player.BackPack.FirstOrDefault();
        if(item != null && _player.BackPack.Remove(item))
        {
            _player.Cell.Items.Add(item);
            _ui.AddMessage($"Player dropped the {item}");
        }
        else
        {
            _ui.AddMessage("Backpack is empty");
        }
    }
}

