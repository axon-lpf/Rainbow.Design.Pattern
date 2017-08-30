using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 大话设计模式.工厂方法模式
{
    public abstract class Live
    {
        public abstract void Action();
    }

    public class Music : Live 
    {
        public override void Action()
        {
            Console.WriteLine("给我唱一首爱情转移");
        }
    }

    public class WatchTV : Live 
    {
        public override void Action()
        {
            Console.WriteLine("我要看AV");
        }
    }

    public abstract class Factory 
    {
        public abstract Live Create();
    }

    public class CreateMusic : Factory 
    {
        public override Live Create()
        {
            return new Music();
        }
    }
    public class CreateWatch : Factory 
    {
        public override Live Create()
        {
            return new WatchTV();
        }
    }
}
