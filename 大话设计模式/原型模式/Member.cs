using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace 大话设计模式.原型模式
{
    [Serializable]
    public class Member
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    [Serializable]
    public class Person : ICloneable
    {
        public string CurrentEmployee { get; set; }
        public Member Member { get; set; }
        public Person()
        {
            this.CurrentEmployee = "admin";
            Member member = new Member();
            member.Id = 3;
            member.Name = "Mem";
            this.Member = member;
        }
        /// <summary>
        /// 克隆
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            return this.MemberwiseClone();
        }

        //静态的创建对象
        private static Person _person;

        /// <summary>
        /// 静态的构造函数 永远只能运行一次
        /// </summary>
        ///
        static Person()
        {
            _person = new Person();
        }

        public static Person StaticClone()
        {
            return _person.MemberwiseClone() as Person;
        }
    }


    public class SerializeHelper
    {
        /// <summary>
        /// 序列化
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public static string Serializable(object target)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                new BinaryFormatter().Serialize(stream, target);
                return Convert.ToBase64String(stream.ToArray());
            }
        }
        public static T Derializable<T>(string target)
        {
            byte[] targetArray = Convert.FromBase64String(target);
            using (MemoryStream stream = new MemoryStream(targetArray))
            {
                return (T)(new BinaryFormatter().Deserialize(stream));
            }
        }

        /// <summary>
        /// 合并反序列化与序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public static T DeepClone<T>(T t)
        {
            return Derializable<T>(Serializable(t));
        }
    }
}
