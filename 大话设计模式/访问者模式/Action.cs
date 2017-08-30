using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 大话设计模式.访问者模式
{
    /// <summary>
    /// 抽象出状态
    /// </summary>
    public abstract class Action
    {
       /// <summary>
        /// 得到男人的结论或反应
       /// </summary>
        public abstract void GetManConclusion(Person man);
        /// <summary>
        /// 得到女人的结论或者反应
        /// </summary>
        public abstract void GetWomanConclusion(Person woman);
    }

    public abstract class Person 
    {
        /// <summary>
        /// 接收消息
        /// </summary>
        /// <param name="visitor"></param>
        public abstract void Accept(Action visitor);
    }

    /// <summary>
    ///成功者
    /// </summary>
    public class Success : Action 
    {
        public override void GetManConclusion(Person man)
        {
            Console.WriteLine("{0},{1}时,背后多半有一个伟大的女人",this.GetType().Name,this.GetType().Name);
        }

        public override void GetWomanConclusion(Person woman)
        {
            Console.WriteLine("{0},{1}时,背后多半有一个失败的男人", this.GetType().Name, this.GetType().Name);
        }
    }


    /// <summary>
    /// 失败者
    /// </summary>
    public class Faliling : Action 
    {
        public override void GetManConclusion(Person man)
        {

            Console.WriteLine("{0},{1}时,背后多半有一个伟大的女人", this.GetType().Name, this.GetType().Name);
        }

        public override void GetWomanConclusion(Person woman)
        {
            Console.WriteLine("{0},{1}时,背后多半有一个伟大的女人", this.GetType().Name, this.GetType().Name);
        }
    }

    /// <summary>
    /// 恋爱者
    /// </summary>
    public class Amativeness : Action 
    {
        public override void GetManConclusion(Person man)
        {

            Console.WriteLine("{0},{1}时,背后多半有一个伟大的女人", this.GetType().Name, this.GetType().Name);
        }

        public override void GetWomanConclusion(Person woman)
        {
            Console.WriteLine("{0},{1}时,背后多半有一个伟大的女人", this.GetType().Name, this.GetType().Name);
        }
    }

    public class Man : Person 
    {
        public override void Accept(Action visitor)
        {

            visitor.GetManConclusion(this);
        }
    }

    public class Woman : Person 
    {
        public override void Accept(Action visitor)
        {
            visitor.GetWomanConclusion(this);
        }
    }

    public class ObjectStructurre 
    {
        private IList<Person> elements = new List<Person>();

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="elemnet"></param>
        public void Attach(Person elemnet)
        {
            elements.Add(elemnet);
        }

        /// <summary>
        /// 移除
        /// </summary>
        /// <param name="ele"></param>
        public void Detach(Person ele)
        {
            elements.Remove(ele);
        }

        /// <summary>
        /// 循环遍历出来
        /// </summary>
        /// <param name="visitor"></param>
        public void Display(Action visitor) 
        {
            foreach (var item in elements)
            {
                item.Accept(visitor);
            }
        }
          
    }
}
