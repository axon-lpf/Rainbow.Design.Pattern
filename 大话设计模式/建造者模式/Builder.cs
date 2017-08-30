using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 大话设计模式.建造者模式
{
    // 抽象建造步骤
   public abstract class Builder
    {
       public abstract void BuildPartA();
       public abstract void BuildPartB();
       public abstract Product GetResult();
    }


   public class Product 
   {
       private List<string> _parts = new List<string>();

       public void Add(string part) 
       {
           _parts.Add(part);
       }
       public void Show() 
       {
           Console.WriteLine("Prduct part");

           foreach (var item in _parts)
           {
               Console.WriteLine(item);
           }
       }
   }
    /// 根据建造步骤创建对象
   public class ConcreteBuilder1 : Builder 
   {
       private Product pro = new Product();
       public override void BuildPartA()
       {
           pro.Add("ParA");
       }

       public override void BuildPartB()
       {
           pro.Add("ParB");
       }

       public override Product GetResult()
       {
           return pro;
       }
   }
   public class ConcreteBuilder2 : Builder 
   {
       private Product pros= new Product();

       public override void BuildPartA()
       {
           pros.Add("PartX");
       }

       public override void BuildPartB()
       {
           pros.Add("PartY");
       }

       public override Product GetResult()
       {
           return pros;
       }
   }


    //指挥者类  指挥创造 
   public class Director 
   {
       public void Construct(Builder build) 
       {
           build.BuildPartA();
           build.BuildPartB();
       }
   }
}
