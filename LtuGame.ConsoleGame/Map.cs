internal class Map
{
    private Cell[,] cells;

    public int Height { get; }
    public int Width {  get; }


    public Map(int height, int width)
    {
        this.Height = height;
        this.Width = width;

        cells = new Cell[height, width];
    }
}