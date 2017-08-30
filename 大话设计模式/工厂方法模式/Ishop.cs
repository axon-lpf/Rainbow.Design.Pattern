using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 大话设计模式.工厂方法模式
{
    public interface Ishop
    {
        double Getrent(int days, double dayprice, double performance);
    }

    public class Ashop : Ishop 
    {

        public double Getrent(int days, double dayprice, double performance)
        {
            Console.WriteLine("A商店的租金算法");
            return days * dayprice + performance * 0.01;  
        }
    }
    public class Bshop : Ishop 
    {
        public double Getrent(int days, double dayprice, double performance)
        {
            Console.WriteLine("B商店的租金算法");
            return days * dayprice + performance * 0.01;  
        }
    }
    /// <summary>
    /// 工厂类 创建商店的实体类
    /// </summary>
    public interface IFactory 
    {
         Ishop CreateShop();
    }
    /// <summary>
    /// 继承工厂类，创建A类型商店实体  
    /// </summary>
    public class CreateAshop : IFactory 
    {

        public Ishop CreateShop()
        {
            return new Ashop();
        }
    }
    /// <summary>
    /// 继承工厂类，创建B类型商店实体  
    /// </summary>
    public class CreateBshop : IFactory 
    {

        public Ishop CreateShop()
        {
            return new Bshop();
        }
    }
}
