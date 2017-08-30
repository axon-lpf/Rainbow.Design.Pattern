using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 大话设计模式.命令模式
{

    /// <summary>
    /// 基本的菜单
    /// </summary>
    public class Barbecure
    {
        public void BakefMutton() 
        {
            Console.WriteLine("烤羊肉串");
        }

        public void BakeChickenWing() 
        {
            Console.WriteLine("烤鸡翅");
        }
    }

    /// <summary>
    /// 抽象执行的命令
    /// </summary>
    public abstract class Command 
    {
        protected Barbecure receiver;

        public Command(Barbecure receiver) 
        {
            this.receiver = receiver;
        }
        public abstract void ExcuteCommand();
    }

    /// <summary>
    /// 执行具体的命令 考羊肉串
    /// </summary>
    public class BakefMuttonCommand : Command 
    {
        public BakefMuttonCommand(Barbecure receiver)
            : base(receiver) 
        {

        }
        public override void ExcuteCommand()
        {
            receiver.BakefMutton();
        }
    }

    /// <summary>
    /// 执行具体的命令 烤鸡翅
    /// </summary>
    public  class  BakeChickenWingCommand:Command
    {
        public BakeChickenWingCommand(Barbecure receiver) : base(receiver) 
        {
        }
        public override void ExcuteCommand()
        {
            receiver.BakeChickenWing();
        }
    }

    /// <summary>
    /// 服务员记录菜单
    /// </summary>
    public class Waiter 
    {
        private IList<Command> command = new List<Command>();
        public void SetOrder(Command com) 
        {
            if (com.ToString() == "大话设计模式.命令模式.BakeChickenWingCommand")
            {
                Console.WriteLine("卖完了");
            }
            else {
                command.Add(com);
            }
        }

        //取消订单
        public void CancelOrder(Command com) 
        {
            command.Remove(com);
        }
        public void Notify() 
        {
            foreach (var item in command)
            {
                item.ExcuteCommand();
            }
           
        }
    }
}
