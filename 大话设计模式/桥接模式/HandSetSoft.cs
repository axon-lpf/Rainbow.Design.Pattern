using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 大话设计模式.桥接模式
{
    //软件的抽象
    public abstract class HandSetSoft
    {
        public abstract void Run();
    }
    /// <summary>
    /// 具体软件的实现  手机游戏
    /// </summary>
    public class HandSetGame : HandSetSoft 
    {
        public override void Run()  
        {
            Console.WriteLine("手机游戏跑起来");
        }
    }
    /// <summary>
    /// 手机通讯录
    /// </summary>
    public class HandSetAddressList : HandSetSoft 
    {
        public override void Run()
        {
            Console.WriteLine("手机通讯录跑起来");
        }
    }

    /// <summary>
    /// 手机品牌抽象   手机品牌包含软件 
    /// </summary>
    public abstract class HandSetBrand 
    {
        protected HandSetSoft soft;

        public HandSetBrand(HandSetSoft soft) 
        {
            this.soft = soft;
        }

        public virtual void Run(){}
    }

    /// <summary>
    /// 手机品牌M
    /// </summary>
    public class HandSetBrandM :HandSetBrand
    {
        public HandSetBrandM(HandSetSoft soft) : base(soft) 
        {

        }
        public override void Run()
        {
            soft.Run();
        }
    }
    /// <summary>
    /// 手机品牌N
    /// </summary>
    public class HandSetBrandN : HandSetBrand
    {
         public HandSetBrandN(HandSetSoft soft) : base(soft) 
        {

        }
        public override void Run()
        {
            soft.Run();
        }
    }
}

