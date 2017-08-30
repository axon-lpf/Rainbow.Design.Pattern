using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace 大话设计模式.解释器模式
{
    public class MessageModel
    {
        private string _message;

        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }

        private DateTime _publishTime;

        public DateTime PublishTime
        {
            get { return _publishTime; }
            set { _publishTime = value; }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="message">发布内容</param>
        /// <param name="pt">发布时间</param>
        public MessageModel(string message, DateTime pt)
        {
            this._message = message;
            this._publishTime = pt;
        }
    }
    /// <summary>
    /// sql的方式操作message
    /// </summary>
    public class SqlMessage
    {
        /// <summary>
        /// 获取Message
        /// </summary>
        /// <returns></returns>
        public static List<MessageModel> Get()
        {
            List<MessageModel> l = new List<MessageModel>();
            l.Add(new MessageModel("SQL方式获取Message", DateTime.Now));

            return l;
        }
    }

    public class JContext
    {
        /// <summary>
        /// 构造函数 
        /// </summary>
        /// <param name="input">输入内容</param>
        public JContext(string input)
        {
            this._input = input;
        }

        private string _input;

        public string Input
        {
            get { return _input; }
            set { _input = value; }
        }
        private string _output;

        public string Output
        {
            get { return _output; }
            set { _output = value; }
        }
    }

    public abstract class AbstractExpression 
    {

        /// <summary>
        /// 解释Context的方法
        /// </summary>
        /// <param name="context">context</param>
        public void Interpret(JContext context)
        {
            if (String.IsNullOrEmpty(context.Input))
            {
                return;
            }

            context.Output += GetCSharp(context.Input);
        }

        /// <summary>
        /// 获得输入内容所对应的C#代码
        /// </summary>
        /// <param name="source">source</param>
        /// <returns></returns>
        private string GetCSharp(string source)
        {
            string csharp = "";
            string word = "";

            // 从输入内容中取得要解释的词
            word = GetWord(source);

            // 从字典中找到word所对应的C#代码
            GetDictionary().TryGetValue(word, out csharp);

            return csharp;
        }

        /// <summary>
        /// 从输入内容中取得要解释的词
        /// </summary>
        /// <param name="source">source</param>
        /// <returns></returns>
        public abstract string GetWord(string source);

        /// <summary>
        /// 获取字典
        /// </summary>
        /// <returns></returns>
        public abstract Dictionary<string, string> GetDictionary();

    }

    /// <summary>
    /// 终端公式（TerminalExpression）分析与数据库相关的
    /// </summary>
    public class DatabaseExpression : AbstractExpression
    {
        public override string GetWord(string source)
        {
            MatchCollection mc;
            Regex r = new Regex(@"\{(.*)\}");
            mc = r.Matches(source);

            return mc[0].Groups[1].Value;
        }

        public override Dictionary<string, string> GetDictionary()
        {
            Dictionary<string, string> d = new Dictionary<string, string>();

            d.Add("数据库", "Sql");

            return d;
        }
    }
    /// <summary>
    ///  终端公式（TerminalExpression）分析与对象相关的
    /// </summary>
    public class ObjectExpression : AbstractExpression 
    {
        /// <summary>
        /// 从输入内容中 获取要得到的解释词
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public override string GetWord(string source)
        {
            MatchCollection mc;
            Regex r = new Regex(@"\((.*)\)");
            mc = r.Matches(source);

            return mc[0].Groups[1].Value;
        }
       /// <summary>
       /// 获取与对象相关词典
       /// </summary>
       /// <returns></returns>
        public override Dictionary<string, string> GetDictionary()
        {
            Dictionary<string, string> d = new Dictionary<string, string>();

            d.Add("获取", ".Get()");

            return d;
        }
    }
    /// <summary>
    ///  终端公式（TerminalExpression）分析与方法相关的
    /// </summary>
    public class MethodExpression : AbstractExpression 
    {
        /// <summary>
        /// 从输入内容中得到的解释词
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public override string GetWord(string source)
        {
            MatchCollection mc;
            Regex r = new Regex(@"\((.*)\)");
            mc = r.Matches(source);

            return mc[0].Groups[1].Value;
        }
        /// <summary>
        /// 获取与方法相关的词典
        /// </summary>
        /// <returns></returns>
        public override Dictionary<string, string> GetDictionary()
        {
            Dictionary<string, string> d = new Dictionary<string, string>();

            d.Add("获取", ".Get()");

            return d;
        }
    }
}
