using LtuGame.ConsoleGame;
using LtuGame.LimitedList;

internal class Player : Creature
{
    public LimitedList<Item> BackPack { get; }
    public Player(Cell cell) : base(cell, "P ",maxHealth: 100)
    {
        Color = ConsoleColor.White;
        BackPack = new LimitedList<Item>(3);
        Damage = 100;
    }
}
