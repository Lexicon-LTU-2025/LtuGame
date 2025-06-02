using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LtuGame.ConsoleGame;
internal struct Position
{
    public int Y { get; }
    public int X { get; }

    public Position(int y, int x)
    {
        Y = y;
        X = x;
    }

}
