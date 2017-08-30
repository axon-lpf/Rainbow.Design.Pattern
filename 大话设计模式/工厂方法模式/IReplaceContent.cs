using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 大话设计模式.工厂模式
{
    public interface IReplaceContent
    {
         string RepContent(string content, RepCon repCon);
         string RepTitle(string title, RepCon repTit);
    }

    public class ReplaceModelOne : IReplaceContent
    {

        public string RepContent(string content, RepCon repCon)
        {
            string result = string.Empty;
            result = content.Replace("User_Name", repCon.User_Name);
            result = result.Replace("User_Email", repCon.User_Email);
            result = result.Replace("CompanyName", repCon.CompanyName);
            return result;
        }

        public string RepTitle(string title, RepCon repTit)
        {
            string result = string.Empty;
            result = title.Replace("User_Name", repTit.User_Name);
            result = result.Replace("User_Email", repTit.User_Email);
            result = result.Replace("CompanyName", repTit.CompanyName);
            return result;
        }
    }
    public class ReplaceModelTwo : IReplaceContent
    {

        public string RepContent(string content, RepCon repCon)
        {
            string result = string.Empty;
            result = content.Replace("User_Phone", repCon.User_Phone);
            result = result.Replace("User_Address", repCon.User_Address);
            result = result.Replace("User_Work", repCon.User_Work);
            return result;
        }

        public string RepTitle(string title, RepCon repTit)
        {
            string result = string.Empty;
            result = title.Replace("User_Phone", repTit.User_Phone);
            result = result.Replace("User_Address", repTit.User_Address);
            result = result.Replace("User_Work", repTit.User_Work);
            return result;
        }
    }
    public class ReplaceModelThree : ReplaceModelOne, IReplaceContent
    {
        public string RepContent(string content, RepCon repCon)
        {
            string result = string.Empty;
            result = base.RepContent(content, repCon);
            result = result.Replace("User_Phone", repCon.User_Phone);
            result = result.Replace("User_Address", repCon.User_Address);
            result = result.Replace("User_Work", repCon.User_Work);
            return result;
        }

        public string RepTitle(string title, RepCon repTit)
        {
            string result = string.Empty;
            result = base.RepContent(title, repTit);
            result = result.Replace("User_Phone", repTit.User_Phone);
            result = result.Replace("User_Address", repTit.User_Address);
            result = result.Replace("User_Work", repTit.User_Work);
            return result;
        }
    }

     /// <summary>
     /// 装饰者模式  对原有的基础方法进行装饰扩展   减少子类爆炸
     /// 
     /// </summary>
    public abstract class DecoratorRepContent : IReplaceContent
    {
        protected IReplaceContent replace;
        public DecoratorRepContent(IReplaceContent content)
        {
            this.replace = content;
        }
        public string RepContent(string content, RepCon repCon)
        {
            string result = string.Empty;
            if (replace != null)
            {
                result = replace.RepContent(content, repCon);
            }
            return result;
        }

        public string RepTitle(string title, RepCon repTit)
        {
            string result = string.Empty;
            if (replace != null)
            {
                result = replace.RepTitle(title, repTit);
            }
            return result;
        }
    }
    public class RepalceContentModelCombination : DecoratorRepContent,IReplaceContent
    {
        string result = string.Empty;
        public RepalceContentModelCombination(IReplaceContent content)
            : base(content)
        {
        }

       public string RepContent(string content, RepCon repCon)
        {
            string result = string.Empty;
            result = base.RepContent(content, repCon);
            result = result.Replace("axib","阿西部");
            return result;
            //result = base.RepContent(content, repCon);
        }

       public  string  RepTitle(string title, RepCon repTit)
        {
            string result = string.Empty;
            result = base.RepContent(title, repTit);
            result = result.Replace("axib", "阿西部");
            return result;
        }

       string IReplaceContent.RepContent(string content, RepCon repCon)
       {
           throw new NotImplementedException();
       }

       string IReplaceContent.RepTitle(string title, RepCon repTit)
       {
           throw new NotImplementedException();
       }
    }

    /// <summary>
    /// 简单工厂模式
    /// </summary>
    public class RepalceContentFactory 
    {
        public static IReplaceContent CreateRepalceFactory(string type) 
        {
            IReplaceContent replace = null;
            switch (type)
            {
                case "1":
                    replace = new ReplaceModelOne();
                    break;
                case "2":
                    replace = new ReplaceModelTwo();
                    break;
                case "3":
                    replace = new ReplaceModelThree();
                    break;
                default:
                    break;
            }
            return replace;
        }
    }

    public class RepCon
    {
        public string User_Name { get; set; }
        public string User_Email { get; set; }
        public string CompanyName { get; set; }
        public string User_Phone { get; set; }
        public string User_Address { get; set; }
        public string User_Work { get; set; }
    }
}
