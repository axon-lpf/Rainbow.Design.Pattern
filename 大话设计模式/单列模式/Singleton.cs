using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 大话设计模式.单列模式
{
    /// <summary>
    /// 简单安全线程
    /// </summary>
    public sealed class Singleton
    {
        private static Singleton instance = null;
        private static readonly object padlock = new object();
        public Singleton()
        {

        }
        public static Singleton Instancte
        {
            get
            {

                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new Singleton();
                    }
                    return instance;
                }
            }
        }
    }

    /// <summary>
    /// 尝试线程安全（双重锁定）
    /// </summary>
    public sealed class Singleton2
    {
        private static Singleton2 instance = null;
        private static readonly object padlock = new object();
        public Singleton2()
        {

        }
        public static Singleton2 Instancte
        {
            get
            {
                if (instance == null)
                {
                    lock (padlock)
                    {
                        if (instance == null)
                        {
                            instance = new Singleton2();
                        }
                    }
                }
                return instance;
            }
        }
    }

    /// <summary>
    /// 不完全lazy,但是线程安全且不用用锁
    /// </summary>
    public sealed class Singleton3
    {
        private static readonly Singleton3 instance = new Singleton3();

        // 显示的static 构造函数
        //没必要标记类型 - 在field初始化以前
        static Singleton3()
        {
        }

        private Singleton3()
        {
        }

        public static Singleton3 Instance
        {
            get
            {
                return instance;
            }
        }
    }
}
