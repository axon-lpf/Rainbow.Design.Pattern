using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 大话设计模式.适配器模式
{
  public abstract  class Player
    {

      protected string name;

      public Player(string name) 
      {
          this.name = name;
      }

      public abstract void Attactk();

      public abstract void Defense();
    }

  public class Center : Player 
  {
      public Center(string name) :base(name) 
      {

      }
      public override void Attactk()
      {
          Console.WriteLine("{0}进功",name);
      }

      public override void Defense()
      {
          Console.WriteLine("{0}防守", name);
      }
  }

  public class Forwords : Player 
  {
      public Forwords(string name) : base(name) 
      {

      }
      public override void Attactk()
      {
          Console.WriteLine("{0}进功", name);
      }

      public override void Defense()
      {
          Console.WriteLine("{0}进功", name);
      }
  }
//外籍中锋球员
  public class ForeignCenter 
  {
      private string name;
      public string Name 
      {
          get { return name; }
          set { Name = name; }
      }

      public void 进攻()
      {
          Console.WriteLine("进攻");
      }
      public void 防守() 
      {
          Console.WriteLine("防守");
      }
  }

    //为外籍球员增加一个适配器(翻译官)
  public class Translator : Player 
  {
      private ForeignCenter center = new ForeignCenter();

      public Translator(string name) : base(name) 
      {

      }
      public override void Attactk()
      {
          center.进攻();
      }

      public override void Defense()
      {
          center.防守();
      }
  }
}
