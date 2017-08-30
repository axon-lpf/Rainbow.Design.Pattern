using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 大话设计模式.迭代器模式
{
    public interface IEumerator
    {
        object Current { get;}
        bool MoveNext();
        void Reset();
    }
    public interface IEumerable 
    {
        IEumerator GetIEumerator();
    }
}

