using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 大话设计模式.适配器模式
{
    /// 定义客户端期待的接口
    public class Target
    {
        public virtual void Request()
        {
            Console.WriteLine("This is a common request");
        }
    }
    //定义需要适配类
    public class Adaptee
    {
        public void SpecificRequest() 
        {
            Console.WriteLine("This is a special request.");
        }
    }

    //定义适配器的类型

    public class Adapter : Target 
    {
        // 建立一个私有的Adeptee对象
        private Adaptee adaptee = new Adaptee();
        public override void Request()
        {
            adaptee.SpecificRequest();
        }
    }
}
