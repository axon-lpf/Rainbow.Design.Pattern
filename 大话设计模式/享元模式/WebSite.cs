using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 大话设计模式.享元模式
{
    public abstract class WebSite
    {
        public abstract void Use(User user);
    }
    public class User
    {
        private string name;
        public User(string name)
        {
            this.name = name;
        }
        public string Name 
        { 
            get { return name; } 
            set { name = value; } 
        }
    }
    public class ConcereteWebsite : WebSite
    {
        private string name = string.Empty;
        public ConcereteWebsite(string name)
        {
            this.name = name;
        }
        public override void Use(User user)
        {
            Console.WriteLine("网站分类：" + name+"用户:"+user.Name);
        }
    }
    public class WebSiteFactory
    {
        private Hashtable hash = new Hashtable();
        public WebSite GetWebSiteConceret(string key)
        {
            if (!hash.ContainsKey(key))
                hash.Add(key, new ConcereteWebsite(key));
            return (WebSite)hash[key];
        }
        public int GetWebsiteCount()
        {
            return hash.Count;
        }
    }
}
