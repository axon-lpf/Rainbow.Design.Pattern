using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 大话设计模式.观察者模式
{
    //订阅者接口
    public interface IObserver 
    {
        void Receive(Blog tenxun);
    }
    //订阅号  抽象类
    public abstract class Blog
    {
        //保存订阅者列表
        List<IObserver> observers = new List<IObserver>();

        public string Symbol { get; set; }//描写订阅号的相关信息
        public string Info { get; set; }//描写此次update的信息

        public Blog(string symbol,string info)
        {
            this.Symbol = symbol;
            this.Info = info;
        }

        // 对同一个订阅号，新增和删除订阅者的操作
        public void AddObserver(IObserver ob)
        {
            observers.Add(ob);
        }
        public void RemoveObserver(IObserver ob)
        {
            observers.Remove(ob);
        }

        public void Update()
        {
            // 遍历订阅者列表进行通知
            foreach (IObserver ob in observers)
            {
                if (ob != null)
                {
                    ob.Receive(this);
                }
            }
        }
    }

    //具体的订阅号类
    public class MyBlog : Blog 
    {
        public MyBlog(string symbol,string info):base( symbol, info)
        {

        }
    }

    //具体的订阅者类
    public class Subscriber : IObserver 
    {
        public string Name { get; set; }

        public Subscriber(string name) 
        {
            this.Name = name;
        }
        public void Receive(Blog tenxun)
        {
            Console.WriteLine("订阅者 {0} 观察到了{1}{2}", Name, tenxun.Symbol, tenxun.Info);
        }
    }
}
