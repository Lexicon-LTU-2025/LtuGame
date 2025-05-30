
using System.ComponentModel;

internal class Game
{
    private Map map;
    private Player player;

    public Game()
    {
    }

    internal void Run()
    {
        Init();
    }

    private void Init()
    {
        //ToDo: Read from config
        map = new Map(height: 10, width: 10);
        player = new Player();
    }
}