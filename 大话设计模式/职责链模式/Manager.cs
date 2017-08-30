using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 大话设计模式.职责链模式
{
    public abstract class Manager
    {
        protected string name;
        //管理者上级
        protected Manager superior;

        public Manager(string name)
        {
            this.name = name;
        }

        public void SetSuperior(Manager manager)
        {
            this.superior = manager;
        }

        abstract public void RequestApplications(Request req);
    }

    /// <summary>
    /// 经理批准
    /// </summary>
    public class CommonManger : Manager
    {
        public CommonManger(string name)
            : base(name)
        {

        }
        public override void RequestApplications(Request req)
        {
            if (req.RequestType == "请假" && req.Number <= 2)
            {
                Console.WriteLine("{0},数量{1},被批准", req.RequestContent, req.Number);
            }
            else
            {
                if (superior != null)
                {
                    superior.RequestApplications(req);
                }
            }
        }
    }

    /// <summary>
    /// 人事总监批准
    /// </summary>
    public class Majordomo : Manager
    {
        public Majordomo(string name)
            : base(name)
        {

        }
        public override void RequestApplications(Request req)
        {
            if (req.RequestType == "请假" && req.Number <= 5)
            {
                Console.WriteLine("{0},数量{1},被批准", req.RequestContent, req.Number);
            }
            else
            {
                if (superior != null)
                {
                    superior.RequestApplications(req);
                }
            }
        }
    }

    /// <summary>
    /// 总经理批准
    /// </summary>
    public class GeneralManager : Manager
    {
        public GeneralManager(string name)
            : base(name)
        {

        }
        public override void RequestApplications(Request req)
        {
            if (req.RequestType == "请假")
            {
                Console.WriteLine("被批准");
            }
            else if (req.RequestType == "加薪" && req.Number < 500)
            {
                Console.WriteLine("{0}{1},被批准");
            }
            else if (req.RequestType == "加薪" && req.Number > 500)
            {
                Console.WriteLine("再说吧");
            }

        }
    }
    public class Request
    {
        /// <summary>
        /// 申请类别
        /// </summary>
        private string requestType;

        public string RequestType
        {
            get { return requestType; }
            set { requestType = value; }
        }


        /// <summary>
        ///申请内容
        /// </summary>
        private string requestContent;

        public string RequestContent
        {
            get { return requestContent; }
            set { requestContent = value; }
        }

        /// <summary>
        /// 申请数量
        /// </summary>
        private int number;

        public int Number
        {
            get { return number; }
            set { number = value; }
        }
    }
}
