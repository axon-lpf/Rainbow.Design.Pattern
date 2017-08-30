using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 大话设计模式.访问者模式
{
    /// <summary>
    /// 首先定义一个公司的员工管理系统的基本员工类，这个类层次要求保持稳定，不得随意添加内容。对此就需要给这些类增加一个Accept方法用于将来的动态扩展。
    /// </summary>
    public abstract class Emploree
    {
        public string Name { get; set; }

        protected Emploree() { }

        public Emploree(string name)
        {
            this.Name = name;

        }

        public abstract void Accept(Visitor visitor);
    }

    public class Managerhua : Emploree
    {
        public Managerhua(string name) : base(name) { }

        public override void Accept(Visitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public class Chairman : Emploree
    {
        public Chairman(string name) : base(name) { }

        public override void Accept(Visitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public abstract class Visitor
    {
        public abstract void Visit(Emploree man);
    }

    public class Salary : Visitor
    {
        public override void Visit(Emploree man)
        {
            Console.WriteLine("给{0},加工资100000",man.Name);
        }
    }
}
