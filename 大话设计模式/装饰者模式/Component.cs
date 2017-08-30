using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 大话设计模式.装饰者模式
{
    //声明一个抽象类
    public abstract class Component
    {
        public abstract void Operation();
    }

    //继承抽象类  并且实现它的功能
    public class ConcreteComponent : Component
    {

        public override void Operation()
        {
            Console.WriteLine("ConcreteComponent.Operation()");
        }
    }

    /// <summary>
    /// 声明一个抽象的装饰类'Decorator'
    /// 并继承Component
    /// </summary>
    public abstract class Decorator : Component 
    {
        protected Component component;

        //装饰的方法
        public void SetCompontent(Component component)
        {
                this.component = component;
        }

        public override void Operation()
        {
            if (component != null)
            {
                component.Operation();
            }
        }
    }

    /// <summary>
    /// 声明一个具体装饰类B，继承Decorator
    /// </summary>
    public class ConcreteDecoratorA : Decorator 
    {
        public override void Operation()
        {
            //一些功能扩展
            Console.WriteLine("ConcreteDecoratorA.Operation()");
            base.Operation();
        }
    }

    /// <summary>
    /// 声明一个具体装饰类B，继承Decorator
    /// </summary>
    public class ConcreteDecoratorB : Decorator 
    {
        public override void Operation()
        {
            //一些功能扩展
            AddedBehavior();
            Console.WriteLine("ConcreteDecoratorB.Operation()");
            base.Operation();
        }

        //装饰类B自有方法
       public  void AddedBehavior()
        {
            Console.WriteLine("阿西吧");
        }
    }
}
