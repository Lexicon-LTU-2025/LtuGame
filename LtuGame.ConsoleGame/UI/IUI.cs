﻿
internal interface IUI
{
    void AddMessage(string message);
    void Clear();
    void Draw();
    ConsoleKey GetKey();
    void PrintStats(string stats);
    void PrintLog();
}

//public class SomeUI : IUI
//{
//    public void AddMessage(string message)
//    {
//        throw new NotImplementedException();
//    }

//    public void Clear()
//    {
//        throw new NotImplementedException();
//    }

//    public ConsoleKey GetKey()
//    {
//        throw new NotImplementedException();
//    }

//    public void PrintStats(string stats)
//    {
//        throw new NotImplementedException();
//    }

//    void IUI.Draw(IMap map)
//    {
//        throw new NotImplementedException();
//    }
//}