using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 大话设计模式.备忘录模式
{
    /// <summary>
    /// 发起人类
    /// </summary>
    public class Originator
    {
        private string state;
        public string State
        {
            get { return state; }
            set { state = value; }
        }
        /// <summary>
        /// 创建备忘录,将当前需要保存的信息导入
        /// </summary>
        /// <returns></returns>
        public Memento CreateMemento()
        {
            return (new Memento(State));
        }

        /// <summary>
        /// 恢复备忘录中的数据
        /// </summary>
        /// <param name="memento"></param>
        public void SetMemento(Memento memento) 
        {
            state = memento.State;
        }

        public void Show() 
        {
            Console.WriteLine("State"+state);
        }
    }

    /// <summary>
    /// 备忘录类
    /// </summary>
    public class Memento 
    {
        private string state;

        public Memento(string state) 
        {
            this.state = state;
        }

        //需要保存数据的属性 可以是多个
        public string State 
        {
            get {return state; }
        }
    }

    public class Caretaker 
    {
        private Memento memneto;

        public Memento Memneto 
        {
            get { return memneto; }
            set { memneto = value; }
        }
    }
}
