internal class Orc : Creature
{
    public Orc(Cell cell) : base(cell, "O ", 80, 30)
    {
        Color = ConsoleColor.DarkGreen;
    }
}
