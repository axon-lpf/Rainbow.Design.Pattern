using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 大话设计模式.组合模式
{
    public abstract class Companys
    {
        protected string name;
        public Companys(string name)
        {
            this.name = name;
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="com"></param>
        public abstract void Add(Companys com);
        /// <summary>
        /// 移除
        /// </summary>
        /// <param name="com"></param>
        public abstract void Remove(Companys com);
        /// <summary>
        /// 显示
        /// </summary>
        /// <param name="depth"></param>
        public abstract void Display(int depth);
        /// <summary>
        /// 履行职责
        /// </summary>
        public abstract void LineOfDuty();
    }

    public class ConcreteCompany : Companys
    {
        List<Companys> CompanyList = new List<Companys>();

        public ConcreteCompany(string name)
            : base(name)
        {

        }
        public override void Add(Companys com)
        {
            CompanyList.Add(com);
        }

        public override void Remove(Companys com)
        {
            CompanyList.Remove(com);
        }

        /// <summary>
        /// 显示
        /// </summary>
        /// <param name="depth"></param>
        public override void Display(int depth)
        {
            Console.WriteLine(new String('-', depth) + name);
            foreach (var item in CompanyList)
            {
                item.Display(depth + 2);
            }
        }
        /// <summary>
        /// 履行职责
        /// </summary>
        public override void LineOfDuty()
        {
            foreach (var item in CompanyList)
            {
                item.LineOfDuty();
            }
        }
    }

    public class HRDepartment : Companys
    {
        public HRDepartment(string name)
            : base(name)
        {

        }

        public override void Add(Companys com)
        {

        }

        public override void Remove(Companys com)
        {

        }

        public override void Display(int depth)
        {
            Console.WriteLine(new String('-', depth) + name);
        }

        public override void LineOfDuty()
        {
            Console.WriteLine("{0}员工培训管理", name);
        }
    }

    public class FinanceDepartment : Companys
    {
        public FinanceDepartment(string name)
            : base(name)
        {

        }


        public override void Add(Companys com)
        {

        }

        public override void Remove(Companys com)
        {

        }

        public override void Display(int depth)
        {
            Console.WriteLine(new String('-', depth) + name);
        }

        public override void LineOfDuty()
        {
            Console.WriteLine("{0}公司财务收支管理", name);
        }
    }
}
