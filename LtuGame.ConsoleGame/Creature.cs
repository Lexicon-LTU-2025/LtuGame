internal abstract class Creature : IDrawable
{
    public string Symbol { get; }
    public ConsoleColor Color { get; protected set; } = ConsoleColor.Green;
    public Cell Cell { get; }

    public Creature(Cell cell, string symbol)
    {
        if (string.IsNullOrWhiteSpace(symbol))
        {
            throw new ArgumentException($"'{nameof(symbol)}' cannot be null or whitespace.", nameof(symbol));
        }

        Cell = cell ?? throw new ArgumentNullException(nameof(cell));
        Symbol = symbol;
    }
}
