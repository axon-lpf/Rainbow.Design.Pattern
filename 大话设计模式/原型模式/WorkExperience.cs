using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 大话设计模式.原型模式
{
   public class WorkExperience:ICloneable
    {
        public string WorkDate { get; set; }
        public string Company { get; set; }
        public object Clone()
        {
            return (WorkExperience)this.MemberwiseClone();
        }   
    }

   public class Resume : ICloneable 
   {
       public string Name { get; set; }

       public string Sex { get; set; }

       public string Age { get; set; }

       public WorkExperience Work { get; set; }

       public Resume(string name) 
       {
           this.Name = name;
       }
       private Resume(WorkExperience work) 
       {
           this.Work = work;
       }
       public void SetPersonInfo(string sex, string age) 
       {
           this.Sex = sex;
           this.Age = age;
       }
       public void SetWorkExperience(string workDate, string company) 
       {
           this.Work.WorkDate = workDate;
           this.Work.Company = company;
       }

       public void Display() 
       {
           Console.WriteLine("{0},{1},{2}",Name,Sex,Age);
           Console.WriteLine("工作经历{0},{1}",Work.WorkDate,Work.Company);
       }

       public object Clone()
       {
           Resume res = new Resume(this.Work);
           res.Name = this.Name;
           res.Sex = this.Sex;
           res.Age = this.Age;
           return res;

       }
   }
}
