using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 大话设计模式.策略模式
{
   public abstract class Strategy
    {
      abstract public  void AlgorithmInterface();
    }

   public class ConcreteStrategyA : Strategy 
   {

        public override void AlgorithmInterface()
       {
           Console.WriteLine("我是策略模式A");
       }
   }
   public class ConcreteStrategyB : Strategy 
   {

       public override void AlgorithmInterface()
       {
           Console.WriteLine("我是策略模式B");
       }
   }
    /// <summary>
    /// 上下文  通该类传入值对象 去调用哪个对象的方法
    /// </summary>
   public class Context  
   {
       public Strategy str { get; set; }
       public Context(Strategy strate) 
       {
           this.str = strate;
       }
       public void AlgorithmInterface() 
       {
           str.AlgorithmInterface();
       }
   }
}
