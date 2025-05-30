
using System.ComponentModel;

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

            //Act

            //Drawmap

            //Ememyaction

            //Drawmap

        }while (gameInProgress);
    }

    private void Drawmap()
    {
         Console.Clear();

        for (int y = 0; y < _map.Height ; y++)
        {
            for (int x = 0; x < _map.Width; x++)
            {
                Cell cell = _map.GetCell(y, x);
            }
        }
    }

    private void Init()
    {
        //ToDo: Read from config
        _map = new Map(height: 10, width: 10);
        _player = new Player();
    }
}