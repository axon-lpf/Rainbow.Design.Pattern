using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 大话设计模式.观察者模式
{
    public interface Subject
    {
        void Noity();
        string SubjectState{get;set;}
    }
    public class Stock
    {
        private string name;
        private Subject sub;
        public Stock(string name, Subject sub)
        {
            this.name = name;
            this.sub = sub;
        }

        public void CloseStock()
        {
            Console.WriteLine("{0},{1}关闭股票", name, sub.SubjectState);
        }
    }

    public class NBA
    {
        private string name;
        private Subject sub;
        public NBA(string name, Subject sub)
        {
            this.name = name;
            this.sub = sub;
        }
        public void CloseNBA()
        {
            Console.WriteLine("{0},{1}关闭股票", name, sub.SubjectState);
        }
    }

    //通过方法的委托  相当于一个类
    public delegate void EventHandler();

    public class Gril : Subject
    {
        public event EventHandler Update;
        private string action;
        public void Noity()
        {
            Update();
        }


       public string  SubjectState
        {
            get
            {
                return action;
            }
            set
            {
                action = value;
            }
        }
    }
}
