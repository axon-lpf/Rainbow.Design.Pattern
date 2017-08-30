using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 大话设计模式.抽象工厂模式
{
    /// <summary>
    /// 构建KFC的食物的抽象类
    /// </summary>
    public abstract class KFCFood
    {
        public abstract void Display();
    }

    public class Chicken : KFCFood 
    {

        public override void Display()
        {
            Console.WriteLine("鸡腿+1");
        }
    }

    public class Wings : KFCFood 
    {

        public override void Display()
        {
            Console.WriteLine("鸡翅+1");
        }
    }

    /// <summary>
    /// 构建可乐的抽象类 
    /// </summary>
    public abstract class KFCDrink 
    {
        public abstract void Display();
    }

    public class Coke : KFCDrink 
    {

        public override void Display()  
        {
            Console.WriteLine("可乐+1");
        }
    }

    public class Coffee : KFCDrink 
    {

        public override void Display()
        {
            Console.WriteLine("咖啡+1");
        }
    }

    /// <summary>
    /// 抽象工厂生产套餐
    /// </summary>
    public interface IKFCFactory 
    {
        KFCFood CreateFood();
        KFCDrink CreateDrink();
    }

   /// <summary>
   /// 经济型套餐 包括鸡翅可乐
   /// 
   /// </summary>
    public class CheapPackageFactory : IKFCFactory 
    {

        public KFCFood CreateFood()
        {
            return new Wings();
        }

        public KFCDrink CreateDrink()
        {
            return new Coke();
        }
    } 
    /// <summary>
    /// 豪华型套餐 鸡腿 咖啡
    /// 
    /// </summary>
    public class LuxuryPackageFactory : IKFCFactory
    {

        public KFCFood CreateFood()
        {
            return new Chicken();
        }

        public KFCDrink CreateDrink()
        {
            return new Coffee();
        }
    }
} 
