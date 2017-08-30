using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 大话设计模式.享元模式
{
    public abstract class Flyweight
    {
        public abstract void Operation(int extrinsicstate);
    }
    public class ConcreteFlyweight : Flyweight 
    {
        public override void Operation(int extrinsicstate)
        {
            Console.WriteLine("具体的Flyweight:"+extrinsicstate);
        }
    }

    public class UnConcreteFlyweight : Flyweight 
    {

        public override void Operation(int extrinsicstate)
        {
            Console.WriteLine("不共享的具体的Flyweight:" + extrinsicstate);
        }
    }

    public class FlyweightFactory 
    {
       private  Hashtable hash = new Hashtable();

       public FlyweightFactory() 
       {
           hash.Add("x", new ConcreteFlyweight());
           hash.Add("y", new ConcreteFlyweight());
           hash.Add("z", new ConcreteFlyweight());
       }
       public Flyweight GetFlyweight(string key) 
       {
           return (Flyweight)hash[key];
       }
    }
}
