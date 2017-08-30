using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 大话设计模式.中介者模式
{
    /// <summary>
    /// 抽象联合国
    /// </summary>
    public abstract class UnitedNations
    {
        /// <summary>
        /// 联合国 通知功能
        /// </summary>
        /// <param name="message"></param>
        /// <param name="country"></param>
        public abstract void Declare(string message,Country country);
    }

    /// <summary>
    /// 抽象国家
    /// </summary>
    public abstract class Country
    {
        protected UnitedNations mediator;
        public Country(UnitedNations med)
        {
            this.mediator = med;
        }
    }

    /// <summary>
    /// 美国
    /// </summary>
    public class USA : Country
    {
        public USA(UnitedNations med)
            : base(med)
        {

        }

        public void Declare(string message) 
        {
            mediator.Declare(message,this);
        }

        public void GetMessage(string message) 
        {
            Console.WriteLine("美国获得对方消息："+message);
        }
    }

    /// <summary>
    /// 伊拉克
    /// </summary>
    public class Iraq : Country 
    {
        public Iraq(UnitedNations med)
            : base(med)
        {

        }

        public void Declare(string message) 
        {
            mediator.Declare(message,this);
        }

        public void GetMessage(string message) 
        {
            Console.WriteLine("伊拉克获得对方消息："+message);
        }
    }

    /// <summary>
    /// 联合国 安全理事会
    /// </summary>
    public class UnitedNationsSecurityCouncil : UnitedNations 
    {
        private USA usa;

        public USA Usa
        {
            get { return usa; }
            set { usa = value; }
        }
        private Iraq iraq;

        public Iraq Iraq
        {
            get { return iraq; }
            set { iraq = value; }
        }

        public override void Declare(string message, Country country)
        {
            if (country == usa)
            {
                usa.GetMessage(message);
            }
            else {
                iraq.GetMessage(message);
            }
        }
    }
}
