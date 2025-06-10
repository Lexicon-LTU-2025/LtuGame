internal class Orc : Creature
{
    public Orc(Cell cell) : base(cell, "O ", 80)
    {
        Color = ConsoleColor.DarkGreen;
    }
}
