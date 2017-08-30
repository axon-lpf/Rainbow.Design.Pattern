using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 大话设计模式.观察者模式
{


    //抽象观察者  列如公司中的员工
    public abstract class Observer
    {
        protected string name;
        protected ISubject sub;
        public Observer(string name, ISubject sub)
        {
            this.name = name;
            this.sub = sub;
        }
        public abstract void Update();
    }

    //增加通知者接口 列如 前台通知
    public interface ISubject
    {
        void Attach(Observer ob);
        void Detach(Observer ob);
        void Noity();
        string SubjectState { get; set; }
    }

    public class GirlReception : ISubject
    {
        private List<Observer> observerList = new List<Observer>();
        private string action;

        //添加员工
        public void Attach(Observer ob)
        {
            observerList.Add(ob);
        }

        //减少员工
        public void Detach(Observer ob)
        {
            observerList.Remove(ob);
        }

        ///通知
        public void Noity()
        {
            foreach (var item in observerList)
            {
                item.Update();   
            }
        }

        //老板的状态
        public string SubjectState
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

    //看股票的同事
    public class StockObserver : Observer 
    {
        public StockObserver(string name, ISubject sub) : base(name, sub) 
        {

        }

        public override void Update()
        {
            Console.WriteLine("{0},{1}关闭股票行情,继续工作",sub.SubjectState,name);
        }
    }

    public class NBAObserver : Observer 
    {
        public NBAObserver(string name, ISubject sub) : base(name, sub) 
        {

        }

        public override void Update()
        {
            Console.WriteLine("{0},{1}关闭NBA视频,继续工作", sub.SubjectState, name);
        }
    }
}
