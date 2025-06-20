﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LtuGame.LimitedList;
public class MessageLog<T> : LimitedList<T>
{
    public MessageLog(int capacity) : base(capacity){}

    public override bool Add(T item)
    {
        if(IsFull) _list.RemoveAt(0);
        return base.Add(item);
    }
}
