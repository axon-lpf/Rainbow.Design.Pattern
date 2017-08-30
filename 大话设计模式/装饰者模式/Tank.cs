using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 大话设计模式.装饰者模式
{
    /// <summary>
    /// 坦克基类
    /// </summary>
    public class Tank
    {
        public virtual void Shoot()
        {
        }
    }
    /// <summary>
    /// 实现一个坦克 
    /// </summary>
    public class T50Tank : Tank
    {
        public override void Shoot()
        {
            Console.WriteLine("T50 型号坦克射击");
        }
    }

    public class T51Tank : Tank
    {
        public override void Shoot()
        {
            Console.WriteLine("T51 型号坦克射击");
        }
    }

    /// <summary>
    /// 该类具有承上启下的作用 用于扩展
    /// </summary>
    public abstract class DecoratorTank : Tank
    {
        protected Tank tank;
        public DecoratorTank(Tank tank)
        {
            this.tank = tank;
        }
        public override void Shoot()
        {
            if (tank != null)
            {
                tank.Shoot();
            }
        }
    }
    /// <summary>
    /// 具有红外线功能的坦克
    /// </summary>
    public class InfraRed : DecoratorTank
    {
        public InfraRed(Tank tank)
            : base(tank)
        {

        }
        public override void Shoot()
        {
            Console.WriteLine("带红外功能");
            base.Shoot();
        }
    }

    /// <summary>
    /// 具有GPS功能的坦克
    /// </summary>
    public class GPS : DecoratorTank
    {
        public GPS(Tank tank)
            : base(tank)
        {

        }
        public override void Shoot()
        {

            Console.WriteLine("带GPS功能");
            base.Shoot();
        }
    }
}
