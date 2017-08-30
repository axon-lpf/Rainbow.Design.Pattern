using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 大话设计模式.中介者模式
{
    /// <summary>
    /// 抽象中介者类
    /// </summary>
    public abstract class Mediator
    {
        /// <summary>
        /// 得到同事对象和发送信息
        /// </summary>
        /// <param name="message"></param>
        /// <param name="coll"></param>
        public abstract void Send(string message, Colleague coll);
    }

    /// <summary>
    /// 抽象类同事
    /// </summary>
    public abstract class Colleague
    {
        /// <summary>
        /// 中介者
        /// </summary>
        protected Mediator mediator;

        /// <summary>
        /// 构造方法得到中介者对象
        /// </summary>
        /// <param name="med"></param>
        public Colleague(Mediator med)
        {
            this.mediator = med;
        }
    }

    /// <summary>
    /// 同事一
    /// </summary>
    public class ConcreteColleaguel1 : Colleague
    {
        public ConcreteColleaguel1(Mediator med)
            : base(med)
        {

        }
        public void Send(string message)
        {
            mediator.Send(message, this);
        }

        public void Noity(string message)
        {
            Console.WriteLine("同事1得到{0}消息", message);
        }
    }
    /// <summary>
    /// 同事二
    /// </summary>
    public class ConcreteColleaguel2 : Colleague
    {
        public ConcreteColleaguel2(Mediator med)
            : base(med)
        {

        }
        public void Send(string message)
        {
            mediator.Send(message, this);
        }

        public void Noity(string message)
        {
            Console.WriteLine("同事2得到{0}消息", message);
        }
    }

    public class ConcreateMediator : Mediator
    {
        private ConcreteColleaguel1 con1;

        public ConcreteColleaguel1 Con1
        {
            get { return con1; }
            set { con1 = value; }
        }
        private ConcreteColleaguel2 con2;

        public ConcreteColleaguel2 Con2
        {
            get { return con2; }
            set { con2 = value; }
        }

        public override void Send(string message, Colleague coll)
        {
            if (coll == con1)
            {
                con1.Noity(message);
            }
            else
            {
                Con2.Noity(message);
            }
        }
    }
}
