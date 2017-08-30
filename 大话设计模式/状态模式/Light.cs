using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 大话设计模式.状态模式
{
    public interface LightState
    {
        void PressSwitch(Light light);
    }
    public class LightOn : LightState
    {

        public void PressSwitch(Light light)
        {
            Console.WriteLine("Light Off");
            light.State = new LightOff();

        }
    }
    public class LightOff : LightState
    {

        public void PressSwitch(Light light)
        {
            Console.WriteLine("Light On");
            light.State = new LightOn();
        }
    }
    public class Light
    {
        public LightState State;

        public Light()
        {         
            State = new LightOff();
        }

        public void PressSwitch()
        {
            State.PressSwitch(this);
        }
    }

}
