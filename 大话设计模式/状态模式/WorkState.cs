using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 大话设计模式.状态模式
{
    public abstract class WorkState
    {
        public abstract void WriteProgram(Work work);
    }

    public class ForenoonState : WorkState
    {

        public override void WriteProgram(Work work)
        {
            if (work.Hour < 12)
            {
                Console.WriteLine("当前为{0}点，上午工作，精神百倍", work.Hour);
            }
            else
            {
                work.SetWorkSate(new NoonState());
                work.WriteProgram();
            }
        }
    }

    public class NoonState : WorkState
    {
        public override void WriteProgram(Work work)
        {
            if (work.Hour < 13)
            {
                Console.WriteLine("当前为{0}点，饿了，午饭，犯困休息了", work.Hour);
            }
            else
            {
                work.SetWorkSate(new AffteroonState());
                work.WriteProgram();
            }
        }
    }

    public class AffteroonState : WorkState
    {
        public override void WriteProgram(Work work)
        {
            if (work.Hour < 17)
            {
                Console.WriteLine("当前为{0}点,下午状态不错,继续努力", work.Hour);
            }
            else
            {
                work.SetWorkSate(new EveningState());
                work.WriteProgram();
            }
        }
    }

    public class EveningState : WorkState
    {
        public override void WriteProgram(Work work)
        {
            if (work.TaskFinshed)
            {
                work.SetWorkSate(new RestState());
                work.WriteProgram();

            }
            else {
                if (work.Hour < 21)
                {
                    Console.WriteLine("继续加班哦");
                }
                else {
                    work.SetWorkSate(new SleepingState());
                    work.WriteProgram();
                }
            }
        }
    }

    public class SleepingState : WorkState
    {
        public override void WriteProgram(Work work)
        {
            Console.WriteLine("当前为{0}点,睡觉咯", work.Hour);
        }
    }

    public class RestState : WorkState
    {
        public override void WriteProgram(Work work)
        {
            Console.WriteLine("当前为{0}点,下班休息状态", work.Hour);
        }

    }


    public class Work
    {
        private WorkState current;
        public Work()
        {
            current = new NoonState();
        }
        /// <summary>
        /// 时间点属性  工作状态转变的依据
        /// </summary>
        private double hour;
        public double Hour
        {
            get { return hour; }
            set { hour = value; }
        }

        /// <summary>
        /// 工作完成的属性 是否能下班的依据
        /// </summary>
        private bool finish = false;

        public bool TaskFinshed
        {
            get { return finish; }
            set { finish = value; }
        }

        public void SetWorkSate(WorkState state)
        {
            current = state;
        }

        public void WriteProgram()
        {
            current.WriteProgram(this);
        }
    }
}
