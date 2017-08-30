using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 大话设计模式.迭代器模式
{
    public abstract  class Iterator
    {
        public abstract object First(); //得到开始的对象
        public abstract object Next(); //得到下一个对象
        public abstract bool IsDone();  //判断是否结尾 当前对象或者方法的统一接口
        public abstract object CurrentItem();
    }

    public abstract class Aggregate 
    {
        public abstract Iterator CreateIterator(); //创建一个迭代的对象
    }

    public class ConcreteIterator : Iterator 
    {
        private ConcreteAggregate aggregate;
        private int current = 0;

        public ConcreteIterator(ConcreteAggregate agg)  //初始化的时候 讲聚集对象传入
        {
            this.aggregate = agg;

        }
        public override object First()  //得到聚集的第一个对象
        {
            return aggregate[0];
        }

        public override object Next()  //得到聚集的下一个对象
        {
            object ret = null;
            current++;
            if (current < aggregate.Count)
            {
                ret = aggregate[current];
            }
            return ret;
        }

        public override bool IsDone()  //判断是否到结尾
        {
            return current >= aggregate.Count ? true : false;
        }

        public override object CurrentItem()  //返回当前的 聚集对象
        {
            return aggregate[current];
        }
    }

    public class ConcreteAggregate : Aggregate 
    {
        private IList<object> items = new List<object>(); //声明一个泛型集合 用于存放聚合对象


        public override Iterator CreateIterator()
        {
            return new ConcreteIterator(this);
        }

        public int Count  //返回聚集总个数
        {
            get { return items.Count;}
        }
        public object this[int index]   //声明一个索引器
        {
            get { return items[index]; }
            set { items.Insert(index, value); }
        }
    }
}
