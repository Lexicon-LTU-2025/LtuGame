
using System.ComponentModel;

internal class Game
{
    private Map map = null!;
    private Player player = null!;

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

            //GetCommand

            //Act

            //Drawmap

            //Ememyaction

            //Drawmap

        }while (gameInProgress);
    }

    private void Init()
    {
        //ToDo: Read from config
        map = new Map(height: 10, width: 10);
        player = new Player();
    }
}